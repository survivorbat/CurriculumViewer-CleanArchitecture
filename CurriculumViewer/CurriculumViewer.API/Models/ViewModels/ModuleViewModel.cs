using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.API.v1.Models.ViewModels
{
    public class ModuleViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        [Required]
        [MaxLength(4096)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string OsirisCode { get; set; }

        [Required]
        public int Teacher { get; set; }
    }
}
