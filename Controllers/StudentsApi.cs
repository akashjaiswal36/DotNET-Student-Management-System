using Microsoft.EntityFrameworkCore;
using StudentManagementDotNet.Data;
using StudentManagementDotNet.Models;

namespace StudentManagementDotNet.Controllers;

public static class StudentsApi
{
    public static IEndpointRouteBuilder MapStudentsApi(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/students");

        group.MapGet("/", async (AppDbContext db) =>
            await db.Students.AsNoTracking().ToListAsync());

        group.MapGet("/{id}", async (int id, AppDbContext db) =>
            await db.Students.FindAsync(id) is Student s ? Results.Ok(s) : Results.NotFound());

        group.MapPost("/", async (Student s, AppDbContext db) =>
        {
            db.Students.Add(s);
            await db.SaveChangesAsync();
            return Results.Created($"/api/students/{s.Id}", s);
        });

        group.MapDelete("/{id}", async (int id, AppDbContext db) =>
        {
            var rows = await db.Students.Where(x => x.Id == id).ExecuteDeleteAsync();
            return rows == 0 ? Results.NotFound() : Results.Ok();
        });

        return app;
    }
}
