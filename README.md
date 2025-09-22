# AI Chat CLI - .NET Console Application

A simple console chat application powered by Azure OpenAI that demonstrates basic AI integration with .NET 8.

## What It Does

Console app for chatting with Azure OpenAI models. Features configurable system prompts, environment-based settings, and proper error handling.

## Setup

### Prerequisites
- .NET 8 SDK
- Azure OpenAI Service with deployed model

### Configuration

1. **Clone and navigate**
   ```bash
   git clone <repo-url>
   cd ai-chat-dotnet/src/AIChat.CLI
   ```

2. **Configure settings**

   Update `appSettings.local.json`:
   ```json
   {
       "AppSettings": {
           "AzureOpenAI": {
               "Endpoint": "https://your-resource.openai.azure.com/",
               "ApiKey": "your-api-key",
               "ModelName": "gpt-4"
           },
           "SystemPrompt": "You are a helpful assistant..."
       }
   }
   ```

3. **Run**
   ```bash
   dotnet run
   ```

## Technologies Used

- **Azure AI Foundry** - Azure AI Foundry deployed models using Endpoint and Key Authentication
- **Azure AI SDK** - Azure AI SDK for .Net
- **Azure Open AI Chat Completion** - Azure Open AI Chat completion using Azure AI Foundry deployed model
- **.NET 8** - Console application with modern C# features

## Project Structure

```
src/AIChat.CLI/
├── Program.cs                  # Main console app with configuration
├── Client/
│   └── AzureOpenAIClient.cs   # AI client with validation
├── appSettings.json           # Default configuration
├── appSettings.local.json     # Local overrides (gitignored)
└── AIChat.CLI.csproj         # Project dependencies
```

## Sample Usage

```
====================================
AI Chat CLI Powered by Azure Open AI
====================================
Type your message and press Enter to chat. Type 'exit' to quit.

Hi Friend, how can I help you?
> What is async/await in C#?
Async/await in C# allows you to write asynchronous code that appears synchronous...

> exit
Press any key to exit...
```