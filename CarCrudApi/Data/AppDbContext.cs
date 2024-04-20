using CarCrudApi.Cars.Model;
using Microsoft.EntityFrameworkCore;

namespace CarCrudApi.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Car> Cars { get; set; }


    }
}
