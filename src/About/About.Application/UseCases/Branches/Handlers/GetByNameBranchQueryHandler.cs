namespace About.Application.UseCases.Branches.Handlers;

public class GetByNameBranchQueryHandler : IRequestHandler<GetByNameBranchQuery, Branch>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetByNameBranchQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Branch> Handle(GetByNameBranchQuery request, CancellationToken cancellationToken)
    {
        var branch = await _applicationDbContext.Branches.FirstOrDefaultAsync(branch=>branch.Name==request.Name);
        return branch;      
    }
}

