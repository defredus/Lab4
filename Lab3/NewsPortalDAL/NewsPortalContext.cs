using Microsoft.EntityFrameworkCore;
using NewsPortalDAL.Models;

namespace NewsPortalDAL
{
    public class NewsPortalContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Commentary> Comments { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Client> Clients { get; set; }

        public NewsPortalContext(DbContextOptions<NewsPortalContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }
    }
}