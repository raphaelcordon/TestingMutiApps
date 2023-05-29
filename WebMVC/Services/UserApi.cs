using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Services
{
	public class UserApi
	{
		string baseUrl = "https://localhost:7148/api/";
		HttpClient _httpClient = new HttpClient();

		public UserApi()
		{
			_httpClient.BaseAddress = new Uri(baseUrl);
			_httpClient.DefaultRequestHeaders.Accept.Clear();
			_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public async Task<IList<ReadUserApi>> GetAllUsers()
		{
			IList<ReadUserApi> user = new List<ReadUserApi>();

			HttpResponseMessage getData = await _httpClient.GetAsync("User");

			if (getData.IsSuccessStatusCode)
			{
				string results = getData.Content.ReadAsStringAsync().Result;
				user = JsonConvert.DeserializeObject<List<ReadUserApi>>(results);
			}
			else
			{
				Console.WriteLine("Error calling web Api");
			}
			return user;
		}

		public async Task DeleteUser(int id)
		{
			var uri = Path.Combine(baseUrl + "User" + "/" + Convert.ToString(id));

			HttpResponseMessage response = await _httpClient.DeleteAsync(uri);
			response.EnsureSuccessStatusCode();
		}

		public async Task CreateUser(CreateUserApi user)
		{
			var userSerialized = JsonConvert.SerializeObject(user);
			var requestContent = new StringContent(userSerialized, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await _httpClient.PostAsync("User", requestContent);
			response.EnsureSuccessStatusCode();
		}

		public async Task<UpdateUserApi> UpdateUser(int id)
		{
			UpdateUserApi user = new();
			HttpResponseMessage getData = await _httpClient.GetAsync($"User/{id}");

			if (getData.IsSuccessStatusCode)
			{
				string result = getData.Content.ReadAsStringAsync().Result;
				user = JsonConvert.DeserializeObject<UpdateUserApi>(result);
			}
			else
			{
				Console.WriteLine("Error calling web Api");
			};
			return user;
		}
		/*public async Task PostUpdateUser(UpdateUserApi user)
		{
			var userSerialized = JsonConvert.SerializeObject(user);
			var requestContent = new StringContent(userSerialized, Encoding.UTF8, "application/json");
			HttpResponseMessage response = await _httpClient.PostAsync("User", requestContent);
			response.EnsureSuccessStatusCode();
		}
		*/
	}
}
