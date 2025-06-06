namespace BasicWebAPI.Models.DTOs
{
    public class RegionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; } // ISO 3166-1 alpha-2 code
        public string? RegionImageUrl { get; set; } // URL to an image representing the region
    }
}
