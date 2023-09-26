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
    /// <summary>
    /// Removes a faculty entry
    /// </summary>
    /// <param name="facultyId">Id of the faculty</param>
    /// <returns>Status of the operation</returns>
    public async Task<Status> RemoveFaculty(int facultyId)
    {
        var faculty = await _context.Faculties.FindAsync(facultyId);
        if (faculty == null)
            return Status.Fail;
        _context.Faculties.Remove(faculty);
        await _context.SaveChangesAsync();
        return Status.Success;
    }
    /// <summary>
    /// Updates an existing subject entry
    /// </summary>
    /// <param name="request">Data for the entry</param>
    /// <returns>Status of the opreation</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Status> UpdateSubject(SubjectDto request)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Removes a subject entry from 
    /// </summary>
    /// <param name="id">Id of the subject</param>
    /// <returns>Status of the operation</returns>
    public async Task<Status> RemoveSubject(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
            return Status.Fail;
        
        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();
        return Status.Success;
    }
    /// <summary>
    /// Gets all subject entries a student has
    /// </summary>
    /// <param name="majorId"></param>
    /// <returns>List with all the subjects belonging to that student</returns>
    public async Task<List<Subject>> GetSubjectsByStudent(int majorId)
    {
        return await _context.SubjectMajors
            .Where(s => s.Major.Id == majorId)
            .Select(studentSubject => studentSubject.Subject)
            .ToListAsync();
    }
    /// <summary>
    /// Gets all subject entries this teacher is currently teaching
    /// </summary>
    /// <param name="teacherId">Id of the teacher</param>
    /// <returns>List with all subjects this teacher is teaching</returns>
    public async Task<List<Subject>> GetSubjectsByTeacher(int teacherId)
    {
        return await _context.TeacherSubjects
            .Where(s => s.Teacher.TeacherId == teacherId)
            .Select(teacherSubject => teacherSubject.Subject)
            .ToListAsync();
    }
    /// <summary>
    /// Gets all subject entries
    /// </summary>
    /// <returns>List with all subjects</returns>
    public async Task<List<SubjectDto>?> GetAllSubjects()
    {
        return await _context.Subjects.Select(s => new SubjectDto()
        {
            Id = s.Id,
            Name = s.Name,
            TeacherIds = s.Teachers.Select(teacher => teacher.Id).ToList()
        }).ToListAsync();
    }
    /// <summary>
    /// Gets all major entries
    /// </summary>
    /// <returns>Returns List of Major objects</returns>
    public async Task<List<MajorQueryResult>?> GetAllMajors()
    {
        return await _context.Majors.Select(specialty => new MajorQueryResult
        {
            Id = specialty.Id,
            Name = specialty.Name,
            Subjects = specialty.SubjectSpecialties
                .Select(intermid => intermid.Subject.Name).ToList()
        }).ToListAsync();
    }
    /// <summary>
    /// Gets all faculty entries
    /// </summary>
    /// <returns>A list of faculty objects</returns>
    public async Task<List<FacultyQueryResult>?> GetAllFaculties()
    {
        return await _context.Faculties.Select(faculty =>  new FacultyQueryResult()
        {
            Id = faculty.FacultyId,
            Name = faculty.Name,
            Specialties = faculty.Specialties
        }).ToListAsync();
    }
    /// <summary>
    /// Adds a new faculty entry
    /// </summary>
    /// <param name="request"></param>
    /// <returns>Status of the operation</returns>
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
    /// <summary>
    /// Removes a Major entry from the db
    /// </summary>
    /// <param name="majorId">Id of the major</param>
    /// <returns>Status of the operation</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Status> RemoveSpecialty(int majorId)
    {
        throw new NotImplementedException();
    }
    /// <summary>
    /// Gets a single faculty entry from the system
    /// </summary>
    /// <param name="facultyId">Id of the faculty</param>
    /// <returns>Faculty object</returns>
    public async Task<Faculty?> GetFaculty(int facultyId)
    {
        var result =  await _context.Faculties
            .FirstOrDefaultAsync(f => f.FacultyId == facultyId);
        return result;
    }
    /// <summary>
    /// Creates a new subject entry
    /// </summary>
    /// <param name="request">Entry data</param>
    /// <returns>Status of the operation</returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Status> CreateSubject(SubjectDto request)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a new major entry into the system
    /// </summary>
    /// <param name="request">Entry data</param>
    /// <returns>Status of the operation</returns>
    public async Task<Status> AddMajor(MajorDto request)
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
    /// <summary>
    /// Gets a single subject from the system
    /// </summary>
    /// <param name="subjectId">Id of the subject</param>
    /// <returns>Subject object</returns>
    public async Task<Subject?> GetSubjectById(int subjectId)
    {
        return await _context.Subjects.FindAsync(subjectId);
    }
    /// <summary>
    /// Gets a major entry
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Status> GetMajor(MajorDto request)
    {
        throw new NotImplementedException();
    }
}