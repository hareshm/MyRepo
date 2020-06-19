using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMApiDAL
{
    public static class CustomerDAL
    {
        public static bool MergeCustomer(string name, string email, out int customerID)
        {
            // Stub: Call Stored Proc to Merge Customer based on email. The SP should return the customerID IDENTITY. 

            customerID = 1;  //stub
            return true;     // stub, return success/fail
        }

        public static bool MergeAddress(int customerID, string line1, string city, string state, string zip, string country, out int addressID)
        {
            /* Stub: Call Stored Proc to Merge Address based on customerID. 
            This assumes the customer can have only one address.  This can be easily extended by having addressType in the input and merging on (customerID, addressType).
            The SP should return the addressID IDENTITY. 
            */

            addressID = 1;    //stub
            return true;     // stub, return success/fail
        }

    }
}
