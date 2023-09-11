using dotnetIdentityDemo.Entities;
using dotnetIdentityDemo.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SampleDbContext>(
    options => {
        options.UseMySql("server=localhost;database=sampledb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));
    }
);

////comment this one for the code gen to run
// builder.Services.AddDbContext<SampleIdentityContext>(
//     options => {
//         options.UseMySql("server=localhost;database=sampledb;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));
//     }
// );

builder.Services.AddIdentity<AppUser, AppRole>(option => {
        option.SignIn.RequireConfirmedAccount = false;
        option.SignIn.RequireConfirmedEmail = false;
        option.SignIn.RequireConfirmedPhoneNumber = false;
        option.User.RequireUniqueEmail = true;
        option.Password.RequireNonAlphanumeric = false;
        option.Password.RequireUppercase = false;
        option.Password.RequireLowercase = false;
        option.Password.RequiredUniqueChars = 0;
        option.Password.RequireDigit = false;
    })
    .AddEntityFrameworkStores<SampleIdentityContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
