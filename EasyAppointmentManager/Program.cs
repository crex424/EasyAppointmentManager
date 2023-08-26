using EasyAppointmentManager.Data;
using EasyAppointmentManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using SendGrid;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// SendGrid Email Test
var apiKey = builder.Configuration.GetSection("SendGridKey").Value;
var client = new SendGridClient(apiKey);
var msg = new SendGridMessage()
{
    From = new EmailAddress("kim8629@students.cptc.edu", "EasyAppointmentManager-DevTeam"),
    Subject = "News from EasyAppointmentManager-DevTeam",
    PlainTextContent = "with the latest updates from our developers team",
    HtmlContent = "<strong>with the latest updates from our developers team</strong>"
};
msg.AddTo(new EmailAddress("kim8629@students.cptc.edu", "EasyAppointmentManager-DevTeam"));
var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
// SendGrid END

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = false;

    // options.SignIn.RequireConfirmedAccount = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

IServiceScope serviceProvider = app.Services.GetService<IServiceProvider>().CreateScope();

// Create default roles
await IdentityHelper.CreateRoles(serviceProvider.ServiceProvider, IdentityHelper.Employee, IdentityHelper.Customer); 

// Create default employee
await IdentityHelper.CreateDefaultUser(serviceProvider.ServiceProvider, IdentityHelper.Employee);

// Create a scope to resolve the database context and call the seed method
using (var scope = serviceProvider.ServiceProvider.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    DatabaseSeeder.SeedData(dbContext);
}

app.Run();
