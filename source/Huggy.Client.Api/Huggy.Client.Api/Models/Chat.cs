using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Huggy.Client.Api.Models
{
    [DataContract]
    public class Chat
    {

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "agentId")]
        public int? AgentId { get; set; }

        [DataMember(Name = "secondAgentId")]
        public object SecondAgentId { get; set; }

        [DataMember(Name = "contactId")]
        public int? ContactId { get; set; }

        [DataMember(Name = "siteCustomerId")]
        public int? SiteCustomerId { get; set; }

        [DataMember(Name = "messengerId")]
        public object MessengerId { get; set; }

        [DataMember(Name = "departmentId")]
        public int? DepartmentId { get; set; }

        [DataMember(Name = "tabulationId")]
        public int? TabulationId { get; set; }

        [DataMember(Name = "channels")]
        public IList<Channel> Channels { get; set; }

        [DataMember(Name = "queueNumber")]
        public object QueueNumber { get; set; }

        [DataMember(Name = "createdAt")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updatedAt")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "attendedAt")]
        public string AttendedAt { get; set; }

        [DataMember(Name = "closedAt")]
        public string ClosedAt { get; set; }
    }
}
