namespace About.Application.UseCases.Branches.Handlers;

public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateBranchCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var isHaveBranch = await _applicationDbContext.Branches.FirstOrDefaultAsync(branch => branch.Name == request.Name);

            if (isHaveBranch != null)
                return false;

            Branch branch = new Branch()
            {
                Name = request.Name,
                Location = request.Location,
                WorkSchedule = request.WorkSchedule
            };

            await _applicationDbContext.Branches.AddAsync(branch);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

