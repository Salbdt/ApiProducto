using ApiProducto.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiProducto.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}