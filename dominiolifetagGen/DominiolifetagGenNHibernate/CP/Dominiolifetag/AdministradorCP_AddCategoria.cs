
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;



/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CP.Dominiolifetag_Administrador_addCategoria) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CP.Dominiolifetag
{
public partial class AdministradorCP : BasicCP
{
public DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN AddCategoria (string nombreCategoria, string descrip, int edad)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CP.Dominiolifetag_Administrador_addCategoria) ENABLED START*/

        IAdministradorCAD administradorCAD = null;
        AdministradorCEN administradorCEN = null;
        CategoriaEN result = null;

        try
        {
                SessionInitializeTransaction ();
                administradorCAD = new AdministradorCAD (session);
                administradorCEN = new  AdministradorCEN (administradorCAD);
                //Initialized AdministradorEN
                CategoriaEN cateNew = new CategoriaEN ();
                CategoriaCAD cateCAD = new CategoriaCAD (session);
                cateNew.Descripcion = descrip;
                cateNew.Edad = edad;
                cateNew.Nombre = nombreCategoria;
                cateCAD.New_ (cateNew); //finalmente enviamos la nueva categoria al cad para que la cree
                result = cateNew;
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
