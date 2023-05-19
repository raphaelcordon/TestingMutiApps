using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Infrastructure
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base (options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
