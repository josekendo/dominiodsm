
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_verCategoria) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class UsuarioCEN
{
public System.Collections.Generic.IList<int> VerCategoria (int p_oid)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_verCategoria) ENABLED START*/

        // Write here your custom code...
        UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault (p_oid);

        String [] categorias = usuario.Categoriassuscrito.Split (separator: ',');   //cortamos la lista por ,
        IList<int> lista = new List<int>();
        foreach (String contador in categorias) {  //Me recorro uno a uno los ids de la categoria
                lista.Add (Convert.ToInt32 (contador)); //Meto cada id de cada categoria en un item de la lista
        }
        return lista;    //RETORNO LA LISTA, si no tiene elementos esta vacia
        throw new NotImplementedException ("Method VerCategoria() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
