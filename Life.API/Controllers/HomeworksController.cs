
using Life.Application.Commons.Interfaces.Homework;
using Life.Application.UseCases.Homeworks;
using Life.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Life.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HomeworksController(IHomeworkService homeworkService) : ControllerBase
    {
        readonly IHomeworkService _homeworkService = homeworkService;

        /// <summary>
        /// Creates a new homework.
        /// </summary>
        [ProducesResponseType(typeof(Homework), StatusCodes.Status201Created)]
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
        [ProducesResponseType(typeof(List<Homework>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(Homework), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(typeof(Homework), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPatch("{id:guid}")]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
