
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Administrador_blockUser) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class AdministradorCEN
{
public bool BlockUser (int p_oid, string iduser)
{
            /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Administrador_blockUser) ENABLED START*/

            // Write here your custom code...
            AdministradorEN admin = _IAdministradorCAD.ReadOIDDefault(p_oid);//esto puede saltar error si no encuentra el id

            /*preguntar si funciona*/
            UsuarioCAD usuario = new UsuarioCAD();
            UsuarioEN user = usuario.ReadOIDDefault(p_oid);//esto tambien podria saltar error ..... creo yo preguntar tambien
            user.Bloqueado = true;

            usuario.Modify(user);//confirmamos en el cambio con el cad

            return true;

            throw new NotImplementedException ("Method BlockUser() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
