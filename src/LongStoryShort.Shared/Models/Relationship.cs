using System;

namespace LongStoryShort.Shared.Models
{
    public class Relationship
    {
        public Guid CharacterOneId { get; set; }
        public Guid CharacterTwoId { get; set; }
        public bool IsPositive { get; set; }
    }
}
