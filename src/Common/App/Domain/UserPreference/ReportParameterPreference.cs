using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Com.Suncor.Olt.Common.Domain.UserPreference
{
    [Serializable]
    public class ReportParameterPreference
    {
        private readonly List<string> selectedCategories = new List<string>();
        private readonly List<long> selectedRoleIds = new List<long>();
        private readonly List<long> selectedWorkAssignmentIds = new List<long>();
        private bool includeDataWithNoWorkAssignment = true;

        [XmlElement("SelectedRole")]
        public List<long> SelectedRoleIds
        {
            get { return selectedRoleIds; }
        }

        [XmlElement("SelectedCategory")]
        public List<string> SelectedCategories
        {
            get { return selectedCategories; }
        }

        [XmlElement("SelectedWorkAssignment")]
        public List<long> SelectedWorkAssignmentIds
        {
            get { return selectedWorkAssignmentIds; }
        }

        [XmlElement("IncludeDataWithNoWorkAssignment")]
        public bool IncludeDataWithNoWorkAssignment
        {
            get { return includeDataWithNoWorkAssignment; }
            set { includeDataWithNoWorkAssignment = value; }
        }
    }
}