using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Rules
{
    public class IndividualCustomerBusienessRules
    {
        IIndividualCustomerRepository _individualCustomerRepository;

        public IndividualCustomerBusienessRules(IIndividualCustomerRepository individualCustomerRepository)
        {
            _individualCustomerRepository = individualCustomerRepository;
        }

        public async Task NationalIdCanBotBeDublicated(string nationalId)
        {
            var result = await _individualCustomerRepository.GetListAsync(c => c.NationalityId == nationalId);
            if (result.Items.Any())
            {
                throw new BusinessException("NationalId cannot be dublicated");
            }
        }

        public async Task<string> CheckIfIndividualCustomerIsExists(int id)
        {
            var individualCustomer = await _individualCustomerRepository.GetAsync(c => c.Id == id);
            if (individualCustomer == null)
            {
                throw new BusinessException("Individual Customer is not exist");
            }
            return individualCustomer.NationalityId;
        }
    }
}
