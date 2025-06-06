using BasicWebAPI.Models.Domain;
using BasicWebAPI.Models.DTOs;

namespace BasicWebAPI.Repositories.Interface
{
    public interface IRegionRepository
    {
        public Task<IEnumerable<Region>> GetAllRegionsAsync();

        public Task<Region?> GetRegionByIdAsync(Guid id);
        public Task<Region?> AddRegionAsync(RegionRequestDto region);
        public Task<Region?> UpdateRegionAsync(Guid id, RegionRequestDto region);
        public Task<Region?> DeleteRegionByIdAsync(Guid id);
    }
}
