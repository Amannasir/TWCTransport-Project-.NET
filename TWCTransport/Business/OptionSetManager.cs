using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using TWCTransport.Model;
using TWCTransport.Provider;

namespace TWCTransport.Business
{
    public class OptionSetManager : IOptionSetManager
    {
        readonly ServiceClient client;
        readonly IDataverseProvider dataverseProvider;
        public OptionSetManager(IDataverseProvider dataverseProvider)
        {
            this.dataverseProvider = dataverseProvider;
            this.client = this.dataverseProvider.GetServiceClient();
        }
        private static OptionSet MapToTRDataverse(Entity entity)
        {
            var result = new OptionSet();
           result.AttributeValue = entity.GetAttributeValue<OptionSetValue>("ss_contacttitle").Value.ToString();
            result.AttributeName = entity.FormattedValues["ss_contacttitle"].ToString();
       
            //result.StringmapId = entity.GetAttributeValue<Guid>("stringmapid");
            //result.AttributeName = entity.GetAttributeValue<string>("attributename");
            //result.AttributeValue = entity.GetAttributeValue<string>("attributevalue");
            //result.ObjectCode = entity.GetAttributeValue<string>("objecttypecode");
            //result.OSValue = entity.GetAttributeValue<string>("value");
            return result;
        }

        public async Task<OptionSet> GetByIdAsync(Guid id)
        {
            var query = new QueryExpression
            {
                EntityName = "ss_transportrequest",   //table name
                ColumnSet = new ColumnSet(true),  //means get all columns

            };
            var entityCollection = await client.RetrieveMultipleAsync(query);//Get all records
                                                                             // var list = entityCollection.Entities.Select(entity => MapToLead(entity)).ToList(); //Getrecord from one by one from collection and MapToLead return model objects
                                                                             var entity = await client.RetrieveAsync("stringmap", id, new ColumnSet(true));
                                                                              var record = MapToTRDataverse(entity);

            return  record;
    
        }
        public List<OptionSet> GetAllOptionset(string entityName,string optionAttribute)
        {
            var items = new List<SelectListItem>();

                var request = new RetrieveAttributeRequest();

                request.EntityLogicalName = entityName;

                request.MetadataId = Guid.Empty;

                request.LogicalName = optionAttribute;

                request.RetrieveAsIfPublished = true;



                var response = client.Execute(request);



                List<OptionSet> resultlist = new List<OptionSet>();
                if (response != null && response.Results != null)

                {

                    foreach (KeyValuePair<string, object> param in response.Results)

                    {

                        string key = param.Key;

                        EnumAttributeMetadata metadata = (EnumAttributeMetadata)param.Value;


                        foreach (OptionMetadata option in metadata.OptionSet.Options)

                        {
                            OptionSet optionSet = new OptionSet();
                            optionSet.OptionSetname = entityName;
                            optionSet.AttributeValue = option.Value.ToString();
                            optionSet.AttributeName = option.Label.UserLocalizedLabel.Label.ToString();
                            resultlist.Add(optionSet);

                        }
                    }
                }

                return resultlist;
           
           
        }
        public async Task<List<OptionSet>> GetListAsync(string entityName, string osName)
        {
          
        
            //string entityName = "ss_transportrequest";
            List<OptionSet> contact_titleOptionsetList = GetAllOptionset(entityName, osName);
            //List<OptionSet> ceducation_schooltypeOptionsetList = GetAllOptionset(entityName, "ss_educationschooltype");
       
            return contact_titleOptionsetList;
        }

        public Task UpdateAsync(OptionSet OptionSetData)
        {
            throw new NotImplementedException();
       
        }


        public async Task<OptionSet> CreateAsync(OptionSet detail)
        {

            ///*var*/ entity = new Entity("ss_transportrequest");
            //// var bookAuthorLookup = entity.GetAttributeValue<EntityReference>("mgt_author");
            //entity["ss_contacttitle"] = detail.ContactTitle;

            ///detail.Id = await client.CreateAsync(entity);
            return detail;
        }










        }


}
