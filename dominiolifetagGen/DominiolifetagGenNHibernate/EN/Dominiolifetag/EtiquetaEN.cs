
using System;
// Definición clase EtiquetaEN
namespace DominiolifetagGenNHibernate.EN.Dominiolifetag
{
public partial class EtiquetaEN
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





public EtiquetaEN()
{
        publicacion = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
        administrador = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN>();
}



public EtiquetaEN(int iD, string nombre, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> administrador
                  )
{
        this.init (ID, nombre, publicacion, administrador);
}


public EtiquetaEN(EtiquetaEN etiqueta)
{
        this.init (ID, etiqueta.Nombre, etiqueta.Publicacion, etiqueta.Administrador);
}

private void init (int ID
                   , string nombre, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.AdministradorEN> administrador)
{
        this.ID = ID;


        this.Nombre = nombre;

        this.Publicacion = publicacion;

        this.Administrador = administrador;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        EtiquetaEN t = obj as EtiquetaEN;
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
