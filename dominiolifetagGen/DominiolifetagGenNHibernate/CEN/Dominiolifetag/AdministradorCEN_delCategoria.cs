
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Administrador_delCategoria) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class AdministradorCEN
{
public bool DelCategoria (int p_oid, string idcategoria)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Administrador_delCategoria) ENABLED START*/

        // Write here your custom code...
        Boolean comprobante = true;

        try
        {
                CategoriaCAD categorias = new CategoriaCAD ();
                categorias.Destroy (Convert.ToInt32 (idcategoria));
                comprobante = false;
                return true;
        }
        finally
        {
                if (comprobante) {
                        Console.WriteLine ("No se ha podido  borrar la categoria con el id -> " + idcategoria);
                }
        }

        /*PROTECTED REGION END*/
}
}
}
