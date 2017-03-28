using AllPointsTransport.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AllPointsTransport.Common
{
    public static class WebApiManager
    {
        static HttpClient client;

        static WebApiManager()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Config.WebApiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static T GetRequest<T>(string uri)
        {
            HttpResponseMessage httpResponseMessage = client.GetAsync(uri).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var result = httpResponseMessage.Content.ReadAsAsync<T>().Result;
                return result;
            }
            return default(T);
        }

        public static bool PostRequest<T>(this T t, string uri)
        {
            HttpResponseMessage httpResponseMessage = client.PostAsJsonAsync<T>(uri, t).Result;
            return httpResponseMessage.IsSuccessStatusCode;
        }

        public static bool DeleteRequest(string uri, int id)
        {
            HttpResponseMessage httpResponseMessage = client.DeleteAsync(uri).Result;
            return httpResponseMessage.IsSuccessStatusCode;
        }
    }
}