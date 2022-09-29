using eCodes.Filters;
using eCodes.Services.HelperMethods;
using eCodes.Services;
using eCodes.Services.Database;
using eCodes.Services.ProductStateMachine;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(x=>
{
    x.Filters.Add<ErrorFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "basic"
    });

    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth"}
            },
            new string[] { }
        }
    });

});

builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<IUsersService, UsersService>();
builder.Services.AddTransient<IProductTypesService, ProductTypesService>();
builder.Services.AddTransient<IPersonsService, PersonsService>();
builder.Services.AddTransient<ICitiesService, CitiesService>();
builder.Services.AddTransient<ICountriesService, CountriesService>();
builder.Services.AddTransient<IRolesService, RolesService>();
builder.Services.AddTransient<IBuyersService, BuyersService>();
builder.Services.AddTransient<ICurrenciesService, CurrenciesService>();
builder.Services.AddTransient<IWalletsService, WalletsService>();
builder.Services.AddTransient<IEmployeeService, EmployeesService>();
builder.Services.AddTransient<IRatingsService, RatingService>();
builder.Services.AddTransient<ISellersService, SellersService>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<IOrderItemsService, OrderItemsService>();


//statemachine registering all states
builder.Services.AddTransient<ProductBaseState>();
builder.Services.AddTransient<ActiveProductState>();
builder.Services.AddTransient<DraftProductState>();
builder.Services.AddTransient<InitialProductState>();
builder.Services.AddTransient<HiddenProductState>();




builder.Services.AddAutoMapper(typeof(IProductsService));

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

//ConnectionString
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<_210331Context>(options =>
    options.UseSqlServer(connectionstring));


var app = builder.Build();

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
