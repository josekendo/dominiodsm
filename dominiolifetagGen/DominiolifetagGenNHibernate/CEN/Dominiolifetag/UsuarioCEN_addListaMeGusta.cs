
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


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_addListaMeGusta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class UsuarioCEN
{
public bool AddListaMeGusta (int p_oid, string arg1)
{
            /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Usuario_addListaMeGusta) ENABLED START*/
            // Write here your custom code...
            UsuarioEN usuario = _IUsuarioCAD.ReadOIDDefault(p_oid);//saco los datos del usuario
            usuario.Listamegusta = usuario.Listamegusta + "," + arg1;//agrego la publicacion a me gusta
            _IUsuarioCAD.Modify(usuario);//le envio al cad para que modifique los datos
            return true;//devuelvo el valor true como que se a ha realizado correctamente
            throw new NotImplementedException ("Method AddListaMeGusta() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
