namespace TaskManagement.Api.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
    }
    public enum TaskStatus { Pending, InProgress, Completed }
}
