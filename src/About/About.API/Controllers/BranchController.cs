using About.Domain.Entities.Branches;
using About.Domain.Entities.Promocodes;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using System.Xml.Linq;

namespace About.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDistributedCache _distributedCache;

        public BranchController(IMediator mediator, IDistributedCache distributedCache)
        {
            _mediator = mediator;
            _distributedCache = distributedCache;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllBranch()
        {
            var fromCache = await _distributedCache.GetStringAsync("GetAllBranch");

            if (fromCache is null)
            {
                var branches = await _mediator.Send(new GetAllBranchesQuery());

                if (!branches.Any())
                    return Ok();

                fromCache = JsonSerializer.Serialize(branches);
                await _distributedCache.SetStringAsync("GetAllBranch", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(180)
                });
            }
            var result = JsonSerializer.Deserialize<List<Branch>>(fromCache);

            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetBranchByName(string Name)
        {
            var fromCache = await _distributedCache.GetStringAsync($"Branch{Name}");

            if (fromCache is null)
            {
                var branch = await _mediator.Send(new GetByNameBranchQuery { Name = Name });

                if (branch is null)
                    return Ok();

                fromCache = JsonSerializer.Serialize(branch);
                await _distributedCache.SetStringAsync($"Branch{Name}", fromCache, new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(180)
                });
            }
            var result = JsonSerializer.Deserialize<Branch>(fromCache);
            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> CreateBranch(CreateBranchDTO createBranchDTO)
        {
            CreateBranchCommand branch = new CreateBranchCommand()
            {
                Name = createBranchDTO.Name,
                Location = createBranchDTO.Location,
                WorkSchedule = createBranchDTO.WorkSchedule
            };
            var result = await _mediator.Send(branch);

            await _distributedCache.RemoveAsync($"Branch{branch.Name}");
            await _distributedCache.RemoveAsync($"GetAllBranch");

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> UpdateBranch(UpdateBranchDTO updateBranchDTO)
        {
            UpdateBranchCommand branchCommand = new UpdateBranchCommand()
            {
                Name=updateBranchDTO.Name,
                Location=updateBranchDTO.Location,
                WorkSchedule=updateBranchDTO.WorkSchedule
            };

            var result = await _mediator.Send(branchCommand);

            await _distributedCache.RemoveAsync($"Branch{branchCommand.Name}");
            await _distributedCache.RemoveAsync($"GetAllBranch");

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteBranch(string Name)
        {
            var result = await _mediator.Send(new DeleteBranchCommand() { Name=Name});
            await _distributedCache.RemoveAsync($"Branch{Name}");
            await _distributedCache.RemoveAsync($"GetAllBranch");
            return Ok(result);
        }
    }
}

