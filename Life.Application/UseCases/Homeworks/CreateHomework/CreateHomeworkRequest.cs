using Life.Domain.Enums;

namespace Life.Application.UseCases.Homeworks.CreateHomework
{
    public class CreateHomeworkRequest
    {
        public string Title { get; set; }
        public HomeworkPriority Priority { get; set; }
        public HomeworkFrequency Frequency { get; set; }

        public CreateHomeworkRequest() { }
    }
}
