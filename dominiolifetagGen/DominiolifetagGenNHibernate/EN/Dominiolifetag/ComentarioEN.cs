
using System;
// Definición clase ComentarioEN
namespace DominiolifetagGenNHibernate.EN.Dominiolifetag
{
public partial class ComentarioEN
{
/**
 *	Atributo iD
 */
private int iD;



/**
 *	Atributo contenido
 */
private string contenido;



/**
 *	Atributo publicacion
 */
private DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN publicacion;



/**
 *	Atributo usuario
 */
private DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN usuario;






public virtual int ID {
        get { return iD; } set { iD = value;  }
}



public virtual string Contenido {
        get { return contenido; } set { contenido = value;  }
}



public virtual DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN Publicacion {
        get { return publicacion; } set { publicacion = value;  }
}



public virtual DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}





public ComentarioEN()
{
}



public ComentarioEN(int iD, string contenido, DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN publicacion, DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN usuario
                    )
{
        this.init (ID, contenido, publicacion, usuario);
}


public ComentarioEN(ComentarioEN comentario)
{
        this.init (ID, comentario.Contenido, comentario.Publicacion, comentario.Usuario);
}

private void init (int ID
                   , string contenido, DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN publicacion, DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN usuario)
{
        this.ID = ID;


        this.Contenido = contenido;

        this.Publicacion = publicacion;

        this.Usuario = usuario;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ComentarioEN t = obj as ComentarioEN;
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
