using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Rental:Entity
    {
        public Rental()
        {

        }

        public Rental(int id,DateTime rentDate, DateTime returnDate, double rentKilometer, double returnKilometer, int carId ,int customerId):this()
        {
            Id = id;
            RentDate = rentDate;
            ReturnDate = returnDate;
            RentKilometer = rentKilometer;
            ReturnKilometer = returnKilometer;
            CarId = carId;
            CustomerId = customerId;
        }

        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double RentKilometer { get; set; }
        public double ReturnKilometer { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }

    }
}
