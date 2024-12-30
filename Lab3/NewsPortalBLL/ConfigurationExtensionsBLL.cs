using Microsoft.Extensions.DependencyInjection;
using NewsPortalBLL.Interfaces;
using NewsPortalBLL.Profiles;
using NewsPortalBLL.Services;
using NewsPortalDAL;
using NewsPortalDAL.Interfaces;

public static class ConfigurationExtensionsBLL
{
    public static void ConfigureBLL(this IServiceCollection services, string connection)
    {
        services.ConfigureDAL(connection);

        services.AddAutoMapper(
            typeof(ArticleProfile),
            typeof(CommentaryProfile),
            typeof(AuthorProfile),
            typeof(ClientProfile)
            );

        services.AddTransient<IArticleService, ArticleService>();
        services.AddTransient<ICommentaryService, CommentaryService>();
        services.AddTransient<IAuthorService, AuthorService>();
        services.AddTransient<IClientService, ClientService>();
    }
}
