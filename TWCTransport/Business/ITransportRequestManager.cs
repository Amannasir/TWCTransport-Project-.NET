using TWCTransport.Model;

namespace TWCTransport.Business
{
    public interface ITransportRequestManager
    {

        Task<TRReqModel> GetByIdAsync(Guid id);
        Task<List<TRReqModel>> GetListAsync();

        Task UpdateAsync(TRReqModel trnsReqModelData);
        Task DeleteAsync(Guid id);
        Task<TRReqModel> CreateAsync(TRReqModel trnsReqModelData);
    }
}
