using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CorporateCustomer:Customer
    {
        public string CompanyName { get; set; }
        public string TaxId { get; set; }

        public CorporateCustomer()
        {

        }

        public CorporateCustomer(int id, string email,string companyName, string taxId):this()
        {
            Id = id;
            Email = email;
            CompanyName = companyName;
            TaxId = taxId;
        }
    }
}
