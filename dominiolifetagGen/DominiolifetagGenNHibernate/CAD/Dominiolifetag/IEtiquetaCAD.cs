
using System;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;

namespace DominiolifetagGenNHibernate.CAD.Dominiolifetag
{
public partial interface IEtiquetaCAD
{
EtiquetaEN ReadOIDDefault (int ID
                           );

void ModifyDefault (EtiquetaEN etiqueta);



int New_ (EtiquetaEN etiqueta);

void Modify (EtiquetaEN etiqueta);


void Destroy (int ID
              );
}
}
