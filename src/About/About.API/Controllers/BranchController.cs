namespace About.API.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BranchController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllBranch()
        {
            var branch = await _mediator.Send(new GetAllBranchesQuery());
            return Ok(branch);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetBranchByName(string Name)
        {
            var branch = await _mediator.Send(new GetByNameBranchQuery{ Name = Name });
            return Ok(branch);
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
            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> DeleteBranch(string Name)
        {
            var result = await _mediator.Send(new DeleteBranchCommand() { Name=Name});
            return Ok(result);
        }
    }
}

