namespace About.Application.UseCases.Branches.Handlers;

public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, List<Branch>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetAllBranchesQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Branch>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
    {
        return await _applicationDbContext.Branches.ToListAsync(cancellationToken);
    }
}

