using DotNetApplication.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Data.Repository;
using System.Linq.Expressions;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollementController : ControllerBase
    {
        private readonly IEnrollementRepository _enrollementRepository;
        public EnrollementController(IEnrollementRepository enrollementRepository)
        {
            _enrollementRepository = enrollementRepository;
        }

        [HttpGet]
        [Route("All", Name = "GetAllRnrollement")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEnrollement()
        {
            var emrollemet = await _enrollementRepository.GetAllAsync();
            return Ok(emrollemet);
        }

        [HttpGet("{id:int}", Name = "GetEmrollementById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEmrollementById(int id)
        {
            var emrollemet = await _enrollementRepository.GetByIdAsync(emrollemet => emrollemet.enrollementId == id, true);

            if (emrollemet == null)
            {
                return NotFound();
            }

            return Ok(emrollemet);
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEmrollement([FromBody] Enrollement model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var emrollemet = model;
            await _enrollementRepository.AddAsync(model);

            return CreatedAtAction(nameof(GetEmrollementById), new { id = emrollemet.studentId }, emrollemet);
            //return Created();
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEnrollement([FromBody] Enrollement model)
        {
            if (model == null || model.enrollementId <= 0)
            {
                return BadRequest();
            }
            var existingEnrollement = await _enrollementRepository.GetByIdAsync(enrollement => enrollement.enrollementId == model.enrollementId, true);
            if (existingEnrollement == null)
                return BadRequest();

            existingEnrollement = model;
            await _enrollementRepository.UpdateAsync(existingEnrollement);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (id <= 0)
                return BadRequest();

            var enrollement = await _enrollementRepository.GetByIdAsync(enrollement => enrollement.enrollementId == id);
            if (enrollement == null)
                return NotFound();

            await _enrollementRepository.DeleteAsync(enrollement);
            return Ok();

        }

        [HttpGet("GetEnrollement/{id}")]
        public async Task<IActionResult> GetAllGetEnrolledCoursesAsync(int id)
        {
        var enrollement = await _enrollementRepository.GetAllGetEnrolledCoursesAsync(emrollemet => emrollemet.studentId == id, true);
            if (enrollement == null)
            {
                return NotFound();
            }

            return Ok(enrollement);
        }

    }
}
