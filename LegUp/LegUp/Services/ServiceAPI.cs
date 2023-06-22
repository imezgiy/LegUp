using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace LegUp.Services
{
    public class ServiceAPI
    {       
        public readonly string ApiBaseUrl = "https://legup.elsayazilim.com/api/";

        public Task<string> GetAPI(string stringContent)
        {
            using (HttpClient client = new HttpClient())
            {
                var CallApi = client.GetAsync(ApiBaseUrl + stringContent).Result;
                return CallApi.Content.ReadAsStringAsync();

            }
        }

        public int PostAPI(StringContent stringContent, string endpoint)
        {
            int result = 0;


            using (HttpClient client = new HttpClient())
            {
                var CallApi = client.PostAsync(ApiBaseUrl + endpoint, stringContent).Result;
                var response = CallApi.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<int>(response.Result);
            }
            return result;
        }
    }
}
