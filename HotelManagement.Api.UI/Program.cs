using HotelManagement.Api.UI.Controllers.Authentication;
using HotelManagement.Application.Authentication;
using HotelManagement.Application.Bookings;
using HotelManagement.Application.Bookings.Payments;
using HotelManagement.Application.Rooms;
using HotelManagement.Application.Users;
using HotelManagement.Domain.Auth;
using HotelManagement.Domain.Bookings;
using HotelManagement.Domain.Bookings.Payment;
using HotelManagement.Domain.Users;
using HotelManagement.Infrastructure.Data.Auth;
using HotelManagement.Infrastructure.Data.Bookings;
using HotelManagement.Infrastructure.Data.Bookings.Payments;
using HotelManagement.Infrastructure.Data.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGetAvailableRooms, GetAvailableRooms>();
builder.Services.AddScoped<ICurrentUserTokenAdapter, CurrentUserTokenAdapter>();
builder.Services.AddScoped<ICreateBooking, CreateBooking>();
builder.Services.AddScoped<ICreateUser, CreateUser>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IPurchaseManager, PurchaseManager>();
builder.Services.AddScoped<IPaymentSripeUseCase, PaymentSripeUseCase>();
builder.Services.AddScoped<ICancelBooking, CancelBooking>();
builder.Services.AddScoped<IPaymentPaypalUseCase, PaymentPaypalUseCase>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IGetRoomsToClean, GetRoomsToClean>();
builder.Services.AddScoped<IPatchCleanedRoom, PatchCleanedRoom>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IPaymentStripeAdapter, PaymentStripeAdapter>();
builder.Services.AddScoped<IPaymentStrategyResolver, PaymentStrategyResolver>();
builder.Services.AddScoped<IPaymentManager, StripePaymentManager>();
builder.Services.AddScoped<IPaymentManager, PaypalPaymentManager>();
builder.Services.AddScoped<IPaymentPaypalAdapter, PaymentPaypalAdapter>();
builder.Services.AddScoped<IPaymentStripeAdapter, PaymentStripeAdapter>();


builder.Services.Configure<JwtBearerOption>(builder.Configuration.GetSection(nameof(JwtBearerOption).ToString()));
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    JwtBearerOption jwtOptions = builder.Configuration
           .GetRequiredSection(nameof(JwtBearerOption))
           .Get<JwtBearerOption>()
               ?? throw new Exception("JWT settings are not configured");
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        //Registered claims
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key!)),
        ValidateAudience = true,
        ValidAudience = jwtOptions.Audience,
        ValidateIssuer = true,
        ValidIssuer = jwtOptions.Issuer,
        ValidateActor = false,
        ValidateLifetime = true,
    };
});

var app = builder.Build();

app.UseExceptionHandler("/api/v1/error");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
