using System.Text.Json;

namespace AtlanticProductDesing.Infrastruture.HtpClientFactory
{
    public class HttpClientFactoryService //: IHttpClientServiceImplementation
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly IBlockchainServices _blockchainServices;
        private readonly JsonSerializerOptions _options;

        //public HttpClientFactoryService(IHttpClientFactory httpClientFactory, IBlockchainServices blockchainServices)
        //{
        //    _httpClientFactory = httpClientFactory;
        //    _blockchainServices = blockchainServices;

        //    _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        //}



        //public async Task Execute()
        //{
        //    //await GetCompaniesWithHttpClientFactory();
        //    await CreateWalletWithTypedClient();
        //}



        //private async Task CreateWalletWithTypedClient() => await _blockchainServices.CreateWallet(new Application.DTOs.WalletRequestDto());
    }
}
