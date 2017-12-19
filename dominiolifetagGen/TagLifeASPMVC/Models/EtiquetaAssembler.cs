using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TagLifeASPMVC.Models
{
    public class EtiquetaAssembler
    {
        public Etiqueta ConvertENToModelUI(EtiquetaEN en)
        {
            Etiqueta cat = new Etiqueta();
            cat.Nombre = en.Nombre;
            cat.iD = en.ID;
            return cat;
        }
        public IList<Etiqueta> ConvertListENToModel(IList<EtiquetaEN> ens)
        {
            IList<Etiqueta> arts = new List<Etiqueta>();
            foreach (EtiquetaEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}