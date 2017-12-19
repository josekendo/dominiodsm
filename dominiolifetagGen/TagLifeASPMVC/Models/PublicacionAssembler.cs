using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TagLifeASPMVC.Models
{
    public class PublicacionAssembler
    {
        public Publicacion ConvertENToModelUI(PublicacionEN en)
        {
            Publicacion cat = new Publicacion();
            cat.Archivo = en.Archivo;
            cat.Fecha = en.Fecha;
            cat.iD = en.ID;
            cat.Nombre = en.Nombre;
            cat.Tipo = en.Tipo;
            return cat;
        }
        public IList<Publicacion> ConvertListENToModel(IList<PublicacionEN> ens)
        {
            IList<Publicacion> arts = new List<Publicacion>();
            foreach (PublicacionEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}