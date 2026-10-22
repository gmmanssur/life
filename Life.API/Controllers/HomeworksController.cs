
using Life.Application.Commons.Interfaces.Homework;
using Life.Application.UseCases.Homeworks;
using Life.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Life.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HomeworksController(
        IHomeworkService homeworkService) : ControllerBase
    {
        readonly IHomeworkService _homeworkService = homeworkService;

        /// <summary>
        /// Creates a new homework.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] HomeworkRequest request,
            CancellationToken cancellationToken)
        {
            Homework homework = await _homeworkService.ExecuteCreateAsync(request, cancellationToken);

            if (homework.Id == Guid.Empty)
                return BadRequest("Failed to create homework.");

            return CreatedAtAction(
                nameof(GetById),
                new { id = homework.Id },
                homework);
        }

        /// <summary>
        /// Gets all homeworks.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            List<Homework> homeworks = await _homeworkService.ExecuteGetAllAsync(cancellationToken);

            if (homeworks.Count == 0)
                return Ok(homeworks);

            return Ok(homeworks);
        }

        /// <summary>
        /// Gets a homework by its ID.
        /// </summary>
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            Homework homework = await _homeworkService.ExecuteGetByIdAsync(id, cancellationToken);

            if (homework is null)
                return NotFound("No homework found.");

            return Ok(homework);
        }

        /// <summary>
        /// Updates an existing homework.
        /// </summary>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            [FromRoute] Guid id,
            [FromBody] HomeworkRequest request,
            CancellationToken cancellationToken)
        {
            Homework homework = await _homeworkService.ExecuteUpdateAsync(id, request, cancellationToken);

            if (homework.Id == Guid.Empty)
                return BadRequest("Failed to update homework.");

            return Ok(homework);
        }

        /// <summary>
        /// Deletes a homework by its ID.
        /// </summary>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken)
        {
            bool isDeleted = await _homeworkService.ExecuteDeleteAsync(id, cancellationToken);

            if (!isDeleted)
                return NotFound("Homework not found or could not be deleted.");

            return NoContent();
        }
    }
}
