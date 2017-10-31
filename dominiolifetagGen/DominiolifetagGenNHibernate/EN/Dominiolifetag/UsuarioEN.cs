
using System;
// Definición clase UsuarioEN
namespace DominiolifetagGenNHibernate.EN.Dominiolifetag
{
public partial class UsuarioEN
{
/**
 *	Atributo iD
 */
private int iD;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo email
 */
private string email;



/**
 *	Atributo password
 */
private String password;



/**
 *	Atributo pais
 */
private string pais;



/**
 *	Atributo telefono
 */
private int telefono;



/**
 *	Atributo nickname
 */
private string nickname;



/**
 *	Atributo fotoruta
 */
private string fotoruta;



/**
 *	Atributo activacion
 */
private bool activacion;



/**
 *	Atributo listamegusta
 */
private string listamegusta;



/**
 *	Atributo categoriassuscrito
 */
private string categoriassuscrito;



/**
 *	Atributo bloqueado
 */
private bool bloqueado;



/**
 *	Atributo publicacion
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN> comentario;



/**
 *	Atributo administrador
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> administrador;



/**
 *	Atributo hash
 */
private int hash;






public virtual int ID {
        get { return iD; } set { iD = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Email {
        get { return email; } set { email = value;  }
}



public virtual String Password {
        get { return password; } set { password = value;  }
}



public virtual string Pais {
        get { return pais; } set { pais = value;  }
}



public virtual int Telefono {
        get { return telefono; } set { telefono = value;  }
}



public virtual string Nickname {
        get { return nickname; } set { nickname = value;  }
}



public virtual string Fotoruta {
        get { return fotoruta; } set { fotoruta = value;  }
}



public virtual bool Activacion {
        get { return activacion; } set { activacion = value;  }
}



public virtual string Listamegusta {
        get { return listamegusta; } set { listamegusta = value;  }
}



public virtual string Categoriassuscrito {
        get { return categoriassuscrito; } set { categoriassuscrito = value;  }
}



public virtual bool Bloqueado {
        get { return bloqueado; } set { bloqueado = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> Publicacion {
        get { return publicacion; } set { publicacion = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> Administrador {
        get { return administrador; } set { administrador = value;  }
}



public virtual int Hash {
        get { return hash; } set { hash = value;  }
}





public UsuarioEN()
{
        publicacion = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
        comentario = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN>();
        administrador = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN>();
}



public UsuarioEN(int iD, string nombre, string email, String password, string pais, int telefono, string nickname, string fotoruta, bool activacion, string listamegusta, string categoriassuscrito, bool bloqueado, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN> comentario, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> administrador, int hash
                 )
{
        this.init (ID, nombre, email, password, pais, telefono, nickname, fotoruta, activacion, listamegusta, categoriassuscrito, bloqueado, publicacion, comentario, administrador, hash);
}


public UsuarioEN(UsuarioEN usuario)
{
        this.init (ID, usuario.Nombre, usuario.Email, usuario.Password, usuario.Pais, usuario.Telefono, usuario.Nickname, usuario.Fotoruta, usuario.Activacion, usuario.Listamegusta, usuario.Categoriassuscrito, usuario.Bloqueado, usuario.Publicacion, usuario.Comentario, usuario.Administrador, usuario.Hash);
}

private void init (int ID
                   , string nombre, string email, String password, string pais, int telefono, string nickname, string fotoruta, bool activacion, string listamegusta, string categoriassuscrito, bool bloqueado, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN> comentario, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> administrador, int hash)
{
        this.ID = ID;


        this.Nombre = nombre;

        this.Email = email;

        this.Password = password;

        this.Pais = pais;

        this.Telefono = telefono;

        this.Nickname = nickname;

        this.Fotoruta = fotoruta;

        this.Activacion = activacion;

        this.Listamegusta = listamegusta;

        this.Categoriassuscrito = categoriassuscrito;

        this.Bloqueado = bloqueado;

        this.Publicacion = publicacion;

        this.Comentario = comentario;

        this.Administrador = administrador;

        this.Hash = hash;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UsuarioEN t = obj as UsuarioEN;
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
