using m2gil_generateur_blogs.Models;
using Microsoft.EntityFrameworkCore;

namespace m2gil_generateur_blogs.Repositories
{
  public class BlogsDbContext : DbContext
  {
    public DbSet<Blog> Blogs { get; set; }
    public BlogsDbContext(DbContextOptions<BlogsDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      // Customize the ASP.NET Identity model and override the defaults if needed.
      // For example, you can rename the ASP.NET Identity table names and more.
      // Add your customizations after calling base.OnModelCreating(builder);
    }
  }
}
