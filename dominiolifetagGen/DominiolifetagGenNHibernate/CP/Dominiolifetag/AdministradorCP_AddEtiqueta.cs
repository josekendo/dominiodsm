
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;



/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CP.Dominiolifetag_Administrador_addEtiqueta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CP.Dominiolifetag
{
public partial class AdministradorCP : BasicCP
{
public DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN AddEtiqueta (string nombreEtiqueta, int publicacionID)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CP.Dominiolifetag_Administrador_addEtiqueta) ENABLED START*/

        IAdministradorCAD administradorCAD = null;
        AdministradorCEN administradorCEN = null;

        DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN result = null;


        try
        {
                SessionInitializeTransaction ();
                administradorCAD = new AdministradorCAD (session);
                administradorCEN = new  AdministradorCEN (administradorCAD);
                EtiquetaCAD etiCAD = new EtiquetaCAD (session);
                EtiquetaCEN etiCEN = new EtiquetaCEN (etiCAD);
                PublicacionCAD publiCAD = new PublicacionCAD (session);

                //obtenemos la publicacion
                PublicacionEN publicacionEN = publiCAD.ReadOIDDefault (publicacionID);
                //creamos el objeto en
                EtiquetaEN etiEN = new EtiquetaEN ();
                etiEN.Nombre = nombreEtiqueta;
                etiEN.Publicacion.Add (publicacionEN);
                //enviamos al cad del categoria para finalizar
                etiCAD.New_ (etiEN);
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
