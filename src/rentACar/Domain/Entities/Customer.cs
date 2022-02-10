
using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : Entity
    {
        public Customer()
        {
            Rentals = new List<Rental>();
        }

        public Customer(int id,string email):this()
        {
            Id = id;
            Email = email;
        }

        public string Email { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual CorporateCustomer CorporateCustomer { get; set; }
        public virtual IndividualCustomer IndividualCustomer { get; set; }
    }
}
