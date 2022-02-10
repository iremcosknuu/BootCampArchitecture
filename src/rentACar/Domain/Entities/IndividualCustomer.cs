using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class IndividualCustomer:Entity
    {

        public IndividualCustomer()
        {

        }

        public IndividualCustomer(int id, string firstName, string lastName, string nationalityId,int customerId):this()
        {
            Id=id;
            CustomerId=customerId;
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
