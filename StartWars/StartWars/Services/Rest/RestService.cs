using Newtonsoft.Json;
using StartWars.Const;
using StartWars.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StartWars.Services.Rest
{
    public interface IRestService
    {
        Task<List<Film>> RefreshDataByFilmAsync();
        Task<List<People>> RefreshDataByPeopleAsync();
        Task<List<Planet>> RefreshDataByPlanetleAsync();
        Task<List<Specie>> RefreshDataBySpecieleAsync();
        Task<List<Version>> RefreshDataByVersionAsync();
    }
    public class RestService : IRestService
    {
        private HttpClient client;
        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }
        public async Task<List<Film>> RefreshDataByFilmAsync()
        {
            var Items = new List<Film>();

            // RestUrl = http://developer.xamarin.com:8081/api/todoitems
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Film>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }

        public Task<List<People>> RefreshDataByPeopleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Planet>> RefreshDataByPlanetleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Specie>> RefreshDataBySpecieleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Version>> RefreshDataByVersionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
