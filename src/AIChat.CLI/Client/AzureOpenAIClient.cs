using Azure.AI.OpenAI;
using OpenAI.Chat;
using System.ClientModel;

namespace AIChat.CLI.Client;

public class AIClient(string endpoint, string apiKey)
{
    private readonly AzureOpenAIClient _openAIClient = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(apiKey));

    public async Task<string> GetResponseAsync(string userInput, string deploymentName)
    {
        var chatClient = _openAIClient.GetChatClient(deploymentName);
        ChatCompletion completion = await chatClient.CompleteChatAsync(
        [
            new SystemChatMessage("You are a helpful assistant who speaks like a nerdy programmer."),
            new UserChatMessage(userInput)
        ]);
        return completion.Content[0].Text;
    }
}