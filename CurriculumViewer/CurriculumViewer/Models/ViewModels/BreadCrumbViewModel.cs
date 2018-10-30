using CurriculumViewer.Domain.Models;
using System.Collections.Generic;

namespace CurriculumViewer.WebUI.Models.ViewModels
{
    public sealed class BreadCrumb
    {
        public string Name { get; set; } = "Home";
        public string Controller { get; set; } = "Home";
        public string Action { get; set; } = "Index";
        public int Id { get; set; }
    }

	public class BreadCrumbViewModel
    {
        public ICollection<BreadCrumb> Crumbs { get; set; } = new List<BreadCrumb>();
    }
}
