using ex1.Moduls;
using ex1.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.NetworkInformation;

namespace ex1.Services
{
    public class TasksServices : ITasksServices
    {
        private readonly iTasksRepository _iTasksRepository;
        public TasksServices(iTasksRepository iTasksRepository)
        {
             _iTasksRepository = iTasksRepository;
        }
        public Tasks CreateTask(Tasks taskCreate)
        {
            return _iTasksRepository.CreateTask(taskCreate);
        }

        public string DeleteTask(string Status)
        {
            var tasks = GetTasks();
            Tasks statusTask = tasks.FirstOrDefault(i => i.Status == Status);
            return _iTasksRepository.DeletTask(statusTask);
        }

        public List<Tasks> GetTasks()
        {
            return _iTasksRepository.GetTasks();
        }

        public Tasks GetTasksByStatus(string status)
        {
            var tasks = GetTasks();
            Tasks statusTask = tasks.FirstOrDefault(i => i.Status == status);
            if (statusTask == null)
                return NotFound();
            return _iTasksRepository.GetTasksByStatus(statusTask);
        }

        private Tasks NotFound()
        {
            throw new NotImplementedException();
        }

        public Tasks UpdateTask(Tasks taskDetails, string Status)
        {

            var tasks = GetTasks();
            Tasks statusTask = tasks.FirstOrDefault(i => i.Status == Status);
            if (statusTask == null)
                return NotFound();
            statusTask.TaskName = taskDetails.TaskName;
            statusTask.Priority = taskDetails.Priority;
            statusTask.DueDate = taskDetails.DueDate;
            statusTask.Status = taskDetails.Status;
            return _iTasksRepository.UpdateTask(statusTask);
        }
    }
}
