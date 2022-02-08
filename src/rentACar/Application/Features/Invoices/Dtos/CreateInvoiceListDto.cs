using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Dtos
{
    public class CreateInvoiceListDto
    {
        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoicedDate { get; set; }
        public int TotalRentalDate { get; set; }
        public double TotalPrice { get; set; }

    }
}
