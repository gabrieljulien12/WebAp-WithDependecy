using WebApıWithDependecy.Entities;

namespace WebApıWithDependecy.Services
{
    public interface Icrudservices
    {
        Task<List<Student>> GetStudents();
        Task<Student> PostStudent(Student student);
        Task<Student> UpdateStudent(int studentId, Student updatedStudent);
        Task DeleteStudent(int studentId);
    }
}
