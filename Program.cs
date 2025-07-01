using Microsoft.EntityFrameworkCore;
using StudentManagementDotNet.Data;
using StudentManagementDotNet.Controllers;

public class Program { // ← Make it public so tests can access
    public static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=students.db"));

        var app = builder.Build();

        app.MapStudentsApi();     // REST API
        app.UseDefaultFiles();    // serve index.html by default
        app.UseStaticFiles();     // enable wwwroot

        app.Run();
    }
}

