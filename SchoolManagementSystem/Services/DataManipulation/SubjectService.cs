using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.IntermediateTables;

namespace SchoolManagementSystem.Services.DataManipulation;

public class SubjectService : ISubjectService
{
    private readonly SchoolDbContext _context;
    public SubjectService(SchoolDbContext context)
    {
        _context = context;
    }
    public async Task<Status> CreateSubject(SubjectDto request)
    {
        var subject = new Subject()
        {
            Name = request.Name,
        };
        List<TeacherSubject> teacherSubjects = new List<TeacherSubject>();
        

        foreach (int teacherId in request.TeacherIds)
        {
            TeacherSubject intermid = new TeacherSubject()
            {
                Subject = subject,
                Teacher = new Teacher()
                {
                    TeacherId = teacherId
                }
            };
            teacherSubjects.Add(intermid);
        }
        _context.TeacherSubjects.AttachRange(teacherSubjects);
        _context.Subjects.Add(subject);

        await _context.SaveChangesAsync();
        return Status.Success;
    }

    public async Task<Status> RemoveFaculty(int facultyId)
    {
        var faculty = await _context.Faculties.FindAsync(facultyId);
        if (faculty == null)
            return Status.Fail;
        _context.Faculties.Remove(faculty);
        await _context.SaveChangesAsync();
        return Status.Success;
    }

    public async Task<Status> UpdateSubject(SubjectDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<Status> RemoveSubject(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
            return Status.Fail;
        
        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();
        return Status.Success;
    }

    public async Task<List<Subject>> GetSubjectsByStudent(int specialtyId)
    {
        return await _context.SubjectSpecialties
            .Where(s => s.Specialty.SpecialtyId == specialtyId)
            .Select(studentSubject => studentSubject.Subject)
            .ToListAsync();
    }

    public async Task<List<Subject>> GetSubjectsByTeacher(int teacherId)
    {
        return await _context.TeacherSubjects
            .Where(s => s.Teacher.TeacherId == teacherId)
            .Select(teacherSubject => teacherSubject.Subject)
            .ToListAsync();
    }
    
    public async Task<Status> AddFaculty(FacultyDto request)
    {
        try
        {
            var faculty = new Faculty()
            {
                Name = request.Name
            };
            var specialties = new List<Specialty>();
            foreach (var specialty in request.SpecialtyIds)
            {
                var newSpecialty = new Specialty()
                {
                    SpecialtyId = specialty
                };
                specialties.Add(newSpecialty);
            }

            faculty.Specialties = specialties;
            _context.Add(faculty);
            await _context.SaveChangesAsync();
        }   
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;  
        }

        return Status.Success;
    }

    public async Task<Status> RemoveSpecialty(int specialtyId)
    {
        throw new NotImplementedException();
    }

    public async Task<Faculty?> GetFaculty(int facultyId)
    {
        return await _context.Faculties
            .FirstOrDefaultAsync(f => f.FacultyId == facultyId);
    }

    public async Task<Status> AddSpecialty(SpecialtyDto request)
    {
        try
        {
            var specialty = new Specialty
            {
                Name = request.Name,
                Faculty = new Faculty(){FacultyId = request.FacultyId}
            };
            _context.Specialties.Add(specialty);
            await _context.SaveChangesAsync();

            var subjects = new List<SubjectSpecialty>();
            foreach (int id in request.SubjectIds)
            {
                var subjectSpecialty = new SubjectSpecialty()
                {
                    Specialty = specialty,
                    Subject = new Subject(){Id = id}
                };
                subjects.Add(subjectSpecialty);
            }
            await _context.SubjectSpecialties.AddRangeAsync(subjects);
            await _context.SaveChangesAsync();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return Status.Success;
    }

    public async Task<Subject?> GetSubjectById(int subjectId)
    {
        return await _context.Subjects.FindAsync(subjectId);
    }

    public async Task<Status> GetSpecialty(SpecialtyDto request)
    {
        throw new NotImplementedException();
    }
}