
using System;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;

namespace DominiolifetagGenNHibernate.CAD.Dominiolifetag
{
public partial interface IComentarioCAD
{
ComentarioEN ReadOIDDefault (int ID
                             );

void ModifyDefault (ComentarioEN comentario);



int New_ (ComentarioEN comentario);

void Modify (ComentarioEN comentario);


void Destroy (int ID
              );
}
}
