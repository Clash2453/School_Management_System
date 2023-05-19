using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystem.Models;

public class Absence
{
    [Key]
    public int AbsenceId { get; set; }
    public bool Excused { get; set; }
    public DateTime Date { get; set; }

    public virtual Student Student { get; set; } = null!;
    public virtual Teacher Teacher { get; set; } = null!;
    public virtual Subject Subject { get; set; } = null!;
}