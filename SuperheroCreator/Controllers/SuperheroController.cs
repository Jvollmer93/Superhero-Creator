using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperheroCreator.Models;
using System.Data.Entity;

namespace SuperheroCreator.Controllers
{
    public class SuperheroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Superhero
        public ActionResult Index()
        {
            ViewBag.superheroId = new SelectList(db.Superheroes, "ID", "Name");
            return View();
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                db.Superheroes.Add(superhero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superhero);
        }
        //GET
        public ActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(superhero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(superhero);
        }
    }
}