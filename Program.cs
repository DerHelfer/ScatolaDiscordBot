using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;

internal class Program
{
    private static DiscordClient Client { get; set; }
    private static CommandsNextExtension Commands { get; set; }
    static async Task Main(string[] args)
    {
        var jsonReader = new JSONReader();
        await jsonReader.ReadJSON();

        var discordConfig = new DiscordConfiguration()
        {
            Intents = DiscordIntents.AllUnprivileged,
            TokenType = TokenType.Bot,
            Token = jsonReader.Token,
            AutoReconnect = true
        };

        Client = new DiscordClient(discordConfig);
        
        Client.Ready += ClientReady;

        await Client.ConnectAsync();
        await Task.Delay(-1);
    }

    private static Task ClientReady(DiscordClient sender, ReadyEventArgs args)
    {
        return Task.CompletedTask;
    }
}