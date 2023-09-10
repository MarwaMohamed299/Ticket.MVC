namespace WebApplication2.Models.models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Department(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public static List<Department> GetDepartments() => new()
    {
        new (1, "Sales"),
        new (2, "Marketing"),
        new (3, "Engineering"),
        new (4, "Finance"),
        new (5, "Human Resources")
    };
    public override string ToString() => Name;
}