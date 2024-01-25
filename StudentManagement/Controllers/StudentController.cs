using DotNetApplication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Repository;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        [Route("All", Name = "GetAllStudents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id:int}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentRepository.GetByIdAsync(student => student.studentId == id, true);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateStudent([FromBody] Student model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var student = model;
            await _studentRepository.AddAsync(model);

            return CreatedAtAction(nameof(GetStudentById), new { id = student.studentId }, student);
            //return Created();
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStudent([FromBody] Student model)
        {
            if (model==null || model.studentId<=0)
            {
                return BadRequest();
            }
            var existingStudent = await _studentRepository.GetByIdAsync(student => student.studentId == model.studentId, true);
            if (existingStudent==null)
                return BadRequest();

            existingStudent = model;
            await _studentRepository.UpdateAsync(existingStudent);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id <= 0)
                return BadRequest();

            var student = await _studentRepository.GetByIdAsync(student => student.studentId == id);
            if (student == null)
                return NotFound();

            await _studentRepository.DeleteAsync(student);
            return Ok();

        }


    }
}
