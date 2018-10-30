using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.API.v1.Models.ViewModels
{
    public class BulkExamProgramViewModel : ExamProgramViewModel
    {
        [Required]
        public int Id { get; set; }
    }
}
