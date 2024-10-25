using Asp.Versioning;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blogify.Common.ApiActionFilters;
using Blogify.Core.API;
using Blogify.Core.API.Domain;
using Blogify.Core.API.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>((container) =>
    {
        container.RegisterAssemblyTypes(typeof(Program).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces()
          .InstancePerLifetimeScope();
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version")
    );
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});


builder.Services.AddDbContext<BlogifyDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("BlogifyDbConnectionString")));


builder.Services.AddAutoMapper(mapper => mapper.AddProfile(typeof(MapperProfile)));

builder.Services.AddScoped<ApiExceptionFilter>();
builder.Services.AddScoped<ValidateModelFilter>();
builder.Services.AddScoped<ApiActionFilter>();
builder.Services.AddScoped<IBlogifyDbContext, BlogifyDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
