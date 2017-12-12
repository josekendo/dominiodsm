using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Los assembler los creamos para pasar los datos en a datos que entienda el motor web 
//aqui tenemos declarado un unico dato y luego una lista 
namespace TagLifeASPMVC.Models
{
    public class ComentarioAssembler
    {
        public Comentario ComentarioENToModelUI(ComentarioEN en)
        {
          Comentario cat = new Comentario ();
          cat.Contenido = en.Contenido;
          return cat;
        }
        public IList<Comentario> ConvertListENToModel(IList<ComentarioEN> ens)
        {
            IList<Comentario> arts = new List<Comentario>();
            foreach (ComentarioEN en in ens)
            {
                arts.Add(ComentarioENToModelUI(en));
            }
            return arts;
        }
    }
}