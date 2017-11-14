
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Publicacion_buscarPublicaciones) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class PublicacionCEN
{
public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> BuscarPublicaciones (int p_oid, bool ordenacion, Nullable<DateTime> fecha, string cadena)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Publicacion_buscarPublicaciones) ENABLED START*/

        // Write here your custom code...

        try {
                IList<PublicacionEN> publis = _IPublicacionCAD.BusquedaNormal (fecha, cadena);

                return publis;
        }
        catch
        {
                throw new Exception ("Method BuscarPublicaciones() ha fallado.");
        }

        /*PROTECTED REGION END*/
}
}
}
