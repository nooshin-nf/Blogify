using Blogify.Web.Infrastructure.Services;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.Configure<ServiceUrls>(
    builder.Configuration.GetSection(nameof(ServiceUrls)));

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddHttpLogging(httpLogging =>
{
    httpLogging.LoggingFields = HttpLoggingFields.All;
    httpLogging.RequestHeaders.Add("Request-Header-Belogify");
    httpLogging.ResponseHeaders.Add("Response-Header-Belogify");
    httpLogging.MediaTypeOptions.
    AddText("application/javascript");
    httpLogging.RequestBodyLogLimit = 4096;
    httpLogging.ResponseBodyLogLimit = 4096;
});
var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Posts/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Posts}/{action=Index}/{id?}");

app.Run();
