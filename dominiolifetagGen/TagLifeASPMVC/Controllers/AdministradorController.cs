﻿using System;
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
using MvcApplication1.Controllers;

namespace TagLifeASPMVC.Controllers
{
    public class AdministradorController : BasicController
    {
        //
        // GET: /Administrador/
        //login
        public ActionResult Index(String men)
        {
            ViewBag.Men = men;
            return View();
        }

        public ActionResult ModerarComentarios(int idpublicacion)
        {
            SessionInitialize();
            PublicacionCAD cad = new PublicacionCAD(session);
            PublicacionEN publi = cad.ReadOIDDefault(idpublicacion);
            IEnumerable<Comentario> ulpu = new ComentarioAssembler().ConvertListENToModel(publi.Comentario).ToList();
            SessionClose();
            ViewBag.idpu = idpublicacion;
            return View(ulpu);
        }

        public ActionResult BorrarComentario(int idcomentario, int idpubli)
        {
            ComentarioCEN cad = new ComentarioCEN();
            cad.Destroy(idcomentario);
            return RedirectToAction("ModerarComentarios", "Administrador", new { idpublicacion = idpubli });
        }

        public ActionResult ModerarPubli(int idpu)
        {
            PublicacionCAD cad = new PublicacionCAD();
            PublicacionEN p = cad.ReadOIDDefault(idpu);
            Publicacion pu = new PublicacionAssembler().ConvertENToModelUI(p);
            return View(pu);
        }

        public ActionResult BorrarPubli(int idpublicacion)
        {
            return RedirectToAction("VerReportes", "Administrador");
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
            int musica = 0;
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
                    if (item.Tipo == "Video")
                        video++;
                    else
                        musica++;
                }
            }

            ViewBag.nr = reporte;
            ViewBag.ni = imagen;
            ViewBag.nv = video;
            ViewBag.nm = musica;
            //SessionClose();
            return View();
        }
        //se carga la session

        public ActionResult VerReportes()
        {
            ReporteCAD cad = new ReporteCAD();
            IList<ReporteEN> admins = cad.ReadAllDefault(0, 0);
            IEnumerable<Reporte> ulpu = new ReporteAssembler().ConvertListENToModel(admins).ToList();
            return View(ulpu);
        }

        public ActionResult BorrarReporte(int idreporte)
        {
            ReporteCAD cen = new ReporteCAD();
            ReporteEN re = cen.ReadOIDDefault(idreporte);
            PublicacionCAD cadp = new PublicacionCAD();
            if (re.Publicacion != null)
            {
                PublicacionEN p = cadp.ReadOIDDefault(re.Publicacion.ID);
                p.Reporte = null;
                cadp.Modify(p);
            }
            re.Publicacion = null;
            re.Confirmacion = true;
            cen.Modify(re);
            //cen.Destroy(re.ID);
            return RedirectToAction("VerReportes", "Administrador");
        }

        public ActionResult SearchMod(String busqueda)
        {
            ViewBag.Busqueda = busqueda;
            return View();
        }

        public ActionResult Close()
        {
            Session["idadmin"] = null;
            return RedirectToAction("Index", "Administrador", new { men = "close" });
        }

        public ActionResult BloquearUser(int Bloquear)
        {
            AdministradorCEN cenA = new AdministradorCEN();
            UsuarioCAD cad = new UsuarioCAD();
            UsuarioEN usu;

            usu = cad.ReadOIDDefault(Bloquear);
            cenA.BlockUser(usu.ID, Bloquear.ToString());

            return RedirectToAction("Bloquear", "Administrador", new { men = "close" });
        }

        public ActionResult Bloquear()
        {
            UsuarioCAD cad = new UsuarioCAD();
            IList<UsuarioEN> admins = cad.ReadAllDefault(0, 0);
            IList<UsuarioEN> admins1 = new List<UsuarioEN>();
            System.Diagnostics.Debug.WriteLine(admins.Count + "aqui estoy, num usuarios");
            if (admins != null)
            {
                foreach (UsuarioEN item in admins)
                {
                    if (item.Bloqueado == false)
                    {
                        admins1.Add(item);
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "NohayUsuarios";
                return View();
            }
            IEnumerable<Usuario> ulpu = new UsuarioAssembler().ConvertListENToModel(admins1).ToList();
            return View(ulpu);
        }

        public ActionResult DesbloquearUser(int Desbloquear)
        {
            //AdministradorCEN cenA = new AdministradorCEN();
            UsuarioCAD cad = new UsuarioCAD();
            UsuarioEN usu;

            usu = cad.ReadOIDDefault(Desbloquear);
            usu.Bloqueado = false;
            cad.Modify(usu);

            return RedirectToAction("Bloqueados", "Administrador", new { men = "close" });
        }

        public ActionResult Bloqueados()
        {
            UsuarioCAD cad = new UsuarioCAD();
            IList<UsuarioEN> admins = cad.ReadAllDefault(0, 0);
            IList<UsuarioEN> admins1 = new List<UsuarioEN>();
            System.Diagnostics.Debug.WriteLine(admins.Count + "aqui estoy, num usuarios");
            if (admins !=null) {
                foreach (UsuarioEN item in admins)
                {
                    if (item.Bloqueado == true)
                    {
                        admins1.Add(item);
                    }
                }
            }
            else
            {
                ViewBag.Mensaje = "NohayUsuarios";
                return View();
            }
            IEnumerable<Usuario> ulpu = new UsuarioAssembler().ConvertListENToModel(admins1).ToList();
            return View(ulpu);
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
    }
}
