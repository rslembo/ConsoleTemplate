using ConsoleTemplate.Domain.Entities;
using ConsoleTemplate.Repositories.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTemplate.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public IConfiguration Configuration { get; set; }

        public ProductRepository(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<Product>> FindAll()
        {
            var connectionString = Configuration.GetConnectionString("Database");

            var sql = @"SELECT [Id], [Name], [IsActive], [CreatedDate] 
                        FROM [Product] 
                        ORDER BY [CreatedDate]";

            using (var connection = new SqlConnection(connectionString))
            {
                return await connection.QueryAsync<Product>(sql);
            }
        }

        public async Task<Product> FindById(Guid id)
        {
            var connectionString = Configuration.GetConnectionString("Database");

            var sql = @"SELECT [Id], [Name], [IsActive], [CreatedDate] 
                        FROM [Product] 
                        WHERE [Id] = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                return (await connection.QueryAsync<Product>(sql, new { Id = id })).FirstOrDefault();
            }
        }
    }
}