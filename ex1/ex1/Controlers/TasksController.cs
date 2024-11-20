using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ex1.Moduls;
using System.Net.NetworkInformation;
using ex1.Services;
using System.Threading.Tasks;

namespace ex1.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase

    {
        private readonly ITasksServices _ITasksServices;

        public TasksController(ITasksServices ITasksServices)
        {
            _ITasksServices = ITasksServices; 
        }

        private static List<Tasks> taskses = new List<Tasks>()
        {
          new Tasks{TaskName="to sleep",Priority= 10, DueDate= new DateTime(2024,01,04), Status="e.g."},
          new Tasks{TaskName="to eat",Priority= 4, DueDate= new DateTime(2023,06,02), Status="pending"},
          new Tasks{TaskName="to do h.w",Priority= 7, DueDate= new DateTime(2020,11,25), Status="completed"}
        };
        //get : api/Tasks
        [HttpGet]
        public ActionResult<List<Tasks>> GetTasks()
        {
            return Ok(_ITasksServices.GetTasks());
        }
        // get : api/Tasks/{Status}
        [HttpGet("{Status}")]
        public ActionResult<Tasks> GetTasksByStatus(string status)
        {
            return Ok(_ITasksServices.GetTasksByStatus(status));
        }
        //post : api/Tasks
        [HttpPost]
        [Route("CreateTask")]
        public ActionResult<Tasks> CreateTask([FromBody] Tasks taskCreate)
        {
            Tasks task = new Tasks();
            task.TaskName = taskCreate.TaskName;
            task.Priority = taskCreate.Priority;
            task.DueDate = taskCreate.DueDate;
            task.Status = taskCreate.Status;
            taskses.Add(task);
            return Ok(_ITasksServices.CreateTask(task));
        }
        //put : api/Tasks
        [HttpPut("{Status}")]
        [Route("UpdateTask")]
        public ActionResult<Tasks> UpdateTask([FromBody] Tasks taskDetails, string Status)
        {
            Tasks taskUpdate = taskses.FirstOrDefault(i => i.Status == Status);
            if (taskUpdate == null)
                return NotFound();
            taskUpdate.TaskName = taskDetails.TaskName;
            taskUpdate.Priority = taskDetails.Priority;
            taskUpdate.DueDate = taskDetails.DueDate;
            taskUpdate.Status = taskDetails.Status;

            return Ok(taskUpdate);
        }
        //delete : api/Tasks
        [HttpDelete("{Status}")]
        public ActionResult<string> DeleteBook(string Status)
        {
            return Ok(_ITasksServices.DeleteTask(Status));
        }
    }
}
