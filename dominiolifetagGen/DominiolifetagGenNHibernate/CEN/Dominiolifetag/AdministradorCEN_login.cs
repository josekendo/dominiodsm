
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
            AdministradorEN admin = _IAdministradorCAD.ReadOIDDefault(p_oid);//esto estaria incorrecto puesto que llamamos al id del usuario (preguntar al profesor como hacer una select desde el custom)
            if (password == admin.Password && (arg2 == admin.Nickname || arg2 == admin.Email))
            {
                return Convert.ToString(p_oid);
            }
            else
            {
                return "usuario incorrecto";
            }

        throw new NotImplementedException ("Method Login() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
