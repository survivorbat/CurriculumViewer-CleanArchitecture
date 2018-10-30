using CurriculumViewer.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CurriculumViewer.WebUI.Components
{
    public class ListViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync(IEnumerable<object> data, ListComponentFieldTypes expression)
        {
            ListComponentViewModel list = new ListComponentViewModel()
            {
                Items = data,
                Expression = expression.ToString()
            };
            return Task.FromResult<IViewComponentResult>(View(list));
        }
    }
}
