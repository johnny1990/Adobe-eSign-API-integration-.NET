using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [DataContract]
    public class NextParticipantSetInfo
    {
        [DataMember(EmitDefaultValue = false)]
        public List<NextParticipantInfo> nextParticipantSetMemberInfos { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string nextParticipantSetName { get; set; }
    }

    [DataContract]
    public class NextParticipantInfo
    {
        [DataMember(EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string WaitingSince { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }


    }



    [DataContract]
    public class ParticipantSetInfo
    {
        [DataMember(EmitDefaultValue = false)]
        public string ParticipantSetId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<ParticipantInfo> ParticipantSetMemberInfos { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> Roles { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Status { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ParticipantSetName { get; set; }


        [DataMember(EmitDefaultValue = false)]
        public string PrivateMessage { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> SecurityOptions { get; set; }


        [DataMember(EmitDefaultValue = false)]
        public int SigningOrder { get; set; }


    }


    [DataContract]
    public class ParticipantInfo
    {
        [DataMember(EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string ParticipantId { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<ParticipantSetInfo> AlternateParticipants { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Company { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<string> SecurityOptions { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Title { get; set; }
    }
}
