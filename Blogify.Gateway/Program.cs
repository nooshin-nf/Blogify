using Blogify.Gateway.DelegatingHandlers;
using MMLib.SwaggerForOcelot.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;
builder.Services.AddSingleton<LoggingDelegatingHandler>();

builder.Configuration.AddOcelotWithSwaggerSupport(options =>
{
    options.Folder = "Configurations";
}).AddEnvironmentVariables();

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOcelot()
    .AddDelegatingHandler<LoggingDelegatingHandler>(true);

builder.Services.AddSwaggerForOcelot(builder.Configuration);

builder.Services.AddOpenApiDocument();
//builder.Services.AddAuthentication("Bearer").AddJwtBearer();
//builder.Services.AddAuthorization();

//builder.Services.Configure<SwaggerGeneratorOptions>(options => options.InferSecuritySchemes = true);

var app = builder.Build();
app.UseOpenApi();
app.UseSwaggerForOcelotUI(options =>
{
    options.PathToSwaggerGenerator = "/swagger/docs";
});

//app.UseAuthentication();
//app.UseAuthorization();

await app.UseOcelot();

app.Run();
