using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text;

namespace Api.Controllers
{
    [Route("api/RESTApi")]
    [ApiController]
    public class RESTApiController : ControllerBase
    {
        private string APIURL = string.Empty;
        private string AccessToken = string.Empty;
        private string ClientID = string.Empty;
        private string ClientSecret = string.Empty;


        public RESTApiController(string apiURL, string accessToken)
        {
            APIURL = apiURL.TrimEnd('/') + "/";
            AccessToken = accessToken;
        }

        #region Api Methods
        [HttpGet]
        [Route("GetRestJson")]
        public async Task<string> GetRestJson(string endpoint, string contentType = "application/json")
        {
            HttpResponseMessage response = await GetResponseMessage(endpoint, contentType);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception(await GetError(response));
            }
        }

        [HttpGet]
        [Route("GetResponseMessageRequest")]
        private async Task<HttpResponseMessage> GetResponseMessageRequest(string endpoint, string contentType)
        {
            endpoint = endpoint.TrimStart('/');
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APIURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            client.DefaultRequestHeaders.Add("Access-Token", AccessToken);

            return await client.GetAsync(endpoint);
        }

        [HttpPost]
        [Route("PostResponseMessage")]
        private async Task<HttpResponseMessage> PostResponseMessage(string endpoint, HttpContent contents, string contentType)
        {
            endpoint = endpoint.TrimStart('/');
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APIURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            client.DefaultRequestHeaders.Add("Access-Token", AccessToken);

            return await client.PostAsync(endpoint, contents);
        }
        #endregion


        #region Utilities
        private async Task<HttpResponseMessage> GetResponseMessage(string endpoint, string contentType)
        {
            endpoint = endpoint.TrimStart('/');
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(APIURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            client.DefaultRequestHeaders.Add("Access-Token", AccessToken);

            return await client.GetAsync(endpoint);
        }

        private async Task<string> GetError(HttpResponseMessage response)
        {
            var errorString = await response.Content.ReadAsStringAsync();
            var errorCode = DeserializeJSon<Library.Errors>(errorString);
            return errorCode.Code + errorCode.Error + System.Environment.NewLine + errorCode.Message + errorCode.Description;
        }

        internal T DeserializeJSon<T>(string jsonString)
        {
            T obj;
            dynamic dT = typeof(T);

            if (dT.Name.EndsWith("List"))
                dT = dT.DeclaredProperties[0].PropertyType.GenericTypeArguments[0];

            DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings()
            {
                DateTimeFormat = new DateTimeFormat("yyyy-MM-ddTHH:mm:ss-f:ff"),
                UseSimpleDictionaryFormat = true
            };

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T), settings);
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                obj = (T)ser.ReadObject(stream);
            }

            return obj;
        }
        #endregion
    }
}
