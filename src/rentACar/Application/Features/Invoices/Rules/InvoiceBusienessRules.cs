using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Rules
{
    public class InvoiceBusienessRules
    {
        private IInvoiceRepository _invoiceRepository;

        public InvoiceBusienessRules(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task InvoiceCanNotBeDuplicatedWhenInserted(int InvoiceNumber)
        {
            var result = await _invoiceRepository.GetListAsync(b => b.InvoiceNumber == InvoiceNumber);
            if (result.Items.Any())
            {
                throw new BusinessException("Invoice Number name exists");
            }

        }
    }
}
