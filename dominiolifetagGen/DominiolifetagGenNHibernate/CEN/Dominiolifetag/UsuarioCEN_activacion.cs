
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_activacion) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class UsuarioCEN
{
public bool Activacion (int p_oid, string hash)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_activacion) ENABLED START*/

        // Write here your custom code...
        UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault (p_oid);

        if (usuario.Hash.Equals (hash) == false) usuario.Activacion = true;   //activacion

        _IUsuarioCAD.Modify (usuario);
        throw new NotImplementedException ("Method Activacion() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
