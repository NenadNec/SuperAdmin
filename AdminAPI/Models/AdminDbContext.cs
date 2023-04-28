using Microsoft.EntityFrameworkCore;

namespace AdminApi.Models
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions<AdminDbContext> options) : base(options)
        { }

    }

}
