﻿using System;
using System.Security.Permissions;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Domain.Form
{
    public class FormGN75BHistory : DomainObjectHistorySnapshot
    {
        public FormGN75BHistory(long id, string functionalLocation, string location, bool blindsRequired,
            string equipmentType, string lockBoxNumber, string lockBoxLocation,
            string isolations, string documentLinks, DateTime? closedDateTime, FormStatus formStatus,
            byte[] schematicImage,
            User lastModifiedBy, DateTime lastModifiedDateTime)
            : base(id, lastModifiedBy, lastModifiedDateTime)
        {
            FunctionalLocation = functionalLocation;
            Location = location;
            BlindsRequired = blindsRequired;
            EquipmentType = equipmentType;
            LockBoxNumber = lockBoxNumber;
            LockBoxLocation = lockBoxLocation;
            Isolations = isolations;
            DocumentLinks = documentLinks;
            ClosedDateTime = closedDateTime;
            FormStatus = formStatus;
            SchematicImage = schematicImage;

        }

        public string EquipmentType { get; private set; }

        public string Location { get; private set; }

        public FormStatus FormStatus { get; private set; }

        public DateTime? ClosedDateTime { get; private set; }

        public string DocumentLinks { get; private set; }

        [ImageDifference]
        public byte[] SchematicImage { get; private set; }

        public string Isolations { get; private set; }

        public string LockBoxLocation { get; private set; }

        public string LockBoxNumber { get; private set; }

        public bool BlindsRequired { get; private set; }

        public string FunctionalLocation { get; private set; }
    }
}