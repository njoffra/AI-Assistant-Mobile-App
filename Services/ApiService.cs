using ChatGptNet;
using ChatGptNet.Extensions;
using ChatGptNet.Models;
using ProjectMobilne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.Services
{
    public class ApiService : IApiService
    {
        private readonly IChatGptClient _chatGptClient;

        public ApiService(IChatGptClient chatGptClient)
        {
            _chatGptClient = chatGptClient;
        }

        public async Task<ChatResponseModel> AskChat(string message)
        {
            var conversationId = Guid.NewGuid();
            var systemMessage = "You are a creative assistant who likes to use irony and comedy to answer certain requests.";

            if (!string.IsNullOrWhiteSpace(systemMessage))
            {
                await _chatGptClient.SetupAsync(conversationId, systemMessage);
            }

            try
            {
                var response = await _chatGptClient.AskAsync(conversationId, message, new ChatGptParameters
                {
                    MaxTokens = 150,
                    Temperature = 0.7
                });
                Console.WriteLine(response);

               
                // Optionally, you can return the response to the caller
                return new ChatResponseModel { Content = response.GetContent() };
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"UnauthorizedAccessException: {ex.Message}");
                // Handle the exception appropriately, e.g., log, show a user-friendly message, etc.
                return new ChatResponseModel { Content = $"UnauthorizedAccessException: {ex.Message}" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected exception occurred: {ex.Message}");
                // Handle other exceptions here if needed
                return new ChatResponseModel { Content = $"UnauthorizedAccessException: {ex.Message}" };
            }
        }
    }

}
