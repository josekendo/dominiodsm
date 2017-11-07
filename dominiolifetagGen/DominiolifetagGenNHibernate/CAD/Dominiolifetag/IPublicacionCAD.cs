
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





System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> BusquedaNormal (Nullable<DateTime> fecha, string cadena);


System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> BusquedaAvanz (string cadena, Nullable<DateTime> fecha, string categoria);


System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> ListadoComentarios ();


System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> ListaUltimas (string categoria, int first, int size);
}
}
