using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CorporateCustomers.Rules
{
    public class CorporateCustomerBusienessRules
    {
        ICorporateCustomerRepository _corporateCustomerRepository;

        public CorporateCustomerBusienessRules(ICorporateCustomerRepository corporateCustomerRepository)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
        }

        public async Task TaxNumberCanBotBeDublicated(string taxId)
        {
            var result = await _corporateCustomerRepository.GetListAsync(c => c.TaxId == taxId);
            if (result.Items.Any())
            {
                throw new BusinessException("TaxNumber cannot be dublicated");
            }
        }
    }
}
