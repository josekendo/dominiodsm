

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

public int New_ (Nullable<DateTime> p_fecha, string p_nombre, string p_tipo, string p_archivo, int p_usuario, System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN> p_etiqueta, System.Collections.Generic.IList<int> p_categoria)
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


        publicacionEN.Categoria = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN>();
        if (p_categoria != null) {
                foreach (int item in p_categoria) {
                        DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN en = new DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN ();
                        en.ID = item;
                        publicacionEN.Categoria.Add (en);
                }
        }

        else{
                publicacionEN.Categoria = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN>();
        }

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

public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> BusquedaNormal (Nullable<DateTime> fecha, string cadena)
{
        return _IPublicacionCAD.BusquedaNormal (fecha, cadena);
}
public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> BusquedaAvanz (string cadena, Nullable<DateTime> fecha, string categoria)
{
        return _IPublicacionCAD.BusquedaAvanz (cadena, fecha, categoria);
}
public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> ListaUltimas (string categoria, int first, int size)
{
        return _IPublicacionCAD.ListaUltimas (categoria, first, size);
}
}
}
