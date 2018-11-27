using System;
using System.ComponentModel.DataAnnotations;

namespace SpreetailTaskManager.Models
{
    public class DevTasks
    {
        public int Id { get; set; }

        public byte IsComplete { get; set; }

        public ApplicationUser Developer { get; set; }

        [Required]
        public string DeveloperId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        public Priority Priority { get; set; }

        [Required]
        public byte PriorityId { get; set; }

        [Required]
        public int ParentId { get; set; }
    }
}