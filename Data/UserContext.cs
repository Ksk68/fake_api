using Microsoft.EntityFrameworkCore;
using UserApi.models;

namespace UserApi.data;


public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public DbSet<User> TodoItems { get; set; } = null!;
}