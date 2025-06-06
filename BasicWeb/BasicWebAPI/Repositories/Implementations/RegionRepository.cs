using BasicWebAPI.Data;
using BasicWebAPI.Models.Domain;
using BasicWebAPI.Models.DTOs;
using BasicWebAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace BasicWebAPI.Repositories.Implement
{
    public class RegionRepository : IRegionRepository
    {
        private NZWalksDbContext _dbContext;

        public RegionRepository(NZWalksDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Region?> AddRegionAsync(RegionRequestDto model)
        {
            var region = new Region
            {
                Id = Guid.NewGuid(), // Generate a new unique identifier
                Name = model.Name,
                Code = model.Code,
                RegionImageUrl = model.RegionImageUrl
            };
            var result = await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Region?> DeleteRegionByIdAsync(Guid id)
        {
            var region = await _dbContext.Regions.FindAsync(id);

            if (region == null)
            {
                return null; // Region not found
            }

            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllRegionsAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid id)
        {
            return await _dbContext.Regions.FindAsync(id);
        }

        public async Task<Region?> UpdateRegionAsync(Guid id, RegionRequestDto region)
        {
            var result =  await _dbContext.Regions.FindAsync(id);

            if (result == null)
            {
                return null; // Region not found
            }

            result.Name = region.Name;
            result.Code = region.Code;
            result.RegionImageUrl = region.RegionImageUrl;

            _dbContext.Regions.Update(result);
            await _dbContext.SaveChangesAsync();

            return result; // Return the updated region
        }
    }
}
