using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Suncor.Olt.Common.Domain
{
     [Serializable]
   public class WorkpermitScan : DomainObject
    {
        public  WorkpermitScan()
        {

        }
        public string WorkPermitId { get; set; }

        public string DocumentPath { get; set; }

        public string UploadedDocumentType { get; set; }
       

        public string Comment { get; set; }


        public string Action { get; set; }
        public User LastModifiedBy { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }
        public long? SiteId { get; set; }

    }
    /// <summary>
    /// This class is to get the permit scan document type from table
    /// </summary>
     [Serializable]
     public class ScanDocumentType
     {
         // define a text and
         // a tag value

         public string Text{get;set;}
         public string Tag{get;set;}

         // override ToString(); this
         // is what the checkbox control
         // displays as text
         public override string ToString()
         {
             return this.Text;
         }
     }




     [Serializable]
     public class ScanCOnfiguration
     {
         
         public string  LocalScanPath{get;set;}
         public string ScanExeName{get;set;}
         public string ScanExePath{get;set;}
         public string SharedPath{get;set;}
         public string Environment { get; set; }
     }
}
