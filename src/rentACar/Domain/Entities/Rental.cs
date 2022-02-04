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

        public Rental(int id,DateTime rentDate, DateTime returnDate, double rentKilometer, double returnKilometer, int carId)
        {
            Id = id;
            RentDate = rentDate;
            ReturnDate = returnDate;
            RentKilometer = rentKilometer;
            ReturnKilometer = returnKilometer;
            CarId = carId;
        }

        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public double RentKilometer { get; set; }
        public double ReturnKilometer { get; set; }
        public int CarId { get; set; }

        public virtual Car Car { get; set; }

    }
}
