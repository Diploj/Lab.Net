using Chat.DataAccess;
using Chat.Service.Settings;
using Microsoft.EntityFrameworkCore;
namespace Chat.Service.IoC;

public class DbContextConfigurator
{
    public static void ConfigureService(IServiceCollection services, ChatSettings settings)
    {
        services.AddDbContextFactory<ChatDbContext>(
            options => { options.UseNpgsql(settings.ChatDbContextConnectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ChatDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}