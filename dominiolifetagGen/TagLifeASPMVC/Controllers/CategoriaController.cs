using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using TagLifeASPMVC.Models;

namespace TagLifeASPMVC.Controllers
{
    public class CategoriaController : Controller
    {
        //
        // GET: /Categoria/

        public ActionResult Index()
        {
            CategoriaCAD cad = new CategoriaCAD();
            IList<CategoriaEN> lista = cad.ReadAllDefault(0, -1);
            IEnumerable<Categoria> listEN = new CategoriaAssembler().ConvertListENToModel(lista).ToList();
            return RedirectToAction("Listar");
        }

        public ActionResult categorias()
        {
            CategoriaCAD cad = new CategoriaCAD();
            //que empieze por la categoria 1 y saque 6
            IList<CategoriaEN> lista = cad.ListadoCategorias(1, 6);
            ViewData["listas"] = lista;
            return View();
        }

        //
        // GET: /Categoria/Details/5

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CrearCategoria(String nombre, String descripcion, String edad)
        {
            CategoriaCAD cen = new CategoriaCAD();
            CategoriaEN us = new CategoriaEN();
            if (Session["idadmin"] != null || (String)Session["idadmin"] != "")
            {                
                us.Nombre = nombre;
                us.Descripcion = descripcion;
                us.Edad = Convert.ToInt32(edad);

            }
            int use = cen.New_(us);

            if (use != -1)
            {               
                String mensaje2 = "categoria creada";
                return RedirectToAction("Categorias", "Publicacion", new { men = mensaje2 });
            }
        
            String mensaje = "categoria incorrecta";

            return RedirectToAction("Categorias", "Publicacion", new { men = mensaje });
        }

		
		[HttpPost]
        [AllowAnonymous]
        public ActionResult BorrarCategoria(int dato)
        {
            CategoriaCAD cen = new CategoriaCAD();
            CategoriaEN us = new CategoriaEN();
            if (Session["idadmin"] != null || (String)Session["idadmin"] != "")
            {
                //no se si falta convertir de alguna forma dato para usarlo
                cen.Destroy(dato);
                String mensaje2 = "categoria eliminada";
                return RedirectToAction("Categorias", "Publicacion", new { men = mensaje2 });
            }
        
            String mensaje = "error";

            return RedirectToAction("Categorias", "Publicacion", new { men = mensaje });
        }
		
            public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Categoria/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Categoria/Create

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
        // GET: /Categoria/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Categoria/Edit/5

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
        // GET: /Categoria/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Categoria/Delete/5

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
