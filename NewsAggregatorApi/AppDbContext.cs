using Domain;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<News> News { get; set; }
    public DbSet<NewsSite> NewsSites { get; set; }

    // Если есть другие сущности, их также можно определить здесь
}