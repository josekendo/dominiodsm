
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.Exceptions;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_verListaMeGusta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class UsuarioCEN
{
public System.Collections.Generic.IList<string> VerListaMeGusta (int p_oid)
{
            /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_verListaMeGusta) ENABLED START*/

            // Write here your custom code...

            UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault(p_oid);
            String[] publicaciones = usuario.Listamegusta.Split(separator: ',');//cortamos la lista por ,
            IList<String> lista = new List<String>();
            foreach (String contador in publicaciones)//Me recorro uno a uno los ids de las publicaciones
            {
                lista.Add(contador);//Meto cada id de cada publicacion en un item de la lista
            }
            return lista;//RETORNO LA LISTA, si no tiene elementos esta vacia

            throw new NotImplementedException ("Method VerListaMeGusta() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
