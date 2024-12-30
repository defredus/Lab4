using NewsPortalDAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsPortalDAL.Repositories;

namespace NewsPortalDAL
{
    public static class ConfigurationExtensionsDAL
    {
        public static void ConfigureDAL(this IServiceCollection services, string connection)
        {
            services.AddDbContext<NewsPortalContext>(options => options.UseSqlServer(connection));
            services.AddScoped<IArticleRep, ArticleRepository>();
            services.AddScoped<ICommentaryRep, CommentaryRepository>();
            services.AddScoped<IAuthorRep, AuthorRepository>();
            services.AddScoped<IClientRep, ClientRepository>();

        }
    }
}
