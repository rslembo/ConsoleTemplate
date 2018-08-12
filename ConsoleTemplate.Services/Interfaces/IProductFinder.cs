using ConsoleTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleTemplate.Services.Interfaces
{
    public interface IProductFinder
    {
        Task<IEnumerable<Product>> FindAll();
        Task<Product> FindById(Guid id);
    }
}