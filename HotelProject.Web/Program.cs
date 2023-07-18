using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.BuninessLayer.Abstract;
using HotelProject.BuninessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using HotelProject.EntityLayer.Concrete;
using HotelProject.Web.DTOS.GuestDtos;
using HotelProject.Web.ValidationRules.GuestValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.



builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddTransient<IValidator<CreateGuestDto>, CreateGuestValidator>();
builder.Services.AddControllersWithViews().AddFluentValidation();

builder.Services.AddMvc(config =>
{
    var policy= new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));

});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan= TimeSpan.FromMinutes(5);
    options.LoginPath = "/Login/Index";
});

builder.Services.AddScoped<IBookingDal, EFBookingDal>();
builder.Services.AddScoped<IBookingServices, BookingManager>();

builder.Services.AddHttpClient();
builder.Services.AddAutoMapper(typeof(Program));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
