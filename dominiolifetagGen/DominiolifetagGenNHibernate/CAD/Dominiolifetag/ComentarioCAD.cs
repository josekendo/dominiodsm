
using System;
using System.Text;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.Exceptions;


/*
 * Clase Comentario:
 *
 */

namespace DominiolifetagGenNHibernate.CAD.Dominiolifetag
{
public partial class ComentarioCAD : BasicCAD, IComentarioCAD
{
public ComentarioCAD() : base ()
{
}

public ComentarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public ComentarioEN ReadOIDDefault (int ID
                                    )
{
        ComentarioEN comentarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                comentarioEN = (ComentarioEN)session.Get (typeof(ComentarioEN), ID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentarioEN;
}

public System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<ComentarioEN> result = null;
        try
        {
                SessionInitializeTransaction();
                
                        if (size > 0)
                                result = session.CreateCriteria (typeof(ComentarioEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<ComentarioEN>();
                        else
                                result = session.CreateCriteria (typeof(ComentarioEN)).List<ComentarioEN>();
                SessionClose();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario.ID);

                comentarioEN.Contenido = comentario.Contenido;



                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                if (comentario.Publicacion != null) {
                        // Argumento OID y no colección.
                        comentario.Publicacion = (DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN)session.Load (typeof(DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN), comentario.Publicacion.ID);

                        comentario.Publicacion.Comentario
                        .Add (comentario);
                }
                if (comentario.Usuario != null) {
                        // Argumento OID y no colección.
                        comentario.Usuario = (DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN)session.Load (typeof(DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN), comentario.Usuario.ID);

                        comentario.Usuario.Comentario
                        .Add (comentario);
                }

                session.Save (comentario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return comentario.ID;
}

public void Modify (ComentarioEN comentario)
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), comentario.ID);

                comentarioEN.Contenido = comentario.Contenido;

                session.Update (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int ID
                     )
{
        try
        {
                SessionInitializeTransaction ();
                ComentarioEN comentarioEN = (ComentarioEN)session.Load (typeof(ComentarioEN), ID);
                session.Delete (comentarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in ComentarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
