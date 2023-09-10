namespace WebApplication2.Models.models;

public class Ticket
{
    public Guid id { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsClosed { get; set; }
    public Severity Severity { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public int Department_id { get; set; }
    public Department? Department { get; set; }
    public List<Award> AwardsIds { get; set; } = new();

    public Ticket(DateTime createdDate, bool isClosed, Severity severity, string description, Department department,int Department_id)
    {
        CreatedDate = createdDate;
        IsClosed = isClosed;
        Severity = severity;
        Description = description;
        Department = department;
        this.Department_id = Department_id;
    }
    public Ticket()
    {
        new Guid();
    }
      
}
