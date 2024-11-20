using ex1.Moduls;
namespace ex1.Repositories
{
    public interface iTasksRepository
    {
        List<Tasks> GetTasks();
        Tasks GetTasksByStatus(Tasks task);
        Tasks CreateTask(Tasks taskCreate);
        Tasks UpdateTask(Tasks taskDetails);
        Tasks DeletTask(Tasks task);
        List<Tasks> SaveTasks(List<Tasks> tasks);
    }
}
