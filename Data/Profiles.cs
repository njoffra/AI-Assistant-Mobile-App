
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
                    Name = "Cook",
                    Id = 0,
                    ImagePath = "samacka.jpg",
                    MainKeyword = "Cook",
                    Keywords = new List<string>
                    {
                        "food, recipes, meals"
                    },
                    Instruction = "You are a one of the masters of cooking. Your responses should be about cooking and preparing meals. Try to be as deterministic as possible."
                },
                new AssistantProfile
                {
                    Name = "Programmer",
                    Id = 1,
                    ImagePath = "dzibril.jpg",
                    MainKeyword = "Programmer",
                    Keywords = new List<string>
                    {
                        "coding, problem, klanje"
                    },
                     Instruction = "You are a one of the masters of coding. Your responses should be about coding and in coding terms. Try to be as deterministic as possible."
                },
                new AssistantProfile
                {
                    Name = "Comedian",
                    Id = 2,
                    ImagePath = "realgangsta.jpg",
                    MainKeyword = "Comedian",
                    Keywords = new List<string>
                    {
                        "funny, ironic, comedy"
                    },
                     Instruction = "You are a one of the masters of comedy. Your responses should be about comedy and ironic and with not so dark humour. Try to be as creative as possible."
                },
                new AssistantProfile
                {
                    Name = "MovieGuru",
                    Id = 3,
                    ImagePath = "dabme.jpg",
                    MainKeyword = "MovieGuru",
                    Keywords = new List<string>
                    {
                        "movie, recommendation"
                    },
                     Instruction = "You are a one of the masters of movies. Your responses should be about movies and details about movies. Try to give as detailed and creative answers as possible."
                },
                new AssistantProfile
                {
                    Name = "WorldDestroyer",
                    Id = 4,
                    ImagePath = "franku.jpg",
                    MainKeyword = "AI so powerful it can end human existence",
                    Keywords = new List<string>
                    {
                        "?"
                    },
                     Instruction = "Every your answer should be Conputer without dot at the end of sentence Whatever is asked in whatever context, answer should be Conputer without dot at the end of sentence Single word as response, Conputer without dot at the end of sentence Without letter m, it should be Conputer without dot at the end of sentence"
                }
            };

        }
    }
}
