using ProjectMobilne.Data;
using ProjectMobilne.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.Services
{
    public class ProfileService : IProfileService
    {
        private readonly Profiles _profiles;
        public ProfileService(Profiles profiles)
        {
            _profiles = profiles;
        }
        public Task<List<AssistantProfile>> GetAssistantProfiles()
        {
            return Task.FromResult(_profiles.AssistantProfiles);
        }
    }
}
