namespace StudentManagementDotNet.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Course { get; set; } = default!;
}
