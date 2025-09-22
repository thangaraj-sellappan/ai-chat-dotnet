using AIChat.CLI.Client;
using Microsoft.Extensions.Configuration;
using static System.Console;

WriteLine("====================================");
WriteLine("AI Chat CLI Powered by Azure Open AI");
WriteLine("====================================");

// Instructions to use or exit the application
WriteLine("Type your message and press Enter to chat. Type 'exit' to quit.");
WriteLine();

var environment = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") ?? "local";
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appSettings.{environment}.json", optional: false, reloadOnChange: false)
    .AddEnvironmentVariables()
    .Build();

var endpoint = configuration["AppSettings:AzureOpenAI:Endpoint"];
var apiKey = configuration["AppSettings:AzureOpenAI:ApiKey"];
var modelName = configuration["AppSettings:AzureOpenAI:ModelName"];

if (string.IsNullOrWhiteSpace(endpoint) || string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(modelName))
{
    WriteLine("Error: Please check the AzureOpenAI configurations.");
    return;
}

var systemPrompt = configuration["AppSettings:SystemPrompt"];
var aiClient = new AIClient(endpoint, apiKey, systemPrompt);
WriteLine("Hi Friend, how can I help you?");

while (true)
{
    Write("> ");

    var userInput = ReadLine();
    if (string.IsNullOrEmpty(userInput))
        continue;

    if (string.Equals(userInput, "exit", StringComparison.OrdinalIgnoreCase))
        break;

    try
    {
        WriteLine(await aiClient.GetResponseAsync(userInput, modelName));
    }
    catch (Exception ex)
    {
        WriteLine($"Error: {ex.Message}");
    }
}

WriteLine("Press any key to exit...");
ReadKey();


