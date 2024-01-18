namespace About.Application.UseCases.Branches.Commands;

public class CreateBranchCommand:IRequest<bool>
{
    public string Name { get; set; }
    public string Location { get; set; }
    public string WorkSchedule { get; set; }

}

