using NightInn.Data;
using NightInn.Models.DrinkModels;
using NightInnV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NightInnV2.Controllers
{
    public class DrinkController : Controller
    {
        private ApplicationDbContext _nightInnDb = new ApplicationDbContext();

        // GET: Drink
        public ActionResult Index()
        {
            List<Drink> drinkList = _nightInnDb.Drinks.ToList();
            List<Drink> orderedList = drinkList.OrderBy(drink => drink.DrinkName).ToList();
            return View(orderedList);
        }

        // GET: Drink
        public ActionResult Create()
        {
            var viewModel = new DrinkCreate();

            var themes = _nightInnDb.Themes.Select(theme => new
            {
                ThemeId = theme.ThemeId,
                ThemeName = theme.ThemeName.ToString()
            }).ToList();

            viewModel.ThemeList = new MultiSelectList(themes, "ThemeId", "ThemeName");
            
            return View(viewModel);
        }

        // POST: Drink
        [HttpPost]
        public ActionResult Create(Drink drink)
        {
            if (ModelState.IsValid)
            {
                _nightInnDb.Drinks.Add(drink);
                _nightInnDb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drink);
        }

        //GET: Delete
        //Drink/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Drink drink = _nightInnDb.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }
        //POST: Delete
        //Drink/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Drink drink = _nightInnDb.Drinks.Find(id);
            _nightInnDb.Drinks.Remove(drink);
            _nightInnDb.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET : Edit
        // Drink/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Drink drink = _nightInnDb.Drinks.Find(id);
            if (drink == null)
            {
                return HttpNotFound();
            }
            return View(drink);
        }
        //POST : Edit
        // Drink/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Drink drink)
        {
            if (ModelState.IsValid)
            {
                _nightInnDb.Entry(drink).State = System.Data.Entity.EntityState.Modified;
                _nightInnDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drink);
        }

        //GET : Details
        // Drink/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Drink drink = _nightInnDb.Drinks.Find(id);

            if (drink == null)
            {
                return HttpNotFound();
            }

            return View(drink);
        }

    }
}