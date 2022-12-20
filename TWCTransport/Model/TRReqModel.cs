namespace TWCTransport.Model
{
    public class TRReqModel
    {
        public Guid? Id { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName {get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddressline1 { get; set; }

        public string ContactAddressline2 { get; set; }

        public string ContactAddressline3 { get; set; }

        public string ContactAddressline4 { get; set; }

        public string ContactAddressPostcode { get; set; }

        public string ContactRelationship { get; set; }






        public string ContactTitle { get; set; } //optionSet
        
        public string CreatedBy { get; set; } //lookup

        public string CreatedByDelegate { get; set; } //lookup
        public DateTime? CreatedOn { get; set; }

        public string DocumentViewerControl { get; set; }

        public string EducationCourseTitle { get; set; }

        public DateTime? EducationEHCPFinalisedDate { get; set; }

        public Boolean EducationFirstYearOfStudy { get; set; }

        public Boolean EducationHasAppliedForBursary { get; set; }
        public Boolean EducationHasEHCPPlan { get; set; }
         public string EducationHoursPerWeek { get; set; }//optionSet
        public Boolean EducationNearestSchoolCollege { get; set; }

        public string EducationQualification { get; set; }
        public DateTime? EducationSchoolAdmittanceDate { get; set; }

        public string EducationSchoolType { get; set; }//optionSet
        public Boolean EducationWhyNotNearestSchool { get; set; }
        public Boolean FreeSchoolMealsEntitlement { get; set; }
        public string GroundsForApplication { get; set; }//optionSet




        public int ImportSequenceNumber { get; set; }
        public Boolean MaximumTaxCredits { get; set; }
        public Boolean MobilityCanTransferToSeatWhilstTravelling { get; set; }
        public string MobilityDetails { get; set; }

        public string MobilityEquipment { get; set; }//optionSet
        public string MobilityEquipmentDimensions { get; set; }
        public Boolean MobilityHasIssues { get; set; }
        
        public string ModifiedBy { get; set; } //lookup

        public string ModifiedOnBehalfBy { get; set; } //lookup
        public DateTime? ModifiedOn { get; set; }
        public string OtherDetails { get; set; }
        /// <summary>
        /// ////public string OwnerId { get; set; }
        /// </summary>
      
        public string OwningBusinessUnit { get; set; } //lookup

        public string OwningTeam { get; set; } //lookup
        public string OwningUser { get; set; } //lookup
        public DateTime? OverriddenCreatedOn { get; set; }









        public string SeizuresFrequency { get; set; }

        public Boolean SeizuresHasSeizures { get; set; }
        public string SeizuresSigns { get; set; }
        //type
        public string SeizuresType { get; set; }
        public string SendOrMedicalDetails { get; set; }
        public Boolean SendOrMedicalHasSendOrMedicalNeeds { get; set; }

      //  public string statecode { get; set; }
      //  public string statuscode { get; set; }
        public string StudentDetailsAddressLine1 { get; set; }
        public string StudentDetailsAddressLine2 { get; set; }
        public string StudentDetailsAddressLine3 { get; set; }
        public string StudentDetailsAddressLine4 { get; set; }
        public string StudentDetailsAddressPostcode { get; set; }
        public Boolean StudentDetailsHasDisabilityLivingAllowance { get; set; }

        public Boolean StudentDetailsInCare { get; set; }
        public Boolean StudentDetailsLivesAtDifferentAddress { get; set; }
        public string StudentDetailsSocialWorker { get; set; }
        public string SupportCalming { get; set; }








        public string SupportOther { get; set; }
        public int TimeZoneRuleVersionNumber { get; set; }
        public Boolean TransportHarnessRequired { get; set; }
        public Boolean TransportHasOwnVehicle { get; set; }

        public string TransportNoSharedTransportDetails { get; set; }
        public Boolean TransportRemoveSeatBelt { get; set; }
       // public string TransportRequestId { get; set; }
        public string TransportRequestNumber { get; set; }
        public Boolean TransportRoadSafety { get; set; }
        public string TransportSeatDetails { get; set; }
        public string TransportSeatType { get; set; }//lookup
        public DateTime? TransportStartDate { get; set; }

        public string TransportStudentJourneyDetails { get; set; }
        public Boolean TransportTravelTraining { get; set; }
        public string TransportWhyNotFamilyOrFriends { get; set; }
        public Boolean Transport_HasTransportMedication { get; set; }
        public string Transport_MedicationDetails { get; set; }
        public int UTCConversionTimeZoneCode { get; set; }
        public int VersionNumber { get; set; }








       

        



    
    }

    public enum ContactTitle
    {
        Mr = 126560000,
        Miss = 804920001,
        Mrs = 804920002,
        Ms = 126560003,
        Cllr = 126560004,
        Rev = 126560005,
        Dr = 126560006,
        Lord = 126560007,
        Lady = 126560008,
        SirGeneral = 126560009,
        Captain = 126560010,
        Sergant = 126560011,

    }

    public enum EducationHoursPerWeek
    {
        Under10Hours = 126560000,
        H10To15Hours = 126560001,
        H16To20Hours = 126560002,
        Over20Hours = 126560003,


    }
    public enum EducationSchoolType
    {
        Primary = 126560000,
        Secondary = 126560001,
        SixthFormSchool = 126560002,
        SixthFormCollege = 126560003,
        FurtherEducationCollege = 126560004,
        Post16Training = 126560005


    }
    public enum GroundsForApplication
    {
        Distance = 126560000,
        LowIncome = 126560001,
        MedicalOrSpecialEducationNeeds = 126560002
    }


    public enum MobilityEquipment
    {
        NotApplicable = 126560000,
        ManualWheelchair = 126560001,
        ElectricWheelchair = 126560002,
        Buggy = 126560003,
        WalkingFrame = 126560004,



    }
    public enum TransportSeatType
    {
        NotApplicable = 126560000,
        JuniorCarSeat = 126560001,
        BoosterSeat = 126560002,
        BoosterCushion = 126560003,
        SpecialChildSeat = 126560004,



    }
}
