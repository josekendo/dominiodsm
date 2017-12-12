using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Los assembler los creamos para pasar los datos en a datos que entienda el motor web 
//aqui tenemos declarado un unico dato y luego una lista 
namespace TagLifeASPMVC.Models
{
    public class AdministradorAssembler
    {
        public Administrador ConvertENToModelUI(AdministradorEN en)
        {
          Administrador cat = new Administrador();
            cat.iD = en.ID;
            cat.Tipo = en.Tipo;
            cat.Nickname = en.Nickname;
            cat.Password = en.Password;
            cat.Email = en.Email;
          return cat;
        }
        public IList<Administrador> ConvertListENToModel(IList<AdministradorEN> ens)
        {
            IList<Administrador> arts = new List<Administrador>();
            foreach (AdministradorEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}