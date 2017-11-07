
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Administrador_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class AdministradorCEN
{
public string Login (int p_oid, String password, string arg2)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Administrador_login) ENABLED START*/

        // Write here your custom code...
        //esto estaria incorrecto puesto que llamamos al id del usuario (preguntar al profesor como hacer una select desde el custom)
        AdministradorEN admin = null;
        AdministradorCEN adminCEN = new AdministradorCEN (_IAdministradorCAD);

        IList<AdministradorEN> admins = adminCEN.SearchUser (arg2, password);
        if (admins != null && admins.Count >= 1) {
                admin = _IAdministradorCAD.ReadOIDDefault (admins [0].ID);
        }

        if (admin != null && password == admin.Password && (arg2 == admin.Nickname || arg2 == admin.Email)) {
                return Convert.ToString (p_oid);
        }
        else{
                return "usuario incorrecto";
        }

        /*PROTECTED REGION END*/
}
}
}
