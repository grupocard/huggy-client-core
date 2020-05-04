using Huggy.Client.Api.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Huggy.Client.Api.Models
{
    [DataContract]
    public class Agent
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "login")]
        public string Login { get; set; }

        [DataMember(Name = "type")]
        public AgentType Type { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }
    }
}
