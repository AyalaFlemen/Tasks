namespace ex1.Moduls
{
    public class Tasks
    {
        public string TaskName { get; set; }
        public int? Priority { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public int projectId { get; set; }

        //public enum Status { eg, pending,inProgress , completed }
    }
  }
