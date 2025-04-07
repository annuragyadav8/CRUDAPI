using RepositoriesLayer.Employee;
using ServiceLayer.Employee;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DBsettingConnection");

builder.Services.AddControllers();

builder.Services.AddScoped<IEmployeeRepository>(provider => new EmployeeRepository(connectionString));
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



var app = builder.Build();
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
