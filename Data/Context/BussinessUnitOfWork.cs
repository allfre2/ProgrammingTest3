using Data.Interfaces;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class BussinessUnitOfWork : UnitOfWork<BussinessContext>, IBussinessUnitOfWork
    {
        public BussinessUnitOfWork() : base()
        {
            _products = new Repository<Product, BussinessContext>(Context);
            _models = new Repository<Model.Model, BussinessContext>(Context);

            InsertMockData().GetAwaiter().GetResult();
        }

        readonly Repository<Product, BussinessContext> _products;
        public IRepository<Product, BussinessContext> Products { get => _products; }

        readonly Repository<Model.Model, BussinessContext> _models;
        public IRepository<Model.Model, BussinessContext> Models { get => _models; }

        private async Task InsertMockData()
        {
            await Products.Add(SeedData.GenerateProducts());
            await Complete();
            await Models.Add(SeedData.GenerateModels(await Products.GetAll()));
            await Complete();
        }
    }
}
