using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CorporateCustomer:Customer
    {

        public CorporateCustomer()
        {

        }

        public CorporateCustomer(int id, string email,string companyName, string taxId,int customerId):this()
        {
            Id = id;
            CustomerId = customerId;
            Email = email;
            CompanyName = companyName;
            TaxId = taxId;
        }

        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string TaxId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
