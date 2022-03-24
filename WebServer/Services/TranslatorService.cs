using Microsoft.Extensions.Options;
using WebServer.Options;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace WebServer.Services
{
    public class TranslatorService
    {
        private readonly AzureTranslatorOptions azureTranslatorOptions;
        public TranslatorService(IOptions<AzureTranslatorOptions> azureTranslatorOptions)
        {
            this.azureTranslatorOptions = azureTranslatorOptions.Value;
        }

        public async Task<string> TranslateToEnglisch(string textToTranslate)
        {
            string route = "/translate?api-version=3.0&from=en&to=de&to=it";
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonSerializer.Serialize(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(azureTranslatorOptions.Endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", azureTranslatorOptions.APIKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", azureTranslatorOptions.Location);

                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
