namespace About.Application.UseCases.Branches.Queries;

public class GetByNameBranchQuery:IRequest<Branch>
{
    public string Name { get; set; }
}

