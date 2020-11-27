using System;

namespace DreamCash.Models
{
    public class Investiment
    {
        public Investiment(string type, string description)
        {
            Type = type;
            Description = description;
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
