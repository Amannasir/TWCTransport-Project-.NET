using System;

public class TransportRequest_EmergencyContact
{
    public Guid? Id { get; set; }
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }
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
    public string SeizuresSigns { get; set; }        //type
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
    public Guid? EmergencyContactId1 { get; set; }
    public string EmergencyContactName1 { get; set; }
    public string EmergencyContactEmail1 { get; set; }
    public string EmergencyContactNumber1 { get; set; }
    public string EmergencyContactRelationship1 { get; set; }
    public Guid? EmergencyContactId2 { get; set; }
    public string EmergencyContactName2 { get; set; }
    public string EmergencyContactEmail2 { get; set; }
    public string EmergencyContactNumber2 { get; set; }
    public string EmergencyContactRelationship2 { get; set; }
}
