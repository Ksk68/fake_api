using Azure;
using Microsoft.EntityFrameworkCore;
using UserApi.models;

namespace UserApi.data;


public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<GoodResponse> GoodResponses { get; set; } = null!;
    public DbSet<noGoodResponse> noGoodResponses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}