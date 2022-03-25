using Microsoft.Extensions.Options;
using WebServer.Options;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Collections.Generic;

namespace WebServer.Services
{
    public class TranslatorService
    {
        private readonly AzureTranslatorOptions azureTranslatorOptions;
        public TranslatorService(IOptions<AzureTranslatorOptions> azureTranslatorOptions)
        {
            this.azureTranslatorOptions = azureTranslatorOptions.Value;
        }

        public async Task<string> TranslateToEnglisch(string textToTranslate, string fromLanguage)
        {
            string route = $"/translate?api-version=3.0&from={fromLanguage}&to=en";
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
                string s = await response.Content.ReadAsStringAsync();
                List<Root> root = JsonSerializer.Deserialize<List<Root>>(s, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IncludeFields = true });
                return String.Join(" ", root.SelectMany(s => s.Translations).Select(s => s.Text));
            }
        }
        public async Task<string> Translate(string textToTranslate, string fromLanguage, string toLanguage)
        {
            if(toLanguage == "ch-DE")
            {
                toLanguage = "DE";
            }
            string route = $"/translate?api-version=3.0&from={fromLanguage}&to={toLanguage}";
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
                string s = await response.Content.ReadAsStringAsync();
                List<Root> root = JsonSerializer.Deserialize<List<Root>>(s, new JsonSerializerOptions { PropertyNameCaseInsensitive = true, IncludeFields = true });
                return String.Join(" ", root.SelectMany(s => s.Translations).Select(s => s.Text));
            }
        }
    }
    public class Translation
    {
        public string Text { get; set; }
        public string To { get; set; }
    }

    public class Root
    {
        public List<Translation> Translations { get; set; }
    }
}
