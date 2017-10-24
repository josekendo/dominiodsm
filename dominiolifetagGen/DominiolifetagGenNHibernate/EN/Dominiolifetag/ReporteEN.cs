
using System;
// Definición clase ReporteEN
namespace DominiolifetagGenNHibernate.EN.Dominiolifetag
{
public partial class ReporteEN
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
 *	Atributo confirmacion
 */
private bool confirmacion;



/**
 *	Atributo publicacion
 */
private System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion;






public virtual int ID {
        get { return iD; } set { iD = value;  }
}



public virtual Nullable<DateTime> Fecha {
        get { return fecha; } set { fecha = value;  }
}



public virtual bool Confirmacion {
        get { return confirmacion; } set { confirmacion = value;  }
}



public virtual System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> Publicacion {
        get { return publicacion; } set { publicacion = value;  }
}





public ReporteEN()
{
        publicacion = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
}



public ReporteEN(int iD, Nullable<DateTime> fecha, bool confirmacion, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion
                 )
{
        this.init (ID, fecha, confirmacion, publicacion);
}


public ReporteEN(ReporteEN reporte)
{
        this.init (ID, reporte.Fecha, reporte.Confirmacion, reporte.Publicacion);
}

private void init (int ID
                   , Nullable<DateTime> fecha, bool confirmacion, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> publicacion)
{
        this.ID = ID;


        this.Fecha = fecha;

        this.Confirmacion = confirmacion;

        this.Publicacion = publicacion;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        ReporteEN t = obj as ReporteEN;
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
