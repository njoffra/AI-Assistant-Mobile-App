﻿using ProjectMobilne.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.Services
{
    public interface IProfileService
    {
        Task<List<AssistantProfile>> GetAssistantProfiles();
       
    }
}
