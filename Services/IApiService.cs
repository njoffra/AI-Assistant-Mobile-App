using ProjectMobilne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.Services
{
    public interface IApiService
    {
        Task<ChatResponseModel> AskChat(string? message);
    }
}
