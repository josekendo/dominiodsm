using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Los assembler los creamos para pasar los datos en a datos que entienda el motor web 
//aqui tenemos declarado un unico dato y luego una lista 
namespace TagLifeASPMVC.Models
{
    public class CategoriaAssembler
    {
        public Categoria ConvertENToModelUI(CategoriaEN en)
        {
          Categoria cat = new Categoria ();
          cat.Descripcion = en.Descripcion;
          cat.edad = en.Edad;
          cat.Nombre = en.Nombre;
           return cat;
        }
        public IList<Categoria> ConvertListENToModel(IList<CategoriaEN> ens)
        {
            IList<Categoria> arts = new List<Categoria>();
            foreach (CategoriaEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}