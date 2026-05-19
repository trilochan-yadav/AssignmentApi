using AssignmentApi.BLL;
using AssignmentApi.BLL.Interfaces;
using AssignmentApi.DAL;
using AssignmentApi.DAL.Interfaces;
using AssignmentApi.Data;
using AssignmentApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database configuration from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Dependency Injection
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProductTransformService, ProductTransformService>();

// Controllers & API Explorer
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Database creation + seeding
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    dbContext.Database.EnsureCreated();

    SeedDatabase(dbContext);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

// ✅ Seed method
static void SeedDatabase(AppDbContext context)
{
    if (context.Users.Any())
    {
        return;
    }

    var users = new List<User>
    {
        new()
        {
            Name = "John Doe",
            Address1 = "123 Main Street",
            Address2 = "Apt 4B"
        },
        new()
        {
            Name = "Jane Smith",
            Address1 = "456 Oak Avenue",
            Address2 = "Suite 200"
        },
        new()
        {
            Name = "Bob Johnson",
            Address1 = "789 Pine Road",
            Address2 = "Unit 12"
        },
        new()
        {
            Name = "Alice Williams",
            Address1 = "321 Elm Street",
            Address2 = "Floor 3"
        },
        new()
        {
            Name = "Charlie Brown",
            Address1 = "654 Maple Drive",
            Address2 = "Building A"
        }
    };

    context.Users.AddRange(users);
    context.SaveChanges();
}