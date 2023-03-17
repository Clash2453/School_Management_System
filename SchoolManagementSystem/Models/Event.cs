using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models;

public class Event
{
    [Key] 
    public int Id { get; set; }

    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Date { get; set; }
    public string Organizer { get; set; } = null!;
}