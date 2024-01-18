namespace About.Application.UseCases.Branches.Handlers;

public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, bool>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public DeleteBranchCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<bool> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var branch = await _applicationDbContext.Branches.FirstOrDefaultAsync(branch=>branch.Name==request.Name);

            if (branch is null)
                return false;

            _applicationDbContext.Branches.Remove(branch);
            var result = await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return result > 0;
        }
        catch
        {
            return false;
        }
    }
}

