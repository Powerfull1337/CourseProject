using CourseProject.Data;
using CourseProject.Models.Domain;
using CourseProject.Repositories.Abstract;
using CourseProject.Repositories.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddRazorPages()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CRUDContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MvcDemoConnectionString")));
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
       .AddEntityFrameworkStores<CRUDContext>()
       .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

var app = builder.Build();
var supportedCultures = new[] { "uk", "en" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

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

app.UseMiddleware<LanguageMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=UserAuthentication}/{action=Login}/{id?}");


app.Run();
