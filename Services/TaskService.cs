using TaskManagementSystem.Data;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Services
{
    public class TaskService : ITaskService
    {
        private readonly DbContextClass _dbContext;

        public TaskService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TaskEntity> GetTaskList()
        {
            return _dbContext.Tasks.ToList();
        }

        public TaskEntity GetTaskById(int id)
        {
            return _dbContext.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public TaskEntity AddTask(TaskEntity task)
        {
            var result = _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public TaskEntity UpdateTask(TaskEntity task)
        {
            var result = _dbContext.Tasks.Update(task);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public bool DeleteTask(int id)
        {
            var filteredData = _dbContext.Tasks.FirstOrDefault(x => x.Id == id);
            if (filteredData != null)
            {
                _dbContext.Tasks.Remove(filteredData); // Use Tasks.Remove instead of just Remove
                _dbContext.SaveChanges();
                return true;
            }
            return false; // Return false if no item was found to delete
        }
    }
}
