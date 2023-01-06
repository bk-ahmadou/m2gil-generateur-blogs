using Microsoft.EntityFrameworkCore;
using m2gil_generateur_blogs.Areas.Identity.Models;
using m2gil_generateur_blogs.Data;
using m2gil_generateur_blogs.Areas.Identity.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity;
using m2gil_generateur_blogs.Utils;
using m2gil_generateur_blogs.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("m2gil_generateur_blogsContextConnection") ?? throw new InvalidOperationException("Connection string 'm2gil_generateur_blogsContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);

builder.Services.AddTransient<IPostRepository,PostRepository>();
builder.Services.AddTransient<IBlogRepository,BlogRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
  try
  {
    SeedData.CreateRoles(scope.ServiceProvider).Wait();
  }
  catch (Exception ex)
  {
    Console.WriteLine(ex.Message);
  }
}

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "area",
//    pattern: "{area:exists}/{controller=home}/{action=index}/{id?}");



app.MapRazorPages();


app.Run();


