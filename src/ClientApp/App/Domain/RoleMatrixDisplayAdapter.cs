using System;
using System.Collections.Generic;
using System.ComponentModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using DevExpress.XtraPrinting.Native;

namespace Com.Suncor.Olt.Client.Domain
{
    public class RoleMatrixDisplayAdapter
    {
        public static string KeyPrefix = "unboundmagicpants-";
        private readonly RoleElement roleElement;

        private  Dictionary<string, bool> values = new Dictionary<string, bool>();

        public RoleMatrixDisplayAdapter(RoleElement roleElement)
        {
            this.roleElement = roleElement;
        }

        public string FunctionalArea
        {
            get { return roleElement.FunctionalArea; }
        }

        public string Name
        {
            get { return roleElement.Name; }
        }

        public void SetValue(string key, bool value)
        {
            values[key] = value;
        }

        //ayman Sarnia eip DMND0008992
        public string clearAllValues()
        {
            foreach (var VARIABLE in values)
            {
                if (VARIABLE.Value == true)
                    return VARIABLE.Key;
            }
            return string.Empty;
        }

        public bool GetValue(string key)
        {
            return values[key];
        }

        public bool GetValue(Role role)
        {
            return values[Key(role)];
        }

        [Browsable(false)]
        public RoleElement RoleElement
        {
            get { return roleElement; }
        }

        public static string Key(Role role)
        {
            return string.Format("{0}-{1}", KeyPrefix, role.IdValue);
        }
    }
}
