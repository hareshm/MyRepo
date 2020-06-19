using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMApi.Models
{
    public class Address
    {
        public long Id { get; set; }
        public string Line1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string DPVConfirmation { get; set; }
        public bool IsValid
        {
            get { return DPVConfirmation?.ToUpper() == "Y"; }
        }
    }
}