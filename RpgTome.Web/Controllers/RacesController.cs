using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RpgTome.Model;
using RpgTome.Repositories;
using RpgTome.Repositories.Queries;
using RpgTome.Web.ViewModels.Races;

namespace RpgTome.Web.Controllers
{
    public class RacesController : Controller
    {
        private readonly IRepository mRepository;

        public RacesController(IRepository repository)
        {
            this.mRepository = repository;
        }

        //
        // GET: /Races/
        public ActionResult Index()
        {
            var lViewModel = new IndexViewModel();
            lViewModel.Races = this.mRepository.FindAll<Race>();
            return this.View(lViewModel);
        }

        //
        // GET: /Races/Create
        public ActionResult Create()
        {
            var lViewModel = new CreateViewModel();
            lViewModel.Sizes = this.mRepository.FindAll<SizeCategory>();
            lViewModel.DefaultSize = lViewModel.Sizes.FirstOrDefault(x => string.Equals(x.Name, "medium", StringComparison.OrdinalIgnoreCase));
            return this.View(lViewModel);
        }

        //
        // GET: /Races/Details/5
        public ActionResult Details(int id)
        {
            var lViewModel = new DetailsViewModel();
            lViewModel.Race = this.mRepository.Get<Race>(id);
            lViewModel.AbilityModifiers = this.mRepository.Find(new SimpleFilterQuery<RaceAbilityModifier>(x => x.Race == lViewModel.Race));
            lViewModel.Languages = this.mRepository.Find(new SimpleFilterQuery<RaceLanguage>(x => x.Race == lViewModel.Race)).Select(x => x.Language);
            lViewModel.SkillBonuses = this.mRepository.Find(new SimpleFilterQuery<RaceSkillBonus>(x => x.Race == lViewModel.Race));
            return this.View(lViewModel);
        }

        //
        // POST: /Races/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var lName = collection["name"];
                var lDescription = collection["description"];
                var lSizeId = int.Parse(collection["size"]);

                var lRace = new Race();
                lRace.Name = lName;
                lRace.Description = lDescription;
                lRace.Size = this.mRepository.Get<SizeCategory>(lSizeId);

                lRace.HeightRange = new HeightRange();
                lRace.HeightRange.MinimumHeightInInches = 0;
                lRace.HeightRange.MaximumHeightInInches = 0;

                lRace.WeightRange = new WeightRange();
                lRace.WeightRange.MinimumWeightInPounds = 0;
                lRace.WeightRange.MaximumWeightInPounds = 0;

                this.mRepository.Add(lRace);

                return RedirectToAction("Details", lRace.Id);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /Races/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Races/Edit/5

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
        // GET: /Races/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Races/Delete/5

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
