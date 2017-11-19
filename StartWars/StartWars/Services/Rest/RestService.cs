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

        public async Task<RestResult<Film>> GetFilmByTitleAsync(string title)
        {
            var uri = new Uri(string.Format("{0}{1}/{2}", Constants.RestUrl, "films", title));
            return await GetUri<Film>.ResponsAsync(uri);
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
            var uri = new Uri(string.Format(Constants.RestUrl, "Planetles"));
            return await GetUri<Planet>.ResponsAsync(uri);
        }

        public async Task<RestResult<Specie>> RefreshDataBySpecieleAsync()
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "Specieles"));
            return await GetUri<Specie>.ResponsAsync(uri);
        }

        public async Task<RestResult<Version>> RefreshDataByVersionAsync()
        {
            var uri = new Uri(string.Format(Constants.RestUrl, "Versions"));
            return await GetUri<Version>.ResponsAsync(uri);
        }
    }
}
