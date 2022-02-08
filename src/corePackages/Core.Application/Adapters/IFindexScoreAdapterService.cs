using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Adapters
{
    public interface IFindexScoreAdapterService
    {
        int GetScoreOfIndividualCustomer(String nationalId);
        int GetScoreOfCorporateCustomer(String taxNumber);
    }
}
