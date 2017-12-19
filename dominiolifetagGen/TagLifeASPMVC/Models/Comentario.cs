using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TagLifeASPMVC.Models
{
    public class Comentario
    {

        [ScaffoldColumn(false)]
        public int ID { get; set; }



        /**
         *	Atributo nombre
         */
        public string Contenido { get; set; }
    }
}