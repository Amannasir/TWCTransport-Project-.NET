using TWCTransport.Model;

namespace TWCTransport.Business
{
    public interface ITransportRequestManager
    {
        Task<TransportRequest> GetTransportRequestByIdAsync(Guid id);
        Task<List<TransportRequest>> GetListAsync(); 
        Task UpdateAsync(TransportRequest transportRequest);
        Task DeleteAsync(Guid id);
        Task<TransportRequest> CreateAsync(TransportRequest transportRequest);
        Task<TransportRequest> CreateEmergencyContact(TransportRequest transportRequest);
    }
}
