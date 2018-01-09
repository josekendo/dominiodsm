
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class UsuarioCEN
{
public string Login (int p_oid, string email, string nickname, String password)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_login) ENABLED START*/

        // Write here your custom code...

        UsuarioEN usuario = null;
        UsuarioCEN usuarioCEN = new UsuarioCEN (_IUsuarioCAD);

        IList<UsuarioEN> users = null;

        if (nickname != null) {
                users = usuarioCEN.Buscarusuario (nickname, password);
            }
        else{
                users = usuarioCEN.Buscarusuario (email, password);
            }

        if (users != null && users.Count == 1 && Utils.Util.GetEncondeMD5(password) == users[0].Password)
        {
                usuario = _IUsuarioCAD.ReadOIDDefault (users [0].ID);
        }

        if (usuario != null)
        {
                return Convert.ToString (Convert.ToString(usuario.ID));
        }
        else{
                return "usuario incorrecto";
        }

        /*PROTECTED REGION END*/
}
}
}
