var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// GET current UTC time
app.MapGet("time/utc", () => Results.Ok(DateTime.UtcNow));

await app.RunAsync();
