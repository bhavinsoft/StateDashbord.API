using StateDashbord.Application.IRepository;
using StateDashbord.Application.Model;
using StateDashbord.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StateDashbord.Infrastructure.Repository
{
    public class FetchFriDetails : IFetchFriDetails
    {

        private readonly HttpClient _httpClient;
        public FetchFriDetails(HttpClient httpClient)
        {
            _httpClient = httpClient;


        }
        public async Task<FRIDetailDto> FetchFriFromApi(FriRequest friRequest)
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(60));
            string responseFromServer = "";

            try
            {

                // Set up a cancellation token with a 30-second timeout

                using var httpClient = new HttpClient();

                // JSON payload


                // Serialize the payload to JSON
                var jsonContent = new StringContent(JsonSerializer.Serialize(friRequest), Encoding.UTF8, "application/json");

                // Add headers
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Add("Accept", "application/json");


                // Send the HTTP POST request
                HttpResponseMessage response = await httpClient.PostAsync("http://egujcop.gujarat.gov.in:7004/hdiits/rest/SCRBWebService/getFIRDetailsForNirbhaya", jsonContent, cts.Token);
                response.EnsureSuccessStatusCode();

                // await Task.Delay(TimeSpan.FromSeconds(70));


                // Read and process the response
                var content = await response.Content.ReadAsStringAsync(cts.Token);
                var movieList = JsonSerializer.Deserialize<FRIDetailDto>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Allows first_name to match FirstName
                });
                return movieList ?? new FRIDetailDto();
            }
            catch (TaskCanceledException ex) when (!cts.Token.IsCancellationRequested)
            {

                Console.WriteLine("The request timed out.");
                return new FRIDetailDto();

            }
            catch (Exception ex)
            {

                Console.WriteLine($"An error occurred: {ex.Message}");
                return new FRIDetailDto();

            }

        }
    }
}
