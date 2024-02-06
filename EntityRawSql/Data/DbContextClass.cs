using EntityRawSql.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityRawSql.Data
{
    public class DbContextClass:DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass>options):base(options) 
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
