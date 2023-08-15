using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Database
{
    public class TodoItem
    {
        public long Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = default!;
        
        public bool IsComplete { get; set; }

        /// <summary>
        /// For the purpose of making a DTO in other projects
        /// </summary>
        public Priority Priority { get; set; }
    }
}
