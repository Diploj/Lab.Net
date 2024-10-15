namespace Chat.Service.Settings;

public class ChatSettingsReader
{
    public static ChatSettings Read(IConfiguration configuration)
    {
        return new ChatSettings()
        {
             ChatDbContextConnectionString = configuration.GetValue<string>("FitnessClubDbContext")
        };
    }
}