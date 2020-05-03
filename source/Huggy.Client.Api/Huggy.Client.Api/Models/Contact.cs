using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Huggy.Client.Api.Models
{
    public class Contact
    {
        [DataContract]
        public class agent
        {

            [DataMember(Name = "id")]
            public int Id { get; set; }

            [DataMember(Name = "name")]
            public string Name { get; set; }

            [DataMember(Name = "email")]
            public object Email { get; set; }

            [DataMember(Name = "mobile")]
            public string Mobile { get; set; }

            [DataMember(Name = "phone")]
            public object Phone { get; set; }

            [DataMember(Name = "customFields")]
            public ContactCustomField CustomFields { get; set; }
        }
    }
}