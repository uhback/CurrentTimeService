using CurrentTimeService.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// app.UseHttpsRedirection();`

app.UseRouting();
app.UseEndpoints(endpoints => 
{
    endpoints.MapControllers();
});

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

await app.RunAsync();
