

namespace DreamCash.Models
{
    public class Investiment : Entity
    {
        public Investiment(string type, string description)
        {
            Type = type;
            Description = description;
        }

        public string Type { get; set; }
        public string Description { get; set; }
    }
}
