namespace About.Application.UseCases.Branches.Commands;

public class UpdateBranchCommand:IRequest<bool>
{
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? WorkSchedule { get; set; }
}

