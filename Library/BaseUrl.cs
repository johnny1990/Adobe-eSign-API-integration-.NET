using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [DataContract]
    public class BaseUrl
    {
        [DataMember(EmitDefaultValue = false)]
        public string AccessPoint { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string WebAccessPoint { get; set; }
    }
}
