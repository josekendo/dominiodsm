
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Administrador_addEtiqueta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class AdministradorCEN
{
public bool AddEtiqueta (int p_oid, string idcategoria)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Administrador_addEtiqueta) ENABLED START*/

        // Write here your custom code...

        Boolean comprobante = true;

        try
        {
                EtiquetaEN eti = new EtiquetaEN ();
                eti.Nombre = idcategoria;
                EtiquetaCAD etiquetas = new EtiquetaCAD ();
                etiquetas.New_ (eti);
                comprobante = false;
                return true;
        }
        finally
        {
                if (comprobante) {
                        Console.WriteLine ("No se ha podido  crear la etiqueta -> " + idcategoria);
                }
        }

        throw new NotImplementedException ("Method AddEtiqueta() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
