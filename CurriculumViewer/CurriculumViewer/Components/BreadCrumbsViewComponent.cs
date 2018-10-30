using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.AspNetCore.Routing;
using CurriculumViewer.WebUI.Resources;
using System.Resources;
using CurriculumViewer.WebUI.Resources.translation;
using CurriculumViewer.WebUI.Models.ViewModels;

namespace CurriculumViewer.WebUI.Components
{
    public class BreadCrumbsViewComponent : ViewComponent
    {
        private static readonly List<string> EXCLUDEDACTIONS = new List<string> { "index", "details" };

        public Task<IViewComponentResult> InvokeAsync(string objectName, int objectId)
        {
            RouteValueDictionary RouteDataValues = ViewContext.RouteData.Values;
            ResourceManager translation = translations.ResourceManager;

            BreadCrumbViewModel breadCrumbViewModel = new BreadCrumbViewModel();

            string controllerName = RouteDataValues["controller"].ToString().ToLower();
            string actionName = RouteDataValues["action"].ToString().ToLower();

            if (controllerName.Equals("home"))
            {
                return Task.FromResult<IViewComponentResult>(View(breadCrumbViewModel));
            }

            breadCrumbViewModel.Crumbs.Add(new BreadCrumb());
            breadCrumbViewModel.Crumbs.Add(new BreadCrumb { Name = translation.GetString(controllerName), Controller = controllerName });
            
            if (!EXCLUDEDACTIONS.Contains(actionName))
            {
                breadCrumbViewModel.Crumbs.Add(new BreadCrumb { Name = translation.GetString(actionName), Action = actionName, Controller = controllerName });
            }

            if (actionName == "details" && objectName != null)
            {
                breadCrumbViewModel.Crumbs.Add(new BreadCrumb { Name = objectName, Action = actionName, Id = objectId, Controller = controllerName });
            }
            
            return Task.FromResult<IViewComponentResult>(View(breadCrumbViewModel));
        }
    }
}
