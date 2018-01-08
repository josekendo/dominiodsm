using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using TagLifeASPMVC.Models;
using System.Collections;
using System.IO;

namespace TagLifeASPMVC.Controllers
{
    public class AdministradorController : Controller
    {
        //
        // GET: /Administrador/
        //login
        public ActionResult Index(String men)
        {
            ViewBag.Men = men;
            return View();
        }
        public ActionResult bloquear()
        {
            return View();
        }
        public ActionResult edicion()
        {
            return View();
        }
        public ActionResult categorias()
        {
            return View();
        }
        //pagina de inicio
        public ActionResult Menu()
        {
            AdministradorCAD cen = new AdministradorCAD();
            AdministradorEN adm;
            System.Diagnostics.Debug.WriteLine("comprobando menu"+Session["idadmin"]);
            if (Session["idadmin"] != null)
            {
                adm = cen.ReadOIDDefault(int.Parse((String)Session["idadmin"]));
                System.Diagnostics.Debug.WriteLine(int.Parse((String)Session["idadmin"]));
                if (adm != null)
                {
                    System.Diagnostics.Debug.WriteLine(adm.Nickname + "1<--->" + adm.Tipo);
                    ViewBag.Tipo = adm.Tipo;
                }
            }
            return View();
        }
        //redireccion login
        public ActionResult Login(String email, String pass)
        {
            AdministradorCEN cen = new AdministradorCEN();
            String mensaje;
            if (email.Length > 5)//a@a.c
            {
                mensaje = cen.Login(0, pass, email);
                if (mensaje != "usuario incorrecto")
                {
                    Session["idadmin"] = mensaje;
                }
                System.Diagnostics.Debug.WriteLine(email + "1<--->" + pass);
            }
            else
            {
                mensaje = "usuario incorrecto";
            }
            //si es correcto creamos la session con el id (seria incorrecto tendriamos que crear la seguridad debidad con claves en rsa y tal pero bueno)
            ViewBag.Men = mensaje;
            if (Session["idadmin"] != null)
            {
                String idu = Convert.ToString(Session["idadmin"]);
                if (idu.Length > 1)
                {
                    return RedirectToAction("Menu", "Administrador", new { men = "Correcto" });
                }
            }
            return RedirectToAction("Index", "Administrador", new { men = mensaje });
        }
        //metodo para desbloquear usuarios bloqueados
        /*public ActionResult desbloquear()
        {
            
            UsuarioCAD cen = new UsuarioCAD();
            IList<UsuarioEN> ultimas = cen.Buscarusuario();

        }*/

        //pagina de estadisticas
        public ActionResult Estadisticas()
        {
            //SessionInitialize();
            PublicacionCAD cen = new PublicacionCAD();
            IList<PublicacionEN> lista= cen.ReadAllDefault(0,0);
            ViewBag.np = lista.Count;
            int reporte = 0;
            int imagen = 0;
            int video = 0;
            foreach (PublicacionEN item in lista)
            {
                if (item.Reporte != null)
                {
                    reporte++;
                }
                if (item.Tipo == "Imagen")
                {
                    imagen++;
                }
                else
                {
                    video++;
                }
            }

            ViewBag.nr = reporte;
            ViewBag.ni = imagen;
            ViewBag.nv = video;
            //SessionClose();
            return View();
        }
        //se carga la session
        public ActionResult Close()
        {
            Session["idadmin"] = null;
            return RedirectToAction("Index", "Administrador", new { men = "close" });
        }
        //pagina de edicion de usuario
        public ActionResult ListaUsuarios(String men)
        {
            if (men != null && men.Length > 0)
            {
                ViewBag.Info = men;
            }
            UsuarioCAD cad = new UsuarioCAD();
            IList<UsuarioEN> admins = cad.ReadAllDefault(0, 0);
            System.Diagnostics.Debug.WriteLine(admins.Count+"aqui estoy, num usuarios");
            IEnumerable<Usuario> ulpu = new UsuarioAssembler().ConvertListENToModel(admins).ToList();
            return View(ulpu);
        }

        public ActionResult EdicionU(FormCollection sele, String sel1, String pass)
        {
            System.Diagnostics.Debug.WriteLine(sele[0]);
            if (sele[0] != "camp" && sele[0] != "del")
            {
                if (sel1 == "del")
                {
                    UsuarioCEN cen = new UsuarioCEN();
                    String[] users = sele[0].Split(',');
                    if (users.Length < 1)
                    {
                        users = new String[1];
                        users[0] = sele[0];
                    }

                    foreach (String item in users)
                    {
                        cen.Destroy(int.Parse(item));
                    }

                    return RedirectToAction("ListaUsuarios", "Administrador", new { men = "correcto" });
                }

                if (sel1 == "camp" && pass.Length > 0)
                {
                    UsuarioCEN cen = new UsuarioCEN();
                    UsuarioCAD cad = new UsuarioCAD();
                    String[] users = sele[0].Split(',');
                    if (users.Length < 1)
                    {
                        users = new String[1];
                        users[0] = sele[0];
                    }
                    foreach (String item in users)
                    {
                        UsuarioEN us = cad.ReadOIDDefault(int.Parse(item));
                        
                        cen.Modify(us.ID, us.Nombre, us.Email, pass, us.Pais, us.Telefono, us.Nickname, us.Fotoruta, us.Activacion, us.Listamegusta, us.Categoriassuscrito, us.Bloqueado, us.Hash);
                    }
                    return RedirectToAction("ListaUsuarios", "Administrador", new { men = "cambio" });
                }
            }

            return RedirectToAction("ListaUsuarios", "Administrador", new { men = "nada" });
        }

        //pagina de edicion de moderador
        public ActionResult EditarModerador(String men)
        {
            if(men != null && men.Length > 0)
            {
                ViewBag.Info = men;
            }
            AdministradorCAD cad = new AdministradorCAD();
            IList<AdministradorEN> admins = cad.ReadAllDefault(0,0);
            IEnumerable<Administrador> ulpu = new AdministradorAssembler().ConvertListENToModel(admins).ToList();
            return View(ulpu);
        }

        public ActionResult EdicionM(FormCollection sele,String sel1, String pass)
        {
            System.Diagnostics.Debug.WriteLine(sele[0]);
            if (sele[0] != "camp" && sele[0] != "del")
            {
                if (sel1 == "del")
                {
                    AdministradorCEN cen = new AdministradorCEN();
                    String [] users= sele[0].Split(',');
                    if (users.Length < 1)
                    {
                        users = new String[1];
                        users[0] = sele[0];
                    }

                        foreach (String item in users)
                        {
                            cen.Destroy(int.Parse(item));
                        }

                        return RedirectToAction("EditarModerador", "Administrador", new { men = "correcto" });
                }

                if (sel1 == "camp" && pass.Length > 0)
                {
                    AdministradorCEN cen = new AdministradorCEN();
                    AdministradorCAD cad = new AdministradorCAD();
                    String[] users = sele[0].Split(',');
                    if (users.Length < 1)
                    {
                        users = new String[1];
                        users[0] = sele[0];
                    }
                    foreach (String item in users)
                        {
                            AdministradorEN us = cad.ReadOIDDefault(int.Parse(item));
                            cen.Modify(us.ID, us.Tipo, us.Nickname, pass, us.Email);
                        }
                        return RedirectToAction("EditarModerador", "Administrador", new { men = "cambio" });
                }
            }

            return RedirectToAction("EditarModerador", "Administrador", new { men = "nada" });
        }
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
