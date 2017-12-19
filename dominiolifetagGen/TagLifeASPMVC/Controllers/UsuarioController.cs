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
        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginUsuario(String nickname, String email,String pass)
        {
            UsuarioCEN cen = new UsuarioCEN();
            String passencrip = Encrypt.GetMD5(pass);
            String mensaje;
            if (email.Length > 5)//a@a.c
            {
                mensaje = cen.Login(0, email, null, pass);
                if (mensaje != "usuario incorrecto")
                {
                    Session["iduser"] = mensaje;
                    Session["password"] = passencrip;
                }
                System.Diagnostics.Debug.WriteLine(email + "1<--->" + pass);
            }
            else if (nickname.Length > 1)
            {
                mensaje = cen.Login(0, email, nickname, passencrip);
                if (mensaje != "usuario incorrecto")
                {
                    Session["iduser"] = mensaje;
                    Session["password"] = passencrip;
                }
                System.Diagnostics.Debug.WriteLine(nickname + "2<--->" + pass);
            }
            else
            {
                mensaje = "No ha introducido ningun valor valido para hacer login.";
            }
            //si es correcto creamos la session con el id (seria incorrecto tendriamos que crear la seguridad debidad con claves en rsa y tal pero bueno)
            ViewBag.Men = mensaje;
            return RedirectToAction("Index", "Home");
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
