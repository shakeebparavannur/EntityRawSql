using EntityRawSql.Data;
using EntityRawSql.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EntityRawSql.Repositories
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;
        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddProductAsync(Product product)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@ProductName",product.ProductName));
            parameter.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
            parameter.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
            parameter.Add(new SqlParameter("@ProductStock", product.ProductStock));
            var result = await Task.Run(() => _dbContext.Database.ExecuteSqlRawAsync(@"EXEC ADDNEWPRODUCT  @ProductName, @ProductDescription, @ProductPrice, @ProductStock", parameter.ToArray()));
            return result;
        }

        public Task<int> DeleteProductAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProductListAsync()
        {
           var result = await _dbContext.Products.FromSqlRaw<Product>("GetProductList").ToListAsync();
           return result;
        }

        public Task<int> UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
