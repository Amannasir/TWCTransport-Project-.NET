namespace TWCTransport.Provider
{
    using Microsoft.PowerPlatform.Dataverse.Client;
    public interface IDataverseProvider
    {
        ServiceClient GetServiceClient();
    }
}
