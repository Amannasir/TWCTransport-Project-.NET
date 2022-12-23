using TWCTransport.Model;

namespace TWCTransport.Business
{
    public interface ITransportRequestManager
    {

        Task<TRReqModel> GetTransportRequestByIdAsync(Guid id);
        Task<List<TRReqModel>> GetListAsync(Guid TransportRequestId);
 
        Task UpdateAsync(TRReqModel trnsReqModelData);
        Task DeleteAsync(Guid id);
        Task<TRReqModel> CreateAsync(TRReqModel trnsReqModelData);
        Task<TRReqModel> CreateEmergencyContact(TRReqModel trnsReqModelData);
    }
}
