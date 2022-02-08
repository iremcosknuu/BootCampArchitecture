using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Dtos
{
    public class InvoiceListDto
    {
        public int RentDate { get; set; }
        public int ReturnDate { get; set;}
        public int Email { get; set; }
        public string CustomerName { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoicedDate { get; set; }
        public int TotalRentalDate { get; set; }
        public double TotalPrice { get; set; }
    }
}
