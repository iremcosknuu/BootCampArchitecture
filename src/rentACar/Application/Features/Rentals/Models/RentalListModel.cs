using Application.Features.Rentals.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Rentals.Models
{
    public class RentalListModel :BasePageableModel
    {
        public IList<RentalListDto> Items { get; set; }
    }
}
