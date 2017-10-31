
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_cambiarDatos) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class UsuarioCEN
{
public bool CambiarDatos (int p_oid, String password, string email, string nombre, int telefono)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_cambiarDatos) ENABLED START*/

        // Write here your custom code...
        UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault (p_oid);

        //cambiar datos de usuario
        if (usuario.Password.Equals (password) == false) usuario.Password = password;
        if (usuario.Email.Equals (email) == false) usuario.Email = email;
        if (usuario.Nombre.Equals (nombre) == false) usuario.Nombre = nombre;
        if (usuario.Telefono.Equals (telefono) == false) usuario.Telefono = telefono;

        _IUsuarioCAD.Modify (usuario);
        throw new NotImplementedException ("Method CambiarDatos() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
