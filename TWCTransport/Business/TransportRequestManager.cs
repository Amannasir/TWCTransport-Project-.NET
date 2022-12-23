using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Linq;
using TWCTransport.Model;
using TWCTransport.Provider;

namespace TWCTransport.Business
{
    public class TransportRequestManager : ITransportRequestManager
    {
        readonly ServiceClient serviceClient;
        readonly IDataverseProvider dataverseProvider;
        public TransportRequestManager(IDataverseProvider dataverseProvider)
        {
            this.dataverseProvider = dataverseProvider;
            this.serviceClient = this.dataverseProvider.GetServiceClient();
        }


        private static TRReqModel MapToTRDataverse(TRReqModel TransportRequest, List<EmergencyContact> EmergencyContacts)
        {
            var result = new TRReqModel();
            result.Id = TransportRequest.Id;

            var CreatedByLookup = entity.GetAttributeValue<EntityReference>("createdby");           
            var ModifiedByLookup = entity.GetAttributeValue<EntityReference>("modifiedby");
            var OwningBusinessUnitLookup = entity.GetAttributeValue<EntityReference>("owningbusinessunit");
            var OwningTeamLookup = entity.GetAttributeValue<EntityReference>("owningteam");
            var OwningUserLookup = entity.GetAttributeValue<EntityReference>("owninguser");

            result.emergencyContactName1 = EmergencyContacts[0].Fullname;
            result.emergencyContactEmail1 = EmergencyContacts[0].Email;
            result.emergencyContactNumber1 = EmergencyContacts[0].Phone;
            result.emergencyContactRelationship1 = EmergencyContacts[0].Relationship;

            result.emergencyContactName2 = EmergencyContacts[1].Fullname;
            result.emergencyContactEmail2 = EmergencyContacts[1].Email;
            result.emergencyContactNumber2 = EmergencyContacts[1].Phone;
            result.emergencyContactRelationship2 = EmergencyContacts[1].Relationship;

            //var emergencyContactName1Lookup = entity.GetAttributeValue<AliasedValue>("ec.ss_name");
            //var emergencyContactEmail1Lookup = entity.GetAttributeValue<AliasedValue>("ec.ss_email");
            //var emergencyContactNumber1Lookup = entity.GetAttributeValue<AliasedValue>("ec.ss_phone");
            //var emergencyContactRelationship1Lookup = entity.GetAttributeValue<AliasedValue>("ec.ss_relationship");

            //result.emergencyContactName1 = emergencyContactName1Lookup == null ? "" : emergencyContactName1Lookup.Value.ToString();
            //result.emergencyContactEmail1 = emergencyContactEmail1Lookup == null ? "" : emergencyContactEmail1Lookup.Value.ToString(); 
            //result.emergencyContactNumber1 = emergencyContactNumber1Lookup == null ? "" : emergencyContactNumber1Lookup.Value.ToString(); 
            //result.emergencyContactRelationship1 = emergencyContactRelationship1Lookup == null ? "" : emergencyContactRelationship1Lookup.Value.ToString(); 

            //result.emergencyContactName2 = entity.GetAttributeValue<string>("ss_contactaddressline1");
            //result.emergencyContactEmail2 = entity.GetAttributeValue<string>("ss_contactaddressline2");
            //result.ContactAddressline3 = entity.GetAttributeValue<string>("ss_contactaddressline3");
            //result.emergencyContactNumber2 = entity.GetAttributeValue<string>("ss_contactaddressline4");
            //result.emergencyContactRelationship2 = entity.GetAttributeValue<string>("ss_contactaddresspostcode");


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
        private static TRReqModel MapToTRDataverse(Entity entity)
        {
            var result = new TRReqModel();
            result.Id = entity.GetAttributeValue<Guid>("ss_transportrequestid");

            var CreatedByLookup = entity.GetAttributeValue<EntityReference>("createdby");
            var ModifiedByLookup = entity.GetAttributeValue<EntityReference>("modifiedby");
            var OwningBusinessUnitLookup = entity.GetAttributeValue<EntityReference>("owningbusinessunit");
            var OwningTeamLookup = entity.GetAttributeValue<EntityReference>("owningteam");
            var OwningUserLookup = entity.GetAttributeValue<EntityReference>("owninguser");


            var emergencyContactName1Lookup = entity.GetAttributeValue<AliasedValue>("ec.ss_name");
            var emergencyContactEmail1Lookup = entity.GetAttributeValue<AliasedValue>("ec.ss_email");
            var emergencyContactNumber1Lookup = entity.GetAttributeValue<AliasedValue>("ec.ss_phone");
            var emergencyContactRelationship1Lookup = entity.GetAttributeValue<AliasedValue>("ec.ss_relationship");

            result.emergencyContactName1 = emergencyContactName1Lookup == null ? "" : emergencyContactName1Lookup.Value.ToString();
            result.emergencyContactEmail1 = emergencyContactEmail1Lookup == null ? "" : emergencyContactEmail1Lookup.Value.ToString();
            result.emergencyContactNumber1 = emergencyContactNumber1Lookup == null ? "" : emergencyContactNumber1Lookup.Value.ToString();
            result.emergencyContactRelationship1 = emergencyContactRelationship1Lookup == null ? "" : emergencyContactRelationship1Lookup.Value.ToString();

            result.emergencyContactName2 = entity.GetAttributeValue<string>("ss_contactaddressline1");
            result.emergencyContactEmail2 = entity.GetAttributeValue<string>("ss_contactaddressline2");
            result.ContactAddressline3 = entity.GetAttributeValue<string>("ss_contactaddressline3");
            result.emergencyContactNumber2 = entity.GetAttributeValue<string>("ss_contactaddressline4");
            result.emergencyContactRelationship2 = entity.GetAttributeValue<string>("ss_contactaddresspostcode");
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
        private static EmergencyContact MapToEmergencyContact(Entity entity)
        {
            var result = new EmergencyContact();
            result.Id = entity.GetAttributeValue<Guid>("ss_emergencycontactid");

            //var ContactTitleOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_contacttitle");
            //var EducationHoursPerWeekOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_educationhoursperweek");
            //var EducationSchoolTypeOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_educationschooltype");
            //var GroundsForApplicationOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_groundsforapplication");
            //var MobilityEquipmentOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_mobilityequipment");
            //var TransportSeatTypeOptionSet = entity.GetAttributeValue<OptionSetValue>("ss_transportseatype");

            

            return result;
        }

        public async Task<TRReqModel> CreateEmergencyContact(TRReqModel trnsReqModelData)
        {
            var entity = new Entity("ss_emergencycontact");
            var entity2 = new Entity("ss_emergencycontact");
            //map
            //new entity
            //

            entity["ss_name"] = trnsReqModelData.emergencyContactName1;
            entity["ss_email"] = trnsReqModelData.emergencyContactEmail1;
            entity["ss_phone"] = trnsReqModelData.emergencyContactNumber1;
            entity["ss_relationship"] = trnsReqModelData.emergencyContactRelationship1;
            trnsReqModelData.emergencyId = await serviceClient.CreateAsync(entity);
            entity2["ss_name"] = trnsReqModelData.emergencyContactName2;
            entity2["ss_email"] = trnsReqModelData.emergencyContactEmail2;
            entity2["ss_phone"] = trnsReqModelData.emergencyContactNumber2;
            entity2["ss_relationship"] = trnsReqModelData.emergencyContactRelationship2;
            trnsReqModelData.emergencyId = await serviceClient.CreateAsync(entity2);
            return trnsReqModelData;
        }

            public async Task<TRReqModel> CreateAsync(TRReqModel trnsReqModelData)
        {
            //var demo = trnsReqModelData.demmofield; ;
            //var emergencycontactfirstName= trnsReqModelData.emergencycontactName1;
            //var emergencycontactEmail = trnsReqModelData.emergencycontactEmail1;
            //var emergencycontactNumber= trnsReqModelData.emergencycontactNumber1;
            //var emergencycontactfirstRelationship = trnsReqModelData.emergencycontactRelationship1;
            
            var entity = new Entity("ss_transportrequest");
            // var bookAuthorLookup = entity.GetAttributeValue<EntityReference>("mgt_author");
            await CreateEmergencyContact(trnsReqModelData);
            entity["ss_contacttitle"] = trnsReqModelData.ContactTitle;


            entity["ss_contactfirstname"] = trnsReqModelData.ContactFirstName;
            entity["ss_contactlastname"] = trnsReqModelData.ContactLastName;
            entity["ss_contactemail"] = trnsReqModelData.ContactEmail;
            entity["ss_contactphone"] = trnsReqModelData.ContactPhone;
            entity["ss_contactaddressline1"] = trnsReqModelData.ContactAddressline1;
            entity["ss_contactaddressline2"] = trnsReqModelData.ContactAddressline2;
            entity["ss_contactaddressline3"] = trnsReqModelData.ContactAddressline3;
            entity["ss_contactaddressline4"] = trnsReqModelData.ContactAddressline4;
            entity["ss_contactaddresspostcode"] = trnsReqModelData.ContactAddressPostcode;
            entity["ss_contactrelationship"] = trnsReqModelData.ContactRelationship;
//lookup
            //entity.Attributes["createdby"] = new EntityReference("createdby", new Guid(trnsReqModelData.CreatedBy));
            //entity.Attributes["modifiedby"] = new EntityReference("modifiedby", new Guid(trnsReqModelData.ModifiedBy));
            //entity.Attributes["owningbusinessunit"] = new EntityReference("owningbusinessunit", new Guid(trnsReqModelData.OwningBusinessUnit));
            //entity.Attributes["owningteam"] = new EntityReference("owningteam", new Guid(trnsReqModelData.OwningTeam));
            //entity.Attributes["owninguser"] = new EntityReference("owninguser", new Guid(trnsReqModelData.OwningUser));


            //entity["createdon"] = trnsReqModelData.CreatedOn;
            entity["ss_documentviewercontrol"] = trnsReqModelData.DocumentViewerControl;
            entity["ss_educationcoursetitle"] = trnsReqModelData.EducationCourseTitle;
            entity["ss_educationehcpfinaliseddate"] = trnsReqModelData.EducationEHCPFinalisedDate;
            entity["ss_educationfirstyearofstudy"] = trnsReqModelData.EducationFirstYearOfStudy;
            entity["ss_educationhasappliedforbursary"] = trnsReqModelData.EducationHasAppliedForBursary;
            entity["ss_educationnearestschoolcollege"] = trnsReqModelData.EducationNearestSchoolCollege;
            entity["ss_educationqualification"] = trnsReqModelData.EducationQualification;
            entity["ss_educationschooladmittancedate"] = trnsReqModelData.EducationSchoolAdmittanceDate;
            entity["ss_educationwhynotnearestschool"] = trnsReqModelData.EducationWhyNotNearestSchool;


            entity["importsequencenumber"] = trnsReqModelData.ImportSequenceNumber;
            entity["ss_maximumtaxcredits"] = trnsReqModelData.MaximumTaxCredits;
            entity["ss_mobilitycantransfertoseatwhilsttravelling"] = trnsReqModelData.MobilityCanTransferToSeatWhilstTravelling;
            entity["ss_mobilitydetails"] = trnsReqModelData.MobilityDetails;
            entity["ss_mobilityequipmentdimensions"] = trnsReqModelData.MobilityEquipmentDimensions;
            entity["ss_mobilityhasissues"] = trnsReqModelData.MobilityHasIssues;
            entity["modifiedon"] = trnsReqModelData.ModifiedOn;
            entity["ss_otherdetails"] = trnsReqModelData.OtherDetails;
            entity["overriddencreatedon"] = trnsReqModelData.OverriddenCreatedOn;


            entity["ss_seizuresfrequency"] = trnsReqModelData.SeizuresFrequency;
            entity["ss_seizureshasseizures"] = trnsReqModelData.SeizuresHasSeizures;
            entity["ss_seizuressigns"] = trnsReqModelData.SeizuresSigns;
            entity["ss_seizurestype"] = trnsReqModelData.SeizuresType;
            entity["ss_sendormedicaldetails"] = trnsReqModelData.SendOrMedicalDetails;
            entity["ss_sendormedicalhassendormedicalneeds"] = trnsReqModelData.SendOrMedicalHasSendOrMedicalNeeds;
            entity["ss_studentdetailsaddressline1"] = trnsReqModelData.StudentDetailsAddressLine1;
            entity["ss_studentdetailsaddressline2"] = trnsReqModelData.StudentDetailsAddressLine2;
            entity["ss_studentdetailsaddressline3"] = trnsReqModelData.StudentDetailsAddressLine3;
            entity["ss_studentdetailsaddressline4"] = trnsReqModelData.StudentDetailsAddressLine4;
            entity["ss_studentdetailsaddresspostcode"] = trnsReqModelData.StudentDetailsAddressPostcode;
            entity["ss_studentdetailshasdisabilitylivingallowance"] = trnsReqModelData.StudentDetailsHasDisabilityLivingAllowance;
            entity["ss_studentdetailsincare"] = trnsReqModelData.StudentDetailsInCare;
            entity["ss_studentdetailslivesatdifferentaddress"] = trnsReqModelData.StudentDetailsLivesAtDifferentAddress;
            entity["ss_studentdetailssocialworker"] = trnsReqModelData.StudentDetailsSocialWorker;
            entity["ss_supportcalming"] = trnsReqModelData.SupportCalming;





            entity["ss_supportother"] = trnsReqModelData.SupportOther;
            entity["timezoneruleversionnumber"] = trnsReqModelData.TimeZoneRuleVersionNumber;
            entity["ss_transportharnessrequired"] = trnsReqModelData.TransportHarnessRequired;
            entity["ss_transporthasownvehicle"] = trnsReqModelData.TransportHasOwnVehicle;
            entity["ss_transportnosharedtransportdetails"] = trnsReqModelData.TransportNoSharedTransportDetails;
            entity["ss_transportremoveseatbelt"] = trnsReqModelData.TransportRemoveSeatBelt;
            entity["ss_transportrequestnumber"] = trnsReqModelData.TransportRequestNumber;
            entity["ss_transportroadsafety"] = trnsReqModelData.TransportRoadSafety;
            entity["ss_transportseatdetails"] = trnsReqModelData.TransportSeatDetails;
            entity["ss_transportstartdate"] = trnsReqModelData.TransportStartDate;
            entity["ss_transportstudentjourneydetails"] = trnsReqModelData.TransportStudentJourneyDetails;
            entity["ss_transporttraveltraining"] = trnsReqModelData.TransportTravelTraining;
            entity["ss_transportwhynotfamilyorfriends"] = trnsReqModelData.TransportWhyNotFamilyOrFriends;
            entity["ss_transport_hastransportmedication"] = trnsReqModelData.Transport_HasTransportMedication;
            entity["ss_transport_medicationdetails"] = trnsReqModelData.Transport_MedicationDetails;
            entity["utcconversiontimezonecode"] = trnsReqModelData.UTCConversionTimeZoneCode;
            entity["versionnumber"] = trnsReqModelData.VersionNumber;

            trnsReqModelData.Id = await serviceClient.CreateAsync(entity);
            return trnsReqModelData;
        }

        //public async Task Get_ContactTitle()
        //{
        //    //stringmap.
        //    //opbject type code 
        //    //attribute name 
        //    await client.DeleteAsync("ss_transportrequest", id);
        //}

        public async Task DeleteAsync(Guid id)
        {
            await serviceClient.DeleteAsync("ss_transportrequest", id);
        }

        public async Task<TRReqModel> GetTransportRequestByIdAsync(Guid id)
        {
            var entity = serviceClient.Retrieve("ss_transportrequest", id, new ColumnSet(true));
            var TransportRequest = MapToTRDataverse(entity);

            var EmergencyContact = "ss_emergencycontact";
            var LinkEntity = "ss_transportrequest_ss_emergencycontact";

            var query = new QueryExpression(EmergencyContact)
            {
                ColumnSet = new ColumnSet("ss_relationship", "ss_name", "ss_email", "ss_phone")
            };
            LinkEntity ss_transportrequest_ss_emergencycontact = new LinkEntity(EmergencyContact, LinkEntity, "ss_emergencycontactid", "ss_emergencycontactid", JoinOperator.Inner);
            ss_transportrequest_ss_emergencycontact.EntityAlias = "TE";
            query.LinkEntities.Add(ss_transportrequest_ss_emergencycontact);

            //query.Criteria = new FilterExpression();
            query.Criteria.AddCondition("ss_transportrequest_ss_emergencycontact", "ss_transportrequestid", ConditionOperator.Equal, id);

            var entityCollection = await serviceClient.RetrieveMultipleAsync(query);
            var EmergencyContacts = entityCollection.Entities.Select(entity => MapToEmergencyContact(entity)).ToList();

            var result =  MapToTRDataverse(TransportRequest, EmergencyContacts);
            return result;
            //var entity = await client.RetrieveAsync("ss_transportrequest", id, new ColumnSet(true));
            //var record = MapToTRDataverse(entity);

            //return record;


            // Define Condition Values
            //Guid query_ss_transportrequest_ss_emergencycontact_ss_transportrequestid = id;

            //// Instantiate QueryExpression query
            //var query = new QueryExpression("ss_transportrequest");
            //query.TopCount = 50;

            //// Add columns to query.ColumnSet
            //query.ColumnSet.AddColumns("ss_contactlastname", "ss_contactfirstname", "ss_contactphone", "versionnumber", "createdon", "ss_transport_hastransportmedication", "ss_transportrequestid", "ss_transportrequestnumber", "ss_studentdetailsaddressline2", "ss_educationschooltype", "ownerid", "modifiedon", "createdonbehalfby", "ss_seizurestype", "ss_supportother", "ss_transportstudentjourneydetails", "overriddencreatedon", "ss_contactaddressline4", "ss_studentdetailssocialworker", "ss_transportroadsafety", "modifiedonbehalfby", "ss_freeschoolmealsentitlement", "ss_sendormedicalhassendormedicalneeds", "ss_contactaddressline2", "ss_studentdetailsaddressline3", "statecode", "ss_studentdetailshasdisabilitylivingallowance", "ss_transporttraveltraining", "timezoneruleversionnumber", "ss_studentdetailsaddresspostcode", "modifiedby", "ss_mobilitycantransfertoseatwhilsttravelling", "ss_supportcalming", "ss_transportstartdate", "ss_transportharnessrequired", "ss_groundsforapplication", "ss_contactaddresspostcode", "ss_studentdetailslivesatdifferentaddress", "ss_transporthasownvehicle", "createdby", "utcconversiontimezonecode", "ss_contactemail", "ss_documentviewercontrol", "ss_mobilitydetails", "ss_transportremoveseatbelt", "importsequencenumber", "ss_educationwhynotnearestschool", "ss_educationnearestschoolcollege", "ss_contactrelationship", "ss_otherdetails", "ss_seizuressigns", "ss_studentdetailsincare", "ss_educationcoursetitle", "ss_educationschooladmittancedate", "ss_studentdetailsaddressline1", "ss_mobilityequipment", "ss_educationehcpfinaliseddate", "ss_maximumtaxcredits", "ss_contactaddressline1", "ss_sendormedicaldetails", "ss_transportseattype", "ss_transportseatdetails", "ss_studentdetailsaddressline4", "ss_educationhoursperweek", "ss_seizureshasseizures", "ss_mobilityequipmentdimensions", "ss_contactaddressline3", "ss_mobilityhasissues", "ss_educationhasappliedforbursary", "ss_transportnosharedtransportdetails", "ss_transportwhynotfamilyorfriends", "ss_educationfirstyearofstudy", "statuscode", "ss_contacttitle", "ss_transport_medicationdetails", "ss_educationqualification", "ss_educationhasehcpplan", "ss_seizuresfrequency", "owningbusinessunit");

            //// Define filter query.Criteria
            //query.Criteria.AddCondition("ss_transportrequest_ss_emergencycontact", "ss_transportrequestid", ConditionOperator.Equal, query_ss_transportrequest_ss_emergencycontact_ss_transportrequestid);

            //// Add link-entity query_ss_transportrequest_ss_emergencycontact
            //var query_ss_transportrequest_ss_emergencycontact = query.AddLink("ss_transportrequest_ss_emergencycontact", "ss_transportrequestid", "ss_transportrequestid");

            //// Add link-entity ec
            //var ec = query_ss_transportrequest_ss_emergencycontact.AddLink("ss_emergencycontact", "ss_emergencycontactid", "ss_emergencycontactid");
            //ec.EntityAlias = "ec";

            //// Add columns to ec.Columns
            //ec.Columns.AddColumns("ss_relationship", "ss_name", "ss_email", "ss_phone");

            //var entityCollection = await client.RetrieveMultipleAsync(query);
            //var list = entityCollection.Entities.Select(entity => MapToTRDataverse(entity)).ToList();

            //return list;

        }

        //public  async Task<Guid>CreateNotewithAttachment(Guid id)

        // {
        //     ////Guid entityId, String entityType, String path, String mimeType
        //     //String fileName = Path.GetFileName(path); //load the attachment file from disk

        //     //Entity a = new Entity("annotation"); //we have to create an annotation

        //     //a.Attributes["objectid"] = new Lookup(entityType, entityId); //and attach to a record, e.g. contact
        //     //a.objecttypecode = new EntityNameReference(entityType);

        //     //a.subject = fileName;

        //     //a.filename = fileName; //the annotation has fields which contain the attachment information
        //     //a.mimetype = mimeType;
        //     //a.documentbody = Convert.ToBase64String(File.ReadAllBytes(path)); //crm like us to store attachments as base64 strings

        //     //return client.Create(a);

        //     string entitytype = "ss_transportrequest";
        //     Entity Note = new Entity("annotation");
        //     Guid EntityToAttachTo = id; // The GUID of the incident
        //     Note["objectid"] = new Microsoft.Xrm.Sdk.EntityReference(entitytype, EntityToAttachTo);
        //     Note["objecttypecode"] = entitytype;
        //     Note["subject"] = "Test Subject";
        //     Note["notetext"] = "Test note text";
        //     Note["filename"] = 
        //     Note["mimetype"] =
        //     Note["documentbody"] =
        //     return client.Create(Note);




        // }

        public async Task<List<TRReqModel>> GetListAsync(Guid TransportRequestId)
        {

            //var fetchXMLPendingCases = "<fetch version=\"1.0\" output-format=\"xml-platform\" mapping=\"logical\" distinct=\"false\">" +
            //                         "<entity name=\"incident\">" +
            //                         "<attribute name=\"title\" />" +
            //                         "<attribute name=\"ticketnumber\" />" +
            //                         "<attribute name=\"createdon\" />" +
            //                         "<attribute name=\"incidentid\" />" +
            //                         "<attribute name=\"caseorigincode\" />" +
            //                         "<order attribute=\"title\" descending=\"false\" />" +
            //                         "<filter type=\"and\">" +
            //                         filterSystems +
            //                         $"<condition attribute=\"createdon\" operator=\"last-x-days\" value=\"{numberOfDays}\" />" +
            //                         "</filter>" +
            //                         "</entity>" +
            //                         "</fetch>";



          //  var resultPendingCases = _service.RetrieveMultiple(new FetchExpression(fetchXMLPendingCases));

          //get transport data and emergency contact
            //////var entity1Name = "ss_emergencycontact";
            //////var relationshipEntityName = "ss_transportrequest_ss_emergencycontact";
            //////QueryExpression consultantsQuery = new QueryExpression()
            //////{
            //////    EntityName = entity1Name,
            //////    ColumnSet = new ColumnSet(true)
            //////};
            ////////consultantsQuery.AddOrder("fullname", OrderType.Ascending);
            //////LinkEntity linkEntity1 = new LinkEntity(entity1Name, relationshipEntityName, "ss_emergencycontactid", "ss_emergencycontactid", JoinOperator.LeftOuter);
            //////consultantsQuery.LinkEntities.Add(linkEntity1);
            //////FilterExpression projectFilter = new FilterExpression(LogicalOperator.And);
            //////projectFilter.Conditions.Add(new ConditionExpression("ss_transportrequestid", ConditionOperator.Equal, TransportRequestId));

            //////var entityCollection = await client.RetrieveMultipleAsync(consultantsQuery);
            //////var list = entityCollection.Entities.Select(entity => MapToEmergencyContact(entity)).ToList();
            //////return list;

            //var caseQuery = new QueryExpression
            //{
            //    EntityName = "ss_emergencycontact",
            //    ColumnSet = new ColumnSet(true)
            //};
            ////var active = 0;
            //FilterExpression filter = new FilterExpression();
            ////filter.AddCondition(new ConditionExpression("statecode", ConditionOperator.Equal, active));
            //filter.AddCondition(new ConditionExpression("customerid", ConditionOperator.Equal, TransportRequestId));
            //caseQuery.Criteria = filter;



            //var serviceClient = this.dataverseProvider.GetServiceClient();
            //var entityCollection = await serviceClient.RetrieveMultipleAsync(caseQuery);



            //var list = entityCollection.Entities.Select(entity => MapToCase(entity)).ToList();
            //return list;
            //List<EntityCollection> list = new List<EntityCollection>();
            // Query Account entity
            //  QueryExpression query = new QueryExpression();
            //  query.EntityName = "ss_transportrequest";
            //  query.ColumnSet = new ColumnSet(true);

            //EntityCollection results = await client.RetrieveMultipleAsync(query);

            // Query related Events for each Account
            //foreach (Entity item in results.Entities)
            //{
            //    QueryExpression childQuery = new QueryExpression();
            //    childQuery.EntityName = "ss_emergencycontact";
            //    childQuery.ColumnSet = new ColumnSet(true);
            //    childQuery.Criteria.AddCondition("ss_emergencycontactid", ConditionOperator.Equal, item.Attributes["ss_transportrequestid"]);
            //    list = await client.RetrieveMultipleAsync(childQuery);


            //}



            //return list;



            var queryEx = new QueryExpression
            {
                EntityName = "ss_transportrequest",
                ColumnSet = new ColumnSet(true),

            };

            var entityCollection = await serviceClient.RetrieveMultipleAsync(queryEx);
            var list = entityCollection.Entities.Select(entity => MapToTRDataverse(entity)).ToList();
            return list;
        }

        public async Task UpdateAsync(TRReqModel trnsReqModelData)
        {
            Entity lookupvalue = new Entity("ss_transportrequest");

            lookupvalue["ss_transportrequestid"] = trnsReqModelData.Id;

            lookupvalue["ss_contactfirstname"] = trnsReqModelData.ContactFirstName;
            lookupvalue["ss_contactlastname"] = trnsReqModelData.ContactLastName;
            lookupvalue["ss_contactemail"] = trnsReqModelData.ContactEmail;
            lookupvalue["ss_contactphone"] = trnsReqModelData.ContactPhone;
            lookupvalue["ss_contactaddressline1"] = trnsReqModelData.ContactAddressline1;
            lookupvalue["ss_contactaddressline2"] = trnsReqModelData.ContactAddressline2;
            lookupvalue["ss_contactaddressline3"] = trnsReqModelData.ContactAddressline3;
            lookupvalue["ss_contactaddressline4"] = trnsReqModelData.ContactAddressline4;
            lookupvalue["ss_contactaddresspostcode"] = trnsReqModelData.ContactAddressPostcode;
            lookupvalue["ss_contactrelationship"] = trnsReqModelData.ContactRelationship;

            lookupvalue["ss_contactrelationship"] = trnsReqModelData.CreatedOn;
            lookupvalue["ss_documentviewercontrol"] = trnsReqModelData.DocumentViewerControl;
            lookupvalue["ss_educationcoursetitle"] = trnsReqModelData.EducationCourseTitle;
            lookupvalue["ss_educationehcpfinaliseddate"] = trnsReqModelData.EducationEHCPFinalisedDate;
            lookupvalue["ss_educationfirstyearofstudy"] = trnsReqModelData.EducationFirstYearOfStudy;
            lookupvalue["ss_educationhasappliedforbursary"] = trnsReqModelData.EducationHasAppliedForBursary;
            lookupvalue["ss_educationnearestschoolcollege"] = trnsReqModelData.EducationNearestSchoolCollege;
            lookupvalue["ss_educationqualification"] = trnsReqModelData.EducationQualification;
            lookupvalue["ss_educationschooladmittancedate"] = trnsReqModelData.EducationSchoolAdmittanceDate;
            lookupvalue["ss_educationwhynotnearestschool"] = trnsReqModelData.EducationWhyNotNearestSchool;

 //lookup
            lookupvalue.Attributes["createdby"] = new EntityReference("createdby", new Guid(trnsReqModelData.CreatedBy));
            lookupvalue.Attributes["modifiedby"] = new EntityReference("modifiedby", new Guid(trnsReqModelData.ModifiedBy));
            lookupvalue.Attributes["owningbusinessunit"] = new EntityReference("owningbusinessunit", new Guid(trnsReqModelData.OwningBusinessUnit));
            lookupvalue.Attributes["owningteam"] = new EntityReference("owningteam", new Guid(trnsReqModelData.OwningTeam));
            lookupvalue.Attributes["owninguser"] = new EntityReference("owninguser", new Guid(trnsReqModelData.OwningUser));


            lookupvalue["importsequencenumber"] = trnsReqModelData.ImportSequenceNumber;
            lookupvalue["ss_maximumtaxcredits"] = trnsReqModelData.MaximumTaxCredits;
            lookupvalue["ss_mobilitycantransfertoseatwhilsttravelling"] = trnsReqModelData.MobilityCanTransferToSeatWhilstTravelling;
            lookupvalue["ss_mobilitydetails"] = trnsReqModelData.MobilityDetails;
            lookupvalue["ss_mobilityequipmentdimensions"] = trnsReqModelData.MobilityEquipmentDimensions;
            lookupvalue["ss_mobilityhasissues"] = trnsReqModelData.MobilityHasIssues;
            lookupvalue["modifiedon"] = trnsReqModelData.ModifiedOn;
            lookupvalue["ss_otherdetails"] = trnsReqModelData.OtherDetails;
            lookupvalue["overriddencreatedon"] = trnsReqModelData.OverriddenCreatedOn;

            lookupvalue["ss_seizuresfrequency"] = trnsReqModelData.SeizuresFrequency;
            lookupvalue["ss_seizureshasseizures"] = trnsReqModelData.SeizuresHasSeizures;
            lookupvalue["ss_seizuressigns"] = trnsReqModelData.SeizuresSigns;
            lookupvalue["ss_seizurestype"] = trnsReqModelData.SeizuresType;
            lookupvalue["ss_sendormedicaldetails"] = trnsReqModelData.SendOrMedicalDetails;
            lookupvalue["ss_sendormedicalhassendormedicalneeds"] = trnsReqModelData.SendOrMedicalHasSendOrMedicalNeeds;
            lookupvalue["ss_studentdetailsaddressline1"] = trnsReqModelData.StudentDetailsAddressLine1;
            lookupvalue["ss_studentdetailsaddressline2"] = trnsReqModelData.StudentDetailsAddressLine2;
            lookupvalue["ss_studentdetailsaddressline3"] = trnsReqModelData.StudentDetailsAddressLine3;
            lookupvalue["ss_studentdetailsaddressline4"] = trnsReqModelData.StudentDetailsAddressLine4;
            lookupvalue["ss_studentdetailsaddresspostcode"] = trnsReqModelData.StudentDetailsAddressPostcode;
            lookupvalue["ss_studentdetailshasdisabilitylivingallowance"] = trnsReqModelData.StudentDetailsHasDisabilityLivingAllowance;
            lookupvalue["ss_studentdetailsincare"] = trnsReqModelData.StudentDetailsInCare;
            lookupvalue["ss_studentdetailslivesatdifferentaddress"] = trnsReqModelData.StudentDetailsLivesAtDifferentAddress;
            lookupvalue["ss_studentdetailssocialworker"] = trnsReqModelData.StudentDetailsSocialWorker;
            lookupvalue["ss_supportcalming"] = trnsReqModelData.SupportCalming;

            lookupvalue["ss_supportother"] = trnsReqModelData.SupportOther;
            lookupvalue["timezoneruleversionnumber"] = trnsReqModelData.TimeZoneRuleVersionNumber;
            lookupvalue["ss_transportharnessrequired"] = trnsReqModelData.TransportHarnessRequired;
            lookupvalue["ss_transporthasownvehicle"] = trnsReqModelData.TransportHasOwnVehicle;
            lookupvalue["ss_transportnosharedtransportdetails"] = trnsReqModelData.TransportNoSharedTransportDetails;
            lookupvalue["ss_transportremoveseatbelt"] = trnsReqModelData.TransportRemoveSeatBelt;
            lookupvalue["ss_transportrequestnumber"] = trnsReqModelData.TransportRequestNumber;
            lookupvalue["ss_transportroadsafety"] = trnsReqModelData.TransportRoadSafety;
            lookupvalue["ss_transportseatdetails"] = trnsReqModelData.TransportSeatDetails;
            lookupvalue["ss_transportstartdate"] = trnsReqModelData.TransportStartDate;
            lookupvalue["ss_transportstudentjourneydetails"] = trnsReqModelData.TransportStudentJourneyDetails;
            lookupvalue["ss_transporttraveltraining"] = trnsReqModelData.TransportTravelTraining;
            lookupvalue["ss_transportwhynotfamilyorfriends"] = trnsReqModelData.TransportWhyNotFamilyOrFriends;
            lookupvalue["ss_transport_hastransportmedication"] = trnsReqModelData.Transport_HasTransportMedication;
            lookupvalue["ss_transport_medicationdetails"] = trnsReqModelData.Transport_MedicationDetails;
            lookupvalue["utcconversiontimezonecode"] = trnsReqModelData.UTCConversionTimeZoneCode;
            lookupvalue["versionnumber"] = trnsReqModelData.VersionNumber;

            try
            {

                await serviceClient.UpdateAsync(lookupvalue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }           
    }
}
