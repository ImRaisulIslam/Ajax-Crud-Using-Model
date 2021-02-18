using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ajax_Crud_Using_Model.Models;
using Ajax_Crud_Using_Model.Repository;
using Ajax_Crud_Using_Model.ViewModel;

namespace Ajax_Crud_Using_Model.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepo;

        public HomeController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public IActionResult Index()
        {

            var model = _studentRepo.GetAll();


            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return PartialView();
        }
        [HttpPost]

        public IActionResult Create(StudentViewModel model)
        {


            try
            {
                _studentRepo.Insert(model);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return View(e);
            }

        }


        public IActionResult Details(int id)
        {
            var model = _studentRepo.GetById(id);

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _studentRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel model)
        {

            try
            {

                _studentRepo.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return View(e);
            }
        }

        public IActionResult Delete(int id)
        {
            var model = _studentRepo.GetById(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(StudentViewModel model)
        {
            try
            {

                _studentRepo.Delete(model);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return View(e);
            }
        }
    }
}
