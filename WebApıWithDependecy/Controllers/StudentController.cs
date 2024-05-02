using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApıWithDependecy.Entities;
using WebApıWithDependecy.Services;
using WebApıWithDependecy.Services.Context;

namespace WebApıWithDependecy.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly Icrudservices _crudServices;

        public StudentController(Icrudservices crudServices)
        {
            _crudServices = crudServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _crudServices.GetStudents();
            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            var createdStudent = await _crudServices.PostStudent(student);
            return CreatedAtAction(nameof(GetStudents), new { id = createdStudent.Id }, createdStudent);
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> PutStudent(int studentId, Student student)
        {
            if (studentId != student.Id)
            {
                return BadRequest();
            }

            var updatedStudent = await _crudServices.UpdateStudent(studentId, student);

            if (updatedStudent == null)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                await _crudServices.DeleteStudent(id);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return NotFound(); 
            }
            catch (Exception)
            {
                return StatusCode(500); 
            }
        }
    }

}

