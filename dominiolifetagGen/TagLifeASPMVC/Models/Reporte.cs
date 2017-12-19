using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TagLifeASPMVC.Models
{
    public class Reporte
    {

        [ScaffoldColumn(false)]
        public int iD {get;set;}
        public bool Confirmacion { get; set; }
        public Nullable<DateTime> fecha { get; set; }
    }
}