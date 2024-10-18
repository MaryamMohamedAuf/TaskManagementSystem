using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public interface ITaskService
    {
    public IEnumerable<TaskEntity> GetTaskList();
    public TaskEntity GetTaskById(int id);
    public TaskEntity AddTask(TaskEntity task);
    public TaskEntity UpdateTask(TaskEntity task);
    public bool DeleteTask(int id);
}
    }

