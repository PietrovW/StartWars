using Newtonsoft.Json;
using StartWars.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StartWars.Tools
{

    public class GetUri<T>
    {
        private static HttpClient client;

        static GetUri()
        {
            client = new HttpClient();
        }

        private static  HttpResponseMessage Request(Uri url)
        {
          
            return  client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).Result;
        }

        public static async Task<RestResult<T>> ResponsAsync(Uri url)
        {

            try
            {
                HttpResponseMessage httpResponseMessage =  Request(url);
                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    string content = await httpResponseMessage.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RestResult<T>>(content);
                 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

            return null;
        }
        
    }
}
