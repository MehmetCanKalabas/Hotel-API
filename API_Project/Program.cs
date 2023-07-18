using API_Project.Controllers;
using HotelProject.BuninessLayer.Abstract;
using HotelProject.BuninessLayer.Concrete;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidIssuer = "http://localhost",
        ValidAudience = "http://localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aspnetcoreapiapi")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew=TimeSpan.Zero
    };
});

builder.Services.AddControllers().AddNewtonsoftJson(option=>
option.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IStaffDal, EFStaffDal>();
builder.Services.AddScoped<IStaffServices, StaffManager>();

builder.Services.AddScoped<IRoomDal, EFRoomDal>();
builder.Services.AddScoped<IRoomServices, RoomManager>();

builder.Services.AddScoped<IServiceDal, EFServiceDal>();
builder.Services.AddScoped<IServiceServices, ServiceManager>();

builder.Services.AddScoped<ITestimonialDal, EFTestimonialDal>();
builder.Services.AddScoped<ITestimonialServices, TestimonialManager>();

builder.Services.AddScoped<ISubscribeDal, EFSubscribeDal>();
builder.Services.AddScoped<ISubscribeServices, SubscribeManager>();

builder.Services.AddScoped<IAboutDal, EFAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();

builder.Services.AddScoped<IBookingDal, EFBookingDal>();
builder.Services.AddScoped<IBookingServices, BookingManager>();

builder.Services.AddScoped<IContactDal, EFContactDal>();
builder.Services.AddScoped<IContactServices, ContactManager>();

builder.Services.AddScoped<IGuestDal, EFGuestDal>();
builder.Services.AddScoped<IGuestServices, GuestManager>();

builder.Services.AddScoped<ISendMessageDal, EFSendMessageDal>();
builder.Services.AddScoped<ISendMessageServices, SendMessageManager>();

builder.Services.AddScoped<IAppUserDal, EFAppUserDal>();
builder.Services.AddScoped<IAppUserServices, AppUserManager>();

builder.Services.AddScoped<IWorkLocationDal, EFWorkLocationDal>();
builder.Services.AddScoped<IWorkLocationServices, WorkLocationManager>();

builder.Services.AddScoped<FileImageController, FileImageController>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("OtelApiCors", opts =>
    {
        opts.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("OtelApiCors");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
