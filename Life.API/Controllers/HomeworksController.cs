using Life.Application.UseCases.Homeworks.CreateHomework;
using Life.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Life.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeworksController : ControllerBase
    {
        private readonly ICreateHomeworkService _createHomeworksService;
        public HomeworksController(
            ICreateHomeworkService createHomeworksService)
        {
            _createHomeworksService = createHomeworksService;
        }

        [HttpPost] 
        public async Task<IActionResult> Create([FromBody] CreateHomeworkRequest request, CancellationToken cancellationToken)
        {
            Homework objHomework = await _createHomeworksService.ExecuteCreateHomeworkAsync(request, cancellationToken);

            if(objHomework.Id == Guid.Empty)
                return BadRequest("Failed to create homework.");

            return Ok(objHomework);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        //{
        //    var homeworks = await _getHomeworksService.ExecuteGetAllAsync(cancellationToken);

        //    return Ok(homeworks);
        //}

        //[HttpGet("{id:guid}")]
        //public async Task<IActionResult> GetById(
        //    Guid id,
        //    CancellationToken cancellationToken)
        //{
        //    var homework = await _getHomeworksService.ExecuteGetByIdAsync(id, cancellationToken);

        //    if (homework is null)
        //        return NotFound();

        //    return Ok(homework);
        //}


        //[HttpPut("{id:guid}")]
        //public async Task<IActionResult> Update(
        //    Guid id,
        //    [FromBody] CreateHomeworkRequest request, CancellationToken cancellationToken)
        //{
        //    var updated = await _getHomeworksService.ExecuteUpdateAsync(
        //        id,
        //        request,
        //        cancellationToken);

        //    if (!updated)
        //        return NotFound();

        //    return NoContent();
        //}

        //[HttpDelete("{id:guid}")]
        //public async Task<IActionResult> Delete(
        //    Guid id,
        //    CancellationToken cancellationToken)
        //{
        //    var deleted = await _getHomeworksService.ExecuteDeleteAsync(id, cancellationToken);

        //    if (!deleted)
        //        return NotFound();

        //    return NoContent();
        //}
    }
}