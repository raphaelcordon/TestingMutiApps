using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebMVC.Models;

namespace WebMVC.Services
{
	public class UserApi
	{
		string baseUrl = "https://localhost:7148";
        public UserApi()
        {
            
        }

        public async Task<IList<ReadUserFromApi>> GetAllUsers()
		{
			IList<ReadUserFromApi> user = new List<ReadUserFromApi>();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage getData = await client.GetAsync("User");

				if (getData.IsSuccessStatusCode)
				{
					string results = getData.Content.ReadAsStringAsync().Result;
					user = JsonConvert.DeserializeObject<List<ReadUserFromApi>>(results);
				}
				else
				{
					Console.WriteLine("Error calling web Api");
				}
			}
			return (IList<ReadUserFromApi>)Task.FromResult(user);
		}
    }
}
