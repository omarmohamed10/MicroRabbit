using MicroRabbit.MVC.Models.DTOs;
using Newtonsoft.Json;
using System.Text;
namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _httpClient;
        public TransferService( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Transfer(TransferDto transferDto)
        {
            var url = "https://localhost:7265/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto),
                                           Encoding.UTF8 , "application/json" );
            var response = await _httpClient.PostAsync(url, transferContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
