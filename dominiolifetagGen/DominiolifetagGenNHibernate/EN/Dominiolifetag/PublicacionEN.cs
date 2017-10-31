
using System;
// Definición clase PublicacionEN
namespace DominiolifetagGenNHibernate.EN.Dominiolifetag
{
public partial class PublicacionEN
{
/**
 *	Atributo iD
 */
private int iD;



/**
 *	Atributo fecha
 */
private Nullable<DateTime> fecha;



/**
 *	Atributo nombre
 */
private string nombre;



/**
 *	Atributo tipo
 */
private string tipo;



/**
 *	Atributo archivo ruta del archivo que almacena el video,foto,audio, etc....
 */
private string archivo;



/**
 *	Atributo usuario
 */
private DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN usuario;



/**
 *	Atributo etiqueta
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN> etiqueta;



/**
 *	Atributo categoria
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN> categoria;



/**
 *	Atributo comentario
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN> comentario;



/**
 *	Atributo reporte
 */
private DominiolifetagGenNHibernate.EN.Dominiolifetag.ReporteEN reporte;






public virtual int ID {
        get { return iD; } set { iD = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual string Nombre {
        get { return nombre; } set { nombre = value;  }
}



public virtual string Tipo {
        get { return tipo; } set { tipo = value;  }
}



public virtual string Archivo {
        get { return archivo; } set { archivo = value;  }
}



public virtual DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN Usuario {
        get { return usuario; } set { usuario = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN> Etiqueta {
        get { return etiqueta; } set { etiqueta = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN> Categoria {
        get { return categoria; } set { categoria = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN> Comentario {
        get { return comentario; } set { comentario = value;  }
}



public virtual DominiolifetagGenNHibernate.EN.Dominiolifetag.ReporteEN Reporte {
        get { return reporte; } set { reporte = value;  }
}





public PublicacionEN()
{
        etiqueta = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN>();
        categoria = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN>();
        comentario = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN>();
}



public PublicacionEN(int iD, Nullable<DateTime> fecha, string nombre, string tipo, string archivo, DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN usuario, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN> etiqueta, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN> categoria, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN> comentario, DominiolifetagGenNHibernate.EN.Dominiolifetag.ReporteEN reporte
                     )
{
        this.init (ID, fecha, nombre, tipo, archivo, usuario, etiqueta, categoria, comentario, reporte);
}


public PublicacionEN(PublicacionEN publicacion)
{
        this.init (ID, publicacion.Fecha, publicacion.Nombre, publicacion.Tipo, publicacion.Archivo, publicacion.Usuario, publicacion.Etiqueta, publicacion.Categoria, publicacion.Comentario, publicacion.Reporte);
}

private void init (int ID
                   , Nullable<DateTime> fecha, string nombre, string tipo, string archivo, DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN usuario, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN> etiqueta, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN> categoria, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN> comentario, DominiolifetagGenNHibernate.EN.Dominiolifetag.ReporteEN reporte)
{
        this.ID = ID;


        this.Fecha = fecha;

        this.Nombre = nombre;

        this.Tipo = tipo;

        this.Archivo = archivo;

        this.Usuario = usuario;

        this.Etiqueta = etiqueta;

        this.Categoria = categoria;

        this.Comentario = comentario;

        this.Reporte = reporte;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        PublicacionEN t = obj as PublicacionEN;
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
