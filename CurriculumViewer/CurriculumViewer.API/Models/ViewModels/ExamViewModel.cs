using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.API.v1.Models.ViewModels
{
    public class ExamViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string Language { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string ExamType { get; set; }

        [Required]
        [Range(1, 60)]
        public int EC { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string GradeType { get; set; }

        [Required]
        [Range(0, 100)]
        public double Weight { get; set; }

        [Required]
        [Range(0, 10)]
        public double PassingGrade { get; set; }

        [Required]
        public bool Compensatable { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public int ResponsibleTeacher { get; set; }

        [Required]
        public int DurationInMinutes { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime AttemptOne { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime AttemptTwo { get; set; }

        [Required]
        public int Module { get; set; }
    }
}
