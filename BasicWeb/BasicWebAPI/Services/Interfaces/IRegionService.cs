using BasicWebAPI.Models.Domain;
using BasicWebAPI.Models.DTOs;

namespace BasicWebAPI.Services.Interfaces
{
    public interface IRegionService
    {
        public Task<IEnumerable<Region>> GetAllRegionsAsync();
        public Task<Region?> GetRegionByIdAsync(Guid id);
        public Task<Region?> AddRegionAsync(RegionRequestDto region);
        public Task<Region?> UpdateRegionAsync(Guid id, RegionRequestDto region);
        public Task<Region?> DeleteRegionByIdAsync(Guid id);
    }
}
