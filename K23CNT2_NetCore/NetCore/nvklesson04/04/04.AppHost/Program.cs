var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.ls04>("ls04");

builder.Build().Run();
