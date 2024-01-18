namespace About.Application.UseCases.Branches.Handlers;

public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public UpdateBranchCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var branch = await _applicationDbContext.Branches.FirstOrDefaultAsync(branch=>branch.Name==request.Name);
            if (branch is null)
                return false;
            branch.Name = request.Name ?? branch.Name;
            branch.Location = request.Location ?? branch.Location;
            branch.WorkSchedule = request.WorkSchedule ?? branch.WorkSchedule;
            _applicationDbContext.Branches.Update(branch);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

