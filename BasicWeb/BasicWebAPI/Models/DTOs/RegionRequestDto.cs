namespace BasicWebAPI.Models.DTOs
{
    public class RegionRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty; // ISO 3166-1 alpha-2 code
        public string? RegionImageUrl { get; set; } // URL to an image representing the region
    }
}
