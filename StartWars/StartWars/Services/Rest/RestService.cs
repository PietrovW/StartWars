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
        Task<Film> GetFilmByTitleAsync(string title);
        Task<List<People>> RefreshDataByPeopleAsync();
        Task<People> GetPeopleByNameAsync(string name);
        Task<List<Planet>> RefreshDataByPlanetleAsync();
        Task<Planet> GetPlanetByNameAsync(string name);
        Task<List<Specie>> RefreshDataBySpecieleAsync();
        Task<Specie> GetSpecieByNameAsync(string name);
        Task<List<Version>> RefreshDataByVersionAsync();
        Task<Version> GetVersionByNameAsync(string name);
    }
    public class RestService : IRestService
    {
        private HttpClient client;
        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public Task<Film> GetFilmByTitleAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task<People> GetPeopleByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Planet> GetPlanetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Specie> GetSpecieByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Version> GetVersionByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Film>> RefreshDataByFilmAsync()
        {
            var Items = new List<Film>();
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

        public async Task<List<People>> RefreshDataByPeopleAsync()
        {
            var Items = new List<People>();
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<People>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task<List<Planet>> RefreshDataByPlanetleAsync()
        {
            var Items = new List<Planet>();
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Planet>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task<List<Specie>> RefreshDataBySpecieleAsync()
        {
            var Items = new List<Specie>();
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Specie>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task<List<Version>> RefreshDataByVersionAsync()
        {
            var Items = new List<Version>();
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Version>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }
    }
}
