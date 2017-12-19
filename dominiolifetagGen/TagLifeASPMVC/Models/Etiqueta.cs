using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;
//creamos el objeto nuevo para el motor web( para luego adaptar el dato en del modelo)
namespace TagLifeASPMVC.Models
{
    public class Etiqueta
    {

        [ScaffoldColumn(false)]
        public int iD {get;set;}



        /**
         *	Atributo nombre
         */
        public string Nombre {get;set;}
    }
}