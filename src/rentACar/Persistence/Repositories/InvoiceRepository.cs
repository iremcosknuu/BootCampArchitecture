﻿using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class InvoiceRepository:EfRepositoryBase<Invoice,BaseDbContext>,IInvoiceRepository
    {
        public InvoiceRepository(BaseDbContext baseDbContext):base(baseDbContext)
        {

        }
    }
}
