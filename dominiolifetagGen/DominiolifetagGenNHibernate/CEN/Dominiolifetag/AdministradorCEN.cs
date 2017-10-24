

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
 *      Definition of the class AdministradorCEN
 *
 */
public partial class AdministradorCEN
{
private IAdministradorCAD _IAdministradorCAD;

public AdministradorCEN()
{
        this._IAdministradorCAD = new AdministradorCAD ();
}

public AdministradorCEN(IAdministradorCAD _IAdministradorCAD)
{
        this._IAdministradorCAD = _IAdministradorCAD;
}

public IAdministradorCAD get_IAdministradorCAD ()
{
        return this._IAdministradorCAD;
}

public int New_ (string p_tipo, string p_nickname, String p_password, string p_email)
{
        AdministradorEN administradorEN = null;
        int oid;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.Tipo = p_tipo;

        administradorEN.Nickname = p_nickname;

        administradorEN.Password = Utils.Util.GetEncondeMD5 (p_password);

        administradorEN.Email = p_email;

        //Call to AdministradorCAD

        oid = _IAdministradorCAD.New_ (administradorEN);
        return oid;
}

public void Modify (int p_Administrador_OID, string p_tipo, string p_nickname, String p_password, string p_email)
{
        AdministradorEN administradorEN = null;

        //Initialized AdministradorEN
        administradorEN = new AdministradorEN ();
        administradorEN.ID = p_Administrador_OID;
        administradorEN.Tipo = p_tipo;
        administradorEN.Nickname = p_nickname;
        administradorEN.Password = Utils.Util.GetEncondeMD5 (p_password);
        administradorEN.Email = p_email;
        //Call to AdministradorCAD

        _IAdministradorCAD.Modify (administradorEN);
}

public void Destroy (int ID
                     )
{
        _IAdministradorCAD.Destroy (ID);
}
}
}
