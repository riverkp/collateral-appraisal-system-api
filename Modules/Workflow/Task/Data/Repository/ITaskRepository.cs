namespace Task.Data.Repository;

public interface ITaskRepository
{
    Task<bool> AddTask(Tasks.Models.Task task, CancellationToken cancellationToken = default);
}