
using System.Windows.Input;

namespace Job.API.Jobs.CreateJobs
{
    public record CreateJobRequest
        (
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
        );
    public record CreateJobResponse(Guid Id);

    public class CreateJobEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/jobs", async (CreateJobRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateJobCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateJobResponse>();

                return Results.Created($"/jobs/{response.Id}", response);

            })
                .WithName("CreateJobs")
                .WithDescription("Creates a new job posting.")
                .Produces<CreateJobResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .WithSummary("Create a new job posting");
        }
    }
}
