using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PizzaRestaurant.API.Infrastructure.Extensions;
using PizzaRestaurant.API.Infrastructure.Mappings;
using PizzaRestaurant.API.Infrastructure.Middlewares;
using PizzaRestaurant.Persistence;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    //option.OperationFilter<SwaggerDefaultValues>();

    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Pizza Restaurant Api",
        Version = "v1",
        Description = "Api to manage pizza restaurant domains",
        Contact = new OpenApiContact
        {
            Name = "Pizza Restaurant",
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine($"{AppContext.BaseDirectory}", xmlFile);

    option.IncludeXmlComments(xmlPath);
    option.ExampleFilters();
});
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());
builder.Services.AddServices();
//Validator
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<PizzaRestaurantDbContext>(
    options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("PizzaRestaurant.Persistence"));
}
);
//builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));
//Mapping 
builder.Services.RegisterMaps();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseGlobalExceptionHandler();
app.UseHttpsRedirection();
//Logging Middleware
app.UseRequestLogging();
app.UseRequestCulture();
//app.UseMiddleware<ResponseLoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
