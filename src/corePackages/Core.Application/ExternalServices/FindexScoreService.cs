using Core.Application.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.ExternalServices
{
    public class FindexScoreService : IFindexScoreAdapterService
    {
        public int GetScoreOfCorporateCustomer(string taxNumber)
        {
            Random random = new Random();
            return random.Next(0, 1901);
        }

        public int GetScoreOfIndividualCustomer(string nationalId)
        {
            Random random = new Random();
            return random.Next(0, 1901);
        }
    }
}
