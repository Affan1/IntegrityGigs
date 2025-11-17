
using k8s.ClientSets;

var builder = DistributedApplication.CreateBuilder(args);

// Add PostgreSQL container
var postgres = builder.AddPostgres("postgres-db");

// Optional: add a database inside Postgres
var jobsDb = postgres.AddDatabase("JobsDB");

// Register your API service and give it the connection string
var jobsService = builder.AddProject<Projects.Job_API>("JobAPI")
                         .WithReference(jobsDb);

builder.Build().Run();
