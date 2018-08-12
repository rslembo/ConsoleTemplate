using ConsoleTemplate.Domain.Entities;
using ConsoleTemplate.Repositories.Interfaces;
using ConsoleTemplate.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleTemplate.Services
{
    public class ProductFinder : IProductFinder
    {
        public IProductRepository ProductRepository { get; set; }

        public ProductFinder(IProductRepository productRepository)
        {
            ProductRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<IEnumerable<Product>> FindAll()
        {
            return await ProductRepository.FindAll();
        }

        public async Task<Product> FindById(Guid id)
        {
            return await ProductRepository.FindById(id);
        }
    }
}