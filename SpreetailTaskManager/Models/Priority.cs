using System.ComponentModel.DataAnnotations;

namespace SpreetailTaskManager.Models
{
    public class Priority
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}