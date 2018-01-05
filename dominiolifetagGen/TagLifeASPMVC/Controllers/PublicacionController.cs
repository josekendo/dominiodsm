using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using TagLifeASPMVC.Models;

namespace TagLifeASPMVC.Controllers
{
    public class PublicacionController : Controller
    {
        //
        // GET: /Publicacion/

        //vista parcial es como hacer un pedazo de una pagina para luego cargarla (un include por decirlo de alguna forma)
        //se crea vista parcial

        public ActionResult CargarMeGusta()
        {
            UsuarioCAD cen = new UsuarioCAD();
            UsuarioEN usr;
            IList<PublicacionEN> favs = new List<PublicacionEN>();

            System.Diagnostics.Debug.WriteLine("comprobando favoritos" + Session["iduser"]);
            if (Session["iduser"] != null)
            {
                usr = cen.ReadOIDDefault(int.Parse((String)Session["iduser"]));
                System.Diagnostics.Debug.WriteLine(int.Parse((String)Session["iduser"]));
                if (usr != null)
                {
                    System.Diagnostics.Debug.WriteLine(usr.Nickname);
                    UsuarioCEN usuarioCEN = new UsuarioCEN();
                    IList<string> lista = usuarioCEN.VerListaMeGusta(int.Parse((String)Session["iduser"]));


                    foreach (String contador in lista)
                    { //Me recorro uno a uno los ids de las publicaciones
                        PublicacionCAD pubcen = new PublicacionCAD();
                        favs.Add(pubcen.ReadOIDDefault(int.Parse(contador)));
                    }

                }
            }
            IEnumerable<Publicacion> favo = new PublicacionAssembler().ConvertListENToModel(favs).ToList();
            return PartialView(favo);
        }

        public ActionResult CargarUltimasPublicaciones()
        {
            // Codigo
            PublicacionCEN publicacionCEN = new PublicacionCEN();
            IList<PublicacionEN> ultimas = publicacionCEN.UltimasPublicaciones("GATOS");
            IEnumerable<Publicacion> ulpu = new PublicacionAssembler().ConvertListENToModel(ultimas).ToList();
            return PartialView(ulpu);
        }

        public ActionResult Searchi(String busqueda)
        {
            System.Diagnostics.Debug.WriteLine(busqueda);
            PublicacionCEN publicacionCEN = new PublicacionCEN();
            IList<PublicacionEN> ultimas = publicacionCEN.BuscarPublicaciones(true, new DateTime(1970,1,1), busqueda);
            IEnumerable<Publicacion> ulpu = new PublicacionAssembler().ConvertListENToModel(ultimas).ToList();
            System.Diagnostics.Debug.WriteLine(ultimas.Count);
            return PartialView(ulpu);
        }
            public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearEtiqueta(String etiquetas)
        {
            /*System.Diagnostics.Debug.WriteLine(etiquetas);
            string[] etiqueta = etiquetas.Split(',');
            foreach (string i in etiqueta)
            {
                //Comprobar
                EtiquetaEN et = new EtiquetaEN();
                et.Nombre = i;
            }*/
            return View();
        }

        public ActionResult Asignacategoria()
        {
            return View();
        }
        //
        // GET: /Publicacion/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Publicacion/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Publicacion/Create

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
        // GET: /Publicacion/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Publicacion/Edit/5

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
        // GET: /Publicacion/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Publicacion/Delete/5

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
