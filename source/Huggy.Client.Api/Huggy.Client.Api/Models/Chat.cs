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
        public long Id { get; set; }

        [DataMember(Name = "agentId")]
        public long? AgentId { get; set; }

        [DataMember(Name = "secondAgentId")]
        public long? SecondAgentId { get; set; }

        [DataMember(Name = "contactId")]
        public long? ContactId { get; set; }

        [DataMember(Name = "siteCustomerId")]
        public long? SiteCustomerId { get; set; }

        [DataMember(Name = "messengerId")]
        public long? MessengerId { get; set; }

        [DataMember(Name = "departmentId")]
        public long? DepartmentId { get; set; }

        [DataMember(Name = "tabulationId")]
        public long? TabulationId { get; set; }

        [DataMember(Name = "channels")]
        public IList<Channel> Channels { get; set; }

        [DataMember(Name = "queueNumber")]
        public long? QueueNumber { get; set; }

        [DataMember(Name = "createdAt")]
        public string CreatedAt { get; set; }

        [DataMember(Name = "updatedAt")]
        public string UpdatedAt { get; set; }

        [DataMember(Name = "attendedAt")]
        public string AttendedAt { get; set; }

        [DataMember(Name = "closedAt")]
        public string ClosedAt { get; set; }


        public DateTime? GetCreatedAt()
        {
            if (CreatedAt != null)
            {
                return Convert.ToDateTime(CreatedAt);
            }

            return null;
        }

        public DateTime? GetAttendedAt()
        {
            if (AttendedAt != null)
            {
                return Convert.ToDateTime(AttendedAt);
            }

            return null;
        }

        public DateTime? GetClosedAt()
        {
            if (ClosedAt != null)
            {
                return Convert.ToDateTime(ClosedAt);
            }

            return null;
        }

        public DateTime? GetUpdatedAt()
        {
            if (UpdatedAt != null)
            {
                return Convert.ToDateTime(UpdatedAt);
            }

            return null;
        }

    }
}
