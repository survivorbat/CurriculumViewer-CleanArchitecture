using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.API.v1.Models.ViewModels
{
    public class ExamProgramViewModel
    {
        [Required]
        [DataType(DataType.Time)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime EndDate { get; set; }
    }
}
