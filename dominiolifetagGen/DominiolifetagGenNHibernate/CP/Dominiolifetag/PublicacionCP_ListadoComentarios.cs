
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;



/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CP.Dominiolifetag_Publicacion_listadoComentarios) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CP.Dominiolifetag
{
public partial class PublicacionCP : BasicCP
{
public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> ListadoComentarios (int idPublicacion)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CP.Dominiolifetag_Publicacion_listadoComentarios) ENABLED START*/

        IPublicacionCAD publicacionCAD = null;
        PublicacionCEN publicacionCEN = null;

        System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>  result = null;


        try
        {
                SessionInitializeTransaction ();
                publicacionCAD = new PublicacionCAD (session);
                publicacionCEN = new  PublicacionCEN (publicacionCAD);
                return publicacionCAD.ListadoComentarios ();


                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
