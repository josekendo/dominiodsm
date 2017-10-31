
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_addCategoria) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class UsuarioCEN
{
public bool AddCategoria (int p_oid, string idcategoria)
{
            /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_addCategoria) ENABLED START*/

            // Write here your custom code...
            UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault(p_oid);
            usuario.Categoriassuscrito = usuario.Categoriassuscrito + "," + idcategoria;
            _IUsuarioCAD.Modify(usuario);
            return true;
            throw new NotImplementedException ("Method AddCategoria() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
