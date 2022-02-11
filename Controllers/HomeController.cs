using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mission6.Models;

namespace mission6.Controllers
{
    public class HomeController : Controller
    {
        
        private ApplicationContext mission6Context { get; set; }
        //Constructor


        public HomeController(ApplicationContext SomeName)
        {

            mission6Context = SomeName;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult mission6Application()
        {
            //ViewBag.Categories = MovieContext.Category.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult mission6Application(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                mission6Context.Add(ar);
                mission6Context.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Tasks = mission6Context.Task.ToList();
                return View();
            }
        }

        [HttpGet]
        public IActionResult List ()
        {
            var applications = mission6Context.NewResponses
              
                 .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Tasks = mission6Context.Task.ToList();

            var application = mission6Context.NewResponses.Single(x => x.ApplicationId == applicationid);
             
            return View("mission6Application", application);
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse mission6)
        {
            mission6Context.Update(mission6);
            mission6Context.SaveChanges();

            return RedirectToAction("List");

        }
        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = mission6Context.NewResponses.Single(x => x.ApplicationId == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            mission6Context.NewResponses.Remove(ar);
            mission6Context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
