using Microsoft.Xrm.Sdk;
using System;
using TWCTransport.Model;

public class Utility
{
    public static TransportRequest MapToTransportRequest(Entity entity)
    {
        var result = new TransportRequest();
        result.Id = entity.GetAttributeValue<Guid>("ss_transportrequestid");

        var CreatedByLookup = entity.GetAttributeValue<EntityReference>("createdby");
        var ModifiedByLookup = entity.GetAttributeValue<EntityReference>("modifiedby");
        var OwningBusinessUnitLookup = entity.GetAttributeValue<EntityReference>("owningbusinessunit");
        var OwningTeamLookup = entity.GetAttributeValue<EntityReference>("owningteam");
        var OwningUserLookup = entity.GetAttributeValue<EntityReference>("owninguser");

        //var ContactTitleOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_contacttitle");
        //var EducationHoursPerWeekOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_educationhoursperweek");
        //var EducationSchoolTypeOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_educationschooltype");
        //var GroundsForApplicationOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_groundsforapplication");
        //var MobilityEquipmentOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_mobilityequipment");
        //var TransportSeatTypeOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_transportseatype");

        result.CreatedBy = CreatedByLookup == null ? "" : CreatedByLookup.Name;
        result.ModifiedBy = ModifiedByLookup == null ? "" : ModifiedByLookup.Name;
        result.OwningBusinessUnit = OwningBusinessUnitLookup == null ? "" : OwningBusinessUnitLookup.Name;
        result.OwningTeam = OwningTeamLookup == null ? "" : OwningTeamLookup.Name;
        result.OwningUser = OwningUserLookup == null ? "" : OwningUserLookup.Name;



        //            result.ContactTitle = ContactTitleOptionSet == null ? string.Empty : ((ContactTitle)ContactTitleOptionSet.Value).ToString();
        //result.EducationHoursPerWeek = EducationHoursPerWeekOptionSet == null ? string.Empty : ((EducationHoursPerWeek)EducationHoursPerWeekOptionSet.Value).ToString();
        //result.EducationSchoolType = EducationSchoolTypeOptionSet == null ? string.Empty : ((EducationSchoolType)EducationSchoolTypeOptionSet.Value).ToString();
        //result.GroundsForApplication = GroundsForApplicationOptionSet == null ? string.Empty : ((GroundsForApplication)GroundsForApplicationOptionSet.Value).ToString();
        //result.MobilityEquipment = MobilityEquipmentOptionSet == null ? string.Empty : ((MobilityEquipment)MobilityEquipmentOptionSet.Value).ToString();
        //result.TransportSeatType = TransportSeatTypeOptionSet == null ? string.Empty : ((TransportSeatType)TransportSeatTypeOptionSet.Value).ToString();

        result.ContactFirstName = entity.GetAttributeValue<string>("ss_contactfirstname");
        result.ContactLastName = entity.GetAttributeValue<string>("ss_contactlastname");
        result.ContactEmail = entity.GetAttributeValue<string>("ss_contactemail");
        result.ContactPhone = entity.GetAttributeValue<string>("ss_contactphone");
        result.ContactAddressline1 = entity.GetAttributeValue<string>("ss_contactaddressline1");
        result.ContactAddressline2 = entity.GetAttributeValue<string>("ss_contactaddressline2");
        result.ContactAddressline3 = entity.GetAttributeValue<string>("ss_contactaddressline3");
        result.ContactAddressline4 = entity.GetAttributeValue<string>("ss_contactaddressline4");
        result.ContactAddressPostcode = entity.GetAttributeValue<string>("ss_contactaddresspostcode");
        result.ContactRelationship = entity.GetAttributeValue<string>("ss_contactrelationship");





        result.CreatedOn = entity.GetAttributeValue<DateTime>("createdon");
        result.DocumentViewerControl = entity.GetAttributeValue<string>("ss_documentviewercontrol");
        result.EducationCourseTitle = entity.GetAttributeValue<string>("ss_educationcoursetitle");
        result.EducationEHCPFinalisedDate = entity.GetAttributeValue<DateTime>("ss_educationehcpfinaliseddate");//DateOnly
        result.EducationFirstYearOfStudy = entity.GetAttributeValue<Boolean>("ss_educationfirstyearofstudy");
        result.EducationHasAppliedForBursary = entity.GetAttributeValue<Boolean>("ss_educationhasappliedforbursary");
        result.EducationNearestSchoolCollege = entity.GetAttributeValue<Boolean>("ss_educationnearestschoolcollege");
        result.EducationQualification = entity.GetAttributeValue<string>("ss_educationqualification");
        result.EducationSchoolAdmittanceDate = entity.GetAttributeValue<DateTime>("ss_educationschooladmittancedate");//DateOnly
        result.EducationWhyNotNearestSchool = entity.GetAttributeValue<Boolean>("ss_educationwhynotnearestschool");
        result.FreeSchoolMealsEntitlement = entity.GetAttributeValue<Boolean>("ss_freeschoolmealsentitlement");

        //result.ImportSequenceNumber = entity.GetAttributeValue<int>("importsequencenumber");
        result.MaximumTaxCredits = entity.GetAttributeValue<Boolean>("ss_maximumtaxcredits");
        result.MobilityCanTransferToSeatWhilstTravelling = entity.GetAttributeValue<Boolean>("ss_mobilitycantransfertoseatwhilsttravelling");
        result.MobilityDetails = entity.GetAttributeValue<string>("ss_mobilitydetails");
        result.MobilityEquipmentDimensions = entity.GetAttributeValue<string>("ss_mobilityequipmentdimensions");
        result.MobilityHasIssues = entity.GetAttributeValue<Boolean>("ss_mobilityhasissues");
        result.ModifiedOn = entity.GetAttributeValue<DateTime>("modifiedon");
        result.OtherDetails = entity.GetAttributeValue<string>("ss_otherdetails");
        result.OverriddenCreatedOn = entity.GetAttributeValue<DateTime>("overriddencreatedon");//DateOnly

        result.SeizuresFrequency = entity.GetAttributeValue<string>("ss_seizuresfrequency");
        result.SeizuresHasSeizures = entity.GetAttributeValue<Boolean>("ss_seizureshasseizures");
        result.SeizuresSigns = entity.GetAttributeValue<string>("ss_seizuressigns");
        result.SeizuresType = entity.GetAttributeValue<string>("ss_seizurestype");
        result.SendOrMedicalDetails = entity.GetAttributeValue<string>("ss_sendormedicaldetails");
        result.SendOrMedicalHasSendOrMedicalNeeds = entity.GetAttributeValue<Boolean>("ss_sendormedicalhassendormedicalneeds");
        result.StudentDetailsAddressLine1 = entity.GetAttributeValue<string>("ss_studentdetailsaddressline1");
        result.StudentDetailsAddressLine2 = entity.GetAttributeValue<string>("ss_studentdetailsaddressline2");
        result.StudentDetailsAddressLine3 = entity.GetAttributeValue<string>("ss_studentdetailsaddressline3");
        result.StudentDetailsAddressLine4 = entity.GetAttributeValue<string>("ss_studentdetailsaddressline4");
        result.StudentDetailsAddressPostcode = entity.GetAttributeValue<string>("ss_studentdetailsaddresspostcode");
        result.StudentDetailsHasDisabilityLivingAllowance = entity.GetAttributeValue<Boolean>("ss_studentdetailshasdisabilitylivingallowance");
        result.StudentDetailsInCare = entity.GetAttributeValue<Boolean>("ss_studentdetailsincare");
        result.StudentDetailsLivesAtDifferentAddress = entity.GetAttributeValue<Boolean>("ss_studentdetailslivesatdifferentaddress");
        result.StudentDetailsSocialWorker = entity.GetAttributeValue<string>("ss_studentdetailssocialworker");
        result.SupportCalming = entity.GetAttributeValue<string>("ss_supportcalming");

        result.SupportOther = entity.GetAttributeValue<string>("ss_supportother");
        result.TimeZoneRuleVersionNumber = entity.GetAttributeValue<int>("timezoneruleversionnumber");
        result.TransportHarnessRequired = entity.GetAttributeValue<Boolean>("ss_transportharnessrequired");
        result.TransportHasOwnVehicle = entity.GetAttributeValue<Boolean>("ss_transporthasownvehicle");
        result.TransportNoSharedTransportDetails = entity.GetAttributeValue<string>("ss_transportnosharedtransportdetails");
        result.TransportRemoveSeatBelt = entity.GetAttributeValue<Boolean>("ss_transportremoveseatbelt");
        result.TransportRequestNumber = entity.GetAttributeValue<string>("ss_transportrequestnumber");
        result.TransportRoadSafety = entity.GetAttributeValue<Boolean>("ss_transportroadsafety");
        result.TransportSeatDetails = entity.GetAttributeValue<string>("ss_transportseatdetails");
        result.TransportStartDate = entity.GetAttributeValue<DateTime>("ss_transportstartdate");//DateOnly
        result.TransportStudentJourneyDetails = entity.GetAttributeValue<string>("ss_transportstudentjourneydetails");
        result.TransportTravelTraining = entity.GetAttributeValue<Boolean>("ss_transporttraveltraining");
        result.TransportWhyNotFamilyOrFriends = entity.GetAttributeValue<string>("ss_transportwhynotfamilyorfriends");
        result.Transport_HasTransportMedication = entity.GetAttributeValue<Boolean>("ss_transport_hastransportmedication");
        result.Transport_MedicationDetails = entity.GetAttributeValue<string>("ss_transport_medicationdetails");
        // result.UTCConversionTimeZoneCode = entity.GetAttributeValue<int>("utcconversiontimezonecode");
        // result.VersionNumber = entity.GetAttributeValue<int>("versionnumber");

        return result;
    }

    public static EmergencyContact MapToEmergencyContact(Entity entity)
    {
        return new EmergencyContact()
        {
            Id = entity.GetAttributeValue<Guid>("ss_emergencycontactid"),
            Fullname = entity.GetAttributeValue<string>("ss_name"),
            Email = entity.GetAttributeValue<string>("ss_email"),
            Phone = entity.GetAttributeValue<string>("ss_phone"),
            Relationship = entity.GetAttributeValue<string>("ss_relationship")
        };
    }
    
}