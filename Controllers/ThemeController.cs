using NightInn.Data;
using NightInnV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NightInnV2.Controllers
{
    public class ThemeController : Controller
    {
        private ApplicationDbContext _nightInnDb = new ApplicationDbContext();
        // GET: Theme
        public ActionResult Index()
        {
            List<Theme> themeList = _nightInnDb.Themes.ToList();
            List<Theme> orderedList = themeList.OrderBy(theme => theme.ThemeName).ToList();
            return View(orderedList);
        }
        // GET: Theme
        public ActionResult Create()
        {
            return View();
        }

        //POST: Theme
        [HttpPost]
        public ActionResult Create(Theme theme)
        {
            if (ModelState.IsValid)
            {
                _nightInnDb.Themes.Add(theme);
                _nightInnDb.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(theme);
        }
        //GET: Delete
        // Theme/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Theme theme = _nightInnDb.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }
        // POST: Delete

        // Theme/delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Theme theme = _nightInnDb.Themes.Find(id);
            _nightInnDb.Themes.Remove(theme);
            _nightInnDb.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Edit
        // Theme/edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Theme theme = _nightInnDb.Themes.Find(id);
            if (theme == null)
            {
                return HttpNotFound();
            }
            return View(theme);
        }

        // POST: Edit
        // Theme/Edit/{id}
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Theme theme)
        {
            if (ModelState.IsValid)
            {
                _nightInnDb.Entry(theme).State = System.Data.Entity.EntityState.Modified;
                _nightInnDb.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(theme);
        }

        // GET: Details
        // Theme/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Theme theme = _nightInnDb.Themes.Find(id);

            if (theme == null)
            {
                return HttpNotFound();
            }

            return View(theme);
        }

    }
}