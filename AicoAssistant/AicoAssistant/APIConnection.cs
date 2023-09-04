using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AicoAssistant
{
    class APIConnection
    {
        string apiKey;
        public APIConnection(string key)
        {
            this.apiKey = key;
        }

        public OpenAiApiClient Connect()
        {
            // Create an instance of the OpenAI API client
            OpenAiApiClient openAiApiClient = new OpenAiApiClient(apiKey);

            return openAiApiClient;
        }
    }

    class OpenAiApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAiApiClient(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<string> GenerateTextAsync(string prompt)
        {
            // API endpoint for text generation
            string apiUrl = "https://api.openai.com/v1/engines/davinci/completions";

            // Create the request payload
            var requestData = new
            {
                prompt = prompt,
                max_tokens = 50
            };

            // Serialize the data to JSON
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(requestData);

            // Create the request content
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Set the Authorization header
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            // Send the POST request
            HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);

            // Read the response content
            string responseContent = await response.Content.ReadAsStringAsync();

            // Return the generated text
            return responseContent;
        }
    }
}
