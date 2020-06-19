using CRMApi.Business;
using CRMApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace CRMApi.Controllers
{
    public class CRMController : ApiController
    {
        // GET: api/CRM
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CRM/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CRM
        public bool Post([FromBody] Customer customer)
        {
            if (customer.Address != null)
            {
                XDocument xDoc = USPS.GetXDoc(customer.Address);
                List<Address> uspsAddresses = USPS.ValidateAddress(xDoc);
                customer.Address = uspsAddresses[0];
            }

            ICrmRepository crmRespository = new CRMRepository();
            return crmRespository.UpsertCustomer(customer);            
        }

        // PUT: api/CRM/5
        public void Put(int id, [FromBody] Customer customer)
        {
           
        }

        // DELETE: api/CRM/5
        public void Delete(int id)
        {
        }
    }
}
