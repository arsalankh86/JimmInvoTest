using JimmInvoTest.Utility;
using System.ComponentModel.DataAnnotations;

namespace JimmInvoTest.Model
{
    public class Taskss
    {
        [Key] // This attribute specifies that TaskId is the primary key
        public int TaskId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [FutureDate(ErrorMessage = "Due date must be in the future.")]
        public DateTime DueDate { get; set; }

        [Required]
        public Priority Priority { get; set; }
    }
}
