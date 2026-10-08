using Life.Application.Commons.Interfaces.Homework;
using Life.Application.UseCases.Homeworks;
using Life.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Life.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeworksController(IHomeworkService homeworkService) : ControllerBase
    {
        private readonly IHomeworkService _homeworkService = homeworkService;

        /// <summary>
        /// Creates a new homework
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HomeworkRequest request, CancellationToken cancellationToken)
        {
            Homework objHomework = await _homeworkService.ExecuteCreateAsync(request, cancellationToken);

            if (objHomework.Id == Guid.Empty)
                return BadRequest("Failed to create homework.");

            return Ok(objHomework);
        }

        /// <summary>
        /// Gets all homeworks
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            List<Homework> homeworks = await _homeworkService.ExecuteGetAllAsync(cancellationToken);

            if(homeworks == null || homeworks.Count == 0)
                return NotFound("No homeworks found.");

            return Ok(homeworks);
        }

        /// <summary>
        /// Gets a homework by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            Homework homeworks = await _homeworkService.ExecuteGetByIdAsync(id, cancellationToken);

            if (homeworks == null)
                return NotFound("No homework found.");

            return Ok(homeworks);
        }

        /// <summary>
        /// Updates an existing homework
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] HomeworkRequest request, CancellationToken cancellationToken)
        {
            Homework objHomework = await _homeworkService.ExecuteUpdateAsync(id, request, cancellationToken);
            
            if (objHomework.Id == Guid.Empty)
                return BadRequest("Failed to update homework.");
            
            return Ok(objHomework);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            bool isDeleted = await _homeworkService.ExecuteDeleteAsync(id, cancellationToken);

            if (!isDeleted)
                return NotFound("Homework not found or could not be deleted.");

            return Ok("Homework deleted successfully.");
        }
    }
}