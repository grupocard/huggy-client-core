using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Huggy.Client.Api.Models
{
    [DataContract]
    public class ContactCustomField
    {

        [DataMember(Name = "codigo_sgv_customer")]
        public string CodigoSgvCustomer { get; set; }

        [DataMember(Name = "codigo_erp_customer")]
        public object CodigoErpCustomer { get; set; }

        [DataMember(Name = "cpf_customer")]
        public string CpfCustomer { get; set; }
    }
}