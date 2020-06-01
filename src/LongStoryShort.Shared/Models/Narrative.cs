using System.Collections.Generic;

namespace LongStoryShort.Shared.Models
{
    public class Narrative
    {
        public int Index { get; set; }
        public string Body { get; set; }
        public List<Decision> Decisions { get; set; }
    }
}
