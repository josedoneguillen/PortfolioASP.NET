using Portfolio.Web.ApiServices.Interfaces;
using Portfolio.Web.ApiServices.Services;

// (This creates an instance of the WebApplication builder, which is used to configure and build the ASP.NET Core web application.)
var builder = WebApplication.CreateBuilder(args);

// Add services to the container. (This registers the controllers and views services in the application's service container.)
builder.Services.AddControllersWithViews();

// This registers the HttpClient service in the application's service container. This is used for making HTTP requests to external APIs.
builder.Services.AddHttpClient();

/*
 This registers the interfaces and its implementations ApiService as transient services in the application's service container. 
 This allows dependency injection into other components.
 */
builder.Services.AddTransient<IUserApiService, UserApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();
/*
 This maps the default controller route for the application. It defines the pattern for URL routing, 
 where {controller=Home} specifies the default controller, 
 {action=Index} specifies the default action, and {id?} makes the id parameter optional.
 */
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
