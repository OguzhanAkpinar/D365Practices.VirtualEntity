using Microsoft.EntityFrameworkCore;
using VirtualEntityODataSource.Data.Entities;

namespace VirtualEntityODataSource.Data
{
    public class VirtualEntityDbContext : DbContext
    {
        public VirtualEntityDbContext(DbContextOptions<VirtualEntityDbContext> options) : base(options)
        {

        }

        public DbSet<DrivingLicenceType> DrivingLicenceTypes { get; set; }
        public DbSet<NonimmigrantVisaCategory> NonimmigrantVisaCategories { get; set; }
    }
}
