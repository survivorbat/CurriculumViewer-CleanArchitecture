using CurriculumViewer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurriculumViewer.WebUI.Models.ViewModels
{
    public class NavBarViewModel
    {
        /// <summary>
        /// Current user
        /// </summary>
        public ApplicationUser applicationUser { get; set; }

        /// <summary>
        /// Current Route
        /// </summary>
        public string currentRoute { get; set; }
    }
}
