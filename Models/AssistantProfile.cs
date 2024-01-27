using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMobilne.Models
{
    public class AssistantProfile
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public string MainKeyword { get; set; }
        public List<String> Keywords { get; set; }
    }
}
