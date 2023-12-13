﻿using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AM.Web.Controllers
{
    public class FlightController : Controller
    {
        IServiceFlight sf;
        IservicePlane sp;

        public FlightController(IServiceFlight sf, IservicePlane sp)
        {
            this.sf = sf;
            this.sp = sp;
        }

        //public FlightController(IServiceFlight sf)
        //{
        //    this.sf = sf;
        //}

        // GET: FlightController
        public ActionResult Index()
        {
            return View(sf.GetAll());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.planeList = new SelectList(sp.GetAll(), "PlaneId", "Capacity");

            
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight, IFormFile AirlineLogo)
        {
            //try
            //{
            //    sf.Add(flight);
            //    sf.Commit();
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
            try
            {
                if (AirlineLogo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",

                    AirlineLogo.FileName);

                    Stream stream = new FileStream(path, FileMode.Create);
                    AirlineLogo.CopyTo(stream);
                    flight.AirlineLogo = AirlineLogo.FileName;
                }
                sf.Add(flight);
                sf.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FlightController/Edit/5
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

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FlightController/Delete/5
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
