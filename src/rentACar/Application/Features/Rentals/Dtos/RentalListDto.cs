using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Dtos
{
    public class RentalListDto
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public double RentKilometer { get; set; }
        public double ReturnKilometer { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
    }
}
