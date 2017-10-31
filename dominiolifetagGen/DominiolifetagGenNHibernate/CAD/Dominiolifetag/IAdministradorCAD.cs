
using System;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;

namespace DominiolifetagGenNHibernate.CAD.Dominiolifetag
{
public partial interface IAdministradorCAD
{
AdministradorEN ReadOIDDefault (int ID
                                );

void ModifyDefault (AdministradorEN administrador);



int New_ (AdministradorEN administrador);

void Modify (AdministradorEN administrador);


void Destroy (int ID
              );







System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> SearchUser (string nickname, String password);
}
}
