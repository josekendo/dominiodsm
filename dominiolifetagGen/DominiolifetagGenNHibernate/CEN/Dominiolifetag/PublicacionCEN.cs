

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
 *      Definition of the class PublicacionCEN
 *
 */
public partial class PublicacionCEN
{
private IPublicacionCAD _IPublicacionCAD;

public PublicacionCEN()
{
        this._IPublicacionCAD = new PublicacionCAD ();
}

public PublicacionCEN(IPublicacionCAD _IPublicacionCAD)
{
        this._IPublicacionCAD = _IPublicacionCAD;
}

public IPublicacionCAD get_IPublicacionCAD ()
{
        return this._IPublicacionCAD;
}

public int New_ (Nullable<DateTime> p_fecha, string p_nombre, string p_tipo, string p_archivo, int p_usuario, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN> p_etiqueta, DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN p_comentario, DominiolifetagGenNHibernate.EN.Dominiolifetag.ReporteEN p_reporte)
{
        PublicacionEN publicacionEN = null;
        int oid;

        //Initialized PublicacionEN
        publicacionEN = new PublicacionEN ();
        publicacionEN.Fecha = p_fecha;

        publicacionEN.Nombre = p_nombre;

        publicacionEN.Tipo = p_tipo;

        publicacionEN.Archivo = p_archivo;


        if (p_usuario != -1) {
                // El argumento p_usuario -> Property usuario es oid = false
                // Lista de oids ID
                publicacionEN.Usuario = new DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN ();
                publicacionEN.Usuario.ID = p_usuario;
        }

        publicacionEN.Etiqueta = p_etiqueta;

        publicacionEN.Comentario = p_comentario;

        publicacionEN.Reporte = p_reporte;

        //Call to PublicacionCAD

        oid = _IPublicacionCAD.New_ (publicacionEN);
        return oid;
}

public void Modify (int p_Publicacion_OID, Nullable<DateTime> p_fecha, string p_nombre, string p_tipo, string p_archivo)
{
        PublicacionEN publicacionEN = null;

        //Initialized PublicacionEN
        publicacionEN = new PublicacionEN ();
        publicacionEN.ID = p_Publicacion_OID;
        publicacionEN.Fecha = p_fecha;
        publicacionEN.Nombre = p_nombre;
        publicacionEN.Tipo = p_tipo;
        publicacionEN.Archivo = p_archivo;
        //Call to PublicacionCAD

        _IPublicacionCAD.Modify (publicacionEN);
}

public void Destroy (int ID
                     )
{
        _IPublicacionCAD.Destroy (ID);
}
}
}
