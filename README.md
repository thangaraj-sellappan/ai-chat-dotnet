# AI Chat CLI - .NET Console Application

A simple console chat application powered by Azure OpenAI that demonstrates basic AI integration with .NET 8.

## What It Does?

This is a straightforward console app that lets you chat with Azure OpenAI models. No fancy UI, no over-engineering - just a basic chat interface that shows how to integrate Azure OpenAI with .NET.

## Quick Start

1. Clone this repo
2. Update `appSettings.json` with your Azure OpenAI details:
   ```json
   {
       "AppSettings": {
           "AzureOpenAI": {
               "Endpoint": "https://your-azure-openai-endpoint/",
               "ApiKey": "your-azure-openai-api-key",
               "ModelName": "gpt-4"
           }
       }
   }
   ```
3. Run the app:
   ```bash
   dotnet run
   ```
4. Start chatting! Type 'exit' to quit.

## Key Technologies

- **Azure OpenAI Service** - Microsoft's managed OpenAI models
- **Azure.AI.OpenAI NuGet Package** - Official .NET SDK for Azure OpenAI

## Project Structure

```
src/
└── AIChat.CLI/
    ├── Program.cs              # Main console app
    ├── Client/
    │   └── AzureOpenAIClient.cs # Simple AI client wrapper
    ├── appSettings.json        # Configuration
    └── AIChat.CLI.csproj      # Project file
```

## Notes

This is intentionally kept simple to serve as a learning example. It's not production-ready solution.

For beginners who want to understand Azure OpenAI integration without getting lost in complex architecture.