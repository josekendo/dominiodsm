using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using System.Web;


namespace TagLifeASPMVC.Models
{
    public class Publicacion
    {

        [ScaffoldColumn(false)]
        public int iD {get;set;}
        public string Nombre {get;set;}
        public string Tipo { get; set; }
        public string Archivo { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
    }
}