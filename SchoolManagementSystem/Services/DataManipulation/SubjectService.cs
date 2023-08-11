using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Enums;
using SchoolManagementSystem.Interfaces;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.Models.DataTransferObjects;
using SchoolManagementSystem.Models.IntermediateTables;
using SchoolManagementSystem.Models.QuerryResultDtos;

namespace SchoolManagementSystem.Services.DataManipulation;

public class SubjectService : ISubjectService
{
    private readonly SchoolDbContext _context;
    public SubjectService(SchoolDbContext context)
    {
        _context = context;
    }
    [HttpPost("post-subject")]
    public async Task<Status> CreateSubject(SubjectDto request)
    {
        var subject = new Subject
        {
            Name = request.Name
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
        return await _context.SubjectMajors
            .Where(s => s.Major.Id == specialtyId)
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

    public async Task<List<SubjectDto>?> GetAllSubjects()
    {
        return await _context.Subjects.Select(s => new SubjectDto()
        {
            Id = s.Id,
            Name = s.Name,
            TeacherIds = s.Teachers.Select(teacher => teacher.Id).ToList()
        }).ToListAsync();
    }

    public async Task<List<SpecialtyQueryResult>?> GetAllSpecialties()
    {
        return await _context.Majors.Select(specialty => new SpecialtyQueryResult
        {
            Id = specialty.Id,
            Name = specialty.Name,
            Subjects = specialty.SubjectSpecialties
                .Select(intermid => intermid.Subject.Name).ToList()
        }).ToListAsync();
    }

    public async Task<List<FacultyQueryResult>?> GetAllFaculties()
    {
        return await _context.Faculties.Select(faculty =>  new FacultyQueryResult()
        {
            Id = faculty.FacultyId,
            Name = faculty.Name,
            Specialties = faculty.Specialties
        }).ToListAsync();
    }

    public async Task<Status> AddFaculty(FacultyDto request)
    {
        try
        {
            var faculty = new Faculty
            {
                Name = request.Name
            };
            
            foreach (var specialty in request.SpecialtyIds)
            {
                var newSpecialty = new Major
                {
                    Id = specialty
                };
                faculty.Specialties.Add(newSpecialty);
            }

            _context.Faculties.Add(faculty);
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
        var result =  await _context.Faculties
            .FirstOrDefaultAsync(f => f.FacultyId == facultyId);
        return result;
    }

    public async Task<Status> AddSpecialty(SpecialtyDto request)
    {
        try
        {
            var specialty = new Major
            {
                Name = request.Name,
            };
            var faculty = await _context.Faculties.FindAsync(request.FacultyId);
            if (faculty != null)
                specialty.Faculty = faculty;
            
            var subjects = new List<SubjectMajor>();
            foreach (int id in request.SubjectIds)
            {
                var subjectSpecialty = new SubjectMajor()
                {
                    Major = specialty,
                    Subject = new Subject(){Id = id}
                };
                subjects.Add(subjectSpecialty);
            }
            _context.SubjectMajors.AttachRange(subjects);
            _context.Majors.Add(specialty);
            await _context.SaveChangesAsync();
            return Status.Success;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

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