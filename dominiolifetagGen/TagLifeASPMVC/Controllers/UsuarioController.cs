using System;
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


            [HttpPost]
            [AllowAnonymous]
            public ActionResult RegistroUser(string nick, string name, string phone, string pais, string email, String pwd, String pwd2, HttpPostedFileBase fil, string poli)
            {
                System.Diagnostics.Debug.WriteLine(nick + " - " + name + " " + phone + " " + pais + " " + email + " " + pwd + " " + pwd2 + " " + poli + " ");
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
                        path = Path.Combine(Server.MapPath("~/App_Data/imagenesp"), nombreArchivo);
                        us.Fotoruta = path;
                    }
                    else
                    {
                        us.Fotoruta = "nula";
                        nombreArchivo = "default.jpg";
                    }
                    int use = cen.New_(name, email, pwd, pais, Convert.ToInt32(phone), nick, nombreArchivo, false, "", "", false, new List<PublicacionEN>());
                    System.Diagnostics.Debug.WriteLine(use + " id devuelto");
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

                }
                Session["iduser"] = null;
                String mensaje = "registro incorrecto";
                return RedirectToAction("Index", "Home", new { men = mensaje });
            }


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

        public ActionResult favoritos()
        {
            return View();
        }

        public ActionResult Subircontenido()
        {
            return View();
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
                System.Diagnostics.Debug.WriteLine(email + "1<--->" + pass +"devolucion ->"+ mensaje);
            }
            else if (nickname.Length > 1)
            {
                mensaje = cen.Login(0, email, nickname, pass);
                if (mensaje != "usuario incorrecto")
                {
                    Session["iduser"] = mensaje;
                    Session["password"] = pass;
                }
                System.Diagnostics.Debug.WriteLine(nickname + "2<--->" + pass+ "devolucion ->" + mensaje);
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


        [HttpPost]
        [AllowAnonymous]
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
        

        /*** PARTE INICIO USUARIO (ENLACES) ***/
        /*public ActionResult EnlacesPublicacionUsuario()
        {
            PublicacionCEN publicacionCEN = new PublicacionCEN();
            UsuarioCAD cen = new UsuarioCAD();
            UsuarioEN usr;

            if (Session["iduser"] != null)
            {
                usr = cen.ReadOIDDefault(int.Parse((String)Session["iduser"]));

                if (usr != null)
                {

                    publicacionCEN.ListadoComentarios(idPublicacion:);
                }
            }

        }*/
        /*** Recoger todas las publicaciones del usuario ***/
       /* public ActionResult RecogerUltimasPublicaciones()
        {

            PublicacionCEN publicacionCEN = new PublicacionCEN();
            UsuarioCAD cen = new UsuarioCAD();
            UsuarioEN usr;

            if (Session["iduser"] == null)
            {
                usr = cen.ReadOIDDefault(int.Parse((String)Session["iduser"]));

                if (usr == null){

                    return RedirectToAction("Index", "Home", new { men = "usuario incorrecto" });
                   
                }
            }
            IList<PublicacionEN> ultimas = publicacionCEN.UltimasPublicaciones("GATOS");
            IEnumerable<Publicacion> ulpu = new PublicacionAssembler().ConvertListENToModel(ultimas).ToList();
            return PartialView(ulpu);
        }
        */

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
           

