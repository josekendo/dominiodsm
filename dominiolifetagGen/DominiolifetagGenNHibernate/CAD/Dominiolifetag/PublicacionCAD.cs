
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
 * Clase Publicacion:
 *
 */

namespace DominiolifetagGenNHibernate.CAD.Dominiolifetag
{
public partial class PublicacionCAD : BasicCAD, IPublicacionCAD
{
public PublicacionCAD() : base ()
{
}

public PublicacionCAD(ISession sessionAux) : base (sessionAux)
{
}



public PublicacionEN ReadOIDDefault (int ID
                                     )
{
        PublicacionEN publicacionEN = null;

        try
        {
                SessionInitializeTransaction ();
                publicacionEN = (PublicacionEN)session.Get (typeof(PublicacionEN), ID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return publicacionEN;
}

public System.Collections.Generic.IList<PublicacionEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<PublicacionEN> result = null;
        try
        {
                using (ITransaction tx = session.BeginTransaction ())
                {
                        if (size > 0)
                                result = session.CreateCriteria (typeof(PublicacionEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<PublicacionEN>();
                        else
                                result = session.CreateCriteria (typeof(PublicacionEN)).List<PublicacionEN>();
                }
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (PublicacionEN publicacion)
{
        try
        {
                SessionInitializeTransaction ();
                PublicacionEN publicacionEN = (PublicacionEN)session.Load (typeof(PublicacionEN), publicacion.ID);

                publicacionEN.Fecha = publicacion.Fecha;


                publicacionEN.Nombre = publicacion.Nombre;


                publicacionEN.Tipo = publicacion.Tipo;


                publicacionEN.Archivo = publicacion.Archivo;






                session.Update (publicacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (PublicacionEN publicacion)
{
        try
        {
                SessionInitializeTransaction ();
                if (publicacion.Usuario != null) {
                        // Argumento OID y no colección.
                        publicacion.Usuario = (DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN)session.Load (typeof(DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN), publicacion.Usuario.ID);

                        publicacion.Usuario.Publicacion
                        .Add (publicacion);
                }
                if (publicacion.Etiqueta != null) {
                        foreach (DominiolifetagGenNHibernate.EN.Dominiolifetag.EtiquetaEN item in publicacion.Etiqueta) {
                                item.Publicacion = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
                                item.Publicacion.Add (publicacion);
                                session.Save (item);
                        }
                }
                if (publicacion.Comentario != null) {
                        // p_comentario
                        publicacion.Comentario.Publicacion.Add (publicacion);
                        session.Save (publicacion.Comentario);
                }
                if (publicacion.Reporte != null) {
                        // p_reporte
                        publicacion.Reporte.Publicacion.Add (publicacion);
                        session.Save (publicacion.Reporte);
                }

                session.Save (publicacion);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return publicacion.ID;
}

public void Modify (PublicacionEN publicacion)
{
        try
        {
                SessionInitializeTransaction ();
                PublicacionEN publicacionEN = (PublicacionEN)session.Load (typeof(PublicacionEN), publicacion.ID);

                publicacionEN.Fecha = publicacion.Fecha;


                publicacionEN.Nombre = publicacion.Nombre;


                publicacionEN.Tipo = publicacion.Tipo;


                publicacionEN.Archivo = publicacion.Archivo;

                session.Update (publicacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
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
                PublicacionEN publicacionEN = (PublicacionEN)session.Load (typeof(PublicacionEN), ID);
                session.Delete (publicacionEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in PublicacionCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
