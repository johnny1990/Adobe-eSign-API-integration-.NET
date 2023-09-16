using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class AdobeObjectType
    {
        private RestAPI API;
        public AdobeObjectType(RestAPI api)
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
