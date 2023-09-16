using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [DataContract]
    public class UserAgreements
    {
        [DataMember]
        public List<UserAgreement> UserAgreementList { get; set; }
    }

    [DataContract]
    public class UserAgreement
    {
        [DataMember(EmitDefaultValue = false)]
        public string AgreementId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string DisplayDate { get; set; }

        [DataMember]
        public List<DisplayUserSetInfo> DisplayUserSetInfos { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool esign { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string LatestVersionId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Status { get; set; }

    }

    [DataContract]
    public class DisplayUserSetInfo
    {
        [DataMember]
        public List<DisplayUserInfo> DisplayUserSetMemberInfos { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string DisplayUserSetName { get; set; }
    }

    [DataContract]
    public class DisplayUserInfo
    {
        [DataMember(EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Company { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string FullName { get; set; }
    }
}
