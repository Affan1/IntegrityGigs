
namespace Job.API.Jobs.GetJobs
{
    public record GetJobResponse(IEnumerable<Job.API.Models.Jobs> Jobs);
    public class GetJobEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("v1/jobs", async (ISender sender) =>
            {
                var query = new GetJobQuery();
                var result = await sender.Send(query);
                var response = new GetJobResponse(result.Jobs);
                return Results.Ok(response);
            })
                .WithName("GetJobs")
                .WithDescription("Retrieves a list of job postings.")
                .Produces<GetJobResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Retrieve job postings");
        }
    }
}
