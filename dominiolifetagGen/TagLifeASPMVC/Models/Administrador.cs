using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace TagLifeASPMVC.Models
{
    public class Administrador
    {

        [ScaffoldColumn(false)]//IMPORTANTE esto solo se pone en atributos que se generan solos (autogenerables como el id)
        public int iD {get;set;}



        /**
         *	Atributo nombre
         */
        public string Nickname {get;set;}

        public string Password { get; set; }

        public string Email { get; set; }

        public string Tipo { get; set; }
    }
}