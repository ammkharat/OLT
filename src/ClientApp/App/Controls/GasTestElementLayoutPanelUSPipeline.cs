using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class GasTestElementLayoutPanelUSPipeline : UserControl
    {
        private readonly GasTestElementTimeResultsUSPipeline gasTestElementTimeResults;

        public GasTestElementLayoutPanelUSPipeline()
        {
            InitializeComponent();
            gasTestElementTimeResults = new GasTestElementTimeResultsUSPipeline();
        }

        public void BuildGasTestElementControls(List<GasTestElementInfo> list, Site site)
        {
            AddControlToPanel(new GasTestElementDetailsHeaderUSPipeline());
            list.ForEach(info => AddControlToPanel(CreateStandardGasTestElementDetails(info)));
            AddControlToPanel(CreateStandardGasTestElementDetails(GasTestElementInfo.CreateOtherGasTestElementInfo(site)));
            AddControlToPanel(gasTestElementTimeResults);
        }

        private static GasTestElementDetailsUSPipeline CreateStandardGasTestElementDetails(GasTestElementInfo info)
        {
            GasTestElementDetailsUSPipeline details = new GasTestElementDetailsUSPipeline(info)
                                                      {
                                                          AutoSize = true,
                                                          Anchor = (AnchorStyles.Left | AnchorStyles.Right),
                                                          Dock = DockStyle.None
                                                      };
            
            return details;
        }

        public List<IGasTestElementDetails> GasTestElementDetailsList
        {
            get
            {
                var list = new List<IGasTestElementDetails>();
                foreach (Control control in layoutPanel.Controls)
                {
                    if (typeof(IGasTestElementDetails).IsAssignableFrom(control.GetType()))
                    {
                        list.Add((IGasTestElementDetails)control);
                    }
                }
                return list;
            }
        }

        [Browsable(false)]
        public Time ImmediateAreaTime
        {
            get { return gasTestElementTimeResults.ImmediateAreaTime; }
            set { gasTestElementTimeResults.ImmediateAreaTime = value; }
        }

        [Browsable(false)]
        public Time ConfinedSpaceTime
        {
            get { return gasTestElementTimeResults.ConfinedSpaceTime; }
            set { gasTestElementTimeResults.ConfinedSpaceTime = value; }
        }

        [Browsable(false)]
        public Time SystemEntryTime
        {
            get { return gasTestElementTimeResults.SystemEntryTime; }
            set { gasTestElementTimeResults.SystemEntryTime = value; }
        }

        private void AddControlToPanel(Control control)
        {
            layoutPanel.Controls.Add(control);
        }
    }
}
