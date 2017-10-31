
using System;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;

namespace DominiolifetagGenNHibernate.CAD.Dominiolifetag
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int ID
                          );

void ModifyDefault (UsuarioEN usuario);



int New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (int ID
              );











System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN> Buscarusuario (string nickname, String password);
}
}
