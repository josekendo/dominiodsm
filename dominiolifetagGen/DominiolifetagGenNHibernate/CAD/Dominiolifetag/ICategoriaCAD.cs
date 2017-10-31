
using System;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;

namespace DominiolifetagGenNHibernate.CAD.Dominiolifetag
{
public partial interface ICategoriaCAD
{
CategoriaEN ReadOIDDefault (int ID
                            );

void ModifyDefault (CategoriaEN categoria);



int New_ (CategoriaEN categoria);

void Modify (CategoriaEN categoria);


void Destroy (int ID
              );


System.Collections.Generic.IList<CategoriaEN> ListadoCategorias (int first, int size);
}
}
