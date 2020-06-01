using System.Collections.Generic;

namespace LongStoryShort.Shared.Models
{
    public class Story
    {
        public string Title { get; set; }
        public int CurrentNarrativeIndex { get; set; }
        public List<Character> Characters { get; set; }
        public List<Relationship> Relationships { get; set; }
        public List<Narrative> Narratives { get; set; }

        public Story()
        {
            CurrentNarrativeIndex = 1;
            Characters = new List<Character>();
            Relationships = new List<Relationship>();
            Narratives = new List<Narrative>();
        }

        public Narrative CurrentNarrative() => Narratives[CurrentNarrativeIndex - 1];
    }
}
