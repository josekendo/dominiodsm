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
        public int iD {get;set;}



        /**
         *	Atributo nombre
         */
        public string Nombre {get;set;}






        /**
         *	Atributo descripcion
         */
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
}