
using System;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;

namespace DominiolifetagGenNHibernate.CAD.Dominiolifetag
{
public partial interface IPublicacionCAD
{
PublicacionEN ReadOIDDefault (int ID
                              );

void ModifyDefault (PublicacionEN publicacion);



int New_ (PublicacionEN publicacion);

void Modify (PublicacionEN publicacion);


void Destroy (int ID
              );
}
}
