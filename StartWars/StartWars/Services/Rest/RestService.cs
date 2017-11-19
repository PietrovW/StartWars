using Newtonsoft.Json;
using StartWars.Const;
using StartWars.Data;
using StartWars.Models;
using StartWars.Pages;
using StartWars.Tools;
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
        Task<RestResult<Film>> RefreshDataByFilmAsync();
        Task<RestResult<Film>> GetFilmByTitleAsync(string title);
        Task<RestResult<People>> RefreshDataByPeopleAsync();
        Task<People> GetPeopleByNameAsync(string name);
        Task<RestResult<Planet>> RefreshDataByPlanetleAsync();
        Task<Planet> GetPlanetByNameAsync(string name);
        Task<RestResult<Specie>> RefreshDataBySpecieleAsync();
        Task<Specie> GetSpecieByNameAsync(string name);
        Task<RestResult<Version>> RefreshDataByVersionAsync();
        Task<Version> GetVersionByNameAsync(string name);
    }
    public class RestService : IRestService
    {
        private HttpClient client;
        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<RestResult<Film>> GetFilmByTitleAsync(string title)
        {
            var Items = new RestResult<Film>();
            var uri = new Uri(string.Format("{0}{1}/{2}",Constants.RestUrl, "films",title));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var repositories = JsonConvert.DeserializeObject<RestResult<Film>>(content);
                    Items = repositories;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
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

        public async Task<RestResult<Film>> RefreshDataByFilmAsync()
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "films/"));
            return await GetUri<Film>.ResponsAsync(uri);
        }

        public async Task<RestResult<People>> RefreshDataByPeopleAsync()
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "Peoples/"));
            return await GetUri<People>.ResponsAsync(uri);
        }

        public async Task<RestResult<Planet>> RefreshDataByPlanetleAsync()
        {
            var Items = new RestResult<Planet>();
            var uri = new Uri(string.Format(Constants.RestUrl, "Planetles"));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<RestResult<Planet>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task<RestResult<Specie>> RefreshDataBySpecieleAsync()
        {
            var Items = new RestResult<Specie>();
            var uri = new Uri(string.Format(Constants.RestUrl, "Specieles"));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<RestResult<Specie>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task<RestResult<Version>> RefreshDataByVersionAsync()
        {
            var Items = new RestResult<Version>();
            var uri = new Uri(string.Format(Constants.RestUrl, "Versions"));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<RestResult<Version>>(content);
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
