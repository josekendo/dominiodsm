
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_cambiarImagen) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class UsuarioCEN
{
public bool CambiarImagen (int p_oid, string ruta)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_cambiarImagen) ENABLED START*/

        // Write here your custom code...
        UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault (p_oid);

            //si son diferentes cambiamos la ruta
            if (usuario.Fotoruta.Equals(ruta) == false)
            {
                usuario.Fotoruta = ruta;
                return true;
            }
            else
            {
                return false;
            }

        /*PROTECTED REGION END*/
}
}
}
