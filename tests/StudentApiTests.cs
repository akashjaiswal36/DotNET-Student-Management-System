using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using StudentManagementDotNet.Models;
using Xunit;

public class StudentApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public StudentApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.WithWebHostBuilder(b => { })  // use in‑memory DB override if desired
                         .CreateClient();
    }

    [Fact]
    public async Task Crud_flow()
    {
        // POST/201
        var s = new Student { Id = 1, Name = "Alice", Course = "Math" };
        var post = await _client.PostAsJsonAsync("/api/students", s);
        post.StatusCode.Should().Be(HttpStatusCode.Created);

        // GET contains Alice
        var list = await _client.GetFromJsonAsync<Student[]>("/api/students");
        list.Should().ContainSingle(x => x.Name == "Alice");

        // DELETE/200
        var del = await _client.DeleteAsync("/api/students/1");
        del.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
