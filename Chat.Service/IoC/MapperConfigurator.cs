using Chat.Service.Mapper;
using Chat.BL.Mapper;

namespace Chat.Service.IoC;

public class MapperConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserBlProfile));
        services.AddAutoMapper(typeof(MessageBlProfile));
        services.AddAutoMapper(typeof(UserServiceProfile));
        services.AddAutoMapper(typeof(MessageServiceProfile));
    }
}

