namespace SchoolManagementSystem.Models;

public class Institution
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Website { get; set; } = null!;
    public string Accreditation { get; set; } = null!;
    public string PrincipalName { get; set; } = null!;
    public decimal TuitionFee { get; set; }
    public string Facilities { get; set; } = null!;
    public int ProgramsCount { get; set; }
    public int EnrollmentCapacity { get; set; }
    public int EnrollmentCurrent { get; set; }
    public string Description { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public string SocialMedia { get; set; } = null!;
    public List<Student> Students { get; set; } = null!;
    public List<Teacher> Teachers { get; set; } = null!;
    public List<Major> MajorsOffered { get; set; } = null!;
}
