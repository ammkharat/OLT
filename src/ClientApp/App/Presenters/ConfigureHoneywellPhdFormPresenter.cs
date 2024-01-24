using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.PlantHistorian;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureHoneywellPhdFormPresenter : BaseFormPresenter<IConfigureHoneywellPhdView>
    {
        private readonly IHoneywellPhdConfigurationService service;

        //ayman PI test
        public string selectedEnv;

        public ConfigureHoneywellPhdFormPresenter(IConfigureHoneywellPhdView view)
            : this(view, ClientServiceRegistry.Instance.GetService<IHoneywellPhdConfigurationService>())
        {
            view.Load += HandleViewLoad;
            view.CancelButtonClick += CancelButton_Click;
            view.SaveButtonClick += SaveConfiguration;
        }

        public ConfigureHoneywellPhdFormPresenter(IConfigureHoneywellPhdView view,
            IHoneywellPhdConfigurationService service)
            : base(view)
        {
            this.service = service;
        }

        private void SaveConfiguration()
        {
            string databaseUsername;
            string databasePassword;
            string databaseServer;
            string databaseInstance;

            if (view.IsOracle)
            {
                databaseUsername = view.OracleUsername;
                databasePassword = view.OraclePassword;
                databaseServer = view.OracleHost;
                databaseInstance = view.OracleServiceName;
            }
            else
            {
                databaseUsername = view.SqlServerUsername;
                databasePassword = view.SqlServerPassword;
                databaseServer = view.SqlServerHost;
                databaseInstance = view.SqlServerInstance;
            }

            var databaseType = view.IsOracle ? HoneywellPhdDatabaseType.Oracle : HoneywellPhdDatabaseType.SqlServer;

            var siteId = ClientSession.GetUserContext().SiteId;
            //ayman PI changes
            
            //var currentConnectionInfo = service.QueryBySiteId(siteId).First();
            var currentConnectionInfo = service.QueryBySiteId(siteId).Find(item => item.Description == selectedEnv);

            var newConnectionInfo = new ScadaConnectionInfo(currentConnectionInfo.Id,siteId, view.PhdUsername, view.PhdPassword,
                view.PhdServer, view.ApiVersion,
                view.UseWindowsAuthentication, databaseType, databaseUsername, databasePassword, databaseServer,
                databaseInstance, view.StartTimeOffset.GetValueOrDefault(0),
                view.EndTimeOffset.GetValueOrDefault(0), view.DataSamplingType, view.DataSamplingFrequency,
                view.DataReductionType, view.DataReductionFrequency, view.DataReductionOffset,
                view.MinimimConfidence,
                currentConnectionInfo.MockTagWrites, DateTime.Now, view.PiServer, view.PiUsername, view.PiPassword, ScadaConnectionType.PhdConnection,currentConnectionInfo.Description);
            service.Update(newConnectionInfo);

            view.Close();
        }

        private void HandleViewLoad(object sender, EventArgs e)
        {
            var connectionInfos = service.QueryBySiteId(ClientSession.GetUserContext().SiteId);

            if (connectionInfos.Count > 0)
            {
                ScadaConnectionInfo connection = null;
                if (connectionInfos.Count > 1)
                {
                    string chosenConnection;
                    var result = OltChooseFromAListMessageBox.Show(view as Form,
                        "Choose a SCADA Connection to edit:",
                        "Choose Connection", connectionInfos.ConvertAll(input => input.Description),
                        MessageBoxIcon.Question,
                        out chosenConnection);
                    if (!chosenConnection.IsNullOrEmpty())
                        connection = connectionInfos.Find(info => info.Description == chosenConnection);
                    //ayman PI test
                    selectedEnv = chosenConnection;
                }
                else
                {
                    selectedEnv = connectionInfos.First().Description;
                }


                var honeywellInfo = connectionInfos.Count > 1 ? connection : connectionInfos.First();
                var databaseInfo = honeywellInfo.DatabaseInfo;
                var isOracle = databaseInfo.DatabaseType == HoneywellPhdDatabaseType.Oracle;

                if (honeywellInfo.ScadaConnectionType == ScadaConnectionType.PhdConnection)
                {
                    if (isOracle)
                    {
                        view.IsOracle = true;
                        view.OracleUsername = databaseInfo.Username;
                        view.OraclePassword = databaseInfo.Password;
                        view.OracleServiceName = databaseInfo.DbName;
                        view.OracleHost = databaseInfo.Server;
                    }
                    else
                    {
                        view.IsSqlServer = true;
                        view.SqlServerUsername = databaseInfo.Username;
                        view.SqlServerPassword = databaseInfo.Password;
                        view.SqlServerHost = databaseInfo.Server;
                        view.SqlServerInstance = databaseInfo.DbName;
                    }
                    view.ShowPhdElements();
                }
                else
                {
                    //ayman pI changes
                    view.IsSqlServer = true;                                  
                    view.SqlServerUsername = databaseInfo.Username;
                    view.SqlServerPassword = databaseInfo.Password;
                    view.SqlServerHost = databaseInfo.Server;
                    view.SqlServerInstance = databaseInfo.DbName;
                    view.ShowPiElements();
                }

                view.ApiVersion = honeywellInfo.ApiVersion;
                view.UseWindowsAuthentication = honeywellInfo.UseWindowsAuthentication;
                view.PhdUsername = honeywellInfo.PhdUsername;
                view.PhdPassword = honeywellInfo.PhdPassword;
                view.PhdServer = honeywellInfo.PhdServer;
                view.PiUsername = honeywellInfo.PiUsername;
                view.PiPassword = honeywellInfo.PiPassword;
                view.PiServer = honeywellInfo.PiServer;

                view.StartTimeOffset = honeywellInfo.StartTimeOffset;
                view.EndTimeOffset = honeywellInfo.EndTimeOffset;

                view.DataSamplingType = honeywellInfo.SampleType;
                view.DataSamplingFrequency = honeywellInfo.SampleFrequency;

                view.DataReductionFrequency = honeywellInfo.DataReductionFrequency;
                view.DataReductionOffset = honeywellInfo.DataReductionOffset;
                view.DataReductionType = honeywellInfo.DataReductionType;

                view.MinimimConfidence = honeywellInfo.MinimumConfidence;
            }
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Honeywell Phd Configuration - {0}", site.IdValue);
        }
    }
}