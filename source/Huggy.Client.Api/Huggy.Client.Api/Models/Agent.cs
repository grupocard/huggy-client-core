using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Huggy.Client.Api.Models
{
    public class Agent
    {
        [DataContract]
        public class agent
        {

            [DataMember(Name = "id")]
            public long Id { get; set; }

            [DataMember(Name = "name")]
            public string Name { get; set; }
        }
    }
}
