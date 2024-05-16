using CRUDApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CRUDApiContext context;

        public StudentController(CRUDApiContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        { 
            var students= await context.Students.ToListAsync();
            return Ok(students);
        }
        [HttpGet("{rollno}")]
        public async Task<ActionResult<Student>> GetStudentBy(int rollno)
        {
            var student = context.Students.Where(x => x.RollNo== rollno).FirstOrDefault();
            if (student==null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student std)
        {
            await context.AddAsync(std);
            await context.SaveChangesAsync();
            return Ok(std);
        }

    }
}
