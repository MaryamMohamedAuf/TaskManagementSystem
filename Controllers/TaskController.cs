using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.Models;
using TaskManagementSystem.RabbitMQ;
using TaskManagementSystem.Services;

namespace TaskManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService TaskService;
        private readonly IRabbitMQProducer _rabbitMQProducer;
        public TaskController(ITaskService _TaskService, IRabbitMQProducer rabbitMQProducer)
        {
            TaskService = _TaskService;
            _rabbitMQProducer = rabbitMQProducer;
        }
        [HttpGet("Tasklist")]
        public IEnumerable<TaskEntity> TaskList()
        {
            var TaskList = TaskService.GetTaskList();
            return TaskList;
        }
        [HttpGet("getTaskbyid")]
        public TaskEntity GetTaskById(int Id)
        {
            return TaskService.GetTaskById(Id);
        }
        [HttpPost("addTask")]
        public TaskEntity AddTask(TaskEntity Task)
        {
            var TaskData = TaskService.AddTask(Task);
            //send the inserted Task data to the queue and consumer will listening this data from queue
            _rabbitMQProducer.SendTaskMessage(TaskData);
            return TaskData;
        }
        [HttpPut("updateTask")]
        public TaskEntity UpdateTask(TaskEntity Task)
        {
            return TaskService.UpdateTask(Task);
        }
        [HttpDelete("deleteTask")]
        public bool DeleteTask(int Id)
        {
            return TaskService.DeleteTask(Id);
        }
    }
}

        
   