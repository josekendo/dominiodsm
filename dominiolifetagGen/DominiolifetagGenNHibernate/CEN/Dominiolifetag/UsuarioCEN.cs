

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.Exceptions;

using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;


namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN> Buscarusuario (string nickname, String password)
{
        return _IUsuarioCAD.Buscarusuario (nickname, Utils.Util.GetEncondeMD5 (password));
}
public int New_ (string p_nombre, string p_email, String p_password, string p_pais, int p_telefono, string p_nickname, string p_fotoruta, bool p_activacion, string p_listamegusta, string p_categoriassuscrito, bool p_bloqueado, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> p_publicacion)
{
        UsuarioEN usuarioEN = null;
        int oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nombre = p_nombre;

        usuarioEN.Email = p_email;

        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        usuarioEN.Pais = p_pais;

        usuarioEN.Telefono = p_telefono;

        usuarioEN.Nickname = p_nickname;

        usuarioEN.Fotoruta = p_fotoruta;

        usuarioEN.Activacion = p_activacion;

        usuarioEN.Listamegusta = p_listamegusta;

        usuarioEN.Categoriassuscrito = p_categoriassuscrito;

        usuarioEN.Bloqueado = p_bloqueado;

        usuarioEN.Publicacion = p_publicacion;

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.New_ (usuarioEN);
        return oid;
}

public void Modify (int p_Usuario_OID, string p_nombre, string p_email, String p_password, string p_pais, int p_telefono, string p_nickname, string p_fotoruta, bool p_activacion, string p_listamegusta, string p_categoriassuscrito, bool p_bloqueado, int p_hash)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.ID = p_Usuario_OID;
        usuarioEN.Nombre = p_nombre;
        usuarioEN.Email = p_email;
        usuarioEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        usuarioEN.Pais = p_pais;
        usuarioEN.Telefono = p_telefono;
        usuarioEN.Nickname = p_nickname;
        usuarioEN.Fotoruta = p_fotoruta;
        usuarioEN.Activacion = p_activacion;
        usuarioEN.Listamegusta = p_listamegusta;
        usuarioEN.Categoriassuscrito = p_categoriassuscrito;
        usuarioEN.Bloqueado = p_bloqueado;
        usuarioEN.Hash = p_hash;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Destroy (int ID
                     )
{
        _IUsuarioCAD.Destroy (ID);
}
}
}
