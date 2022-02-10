using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CorporateCustomer:Entity
    {

        public CorporateCustomer()
        {

        }

        public CorporateCustomer(int id,string companyName, string taxId,int customerId):this()
        {
            Id = id;
            CustomerId = customerId;
            CompanyName = companyName;
            TaxId = taxId;
        }

        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string TaxId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
