
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
                if (publicacion.Categoria != null) {
                        for (int i = 0; i < publicacion.Categoria.Count; i++) {
                                publicacion.Categoria [i] = (DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN)session.Load (typeof(DominiolifetagGenNHibernate.EN.Dominiolifetag.CategoriaEN), publicacion.Categoria [i].ID);
                                publicacion.Categoria [i].Publicacion.Add (publicacion);
                        }
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

public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> BusquedaNormal (Nullable<DateTime> fecha, string cadena)
{
        System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PublicacionEN self where SELECT (pu) FROM PublicacionEN as pu WHERE pu.Fecha >= :fecha or pu.Nombre like :cadena";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PublicacionENbusquedaNormalHQL");
                query.SetParameter ("fecha", fecha);
                query.SetParameter ("cadena", cadena);

                result = query.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
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

        return result;
}
public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> BusquedaAvanz (string cadena, Nullable<DateTime> fecha, string categoria)
{
        System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PublicacionEN self where SELECT (pu) FROM PublicacionEN as pu inner join pu.Categoria as ca WHERE :cadena is not null and pu.Nombre like '%'+:cadena+'%' or :fecha is not null and  pu.Fecha >= :fecha or :categoria is not null and ca.Nombre = :categoria";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PublicacionENbusquedaAvanzHQL");
                query.SetParameter ("cadena", cadena);
                query.SetParameter ("fecha", fecha);
                query.SetParameter ("categoria", categoria);

                result = query.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
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

        return result;
}
public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN> ListadoComentarios (int ? idPublicacion)
{
        System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PublicacionEN self where SELECT (co) FROM PublicacionEN as pu inner join pu.Comentario as co WHERE pu.ID = :idPublicacion";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PublicacionENlistadoComentariosHQL");
                query.SetParameter ("idPublicacion", idPublicacion);

                result = query.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN>();
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

        return result;
}
public System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> ListaUltimas (string categoria, int first, int size)
{
        System.Collections.Generic.IList<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PublicacionEN self where SELECT (pu) FROM PublicacionEN as pu inner join pu.Categoria as ca WHERE ca.Nombre = :categoria ORDER BY pu.Fecha DESC";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PublicacionENlistaUltimasHQL");
                query.SetParameter ("categoria", categoria);

                if (size > 0) {
                        query.SetFirstResult (first).SetMaxResults (size);
                }
                else{
                        query.SetFirstResult (first);
                }

                result = query.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
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

        return result;
}
}
}
