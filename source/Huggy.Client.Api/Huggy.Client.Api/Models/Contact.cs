using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Huggy.Client.Api.Models
{
    [DataContract]
    public class Contact
    {
        [DataMember(Name = "id")]
        public long Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "mobile")]
        public string Mobile { get; set; }

        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "customFields")]
        public ContactCustomField CustomFields { get; set; }
    }

}