namespace About.Application.UseCases.Branches.Commands;

public class DeleteBranchCommand:IRequest<bool>
{
    public string Name { get; set; }
}

