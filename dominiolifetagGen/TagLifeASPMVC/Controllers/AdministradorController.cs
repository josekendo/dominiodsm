﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using TagLifeASPMVC.Models;

namespace TagLifeASPMVC.Controllers
{
    public class AdministradorController : Controller
    {
        //
        // GET: /Administrador/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Administrador/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Administrador/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrador/Create

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
        // GET: /Administrador/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Administrador/Edit/5

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
        // GET: /Administrador/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Administrador/Delete/5

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
