namespace BasicWebAPI.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Length { get; set; } // Length in kilometers
        public string? WalkImageUrl { get; set; } // URL to an image representing the walk

        public Guid DifficultyId { get; set; } // Foreign key to Difficulty
        public Guid RegionId { get; set; } // Foreign key to Region

        public Difficulty Difficulty { get; set; } // Navigation property to Difficulty
        public Region Region { get; set; } // Navigation property to Region
    }
}
