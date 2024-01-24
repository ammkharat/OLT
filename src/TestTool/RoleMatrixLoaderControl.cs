using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Common.Wcf;
using Infragistics.Excel;

namespace TestTool
{
    public partial class RoleMatrixLoaderControl : UserControl
    {
        public RoleMatrixLoaderControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(serverURITextBox.Text))
            {
                MessageBox.Show("Need to enter a Uri for the server address.");
                return;
            }

            try
            {
                string baseAddress = serverURITextBox.Text;
                ISiteService siteService = GenericServiceRegistry.Instance.GetService<ISiteService>(baseAddress);
                List<Site> sites = siteService.GetAll();

                connectionResultTextBox.Text = sites.Count > 0 ? "Ok" : "ERROR!";

                comboBox1.DataSource = sites;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, exception.StackTrace);
                connectionResultTextBox.Text = "ERROR!";
                comboBox1.DataSource = new List<Site>(0);
            }
            finally
            {
                GenericServiceRegistry.Instance.CloseAll();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new OpenFileDialog();
            dialog.CheckFileExists = true;
            dialog.CheckPathExists = true;
            dialog.DefaultExt = ".xls"; 
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string fileName = dialog.FileName;
                if (!string.IsNullOrEmpty(fileName))
                {
                    fileTextBox.Text = fileName;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileTextBox.Text))
            {
                MessageBox.Show("Need to have a file to generate script from.");
                return;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a site!");
                return;
            }
            string baseAddress = serverURITextBox.Text;

            IStreamingRequestRoleService proxy = null;
            try
            {
                ChannelFactory<IStreamingRequestRoleService> clientToServerChannelFactory = ChannelFactoryCreator.CreateClientToServerChannelFactory<IStreamingRequestRoleService>(BindingType.HttpBinaryStreamedRequestEncoding, baseAddress);
                proxy = clientToServerChannelFactory.CreateChannel();
            
                Workbook workbook = Workbook.Load(fileTextBox.Text);

                List<RoleElementChange> roleChanges;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    workbook.Save(memoryStream);
                    memoryStream.Flush();
                    memoryStream.Seek(0, SeekOrigin.Begin);
                
                    ((IClientChannel)proxy).Open();
                    roleChanges = proxy.GenerateRoleChanges(memoryStream);
                    
                }
                Site selectedSite = comboBox1.SelectedItem as Site;

                List<RoleElementChange> changesForSite = roleChanges.FindAll(c => c.Site.IdValue == selectedSite.IdValue);

                StringBuilder builder = new StringBuilder();
                changesForSite.ConvertAll(c => c.ConvertToSql()).ForEach(c => builder.AppendLine(c));
                responseTextBox.Text = builder.ToString();
            }
            finally
            {
                ((IClientChannel)proxy).CloseOrAbort();
            }
        }

        private void portLabel_Click(object sender, EventArgs e)
        {

        }
    }
}