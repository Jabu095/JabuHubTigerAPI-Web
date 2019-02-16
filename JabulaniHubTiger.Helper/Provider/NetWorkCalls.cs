using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JabulaniHubTiger.Helper.Provider
{
    public class NetWorkCalls<T>
    {
        /// <summary>
        /// Gets the list of objects.
        /// </summary>
        /// <param name="urlParam">The URL parameter.</param>
        /// <returns></returns>
        public async Task<T> GET(string urlParam, string token = null)
        {
            using (var client = new HttpClient())
            {

                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Add("Authorization", token);
                var response = await client.GetAsync(urlParam);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
                throw new HttpException(response.StatusCode, responseBody);
            }
        }

        /// <summary>
        /// Posts the specified object.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="jsonData">The json data.</param>
        /// <returns></returns>
        public async Task<T> POST(string url, string jsonData, string token = null)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Add("Authorization", token);
                var response = await client.PostAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"));
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
                throw new HttpException(response.StatusCode, responseBody);
            }

        }

        public async Task<T> PUT(string url, string jsonData, string token = null)
        {
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Add("Authorization", token);
                var response = await client.PutAsync(url, new StringContent(jsonData, Encoding.UTF8, "application/json"));
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
                throw new HttpException(response.StatusCode, responseBody);
            }

        }

        public async Task<T> DELETE(string urlParam, string token = null)
        {
            using (var client = new HttpClient())
            {

                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Add("Authorization", token);
                var response = await client.DeleteAsync(urlParam);
                var responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }
                throw new HttpException(response.StatusCode, responseBody);
            }
        }
    }
}
