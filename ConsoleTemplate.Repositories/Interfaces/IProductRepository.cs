using ConsoleTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleTemplate.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> FindAll();
        Task<Product> FindById(Guid id);
    }
}