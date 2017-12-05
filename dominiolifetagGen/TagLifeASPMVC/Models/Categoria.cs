using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TagLifeASPMVC.Models
{
    public class Categoria
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
        public string Descripcion { get; set; }



        /**
         *	Atributo edad
         */
        public int edad {get;set;}
    }
}