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
        public Comentario ConvertENToModelUI(ComentarioEN en)
        {
          Comentario cat = new Comentario ();
          cat.Contenido = en.Contenido;
          cat.iD = en.ID;
          return cat;
        }
        public IList<Comentario> ConvertListENToModel(IList<ComentarioEN> ens)
        {
            IList<Comentario> arts = new List<Comentario>();
            foreach (ComentarioEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}