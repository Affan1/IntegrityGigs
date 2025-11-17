public record CreateJobCommand(
    string Title,
    string Description,
    BudgetType BudgetType,
    decimal? FixedPrice,
    decimal? HourlyRate,
    decimal? MinBudget,
    decimal? MaxBudget,
    ExperienceLevel ExperienceLevel,
    ProjectSize ProjectSize,
    JobDuration Duration,
    DateTime? Deadline,
    bool IsRemote,
    string? Location
    ) : ICommand<CreateJobResult>;

public record CreateJobResult(Guid Id);

internal class CreateJobCommandHandler(IDocumentSession session) : ICommandHandler<CreateJobCommand, CreateJobResult>
{
    public async Task<CreateJobResult> Handle(CreateJobCommand command, CancellationToken cancellationToken)
    {
        var job = new Jobs
        {
            Title = command.Title,
            Description = command.Description,
            BudgetType = command.BudgetType,
            FixedPrice = command.FixedPrice,
            HourlyRate = command.HourlyRate,
            MinBudget = command.MinBudget,
            MaxBudget = command.MaxBudget,
            ExperienceLevel = command.ExperienceLevel,
            ProjectSize = command.ProjectSize,
            Duration = command.Duration,
            Deadline = command.Deadline,
            Status = JobStatus.Published,
            IsRemote = command.IsRemote,
            Location = command.Location
        };
        
        session.Store(job);
        await session.SaveChangesAsync(cancellationToken);
        return new CreateJobResult(job.Id);
    }
}
