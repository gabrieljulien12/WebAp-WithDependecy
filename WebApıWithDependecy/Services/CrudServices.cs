using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApıWithDependecy.Entities;
using WebApıWithDependecy.Services.Context;

namespace WebApıWithDependecy.Services
{
    public class CrudServices : Icrudservices
    {
        SutudentContext _studentcontext;
        public CrudServices(SutudentContext studentContext)
        {
            _studentcontext = studentContext;
        }
        //Get
        public async Task<List<Student>> GetStudents()
        {
            return await _studentcontext.Students.ToListAsync();
        }
        //Post
        public async Task<Student> PostStudent(Student student)
        {
            _studentcontext.Students.Add(student);
            await _studentcontext.SaveChangesAsync();
            return student;
        }
        //Put
        public async Task<Student> UpdateStudent(int studentId, Student updatedStudent)
        {
            var existingStudent = await _studentcontext.Students.FindAsync(studentId);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.FristName =updatedStudent.FristName;
            existingStudent.LastName = updatedStudent.LastName;
            existingStudent.Number = updatedStudent.Number;
            existingStudent.Clas = updatedStudent.Clas;
            existingStudent.Gender = updatedStudent.Gender;

            try
            {
                await _studentcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                
                throw;
            }

            return existingStudent;
        }
        //Delete
        public async Task DeleteStudent(int studentId)
        {
            var existingStudent = await _studentcontext.Students.FindAsync(studentId);

            if (existingStudent == null)
            {
                throw new ArgumentException("Student not found");
            }

            _studentcontext.Students.Remove(existingStudent);
            await _studentcontext.SaveChangesAsync();
        }
    }
}
