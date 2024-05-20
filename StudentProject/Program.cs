using StudentProject.Models;
using StudentProject.Repository;
using StudentProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Add(new ServiceDescriptor(typeof(StudentDbContext),new StudentDbContext(builder.Configuration.GetConnectionString("DefaultConnection"))));
builder.Services.AddScoped<IStudent,StudentService>();
//builder.Services.AddScoped<StudentService,StudentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());//for cors 
app.UseAuthorization();

app.MapControllers();

app.Run();
