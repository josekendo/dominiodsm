using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Los assembler los creamos para pasar los datos en a datos que entienda el motor web 
//aqui tenemos declarado un unico dato y luego una lista 
namespace TagLifeASPMVC.Models
{
    public class UsuarioAssembler
    {
        public Usuario ConvertENToModelUI(UsuarioEN en)
        {
            Usuario cat = new Usuario();
            cat.ID = en.ID;
            cat.Nickname = en.Nickname;
            cat.Password = en.Password;
            cat.Email = en.Email;
            cat.Activacion = en.Activacion;
            cat.Listamegusta = en.Nombre;
            cat.Pais = en.Pais;
            cat.Fotoruta = en.Fotoruta;
            cat.Categoriassuscrito = en.Categoriassuscrito;
            cat.Bloqueado = en.Bloqueado;
            cat.Telefono = en.Telefono;
            cat.Nombre = en.Nombre;

          return cat;
        }
        public IList<Usuario> ConvertListENToModel(IList<UsuarioEN> ens)
        {
            IList<Usuario> arts = new List<Usuario>();
            foreach (UsuarioEN en in ens)
            {
                arts.Add(ConvertENToModelUI(en));
            }
            return arts;
        }
    }
}