using System.Text.Json;
using BookLibrary.Models.Entities;

namespace BookLibrary.Services
{
    public class BookApiService
    {
        private readonly HttpClient httpClient;

        public BookApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<BookInfo>> GetBooks()
        {
            string url = "https://www.googleapis.com/books/v1/volumes";
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode) {
                return new List<BookInfo>();
            }

            var jsonString = await response.Content.ReadAsStreamAsync();
            
            //case sensitive
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            //deserializing from json to object
            var result = await JsonSerializer.DeserializeAsync<BookApiModel>(jsonString, options);

            return result?.Items ?? new List<BookInfo>();
            
        }
    }
}
