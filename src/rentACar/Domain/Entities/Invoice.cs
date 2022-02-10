using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice:Entity
    {
        public Invoice()
        {

        }

        public Invoice(int id,int rentalId, int customerId, int invoiceNumber, DateTime invoicedDate, int totalRentalDate, double totalPrice):this()
        {
            Id = id;
            RentalId = rentalId;
            CustomerId = customerId;
            InvoiceNumber = invoiceNumber;
            InvoicedDate = invoicedDate;
            TotalRentalDate = totalRentalDate;
            TotalPrice = totalPrice;
        }

        public int RentalId { get; set; }
        public int CustomerId { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoicedDate { get; set; }
        public int TotalRentalDate { get; set; }
        public double TotalPrice { get; set; }

        public virtual Rental Rental { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
