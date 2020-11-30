

namespace DreamCash.Models
{
    public class Investiment : Entity
    {
        public Investiment(string type, string description, long minimumValue)
        {
            Type = type;
            Description = description;
            MinimumValue = minimumValue;
        }

        public string Type { get; set; }
        public string Description { get; set; }
        public long MinimumValue { get; set; }
    }
}
