using System.Text;
using CalendarApp.Domain.Model;
using CalendarApp.Domain.Repositories;
using CalendarApp.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["DataBase:SqlServer"]);

var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => TokenService.GetAuthenticationOptions(key));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("manager"));
    options.AddPolicy("Employee", policy => policy.RequireRole("employee"));
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapPost("/login", (User model, IUserRepository userRepository) =>
{   
    var user = userRepository.Get(model.UserName, model.Password);
    if(user is null)
    {
        return Results.NotFound(new
        {
            message = "Invalid username or password."
        });
    }

    var token = TokenService.GenerateToken(user, key);
    user.Password = "";
    return Results.Ok(new
    {
        user = user,
        token = token
    });
});

app.MapGet("/product/{id}", (Guid id, IProductRepository productRepository) => 
{
    var product = productRepository.Get(id);
    if (product is not null)
        return Results.Ok(new 
        {
           product = product
        });
    return Results.NotFound(new
    {
        message = "Product not found."
    });
});

app.Run();
