using Shared.DDD;

namespace Task.Tasks.Models;

public class Task : Aggregate<long>
{
    public string TaskName { get; private set; } = default!;
    public string AssignedTo { get; private set; } = default!;
    public string AssignedType { get; private set; } = default!;

    private Task()
    {

    }

    private Task(
        string taskName,
        string assignedTo,
        string assignedType
    )
    {
        TaskName = taskName;
        AssignedTo = assignedTo;
        AssignedType = assignedType;
    }

    public static Task Create(
        string taskName,
        string assignedTo,
        string assignedType
    )
    {
        return new Task(taskName, assignedTo, assignedType);
    }
}