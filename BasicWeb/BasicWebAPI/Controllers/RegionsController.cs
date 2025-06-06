using BasicWebAPI.Data;
using BasicWebAPI.Models.DTOs;
using BasicWebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext _context;
        private readonly IRegionService _regionService;
        public RegionsController(NZWalksDbContext context, IRegionService regionService) 
        { 
            _context = context;
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegions()
        {
            var regionsDomain = await _regionService.GetAllRegionsAsync();

            var regionsDto = new List<RegionDto>();
            foreach (var region in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl
                });
            }
            return Ok(regionsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegionById(Guid id)
        {
            var region = await _regionService.GetRegionByIdAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody]RegionRequestDto requestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var region = await _regionService.AddRegionAsync(requestModel);

            if(region == null)
            {
                return BadRequest("Error creating region. Please try again.");
            }

            var regionDto = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImageUrl = region.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion(Guid id, [FromBody] RegionRequestDto model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedRegion = await _regionService.UpdateRegionAsync(id, model);

            if (updatedRegion == null)
            {
                return NotFound();
            }
            var regionDto = new RegionDto()
            {
                Id = updatedRegion.Id,
                Name = updatedRegion.Name,
                Code = updatedRegion.Code,
                RegionImageUrl = updatedRegion.RegionImageUrl
            };

            return Ok(regionDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 

            var deletedRegion = await _regionService.DeleteRegionByIdAsync(id);

            if (deletedRegion == null)
            {
                return NotFound();
            }

            return NoContent(); // 204 No Content response indicates successful deletion
        }
    }
}
