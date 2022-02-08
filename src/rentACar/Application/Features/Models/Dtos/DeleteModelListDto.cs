﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Dtos
{
    public class DeleteModelListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public string ImageUrl { get; set; }
        public string BrandName { get; set; }
        public string FuelName { get; set; }
        public string TransmissionName { get; set; }
    }
}
