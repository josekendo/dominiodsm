using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TagLifeASPMVC.Models
{
    public class ReporteAssembler
    {
        public Reporte ConvertENToModelUI(ReporteEN en)
        {
            Reporte cat = new Reporte();
            cat.Confirmacion = en.Confirmacion;
            cat.fecha = en.Fecha;
            cat.iD = en.ID;
            cat.IDPUBLICACION = en.Publicacion.ID;
            return cat;
        }
        public IList<Reporte> ConvertListENToModel(IList<ReporteEN> ens)
        {
            IList<Reporte> arts = new List<Reporte>();
            foreach (ReporteEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}