using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using TWCTransport.Model;
using TWCTransport.Provider;

namespace TWCTransport.Business
{
    public class TransportRequestManager : ITransportRequestManager
    {
        readonly ServiceClient client;
        readonly IDataverseProvider dataverseProvider;
        public TransportRequestManager(IDataverseProvider dataverseProvider)
        {
            this.dataverseProvider = dataverseProvider;
            this.client = this.dataverseProvider.GetServiceClient();
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

            result.ImportSequenceNumber = entity.GetAttributeValue<int>("importsequencenumber");
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
            result.UTCConversionTimeZoneCode = entity.GetAttributeValue<int>("utcconversiontimezonecode");
            result.VersionNumber = entity.GetAttributeValue<int>("versionnumber");

            return result;
        }
        public async Task<TRReqModel> CreateAsync(TRReqModel trnsReqModelData)
        {

            var entity = new Entity("ss_transportrequest");
            // var bookAuthorLookup = entity.GetAttributeValue<EntityReference>("mgt_author");
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
            entity.Attributes["createdby"] = new EntityReference("createdby", new Guid(trnsReqModelData.CreatedBy));
            entity.Attributes["modifiedby"] = new EntityReference("modifiedby", new Guid(trnsReqModelData.ModifiedBy));
            entity.Attributes["owningbusinessunit"] = new EntityReference("owningbusinessunit", new Guid(trnsReqModelData.OwningBusinessUnit));
            entity.Attributes["owningteam"] = new EntityReference("owningteam", new Guid(trnsReqModelData.OwningTeam));
            entity.Attributes["owninguser"] = new EntityReference("owninguser", new Guid(trnsReqModelData.OwningUser));


            entity["createdon"] = trnsReqModelData.CreatedOn;
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

            trnsReqModelData.Id = await client.CreateAsync(entity);
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
            await client.DeleteAsync("ss_transportrequest", id);
        }

        public async Task<TRReqModel> GetByIdAsync(Guid id)
        {
            var entity = await client.RetrieveAsync("ss_transportrequest", id, new ColumnSet(true));
            var record = MapToTRDataverse(entity);

            return record;
        }

        public async Task<List<TRReqModel>> GetListAsync()
        {
            var query = new QueryExpression
            {
                EntityName = "ss_transportrequest",
                ColumnSet = new ColumnSet(true),

            };

            var entityCollection = await client.RetrieveMultipleAsync(query);
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

                await client.UpdateAsync(lookupvalue);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

      
       

    }
}
