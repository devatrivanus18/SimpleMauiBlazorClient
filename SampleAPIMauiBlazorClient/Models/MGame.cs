using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPIMauiBlazorClient.Models
{
    public class MGame
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<string>? Genre { get; set; }
        public List<string>? Developers { get; set; }
        public List<string>? Publishers { get; set; }
        public MReleaseDates? ReleaseDates { get; set; }
    }
}
