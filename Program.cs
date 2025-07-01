using Microsoft.EntityFrameworkCore;
using StudentManagementDotNet.Data;
using StudentManagementDotNet.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(o =>
    o.UseSqlite("Data Source=students.db"));

var app = builder.Build();

app.MapStudentsApi();                    // REST API
app.UseDefaultFiles();                   // serve index.html by default
app.UseStaticFiles();                    // enable wwwroot

app.Run();
