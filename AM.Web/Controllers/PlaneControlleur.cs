using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AM.Web.Controllers
{
    public class PlaneControlleur : Controller
    {
        IservicePlane sp;

        public PlaneControlleur(IservicePlane sp)
        {
            this.sp = sp;
        }

        // GET: PlaneControlleur
        public ActionResult Index()
        {
            return View(sp.GetAll());
        }

        // GET: PlaneControlleur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlaneControlleur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlaneControlleur/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Plane plane)
        {
            try
            {
                sp.Add(plane);
                sp.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneControlleur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlaneControlleur/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlaneControlleur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlaneControlleur/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
