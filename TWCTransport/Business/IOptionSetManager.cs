using TWCTransport.Model;

namespace TWCTransport.Business
{
    public interface IOptionSetManager
    {
        Task<OptionSet> GetByIdAsync(Guid id);
        Task<List<OptionSet>> GetListAsync(string entityName, string osName);
        Task UpdateAsync(OptionSet OptionSetData);
        Task<OptionSet> CreateAsync(OptionSet detail);

    }
}
