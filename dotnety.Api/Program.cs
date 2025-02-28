using MediatR;
using System.Reflection;
using dotnety.Api.SocketHubs;
using dotnety.Infrastructure.Extensions;
using dotnety.Application.Features.NumberPlates.Commands.SeedDb;
using dotnety.Application.Features.NumberPlates.Queries.GetById;
using dotnety.Api.Middleware;
using dotnety.Infrastructure.Repositories;
using dotnety.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
    cfg.RegisterServicesFromAssemblies(typeof(GetNumberPlateByIdQueryHandler).Assembly);
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", policy =>
{
    policy.AllowAnyHeader()
        .AllowAnyMethod()
        .WithOrigins("http://localhost:3000")
        .WithOrigins("http://localhost:1881")
        .AllowCredentials();
}));
builder.Services.RegisterInfrastructureServices(builder.Configuration);
builder.Services.AddSignalR();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<INumberPlateRepository, NumberPlateRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.MapControllers();
app.MapHub<LoggerHub>("/logHub");
app.Run();
