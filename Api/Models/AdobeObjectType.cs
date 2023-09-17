using Api.Controllers;
using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Api.Models
{
    public class AdobeObjectType
    {
        private RESTApiController API;
        public AdobeObjectType(RESTApiController api)
        {
            API = api;
        }

        public async Task<BaseUrl> GetBaseURI()
        {
            string json = await API.GetRestJson("/base_uris");
            return API.DeserializeJSon<BaseUrl>(json);
        }
    }
}
