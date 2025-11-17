namespace Job.API.Jobs.GetJobs;
    
public record GetJobQuery() : IQuery<GetJobResult>;
    
public record GetJobResult(IEnumerable<Job.API.Models.Jobs> Jobs);

    
internal class GetJobHandler(IDocumentSession session) : IQueryHandler<GetJobQuery, GetJobResult>
    
{
    public async Task<GetJobResult> Handle(GetJobQuery request, CancellationToken cancellationToken)
    {
        var jobs = await session.Query<Job.API.Models.Jobs>()
            .Where(j => j.Status == JobStatus.Published)
            .OrderByDescending(j => j.CreatedAt)
            .ToListAsync(cancellationToken);

        return new GetJobResult(jobs);
    }
}
