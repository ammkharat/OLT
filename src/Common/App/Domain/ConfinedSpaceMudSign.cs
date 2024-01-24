using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
   public class ConfinedSpaceMudSign:DomainObject
    {
         public string ConfinedSpaceId { get; set; }


        public string Verifier_FNAME { get; set; }
        public string Verifier_LNAME { get; set; }
        public string Verifier_BADGENUMBER { get; set; }
        public string Verifier_BADGETYPE { get; set; }
        public string Verifier_SOURCE { get; set; }

        public string DETENTEUR_FNAME { get; set; }
        public string DETENTEUR_LNAME { get; set; }
        public string DETENTEUR_BADGENUMBER { get; set; }
        public string DETENTEUR_BADGETYPE { get; set; }
        public string DETENTEUR_SOURCE { get; set; }

        public string EMETTEUR_FNAME { get; set; }
        public string EMETTEUR_LNAME { get; set; }
        public string EMETTEUR_BADGENUMBER { get; set; }
        public string EMETTEUR_BADGETYPE { get; set; }
        public string EMETTEUR_SOURCE { get; set; }



        public int UpdatedBy { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public string SiteId { get; set; }

         public string FirstNameFirstResult
        {
            get;
            set;
        }
        public string LasttNameFirstResult
        {
            get;
            set;
        }
        public string SourceFirstResult
        {
            get;
            set;
        }

        public string BadgeFirstResult
        {
            get;
            set;
        }

        public string FirstNameSecondResult
        {
            get;
            set;
        }
        public string LasttNameSecondResult
        {
            get;
            set;
        }
        public string SourceSecondResult
        {
            get;
            set;
        }

        public string BadgeSecondResult
        {
            get;
            set;
        }

        public string FirstNameThirdResult
        {
            get;
            set;
        }
        public string LasttNameThirdResult
        {
            get;
            set;
        }
        public string SourceThirdResult
        {
            get;
            set;
        }

        public string BadgeThirdResult
        {
            get;
            set;
        }




        public string FirstNameFourthResult
        {
            get;
            set;
        }
        public string LasttNameFourthResult
        {
            get;
            set;
        }
        public string SourceFourthResult
        {
            get;
            set;
        }

        public string BadgeFourthResult
        {
            get;
            set;
        }
      
    }
   }

