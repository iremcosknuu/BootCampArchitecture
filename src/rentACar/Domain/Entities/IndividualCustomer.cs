using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IndividualCustomer:Customer
    {

        public IndividualCustomer()
        {

        }

        public IndividualCustomer(int id, string email, string firstName, string lastName, string nationalityId,int customerId):this()
        {
            Id=id;
            CustomerId=customerId;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            NationalityId = nationalityId;
        }
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalityId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
