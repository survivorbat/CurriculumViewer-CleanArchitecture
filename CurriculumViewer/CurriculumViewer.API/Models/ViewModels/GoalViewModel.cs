using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.API.v1.Models.ViewModels
{
    public class GoalViewModel
    {
        [Required]
        [MaxLength(4096)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        public string Bloom { get; set; }
    }
}
