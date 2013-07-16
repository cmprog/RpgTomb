using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RpgTome.Model;
using RpgTome.Repositories;
using RpgTome.Web.ViewModels.Characters;

namespace RpgTome.Web.Controllers
{
    public class CharactersController : Controller
    {
        private readonly IRepository mRepository;

        public CharactersController(IRepository repository)
        {
            this.mRepository = repository;
        }

        //
        // GET: /Characters/

        public ActionResult Index()
        {
            var lViewModel = new IndexViewModel();
            lViewModel.Characters = this.mRepository.FindAll<Character>();
            return this.View(lViewModel);
        }

        //
        // GET: /Characters/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Characters/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Characters/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Characters/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Characters/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Characters/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Characters/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
