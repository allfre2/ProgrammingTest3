using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IBussinessUnitOfWork : IUnitOfWork
    {
        IRepository<Product, BussinessContext> Products { get; }
        IRepository<Model.Model, BussinessContext> Models { get; }
    }
}
