using AwsApiPersonajes.Data;
using AwsApiPersonajes.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(p => p.AddPolicy("corsenabled", options =>
{
    options.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddDbContext<TelevisionContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("AwsMySql")));
// Add services to the container.
builder.Services.AddTransient<RepositoryTelevision>();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.MapOpenApi();
app.MapScalarApiReference();
app.UseHttpsRedirection();

app.MapGet("/", context =>
{
    context.Response.Redirect("/scalar");
    return Task.CompletedTask;
});
app.UseAuthorization();

app.MapControllers();

app.Run();
