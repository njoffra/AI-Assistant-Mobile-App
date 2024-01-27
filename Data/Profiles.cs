
using ProjectMobilne.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.Data
{
    public class Profiles
    {
        public List<AssistantProfile> AssistantProfiles { get; set; } = GetAssistantProfiles();

        private static List<AssistantProfile> GetAssistantProfiles()
        {
            return new List<AssistantProfile> 
            {
                new AssistantProfile
                {
                    Id = 0,
                    ImagePath = "samacka.jpg",
                    MainKeyword = "Samačka",
                    Keywords = new List<string>
                    {
                        "samacka, hate, retards"
                    }
                },
                new AssistantProfile
                {
                    Id = 1,
                    ImagePath = "dzibril.jpg",
                    MainKeyword = "Džibril",
                    Keywords = new List<string>
                    {
                        "dzibril, kum, klanje"
                    }
                },
                new AssistantProfile
                {
                    Id = 2,
                    ImagePath = "realgangsta.jpg",
                    MainKeyword = "Mirso",
                    Keywords = new List<string>
                    {
                        "islam, protector, utoka"
                    }
                },
                new AssistantProfile
                {
                    Id = 3,
                    ImagePath = "dabme.jpg",
                    MainKeyword = "Dabmeup",
                    Keywords = new List<string>
                    {
                        "dabmeup, krindz"
                    }
                },
                new AssistantProfile
                {
                    Id = 4,
                    ImagePath = "franku.jpg",
                    MainKeyword = "me",
                    Keywords = new List<string>
                    {
                        "me, me, me"
                    }
                }
            };

        }
    }
}
