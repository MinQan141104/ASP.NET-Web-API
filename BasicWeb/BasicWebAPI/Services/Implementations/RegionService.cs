using BasicWebAPI.Models.Domain;
using BasicWebAPI.Models.DTOs;
using BasicWebAPI.Repositories.Interface;
using BasicWebAPI.Services.Interfaces;

namespace BasicWebAPI.Services.Implementations
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;
        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<Region?> AddRegionAsync(RegionRequestDto region)
        {
            return await _regionRepository.AddRegionAsync(region);
        }

        public async Task<Region?> DeleteRegionByIdAsync(Guid id)
        {
            return await _regionRepository.DeleteRegionByIdAsync(id);
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _regionRepository.GetAllRegionsAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await _regionRepository.GetRegionByIdAsync(id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, RegionRequestDto region)
        {
            return await _regionRepository.UpdateRegionAsync(id, region);
        }
    }
}
