using ex1.Moduls;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ex1.Services
{
    public interface ITasksServices
    {
        List<Tasks> GetTasks();
        List<Tasks> GetTasksByStatus(string status);
        Tasks CreateTask(Tasks taskCreate);
        Tasks UpdateTask(Tasks taskDetails, string Status);
        string DeleteTask(string Status);
    }
}
