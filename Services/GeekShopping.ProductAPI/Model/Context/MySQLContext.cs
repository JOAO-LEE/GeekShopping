using Microsoft.EntityFrameworkCore;
using GeekShopping.ProductAPI.Model;

namespace GeekShopping.ProductAPI.Model.Context
{
  public class MySQLContext : DbContext
  {
    public MySQLContext()
    {

    }

    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options)
    {

    }
    public DbSet<Product> Products { get; set; }
  }
}