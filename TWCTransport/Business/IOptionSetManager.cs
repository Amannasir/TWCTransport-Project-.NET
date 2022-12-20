using TWCTransport.Model;

namespace TWCTransport.Business
{
    public interface IOptionSetManager
    {
        Task<OptionSetModel> GetByIdAsync(Guid id);
        Task<List<OptionSetModel>> GetListAsync(string entityName, string osName);
        Task UpdateAsync(OptionSetModel optionSetModelData);
        Task<OptionSetModel> CreateAsync(OptionSetModel detail);

    }
}
