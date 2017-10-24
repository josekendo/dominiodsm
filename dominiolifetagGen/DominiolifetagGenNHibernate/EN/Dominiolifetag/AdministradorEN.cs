
using System;
// Definición clase AdministradorEN
namespace DominiolifetagGenNHibernate.EN.Dominiolifetag
{
public partial class AdministradorEN
{
/**
 *	Atributo iD
 */
private int iD;



/**
 *	Atributo tipo
 */
private string tipo;



/**
 *	Atributo nickname
 */
private string nickname;



/**
 *	Atributo password
 */
private String password;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo usuario
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN> usuario;



/**
 *	Atributo etiqueta
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN> etiqueta;



/**
 *	Atributo categoria
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN> categoria;






public virtual int ID {
        get { return iD; } set { iD = value;  }
}



public virtual string Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual string Nickname {
        get { return nickname; } set { nickname = value;  }
}



public virtual String Password {
        get { return password; } set { password = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN> Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN> Etiqueta {
        get { return etiqueta; } set { etiqueta = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN> Categoria {
        get { return categoria; } set { categoria = value;  }
}





public AdministradorEN()
{
        usuario = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN>();
        etiqueta = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN>();
        categoria = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN>();
}



public AdministradorEN(int iD, string tipo, string nickname, String password, string email, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN> usuario, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN> etiqueta, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN> categoria
                       )
{
        this.init (ID, tipo, nickname, password, email, usuario, etiqueta, categoria);
}


public AdministradorEN(AdministradorEN administrador)
{
        this.init (ID, administrador.Tipo, administrador.Nickname, administrador.Password, administrador.Email, administrador.Usuario, administrador.Etiqueta, administrador.Categoria);
}

private void init (int ID
                   , string tipo, string nickname, String password, string email, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN> usuario, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN> etiqueta, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN> categoria)
{
        this.ID = ID;


        this.Tipo = tipo;

        this.Nickname = nickname;

        this.Password = password;

        this.Email = email;

        this.Usuario = usuario;

        this.Etiqueta = etiqueta;

        this.Categoria = categoria;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdministradorEN t = obj as AdministradorEN;
        if (t == null)
                return false;
        if (ID.Equals (t.ID))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.ID.GetHashCode ();
        return hash;
}
}
}
