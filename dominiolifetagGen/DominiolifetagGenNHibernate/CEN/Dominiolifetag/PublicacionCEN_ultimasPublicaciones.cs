
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Publicacion_ultimasPublicaciones) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class PublicacionCEN
{
public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> UltimasPublicaciones (string categoria)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Publicacion_ultimasPublicaciones) ENABLED START*/

        // Write here your custom code...

        try
        {
                IList<PublicacionEN> publis = _IPublicacionCAD.ListaUltimas (categoria, 0, 5);

                return publis;
        }
        catch
        {
                throw new Exception ("Method BuscarPublicaciones() ha fallado.");
        }

        throw new NotImplementedException ("Method UltimasPublicaciones() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
