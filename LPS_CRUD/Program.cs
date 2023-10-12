var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
IConfiguration configuration = new ConfigurationBuilder()
							.AddJsonFile("appsettings.json")
							.Build();
var connectionStringx = configuration["mysqlconnection:connectionString"];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
