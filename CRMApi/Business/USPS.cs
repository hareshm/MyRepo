using CRMApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml.Linq;

namespace CRMApi.Business
{
    public static class USPS
    {
		private const string USPSURL = "http://production.shippingapis.com/ShippingAPI.dll?API=Verify&XML=";
		public const string USERID = "017MIRTE5809";
        public static XDocument GetXDoc(Address address)
        {
			XDocument requestDoc = new XDocument(
				new XElement("AddressValidateRequest",
					new XAttribute("USERID", USERID),
					new XElement("Revision", "1"),
					new XElement("Address",
						new XAttribute("ID", "0"),
						new XElement("Address1", address.Line1),
						new XElement("Address2", string.Empty),
						new XElement("City", address.City),
						new XElement("State", address.State),
						new XElement("Zip5", address.PostalCode),
						new XElement("Zip4", string.Empty)
					)
				)
			);

			return requestDoc;
		}

		public static List<Address> ValidateAddress(XDocument requestDoc)
		{
			List<Address> uspsAddresses = new List<Address>();

			try
			{				
				var url = USPSURL + requestDoc;
				var client = new WebClient();
				var response = client.DownloadString(url);
				var xdoc = XDocument.Parse(response.ToString());				

				foreach (XElement element in xdoc.Descendants("Address"))
				{
					int id = 0;
					Int32.TryParse(GetXMLAttribute(element, "ID"), out id);

					Address address = new Address()
					{
						Id = id,
						Line1 = GetXMLElement(element, "Address1"),
						City = GetXMLElement(element, "City"),
						State = GetXMLElement(element, "State"),
						PostalCode = GetXMLElement(element, "Zip5"),
						DPVConfirmation = GetXMLElement(element, "DPVConfirmation"),
						Country = "US"
					};

					uspsAddresses.Add(address);
				}				
			}
			catch (WebException e)
			{
				Logger.Log(e.ToString());
			}

			return uspsAddresses;
		}

		private static string GetXMLElement(XElement element, string name)
		{
			var el = element.Element(name);
			if (el != null)
			{
				return el.Value;
			}
			return "";
		}
		private static string GetXMLAttribute(XElement element, string name)
		{
			var el = element.Attribute(name);
			if (el != null)
			{
				return el.Value;
			}
			return "";
		}

	}
}