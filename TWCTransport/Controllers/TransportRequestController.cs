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
        public async Task<TRReqModel> GetTransportRequestByIdAsync([FromRoute] Guid id) => await this.transportRequestManager.GetTransportRequestByIdAsync(id);

        //[HttpGet("{TransportRequestId}")]
        //public async Task<List<EmergencyContact>> GetEmergencyContactListAsync([FromRoute] Guid TransportRequestId) => await this.transportRequestManager.GetListAsync(TransportRequestId);

        [HttpGet("AllOptionset/{entityName}/{osName}")]
        public async Task<List<OptionSetModel>> GetOptionSetListAsync(string entityName, string osName) => await this.OptionSetManager.GetListAsync( entityName, osName);

        // POST api/<ResversationController>
        [HttpPut("{id}")]
        public async Task UpdateAsync([FromBody] TRReqModel detail) => await this.transportRequestManager.UpdateAsync(detail);

        [HttpDelete("{id}")]
        public async Task Deleteasync([FromRoute] Guid id) => await this.transportRequestManager.DeleteAsync(id);

        [HttpPost("op")]
        public async Task<OptionSetModel> CreateOptionsetAsync([FromBody] OptionSetModel detail)
        {

            return await this.OptionSetManager.CreateAsync(detail);
        }
        [HttpPost]
        public async Task<TRReqModel> CreateAsync(TRReqModel detail)
        {

            return await this.transportRequestManager.CreateAsync(detail);
        }

    }
}
