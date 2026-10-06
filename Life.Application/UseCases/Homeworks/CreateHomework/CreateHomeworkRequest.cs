using Life.Domain.Enums;

namespace Life.Application.UseCases.Homeworks.CreateHomework;

public sealed class CreateHomeworkRequest
{
    public required string Title { get; init; }
    public HomeworkPriority Priority { get; init; }
    public HomeworkFrequency Frequency { get; init; }
}