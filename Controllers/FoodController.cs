using NightInn.Data;
using NightInnV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NightInnV2.Controllers
{
    public class FoodController : Controller
    {
        private ApplicationDbContext _nightInnDb = new ApplicationDbContext();

        // GET: Food
        public ActionResult Index()
        {
            List<Food> foodList = _nightInnDb.Foods.ToList();
            List<Food> orderedList = foodList.OrderBy(food => food.FoodName).ToList();
            return View(orderedList);
        }

        // GET: Food
        public ActionResult Create()
        {
            return View();
        }

        // POST: Food
        [HttpPost]
        public ActionResult Create(Food food)
        {
            if (ModelState.IsValid)
            {
                _nightInnDb.Foods.Add(food);
                _nightInnDb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(food);
        }

        //GET: Delete
        //Food/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Food food = _nightInnDb.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }
        //POST: Delete
        //Food/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Food food = _nightInnDb.Foods.Find(id);
            _nightInnDb.Foods.Remove(food);
            _nightInnDb.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET : Edit
        // Food/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Food food = _nightInnDb.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }
        //POST : Edit
        // Food/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Food food)
        {
            if (ModelState.IsValid)
            {
                _nightInnDb.Entry(food).State = System.Data.Entity.EntityState.Modified;
                _nightInnDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(food);
        }

        //GET : Details
        // Food/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Food food = _nightInnDb.Foods.Find(id);

            if (food == null)
            {
                return HttpNotFound();
            }

            return View(food);
        }
    }
}