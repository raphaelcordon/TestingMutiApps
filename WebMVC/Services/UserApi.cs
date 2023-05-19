using Newtonsoft.Json;
using System.Collections;
using System.Data;
using System.Net.Http.Headers;

namespace WebMVC.Services
{
	public class UserApi
	{
		string baseUrl = "https://localhost:7148";
        public UserApi()
        {
            
        }

        public async Task<DataTable?> GetAllUsers()
		{
			DataTable dt = new DataTable();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseUrl);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage getData = await client.GetAsync("User");

				if (getData.IsSuccessStatusCode)
				{
					string results = getData.Content.ReadAsStringAsync().Result;
					dt = JsonConvert.DeserializeObject<DataTable>(results);
				}
				else
				{
					Console.WriteLine("Error calling web Api");
				}
			}
            return dt;
		}
    }
}
