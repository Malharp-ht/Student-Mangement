using DotNetApplication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Repository;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
           _courseRepository = courseRepository;
        }

        [HttpGet]
        [Route("All", Name = "GetAllCourses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllAsync();
            return Ok(courses);
        }


        [HttpGet("{id:int}", Name = "GetCourseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseRepository.GetByIdAsync(course => course.courseId == id, true);

            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCourse([FromBody] Course model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var course = model;
            await _courseRepository.AddAsync(model);

            return CreatedAtAction(nameof(GetCourseById), new { id = course.courseId }, course);
            //return Created();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            if (id <= 0)
                return BadRequest();

            var course = await _courseRepository.GetByIdAsync(course => course.courseId == id);
            if (course == null)
                return NotFound();

            await _courseRepository.DeleteAsync(course);
            return Ok();

        }
        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStudent([FromBody] Course model)
        {
            if (model == null || model.courseId <= 0)
            {
                return BadRequest();
            }
            var existingCourse = await _courseRepository.GetByIdAsync(course => course.courseId == model.courseId, true);
            if (existingCourse == null)
                return BadRequest();

            existingCourse = model;
            await _courseRepository.UpdateAsync(existingCourse);

            return NoContent();
        }


        [HttpGet("Get Courses")]
        public ActionResult<IEnumerable<Course>> GetStudentCourses(int studentId)
        {
            var courses = _courseRepository.GetStudentCourses(studentId);
            return Ok(courses);
        }

    }
}
