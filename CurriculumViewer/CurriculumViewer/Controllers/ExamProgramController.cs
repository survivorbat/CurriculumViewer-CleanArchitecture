using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CurriculumViewer.Abstract.Services;
using CurriculumViewer.ApplicationServices.Abstract.Services;
using CurriculumViewer.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurriculumViewer.WebUI.Controllers
{
    [Authorize]
    public class ExamProgramController : Controller
    {
        public IGenericService<ExamProgram> examProgramService;
        public ExamProgramController(IGenericService<ExamProgram> ExamProgramService)
        {
            this.examProgramService = ExamProgramService;
        }

        // GET: ExamProgram
        public ActionResult Index()
        {
            return View(this.examProgramService.FindAll());
        }

        // GET: ExamProgram/Details/5
        public IActionResult Details(int id)
        {
            return View(examProgramService.FindById(id, new string[] { "Courses" }));
        }

        // GET: ExamProgram/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExamProgram examProgram)
        {
            IActionResult actionResult = View(examProgram);
            
            if (!ModelState.IsValid)
            {
                actionResult = View("Error");
            }
            else if (examProgramService.Insert(examProgram) == 1)
            {
                actionResult = RedirectToAction(nameof(Index));
            }

            return actionResult;
        }
        

        // GET: ExamProgram/Edit/5
        public ActionResult Edit(int id)
        {
            return View(examProgramService.FindById(id));
        }

        // POST: ExamProgram/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ExamProgram examProgram)
        {
            IActionResult actionResult = View(examProgram);

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values;
                actionResult = View("Error");
            }
            else if (examProgramService.Update(examProgram) == 1)
            {
                actionResult = RedirectToAction(nameof(Index));
            }

            return actionResult;
        }
        
        // POST: ExamProgram/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            ExamProgram examProgram = examProgramService.FindById(id);
            IActionResult actionResult = View();

            if (examProgramService.Delete(examProgram) == 1)
            {
                actionResult = RedirectToAction(nameof(Index));
            }

            return actionResult;
        }
    }
}