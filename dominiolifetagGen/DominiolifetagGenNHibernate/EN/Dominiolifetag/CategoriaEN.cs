
using System;
// Definición clase CategoriaEN
namespace DominiolifetagGenNHibernate.EN.Dominiolifetag
{
public partial class CategoriaEN
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
 *	Atributo publicacion
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion;



/**
 *	Atributo administrador
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> administrador;



/**
 *	Atributo descripcion
 */
private string descripcion;



/**
 *	Atributo edad
 */
private int edad;






public virtual int ID {
        get { return iD; } set { iD = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> Publicacion {
        get { return publicacion; } set { publicacion = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> Administrador {
        get { return administrador; } set { administrador = value;  }
}



public virtual string Descripcion {
        get { return descripcion; } set { descripcion = value;  }
}



public virtual int Edad {
        get { return edad; } set { edad = value;  }
}





public CategoriaEN()
{
        publicacion = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
        administrador = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN>();
}



public CategoriaEN(int iD, string nombre, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> administrador, string descripcion, int edad
                   )
{
        this.init (ID, nombre, publicacion, administrador, descripcion, edad);
}


public CategoriaEN(CategoriaEN categoria)
{
        this.init (ID, categoria.Nombre, categoria.Publicacion, categoria.Administrador, categoria.Descripcion, categoria.Edad);
}

private void init (int ID
                   , string nombre, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> administrador, string descripcion, int edad)
{
        this.ID = ID;


        this.Nombre = nombre;

        this.Publicacion = publicacion;

        this.Administrador = administrador;

        this.Descripcion = descripcion;

        this.Edad = edad;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        CategoriaEN t = obj as CategoriaEN;
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
