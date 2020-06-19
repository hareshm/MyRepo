using CRMApi.Models;
using CRMApiDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CRMApi.Business
{
    public interface ICrmRepository
    {
        bool UpsertCustomer(Customer customer);
    }
    public class CRMRepository : ICrmRepository
    {
        public bool UpsertCustomer(Customer customer)
        {
            bool retVal = CustomerDAL.MergeCustomer(customer.Name, customer.Email, out int customerID);

            if (retVal && customer.Address.IsValid)
            {
                Address address = customer.Address;
                retVal = CustomerDAL.MergeAddress(customerID, address.Line1, address.City, address.State, address.PostalCode, address.Country, out int addressID);
            }

            return retVal;
        }
    }
}