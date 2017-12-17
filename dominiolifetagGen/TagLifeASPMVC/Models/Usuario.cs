using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TagLifeASPMVC.Models
{
    public class Usuario
    {

        [ScaffoldColumn(false)]
        public int ID {get;set;}
        public string Nombre {get;set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public string Pais { get; set; }
        public int Telefono { get; set; }
        public string Nickname { get; set; }
        public string Fotoruta { get; set; }
        public bool Activacion { get; set; }
        public string Listamegusta { get; set; }
        public string Categoriassuscrito { get; set; }
        public bool Bloqueado { get; set; }
    }
    //modelo que nos servira para recorger los datos del login, uno de los dos estara vacio por defecto el email
    public class LoginModel
    {
        [Required]
        public string Nick { get; set; }
  
        [Required]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }
    }
}