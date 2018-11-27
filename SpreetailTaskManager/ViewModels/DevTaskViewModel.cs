using SpreetailTaskManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpreetailTaskManager.ViewModels
{
    public class DevTaskViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [FutureDate]
        public string DueDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public byte Priority { get; set; }

        [Required]
        public int ParentId { get; set; }

        public byte IsComplete { get; set; }

        public IEnumerable<Priority> Priorities { get; set; }

        public IEnumerable<DevTasks> Tasks { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(DueDate);
        }
    }
}