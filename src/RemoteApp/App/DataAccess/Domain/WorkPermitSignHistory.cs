﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class WorkPermitSignHistory : DomainObject, IHistorySnapshot
    {
        public string WorkPermitId { get; set; }
        public string PERMIT_ISSUER_NAME { get; set; }
        public string PERMIT_ISSUER_BADGENUMBER { get; set; }
        public string PERMIT_ISSUER_SOURCE { get; set; }

        public string NEXT_LEVEL_PERMITISSUER_NAME { get; set; }
        public string NEXT_LEVEL_PERMITISSUER_BADGENUMBER { get; set; }
        public string NEXT_LEVEL_PERMITISSUER_SOURCE { get; set; }

        public string PERMIT_RECEIVER_NAME { get; set; }
        public string PERMIT_RECEIVER_BADGENUMBER { get; set; }
        public string PERMIT_RECEIVER_SOURCE { get; set; }

        public string CROSS_ZONE_AUTHORIZATION_NAME { get; set; }
        public string CROSS_ZONE_AUTHORIZATION_BADGENUMBER { get; set; }
        public string CROSS_ZONE_AUTHORIZATION_SOURCE { get; set; }

        public string IMMIDIATE_AREA_NAME { get; set; }
        public string IMMIDIATE_AREA_BADGENUMBER { get; set; }
        public string IMMIDIATE_AREA_SOURCE { get; set; }

        public string CONFINED_SPACE_NAME { get; set; }

        public string CONFINED_SPACE_BADGENUMBER { get; set; }
        public string CONFINED_SPACE_SOURCE { get; set; }

        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string SiteId { get; set; }
        User _LastModifiedBy;
        DateTime _LastModifiedDate;
        public User LastModifiedBy { get { return _LastModifiedBy; } set { _LastModifiedBy = value; } }
        public DateTime LastModifiedDate
        {
            get { return _LastModifiedDate; }
            set { _LastModifiedDate = value; }
        }
    }



    [Serializable]
    public class WorkPermitMudsSignHistory : DomainObject, IHistorySnapshot
    {
        public string WorkPermitId { get; set; }
        public string VERIFICATEUR { get; set; }
        public string VERIFICATEUR_BADGENUMBER { get; set; }
        public string VERIFICATEUR_SOURCE { get; set; }

        public string DETENTEUR_NAME { get; set; }
        public string DETENTEUR_BADGENUMBER { get; set; }
        public string DETENTEUR_SOURCE { get; set; }

        public string EMETTEUR_NAME { get; set; }
        public string EMETTEUR_BADGENUMBER { get; set; }
        public string EMETTEUR_SOURCE { get; set; }

       
        
        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string SiteId { get; set; }
        User _LastModifiedBy;
        DateTime _LastModifiedDate;
        public User LastModifiedBy { get { return _LastModifiedBy; } set { _LastModifiedBy = value; } }
        public DateTime LastModifiedDate
        {
            get { return _LastModifiedDate; }
            set { _LastModifiedDate = value; }
        }


        public string FirstResult_Name
        {
            get;
            set;
        }
       
        public string FirstResult_Source
        {
            get;
            set;
        }

       

        public string SecondResult_Name
        {
            get;
            set;
        }

        public string SecondResult_Source
        {
            get;
            set;
        }

       

        public string ThirdResult_Name
        {
            get;
            set;
        }
       
        public string ThirdResult_Source
        {
            get;
            set;
        }

       



        public string FourthResult_Name
        {
            get;
            set;
        }

        public string FourthResult_Source
        {
            get;
            set;
        }

       
    }
}
      