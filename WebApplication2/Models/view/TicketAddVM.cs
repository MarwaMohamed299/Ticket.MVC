using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Models.models;

namespace WebApplication2.Models.view;

public class TicketAddVM
{

    [Required]
    [Range(1, 99999, ErrorMessage = "The id must be a number between 1 and 99999.")]
    public int id { get; set; }

    public DateTime CreatedDate { get; set; }
    public bool IsClosed { get; set; }
    [Required]
    public Severity Severity { get; set; } = new();

    public int Severity_id { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 5)]

    public string Description { get; set; } = string.Empty;

    [DisplayName("Deparment")]
    [Required]
    public int Department_id { get; set; }

    [DisplayName("Awards")]
    public List<int> AwardIds { get; set; } = new();
}
