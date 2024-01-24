using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public partial class ActionItemDefinitionSummary : UserControl, IActionItemDefinitionSummary
    {
        //private ActionItemDefinition actionItemDefinition;

        public ActionItemDefinitionSummary()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        public string Name
        {
            set { nameLabelData.Text = value; }
        }

        public BusinessCategory Category
        {
            set {categoryLabelData.Text = value.Name; }
        }

        public string Author
        {
            set { authorLabelData.Text = value; }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            set { functionalLocationsListBox.FunctionalLocations = value; }
        }

        public string Description
        {
            set { descriptionTextBox.Text = value; }
        }



    }
}
