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
        private static TransportRequest MapToTransportRequest_EmergencyContact(TransportRequest TransportRequest, List<EmergencyContact> EmergencyContacts)
        {
            var result = new TransportRequest_EmergencyContact();
            result.Id = TransportRequest.Id;

            result.EmergencyContactName1 = EmergencyContacts[0].Fullname;
            result.EmergencyContactEmail1 = EmergencyContacts[0].Email;
            result.EmergencyContactNumber1 = EmergencyContacts[0].Phone;
            result.EmergencyContactRelationship1 = EmergencyContacts[0].Relationship;

            result.EmergencyContactName2 = EmergencyContacts[1].Fullname;
            result.EmergencyContactEmail2 = EmergencyContacts[1].Email;
            result.EmergencyContactNumber2 = EmergencyContacts[1].Phone;
            result.EmergencyContactRelationship2 = EmergencyContacts[1].Relationship;

            result.ContactFirstName = TransportRequest.ContactFirstName;
            result.ContactLastName = TransportRequest.ContactLastName;
            result.ContactEmail = TransportRequest.ContactEmail;
            result.ContactPhone = TransportRequest.ContactPhone;
            result.ContactAddressline1 = TransportRequest.ContactAddressline1;
            result.ContactAddressline2 = TransportRequest.ContactAddressline2;
            result.ContactAddressline3 = TransportRequest.ContactAddressline3;
            result.ContactAddressline4 = TransportRequest.ContactAddressline4;
            result.ContactAddressPostcode = TransportRequest.ContactAddressPostcode;
            result.ContactRelationship = TransportRequest.ContactRelationship;

            result.CreatedOn = TransportRequest.CreatedOn;
            result.DocumentViewerControl = TransportRequest.DocumentViewerControl;
            result.EducationCourseTitle = TransportRequest.EducationCourseTitle;
            result.EducationEHCPFinalisedDate = TransportRequest.EducationEHCPFinalisedDate;//DateOnly
            result.EducationFirstYearOfStudy = TransportRequest.EducationFirstYearOfStudy;
            result.EducationHasAppliedForBursary = TransportRequest.EducationHasAppliedForBursary;
            result.EducationNearestSchoolCollege = TransportRequest.EducationNearestSchoolCollege;
            result.EducationQualification = TransportRequest.EducationQualification;
            result.EducationSchoolAdmittanceDate = TransportRequest.EducationSchoolAdmittanceDate;//DateOnly
            result.EducationWhyNotNearestSchool = TransportRequest.EducationWhyNotNearestSchool;
            result.FreeSchoolMealsEntitlement = TransportRequest.FreeSchoolMealsEntitlement;

            //result.ImportSequenceNumber = entity.GetAttributeValue<int>("importsequencenumber");
            result.MaximumTaxCredits = TransportRequest.MaximumTaxCredits;
            result.MobilityCanTransferToSeatWhilstTravelling = TransportRequest.MobilityCanTransferToSeatWhilstTravelling;
            result.MobilityDetails = TransportRequest.MobilityDetails;
            result.MobilityEquipmentDimensions = TransportRequest.MobilityEquipmentDimensions;
            result.MobilityHasIssues = TransportRequest.MobilityHasIssues;
            result.ModifiedOn = TransportRequest.ModifiedOn;
            result.OtherDetails = TransportRequest.OtherDetails;
            result.OverriddenCreatedOn = TransportRequest.OverriddenCreatedOn;//DateOnly

            result.SeizuresFrequency = TransportRequest.SeizuresFrequency;
            result.SeizuresHasSeizures = TransportRequest.SeizuresHasSeizures;
            result.SeizuresSigns = TransportRequest.SeizuresSigns;
            result.SeizuresType = TransportRequest.SeizuresType;
            result.SendOrMedicalDetails = TransportRequest.SendOrMedicalDetails;
            result.SendOrMedicalHasSendOrMedicalNeeds = TransportRequest.SendOrMedicalHasSendOrMedicalNeeds;
            result.StudentDetailsAddressLine1 = TransportRequest.StudentDetailsAddressLine1;
            result.StudentDetailsAddressLine2 = TransportRequest.StudentDetailsAddressLine2;
            result.StudentDetailsAddressLine3 = TransportRequest.StudentDetailsAddressLine3;
            result.StudentDetailsAddressLine4 = TransportRequest.StudentDetailsAddressLine4;
            result.StudentDetailsAddressPostcode = TransportRequest.StudentDetailsAddressPostcode;
            result.StudentDetailsHasDisabilityLivingAllowance = TransportRequest.StudentDetailsHasDisabilityLivingAllowance;
            result.StudentDetailsInCare = TransportRequest.StudentDetailsInCare;
            result.StudentDetailsLivesAtDifferentAddress = TransportRequest.StudentDetailsLivesAtDifferentAddress;
            result.StudentDetailsSocialWorker = TransportRequest.StudentDetailsSocialWorker;
            result.SupportCalming = TransportRequest.SupportCalming;

            result.SupportOther = TransportRequest.SupportOther;
            result.TimeZoneRuleVersionNumber = TransportRequest.TimeZoneRuleVersionNumber;
            result.TransportHarnessRequired = TransportRequest.TransportHarnessRequired;
            result.TransportHasOwnVehicle = TransportRequest.TransportHasOwnVehicle;
            result.TransportNoSharedTransportDetails = TransportRequest.TransportNoSharedTransportDetails;
            result.TransportRemoveSeatBelt = TransportRequest.TransportRemoveSeatBelt;
            result.TransportRequestNumber = TransportRequest.TransportRequestNumber;
            result.TransportRoadSafety = TransportRequest.TransportRoadSafety;
            result.TransportSeatDetails = TransportRequest.TransportSeatDetails;
            result.TransportStartDate = TransportRequest.TransportStartDate;//DateOnly
            result.TransportStudentJourneyDetails = TransportRequest.TransportStudentJourneyDetails;
            result.TransportTravelTraining = TransportRequest.TransportTravelTraining;
            result.TransportWhyNotFamilyOrFriends = TransportRequest.TransportWhyNotFamilyOrFriends;
            result.Transport_HasTransportMedication = TransportRequest.Transport_HasTransportMedication;
            result.Transport_MedicationDetails = TransportRequest.Transport_MedicationDetails;
            // result.UTCConversionTimeZoneCode = entity.GetAttributeValue<int>("utcconversiontimezonecode");
            // result.VersionNumber = entity.GetAttributeValue<int>("versionnumber");

            return result;
        }

        private async Task<Guid> CreateEmergencyContactAsync(TransportRequest_EmergencyContact transportRequest_emergencyContact, int type)
        {
            if (type < 1 || type > 2)
            {
                var entity = new Entity("ss_emergencycontact");

                entity["ss_name"] = type == 1 ? transportRequest_emergencyContact.EmergencyContactName1 : transportRequest_emergencyContact.EmergencyContactName2;
                entity["ss_email"] = type == 1 ? transportRequest_emergencyContact.EmergencyContactEmail1 : transportRequest_emergencyContact.EmergencyContactEmail2;
                entity["ss_phone"] = type == 1 ? transportRequest_emergencyContact.EmergencyContactNumber1 : transportRequest_emergencyContact.EmergencyContactNumber2;
                entity["ss_relationship"] = type == 1 ? transportRequest_emergencyContact.EmergencyContactRelationship1 : transportRequest_emergencyContact.EmergencyContactRelationship2;

                return await serviceClient.CreateAsync(entity);
            }
            //add exception message
            return new Guid();
        }
        private async Task<Guid> CreateTransportRequestAsync(TransportRequest_EmergencyContact transportRequest_emergencyContact)
        {
            //var demo = trnsReqModelData.demmofield; ;
            //var emergencycontactfirstName= trnsReqModelData.emergencycontactName1;
            //var emergencycontactEmail = trnsReqModelData.emergencycontactEmail1;
            //var emergencycontactNumber= trnsReqModelData.emergencycontactNumber1;
            //var emergencycontactfirstRelationship = trnsReqModelData.emergencycontactRelationship1;
            
            var entity = new Entity("ss_transportrequest");
            entity["ss_contacttitle"] = transportRequest_emergencyContact.ContactTitle;
            entity["ss_contactfirstname"] = transportRequest_emergencyContact.ContactFirstName;
            entity["ss_contactlastname"] = transportRequest_emergencyContact.ContactLastName;
            entity["ss_contactemail"] = transportRequest_emergencyContact.ContactEmail;
            entity["ss_contactphone"] = transportRequest_emergencyContact.ContactPhone;
            entity["ss_contactaddressline1"] = transportRequest_emergencyContact.ContactAddressline1;
            entity["ss_contactaddressline2"] = transportRequest_emergencyContact.ContactAddressline2;
            entity["ss_contactaddressline3"] = transportRequest_emergencyContact.ContactAddressline3;
            entity["ss_contactaddressline4"] = transportRequest_emergencyContact.ContactAddressline4;
            entity["ss_contactaddresspostcode"] = transportRequest_emergencyContact.ContactAddressPostcode;
            entity["ss_contactrelationship"] = transportRequest_emergencyContact.ContactRelationship;

            entity["ss_documentviewercontrol"] = transportRequest_emergencyContact.DocumentViewerControl;
            entity["ss_educationcoursetitle"] = transportRequest_emergencyContact.EducationCourseTitle;
            entity["ss_educationehcpfinaliseddate"] = transportRequest_emergencyContact.EducationEHCPFinalisedDate;
            entity["ss_educationfirstyearofstudy"] = transportRequest_emergencyContact.EducationFirstYearOfStudy;
            entity["ss_educationhasappliedforbursary"] = transportRequest_emergencyContact.EducationHasAppliedForBursary;
            entity["ss_educationnearestschoolcollege"] = transportRequest_emergencyContact.EducationNearestSchoolCollege;
            entity["ss_educationqualification"] = transportRequest_emergencyContact.EducationQualification;
            entity["ss_educationschooladmittancedate"] = transportRequest_emergencyContact.EducationSchoolAdmittanceDate;
            entity["ss_educationwhynotnearestschool"] = transportRequest_emergencyContact.EducationWhyNotNearestSchool;

            entity["importsequencenumber"] = transportRequest_emergencyContact.ImportSequenceNumber;
            entity["ss_maximumtaxcredits"] = transportRequest_emergencyContact.MaximumTaxCredits;
            entity["ss_mobilitycantransfertoseatwhilsttravelling"] = transportRequest_emergencyContact.MobilityCanTransferToSeatWhilstTravelling;
            entity["ss_mobilitydetails"] = transportRequest_emergencyContact.MobilityDetails;
            entity["ss_mobilityequipmentdimensions"] = transportRequest_emergencyContact.MobilityEquipmentDimensions;
            entity["ss_mobilityhasissues"] = transportRequest_emergencyContact.MobilityHasIssues;
            entity["modifiedon"] = transportRequest_emergencyContact.ModifiedOn;
            entity["ss_otherdetails"] = transportRequest_emergencyContact.OtherDetails;
            entity["overriddencreatedon"] = transportRequest_emergencyContact.OverriddenCreatedOn;

            entity["ss_seizuresfrequency"] = transportRequest_emergencyContact.SeizuresFrequency;
            entity["ss_seizureshasseizures"] = transportRequest_emergencyContact.SeizuresHasSeizures;
            entity["ss_seizuressigns"] = transportRequest_emergencyContact.SeizuresSigns;
            entity["ss_seizurestype"] = transportRequest_emergencyContact.SeizuresType;
            entity["ss_sendormedicaldetails"] = transportRequest_emergencyContact.SendOrMedicalDetails;
            entity["ss_sendormedicalhassendormedicalneeds"] = transportRequest_emergencyContact.SendOrMedicalHasSendOrMedicalNeeds;
            entity["ss_studentdetailsaddressline1"] = transportRequest_emergencyContact.StudentDetailsAddressLine1;
            entity["ss_studentdetailsaddressline2"] = transportRequest_emergencyContact.StudentDetailsAddressLine2;
            entity["ss_studentdetailsaddressline3"] = transportRequest_emergencyContact.StudentDetailsAddressLine3;
            entity["ss_studentdetailsaddressline4"] = transportRequest_emergencyContact.StudentDetailsAddressLine4;
            entity["ss_studentdetailsaddresspostcode"] = transportRequest_emergencyContact.StudentDetailsAddressPostcode;
            entity["ss_studentdetailshasdisabilitylivingallowance"] = transportRequest_emergencyContact.StudentDetailsHasDisabilityLivingAllowance;
            entity["ss_studentdetailsincare"] = transportRequest_emergencyContact.StudentDetailsInCare;
            entity["ss_studentdetailslivesatdifferentaddress"] = transportRequest_emergencyContact.StudentDetailsLivesAtDifferentAddress;
            entity["ss_studentdetailssocialworker"] = transportRequest_emergencyContact.StudentDetailsSocialWorker;
            entity["ss_supportcalming"] = transportRequest_emergencyContact.SupportCalming;

            entity["ss_supportother"] = transportRequest_emergencyContact.SupportOther;
            entity["timezoneruleversionnumber"] = transportRequest_emergencyContact.TimeZoneRuleVersionNumber;
            entity["ss_transportharnessrequired"] = transportRequest_emergencyContact.TransportHarnessRequired;
            entity["ss_transporthasownvehicle"] = transportRequest_emergencyContact.TransportHasOwnVehicle;
            entity["ss_transportnosharedtransportdetails"] = transportRequest_emergencyContact.TransportNoSharedTransportDetails;
            entity["ss_transportremoveseatbelt"] = transportRequest_emergencyContact.TransportRemoveSeatBelt;
            entity["ss_transportrequestnumber"] = transportRequest_emergencyContact.TransportRequestNumber;
            entity["ss_transportroadsafety"] = transportRequest_emergencyContact.TransportRoadSafety;
            entity["ss_transportseatdetails"] = transportRequest_emergencyContact.TransportSeatDetails;
            entity["ss_transportstartdate"] = transportRequest_emergencyContact.TransportStartDate;
            entity["ss_transportstudentjourneydetails"] = transportRequest_emergencyContact.TransportStudentJourneyDetails;
            entity["ss_transporttraveltraining"] = transportRequest_emergencyContact.TransportTravelTraining;
            entity["ss_transportwhynotfamilyorfriends"] = transportRequest_emergencyContact.TransportWhyNotFamilyOrFriends;
            entity["ss_transport_hastransportmedication"] = transportRequest_emergencyContact.Transport_HasTransportMedication;
            entity["ss_transport_medicationdetails"] = transportRequest_emergencyContact.Transport_MedicationDetails;
            entity["utcconversiontimezonecode"] = transportRequest_emergencyContact.UTCConversionTimeZoneCode;
            entity["versionnumber"] = transportRequest_emergencyContact.VersionNumber;

            return await serviceClient.CreateAsync(entity);
        }

        public async Task AssociateTransportRequestToEmergencyContacts(TransportRequest_EmergencyContact transportRequest_emergencyContact)
        {
            var emergencyContact1Id = await CreateEmergencyContactAsync(transportRequest_emergencyContact, 1);
            var emergencyContact2Id = await CreateEmergencyContactAsync(transportRequest_emergencyContact, 2);

            var transportRequestId = await CreateTransportRequestAsync(transportRequest_emergencyContact);

            var query = new QueryExpression("ss_emergencycontact")
            {
                ColumnSet = new ColumnSet("");
            }
            var emergencyContactReferences = new EntityReferenceCollection();
        }

        //public async Task Get_ContactTitle()
        //{
        //    //stringmap.
        //    //opbject type code 
        //    //attribute name 
        //    await client.DeleteAsync("ss_transportrequest", id);
        //}


        public async Task<TransportRequest> GetTransportRequestByIdAsync(Guid id)
        {
            var entity = serviceClient.Retrieve("ss_transportrequest", id, new ColumnSet(true));
            var TransportRequest = Utility.MapToTransportRequest(entity);

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
            var EmergencyContacts = entityCollection.Entities.Select(entity => Utility.MapToEmergencyContact(entity)).ToList();

            var result = MapToTransportRequest_EmergencyContact(TransportRequest, EmergencyContacts);
            return result;
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
        public async Task<List<TransportRequest>> GetListAsync()
        {
            var query = new QueryExpression
            {
                EntityName = "ss_transportrequest",
                ColumnSet = new ColumnSet(true)
            };

            var entityCollection = await serviceClient.RetrieveMultipleAsync(query);
            var list = entityCollection.Entities.Select(entity => Utility.MapToTransportRequest(entity)).ToList();
            return list;
        }
        public async Task UpdateAsync(TransportRequest trnsReqModelData)
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
        public async Task DeleteAsync(Guid id)
        {
            await serviceClient.DeleteAsync("ss_transportrequest", id);
        }
    }
}
