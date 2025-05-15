using Task_Management.Models;
namespace Task_Management.Service
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks=new();
        public IEnumerable<TaskItem> GetAll() => _tasks;
        public TaskItem GetById(int id) => _tasks.FirstOrDefault(t=>t.Id == id);
        public TaskItem Create(TaskItem item)
        {
            item.Id = _tasks.Count + 1;
            _tasks.Add(item);
            return item;
        }
        public bool Update(int id, TaskItem updatedTask)
        {
            var task = GetById(id);
            if (task == null) return false;
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description; 
            task.Status = updatedTask.Status;  
            return true;
        }
        public bool Delete(int id)
        {  
            var task = GetById(id);
            if (task == null) return false;
            _tasks.Remove(task);
            return true;
        }

    }
}
