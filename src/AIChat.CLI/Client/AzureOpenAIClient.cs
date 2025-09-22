using Azure.AI.OpenAI;
using OpenAI.Chat;
using System.ClientModel;

namespace AIChat.CLI.Client;

public class AIClient
{
    private const string DefaultSystemPrompt = "You are a helpful assistant whoe provides clear and concise answers to users questions.";

    private readonly AzureOpenAIClient _openAIClient;
    private readonly string  _systemPrompt;

    public AIClient(string endpoint, string apiKey, string systemPrompt = DefaultSystemPrompt)
    {
        if (string.IsNullOrWhiteSpace(endpoint))
            throw new ArgumentException("Endpoint cannot be null or empty.", nameof(endpoint));
        if (string.IsNullOrWhiteSpace(apiKey))
            throw new ArgumentException("API key cannot be null or empty.", nameof(apiKey));
        if (string.IsNullOrWhiteSpace(systemPrompt))
            systemPrompt = DefaultSystemPrompt;

        _systemPrompt = systemPrompt;
        _openAIClient = new AzureOpenAIClient(new Uri(endpoint), new ApiKeyCredential(apiKey));
    }

    public async Task<string> GetResponseAsync(string userInput, string deploymentName)
    {
        var chatClient = _openAIClient.GetChatClient(deploymentName);
        ChatCompletion completion = await chatClient.CompleteChatAsync(
        [
            new SystemChatMessage(_systemPrompt),
            new UserChatMessage(userInput)
        ]);
        return completion.Content[0].Text ?? "No response received.";
    }
}