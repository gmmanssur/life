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

        /// <summary>
        /// Creates a new homework
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHomeworkRequest request, CancellationToken cancellationToken)
        {
            Homework objHomework = await _createHomeworksService.ExecuteCreateHomeworkAsync(request, cancellationToken);

            if(objHomework.Id == Guid.Empty)
                return BadRequest("Failed to create homework.");

            return Ok(objHomework);
        }
    }
}