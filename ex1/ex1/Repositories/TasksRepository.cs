using ex1.Moduls;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.NetworkInformation;
using System.Text.Json;

namespace ex1.Repositories
{
    public class TasksRepository : iTasksRepository
    {
        string path = "Tasks.json";

        public Tasks CreateTask(Tasks taskCreate)
        {
            var tasks = GetTasks();
            tasks.Add(taskCreate);
            SaveTasks(tasks);
            return taskCreate;
        }


        public List<Tasks> GetTasks()
        {

            if (!File.Exists(path))
            {
                return new List<Tasks>();
            }

            var tasks = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Tasks>>(tasks);
        }

        public Tasks GetTasksByStatus(string status)
        {

            if (!File.Exists(path))
            {
                return new Tasks();
            }

            var tasks = File.ReadAllText(path);
            var listTasks= JsonSerializer.Deserialize<List<Tasks>>(tasks);
            return listTasks.FirstOrDefault(i => i.Status == status);
            
        }

        public Tasks UpdateTask(Tasks taskDetails)
        {
            var tasks = GetTasks();
            tasks.Add(taskDetails);
            SaveTasks(tasks);
            return taskDetails;
        }
        public void SaveTasks(List<Tasks> tasks)
        {
            var jsonData = JsonSerializer.Serialize(tasks);
            File.WriteAllText(path, jsonData);
        }
        public Tasks DeletTask(Tasks task )
        {
            var tasks = GetTasks();
            tasks.Remove(task);
            SaveTasks(tasks);
            return task;
        }

    
    }
}
