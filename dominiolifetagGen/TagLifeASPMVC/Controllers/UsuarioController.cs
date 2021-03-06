﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using TagLifeASPMVC.Models;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace TagLifeASPMVC.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Close()
        {
            Session["iduser"] = null;
            return RedirectToAction("Index", "Usuario", new { men = "close" });
        }

        public ActionResult perfil()
        {

            UsuarioCAD cen = new UsuarioCAD();
            UsuarioEN usr;
            UsuarioCEN usuarioCEN = new UsuarioCEN();

            if (Session["iduser"] != null)
            {
                usr = cen.ReadOIDDefault(int.Parse((String)Session["iduser"]));
                if (usr != null)
                {
                    ViewBag.name = usr.Nombre;
                    ViewBag.phone = usr.Telefono;
                    ViewBag.email = usr.Email;
                    ViewBag.avatar = usr.Fotoruta;
                }
            }
            return View();
        }

        public ActionResult MisPublicaciones()
        {
            return View();
        }

        public ActionResult Reportar(int idpu)
        {
            ReporteCEN repor = new ReporteCEN();
            try
            {
                repor.New_(DateTime.Now, false, idpu);
            }
            catch (Exception e)
            {
                //no se hace nada
            }
            return RedirectToAction("Index","Publicacion", new {idpublicacion = idpu});
        }
        public ActionResult Like(int idpu)
        {
            UsuarioCAD cen = new UsuarioCAD();
            PublicacionCAD cad = new PublicacionCAD();
            UsuarioEN usr;


            if (Session["iduser"] != null)
            {
                usr = cen.ReadOIDDefault(int.Parse((String)Session["iduser"]));
                if (usr != null)
                {
                    if (usr.Listamegusta == "")
                    {
                        usr.Listamegusta = Convert.ToString(idpu);
                    }
                    else
                    {
                        String[] publis = usr.Listamegusta.Split(',');
                        if (!usr.Listamegusta.Contains(','))
                        {
                            if (!(Convert.ToString(idpu) == usr.Listamegusta))
                            {
                                usr.Listamegusta = usr.Listamegusta + "," + Convert.ToString(idpu);
                            }
                        }
                        else
                        {
                            Boolean existe = false;
                            foreach (string publica in publis)
                            {
                                if (existe == false && publica == Convert.ToString(idpu))
                                {
                                    existe = true;
                                }
                            }
                            if (!existe)
                            {
                                usr.Listamegusta = usr.Listamegusta + "," + Convert.ToString(idpu);
                            }
                        }
                    }
                }
                
                cen.Modify(usr);
            }
            ViewBag.Men = "Correcto";
            return RedirectToAction("Index", "Publicacion", new { idpublicacion = idpu, Men = "Correcto" });
        }
        public ActionResult Publi()
        {
            PublicacionCAD publiCAD = new PublicacionCAD();
            IList<PublicacionEN> publicaciones = publiCAD.ReadAllDefault(0, 0);
            UsuarioCAD usuCAD = new UsuarioCAD();
            UsuarioEN usu;

            usu = usuCAD.ReadOIDDefault(int.Parse((String)Session["iduser"]));
            IList<PublicacionEN> publiUsu = new List<PublicacionEN>();
            foreach (PublicacionEN item in publicaciones)
            {
                if (item.Usuario.ID == usu.ID)
                {
                    publiUsu.Add(item);
                }
            }

            IEnumerable<Publicacion> ulpu = new PublicacionAssembler().ConvertListENToModel(publiUsu).ToList();
            return PartialView(ulpu);
        }
        public ActionResult AgregarCateg(int idCategoria)
        {
            UsuarioCAD cen = new UsuarioCAD();
            CategoriaCAD cad = new CategoriaCAD();
            UsuarioEN usr;

            
            if (Session["iduser"] != null)
            {
                usr = cen.ReadOIDDefault(int.Parse((String)Session["iduser"]));
                if (usr != null)
                {
                    if (usr.Categoriassuscrito == "")
                    {
                        usr.Categoriassuscrito = Convert.ToString(idCategoria);
                    }
                    else
                    {
                        String[] cates = usr.Categoriassuscrito.Split(',');
                        if (!usr.Categoriassuscrito.Contains(','))
                        {
                            if (!(Convert.ToString(idCategoria) == usr.Categoriassuscrito))
                            {
                                usr.Categoriassuscrito = usr.Categoriassuscrito + "," + Convert.ToString(idCategoria);
                            }
                        }
                        else
                        {
                            Boolean existe = false;
                            foreach (string catego in cates)
                            {
                                if (existe == false && catego == Convert.ToString(idCategoria))
                                {
                                    existe = true;
                                }
                            }
                            if (!existe)
                            {
                                usr.Categoriassuscrito = usr.Categoriassuscrito + "," + Convert.ToString(idCategoria);
                            }
                        }
                    }
                }
                cen.Modify(usr);
            }
            return RedirectToAction("Index", "Usuario");
        }
        public ActionResult favoritos()
        {
            return View();
        }

        public ActionResult Subircontenido(FormCollection scont)
        {
            if (scont["nombre"] != null && scont["tipo"] != null && scont["archivo"] != null && scont["categorias"] != null)
            {
                System.Diagnostics.Debug.WriteLine("nombre: " + scont["nombre"]);
                System.Diagnostics.Debug.WriteLine("tipo: " + scont["tipo"]);
                System.Diagnostics.Debug.WriteLine("archivo: " + scont["archivo"]);
                System.Diagnostics.Debug.WriteLine("iduser: " + Session["iduser"]);

                IList<EtiquetaEN> etil = new List<EtiquetaEN>();
                IList<int> catel = new List<int>();

                string[] cateq = scont["categorias"].Split(',');
                foreach (string item in cateq)
                {
                    catel.Add(int.Parse(item));
                    System.Diagnostics.Debug.WriteLine(item);
                }

                PublicacionCEN cen = new PublicacionCEN();
                int use = cen.New_(DateTime.Today, scont["nombre"], scont["tipo"], scont["archivo"], Convert.ToInt32(Session["iduser"]), etil, catel);

                //Etiquetas
                IList<int> lista = new List<int>();
                EtiquetaCEN etiCEN = new EtiquetaCEN();
                string[] etiq = scont["etiquetas"].Split(',');
                if (etiq.Length < 1)
                {
                    etiq = new String[1];
                    etiq[0] = etiq[0];
                }
                EtiquetaCAD cad = new EtiquetaCAD();
                IList<EtiquetaEN> etique = cad.ReadAllDefault(0, 0);

                PublicacionCAD publicad = new PublicacionCAD();
                IList<PublicacionEN> publien = publicad.ReadAllDefault(0, 0);

                lista.Add(use);
                bool existe = false;
                foreach (String item in etiq)
                {
                    foreach (EtiquetaEN item2 in etique)
                    {
                        if (item2.Nombre == item)
                        {
                            existe = true;
                            //Buscar publicacion
                            foreach (PublicacionEN item3 in publien)
                            {
                                if(item3.ID == use)
                                {
                                    //agregar a la lista la nueva publicacion
                                    System.Diagnostics.Debug.WriteLine("tengo etiqueta:"+item2.Nombre + " publi:" +item3.Nombre);
                                    //item2.Publicacion.Add(item3);
                                }
                            }
                        }
                    }
                    if (existe == false)
                    {
                        int etiqueta1 = etiCEN.New_(item, lista);
                        System.Diagnostics.Debug.WriteLine(item);
                    }
                    existe = false;
                }

                System.Diagnostics.Debug.WriteLine(use + " id devuelto");
                return RedirectToAction("Index", "Usuario");
            }
            return View();
        }

        public ActionResult SearchU(String busqueda)
        {
            System.Diagnostics.Debug.WriteLine(busqueda);
            PublicacionCEN publicacionCEN = new PublicacionCEN();
            IList<PublicacionEN> ultimas = publicacionCEN.BuscarPublicaciones(true, new DateTime(1970, 1, 1), busqueda);
            IEnumerable<Publicacion> ulpu = new PublicacionAssembler().ConvertListENToModel(ultimas).ToList();
            System.Diagnostics.Debug.WriteLine(ultimas.Count);
            return View(ulpu);
        }

        public ActionResult SearchAv(String busqueda, String categoria)
        {
            System.Diagnostics.Debug.WriteLine(busqueda, categoria);
            PublicacionCEN publicacionCEN = new PublicacionCEN();
            IList<PublicacionEN> ultimas = publicacionCEN.BuscarAvanzado(true, busqueda, new DateTime(1970, 1, 1), categoria);
            IEnumerable<Publicacion> ulpu = new PublicacionAssembler().ConvertListENToModel(ultimas).ToList();
            System.Diagnostics.Debug.WriteLine(ultimas.Count);
            return View(ulpu);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginUsuario(String nickname, String email, String pass)
        {
            UsuarioCEN cen = new UsuarioCEN();
            String passencrip = Encrypt.GetMD5(pass);
            String mensaje;
            if (email.Length >= 5)//a@a.c
            {
                mensaje = cen.Login(0, email, null, pass);

                if (mensaje != "usuario incorrecto")
                {
                    Session["iduser"] = mensaje;
                    Session["password"] = pass;
                }
                System.Diagnostics.Debug.WriteLine(email + "1<--->" + pass + "devolucion ->" + mensaje);
            }
            else if (nickname.Length > 1)
            {
                mensaje = cen.Login(0, email, nickname, pass);
                if (mensaje != "usuario incorrecto")
                {
                    Session["iduser"] = mensaje;
                    Session["password"] = pass;
                }
                System.Diagnostics.Debug.WriteLine(nickname + "2<--->" + pass + "devolucion ->" + mensaje);
            }
            else
            {
                mensaje = "usuario incorrecto";
            }
            //si es correcto creamos la session con el id (seria incorrecto tendriamos que crear la seguridad debidad con claves en rsa y tal pero bueno)
            ViewBag.Men = mensaje;
            if (Session["iduser"] != null)
            {
                String idu = Convert.ToString(Session["iduser"]);
                if (idu.Length > 1)
                {
                    return RedirectToAction("Index", "Usuario", new { men = mensaje });
                }
            }
            return RedirectToAction("Index", "Home", new { men = mensaje });
        }

        public ActionResult EditarUser(String name, String phone, String email, String pwd, String pwd2, HttpPostedFileBase fil)
        {

            UsuarioCAD cen = new UsuarioCAD();
            UsuarioEN usr;
            UsuarioCEN usuarioCEN = new UsuarioCEN();
            var path = "";
            System.Diagnostics.Debug.WriteLine("comprobando perfil" + Session["iduser"]);
            if (Session["iduser"] != null)
            {
                usr = cen.ReadOIDDefault(int.Parse((String)Session["iduser"]));
                System.Diagnostics.Debug.WriteLine(int.Parse((String)Session["iduser"]));
                if (usr != null)
                {
                    System.Diagnostics.Debug.WriteLine(usr.Nickname);

                    //comprobando archivo
                    if (fil != null && fil.ContentLength > 0)
                    {
                        var nombreArchivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + Path.GetFileName(fil.FileName)).ToLower();
                        path = Path.Combine(Server.MapPath("~/App_Data/imagenesp"), nombreArchivo);

                    }
                    else
                    {
                        path = "nula";
                    }


                }

                /*asegurarme que las dos contraseñas son iguales pwd y pwd2*/
            }
            bool use = usuarioCEN.CambiarDatos(int.Parse((String)Session["iduser"]), pwd, email, name, int.Parse(phone));
            if (use != false)
            {
                //aqui subimos la imagen
                if (fil != null && fil.ContentLength > 0)
                {
                    fil.SaveAs(path);
                }

            }

            usuarioCEN.CambiarImagen(int.Parse((String)Session["iduser"]), path);

            Session["iduser"] = Convert.ToString(use);
            String mensaje2 = "registro correcto";
            return RedirectToAction("perfil", "usuario", new { men = mensaje2 });


        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegistroUser(String nick, String name, String phone, String pais, String email, String pwd, String pwd2, HttpPostedFileBase fil,String poli)
        {
            System.Diagnostics.Debug.WriteLine(nick+" - "+name+" "+phone+" "+pais+" "+email+" "+pwd+" "+pwd2+" "+poli+" ");
            UsuarioCEN cen = new UsuarioCEN();

            if (Session["iduser"] == null || (String)Session["iduser"] == "")
            {
                UsuarioEN us = new UsuarioEN();
                us.Activacion = false;
                us.Telefono = Convert.ToInt32(phone);
                us.Nombre = name;
                us.Nickname = nick;
                us.Publicacion = new List<PublicacionEN>();
                us.Pais = pais;
                us.Password = pwd;
                us.Listamegusta = "";
                us.Bloqueado = false;
                us.Categoriassuscrito = "";
                us.Email = email;
                var path = "";
                var nombreArchivo = "";
                if (fil != null && fil.ContentLength > 0)
                {
                    nombreArchivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + Path.GetFileName(fil.FileName)).ToLower();
                    path = Path.Combine(Server.MapPath("~/Images/"), nombreArchivo);
                    us.Fotoruta = path;
                }
                else
                {
                    us.Fotoruta = "nula";
                    nombreArchivo = "default.jpg";
                    path = Path.Combine(Server.MapPath("~/Images/"), nombreArchivo);
                }
                int use = cen.New_(name, email, pwd, pais, Convert.ToInt32(phone), nick, nombreArchivo, false, "", "", false, new List<PublicacionEN>());
                System.Diagnostics.Debug.WriteLine(use+" id devuelto");
                if (use != -1)
                {
                    //aqui subimos la imagen
                    if (fil != null && fil.ContentLength > 0)
                    {
                        fil.SaveAs(path);
                    }
                    Session["iduser"] = Convert.ToString(use);
                    String mensaje2 = "registro correcto";
                    return RedirectToAction("Index", "Home", new { men = mensaje2 });
                }
                //cen.New_(name, email, pwd, pais, Convert.ToInt32(phone), nick, "nula", false, "", "", false, new List<PublicacionEN>()); }
            }
            Session["iduser"] = null;
            String mensaje = "registro incorrecto";
            return RedirectToAction("Index", "Home", new { men = mensaje });
        }

        public ActionResult About()
        {
            ViewBag.Message = "Quienes somos?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contactanos";

            return View();
        }

        public class Encrypt
        {
            public static string GetMD5(string str)
            {
                System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5CryptoServiceProvider.Create();
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] stream = null;
                System.Text.StringBuilder sb = new StringBuilder();
                stream = md5.ComputeHash(encoding.GetBytes(str));
                for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
                return sb.ToString();
            }
        }
    }

}
