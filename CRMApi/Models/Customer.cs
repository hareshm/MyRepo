using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace CRMApi.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }

        public bool IsEmailValid()
        {
            try
            {
                MailAddress m = new MailAddress(Email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        public bool IsCustomerValid()
        {
            return String.IsNullOrEmpty(Name) == false && IsEmailValid();
        }
    }   
    
}