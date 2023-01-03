using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TWCTransport.Business;
using TWCTransport.Model;

namespace TWCTransport.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class TransportRequestController : ControllerBase
    {
        readonly ITransportRequestManager transportRequestManager;
        readonly IOptionSetManager OptionSetManager;

        public TransportRequestController(ITransportRequestManager transportRequestManager, IOptionSetManager optionSetManager)
        {
            this.transportRequestManager = transportRequestManager;
            OptionSetManager = optionSetManager;
        }

        [HttpGet("{id}")]
        public async Task<TransportRequest> GetTransportRequestByIdAsync([FromRoute] Guid id)
        {
            return await this.transportRequestManager.GetTransportRequestByIdAsync(id);
        }
            

        //[HttpGet("{TransportRequestId}")]
        //public async Task<List<EmergencyContact>> GetEmergencyContactListAsync([FromRoute] Guid TransportRequestId) => await this.transportRequestManager.GetListAsync(TransportRequestId);

        [HttpGet("AllOptionset/{entityName}/{osName}")]
        public async Task<List<OptionSet>> GetOptionSetListAsync(string entityName, string osName) => await this.OptionSetManager.GetListAsync( entityName, osName);

        // POST api/<ResversationController>
        [HttpPut("{id}")]
        public async Task UpdateAsync([FromBody] TransportRequest detail) => await this.transportRequestManager.UpdateAsync(detail);

        [HttpDelete("{id}")]
        public async Task Deleteasync([FromRoute] Guid id) => await this.transportRequestManager.DeleteAsync(id);

        [HttpPost("op")]
        public async Task<OptionSet> CreateOptionsetAsync([FromBody] OptionSet detail)
        {

            return await this.OptionSetManager.CreateAsync(detail);
        }
        [HttpPost]
        public async Task<TransportRequest> CreateAsync(TransportRequest detail)
        {

            return await this.transportRequestManager.CreateAsync(detail);
        }

    }
}
