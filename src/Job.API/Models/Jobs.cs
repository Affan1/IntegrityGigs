using Microsoft.AspNetCore.Builder;

namespace Job.API.Models
{
    public class Jobs
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        // Budget
        public BudgetType BudgetType { get; set; }
        public decimal? FixedPrice { get; set; }
        public decimal? HourlyRate { get; set; }
        public decimal? MinBudget { get; set; }
        public decimal? MaxBudget { get; set; }

        // Requirements
        public ExperienceLevel ExperienceLevel { get; set; }
        public ProjectSize ProjectSize { get; set; }
        public JobDuration Duration { get; set; }

        //// Client
        //public Guid ClientId { get; set; }
        //public User Client { get; set; }

        // Status & Dates
        public JobStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? Deadline { get; set; }

        // Location
        public bool IsRemote { get; set; }
        public string? Location { get; set; }
    }

    // Supporting Enums
    public enum BudgetType
    {
        FixedPrice,
        Hourly
    }

    public enum ExperienceLevel
    {
        Entry,
        Intermediate,
        Expert
    }

    public enum ProjectSize
    {
        Small,
        Medium,
        Large
    }

    public enum JobDuration
    {
        LessThan1Month,
        OneToThreeMonths,
        ThreeToSixMonths,
        MoreThan6Months
    }

    public enum JobStatus
    {
        Draft,
        Published,
        InProgress,
        Completed,
        Cancelled,
        Expired
    }
}
