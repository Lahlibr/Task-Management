using System.ComponentModel.DataAnnotations;

namespace Task_Management.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
