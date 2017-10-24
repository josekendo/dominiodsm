

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
 *      Definition of the class ComentarioCEN
 *
 */
public partial class ComentarioCEN
{
private IComentarioCAD _IComentarioCAD;

public ComentarioCEN()
{
        this._IComentarioCAD = new ComentarioCAD ();
}

public ComentarioCEN(IComentarioCAD _IComentarioCAD)
{
        this._IComentarioCAD = _IComentarioCAD;
}

public IComentarioCAD get_IComentarioCAD ()
{
        return this._IComentarioCAD;
}

public int New_ (string p_contenido, System.Collections.Generic.IList<int> p_publicacion, System.Collections.Generic.IList<int> p_usuario)
{
        ComentarioEN comentarioEN = null;
        int oid;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.Contenido = p_contenido;


        comentarioEN.Publicacion = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
        if (p_publicacion != null) {
                foreach (int item in p_publicacion) {
                        DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN en = new DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN ();
                        en.ID = item;
                        comentarioEN.Publicacion.Add (en);
                }
        }

        else{
                comentarioEN.Publicacion = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
        }


        comentarioEN.Usuario = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN>();
        if (p_usuario != null) {
                foreach (int item in p_usuario) {
                        DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN en = new DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN ();
                        en.ID = item;
                        comentarioEN.Usuario.Add (en);
                }
        }

        else{
                comentarioEN.Usuario = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN>();
        }

        //Call to ComentarioCAD

        oid = _IComentarioCAD.New_ (comentarioEN);
        return oid;
}

public void Modify (int p_Comentario_OID, string p_contenido)
{
        ComentarioEN comentarioEN = null;

        //Initialized ComentarioEN
        comentarioEN = new ComentarioEN ();
        comentarioEN.ID = p_Comentario_OID;
        comentarioEN.Contenido = p_contenido;
        //Call to ComentarioCAD

        _IComentarioCAD.Modify (comentarioEN);
}

public void Destroy (int ID
                     )
{
        _IComentarioCAD.Destroy (ID);
}
}
}
