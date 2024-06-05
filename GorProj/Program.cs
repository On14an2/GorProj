using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using GorProj.Models;


var builder = WebApplication.CreateBuilder(args);
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HoldingContext>(options => options.UseSqlServer(connection));
builder.Services.AddMvc();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
			  .AddCookie(options =>
			  {
				  options.LoginPath = "/Login";
				  options.AccessDeniedPath = "/Login";
			  });

var app = builder.Build();


app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Employees}/{action=Index}"
);
app.Run();
