
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;



/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CP.Dominiolifetag_Administrador_delCategoria) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CP.Dominiolifetag
{
public partial class AdministradorCP : BasicCP
{
public void DelCategoria (int categoriaID)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CP.Dominiolifetag_Administrador_delCategoria) ENABLED START*/

        IAdministradorCAD administradorCAD = null;
        AdministradorCEN administradorCEN = null;
        ICategoriaCAD icad = null;
        CategoriaCEN icen = null;


        try
        {
                SessionInitializeTransaction ();
                administradorCAD = new AdministradorCAD (session);
                administradorCEN = new  AdministradorCEN (administradorCAD);
                icad = new CategoriaCAD (session);
                icen = new CategoriaCEN (icad);
                icen.Destroy (categoriaID);

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


        /*PROTECTED REGION END*/
}
}
}
