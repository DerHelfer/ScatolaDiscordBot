using Newtonsoft.Json;

internal class JSONReader
{
    public string Token { get; set; }
    public string Prefix { get; set; }

    public async Task ReadJSON()
    {
        using (StreamReader reader = new StreamReader("config.json"))
        {
            string json = await reader.ReadToEndAsync();
            JSONStructure data = JsonConvert.DeserializeObject<JSONStructure>(json);

            this.Token = data.Token;
            this.Prefix = data.Prefix;
        }
    }
}

internal sealed class JSONStructure
{
    public string Token { get; set; }
    public string Prefix { get; set; }
}