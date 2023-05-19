using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.Models.IntermediateTables;
[Table("StudentSubjects")]
public class StudentSubject
{
    [Key]
    public int Id { get; set; }
}