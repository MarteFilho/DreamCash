namespace DreamCash.Models
{
    public class Investment : Entity
    {
        public Investment(string type, string description, long minimumValue)
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
