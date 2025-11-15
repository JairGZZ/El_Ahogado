namespace El_Ahogado.Server.services
{
    using El_Ahogado.Server.models;
    using System;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ApiService
    {
        private readonly HttpClient _httpClient;
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetRandomWordAsync(int? minLength = null,int? maxLength = null)
        {
            string url = "https://rae-api.com/api/random";


            if (minLength.HasValue || maxLength.HasValue)
            {
                url += "?";
                if (minLength.HasValue)
                {
                    url += $"min_length={minLength.Value}&";
                }
                if (maxLength.HasValue)
                {
                    url += $"max_length={maxLength.Value}&";
                }
                url = url.TrimEnd('&');
            }

            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            Console.WriteLine(json);

            var apiResponse = JsonSerializer.Deserialize<WordApiResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return apiResponse.Data.Word;
        }
    }
}
