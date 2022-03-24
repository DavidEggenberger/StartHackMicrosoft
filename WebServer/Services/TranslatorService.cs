using Microsoft.Extensions.Options;
using WebServer.Options;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace WebServer.Services
{
    public class TranslatorService
    {
        private readonly IOptions<AzureTranslatorOptions> azureTranslatorOptions;
        public TranslatorService(IOptions<AzureTranslatorOptions> azureTranslatorOptions)
        {
            this.azureTranslatorOptions = azureTranslatorOptions;
        }

        public async Task<string> TranslateToEnglisch(string message)
        {
            string route = "/translate?api-version=3.0&from=en&to=de&to=it";
            string textToTranslate = "Hello, world!";
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConverter.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8 "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
