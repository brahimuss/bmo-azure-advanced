using Microsoft.Extensions.Configuration.AzureAppConfiguration;

var builder = WebApplication.CreateBuilder(args);

// Connect to Azure App Configuration using connection string
// builder.Configuration.AddAzureAppConfiguration(options =>
// {
//     // Replace 'YourConnectionString' with your Azure App Configuration connection string
//     options.Connect("Endpoint=https://azconfiguration.azconfig.io;Id=XZpR;Secret=3GaV0m7EeCsYVBSNL4Kuz2b5pNlIOLTLxHONUw5Z8EfQIJ23kGIBJQQJ99AIAC5T7U2oySsEAAACAZAC0p5W");

// });

//Adding Application Insight
//builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();


app.MapGet("/", (IConfiguration config) =>
{
    // Access a key-value from Azure App Configuration
    var mySetting = config["MySettingKey"] ?? "Default value";
    if (true) throw new Exception("execption");
    return Results.Ok(new { Setting = mySetting });
});

app.Run();
