
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
 * Clase Etiqueta:
 *
 */

namespace DominiolifetagGenNHibernate.CAD.Dominiolifetag
{
public partial class EtiquetaCAD : BasicCAD, IEtiquetaCAD
{
public EtiquetaCAD() : base ()
{
}

public EtiquetaCAD(ISession sessionAux) : base (sessionAux)
{
}



public EtiquetaEN ReadOIDDefault (int ID
                                  )
{
        EtiquetaEN etiquetaEN = null;

        try
        {
                SessionInitializeTransaction ();
                etiquetaEN = (EtiquetaEN)session.Get (typeof(EtiquetaEN), ID);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in EtiquetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return etiquetaEN;
}

public System.Collections.Generic.IList<EtiquetaEN> ReadAllDefault (int first, int size)
{
        System.Collections.Generic.IList<EtiquetaEN> result = null;
        try
        {
                SessionInitializeTransaction();
                if (size > 0)
                                result = session.CreateCriteria (typeof(EtiquetaEN)).
                                         SetFirstResult (first).SetMaxResults (size).List<EtiquetaEN>();
                        else
                                result = session.CreateCriteria (typeof(EtiquetaEN)).List<EtiquetaEN>();
                SessionClose();
            }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in EtiquetaCAD.", ex);
        }

        return result;
}

// Modify default (Update all attributes of the class)

public void ModifyDefault (EtiquetaEN etiqueta)
{
        try
        {
                SessionInitializeTransaction ();
                EtiquetaEN etiquetaEN = (EtiquetaEN)session.Load (typeof(EtiquetaEN), etiqueta.ID);

                etiquetaEN.Nombre = etiqueta.Nombre;



                session.Update (etiquetaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in EtiquetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}


public int New_ (EtiquetaEN etiqueta)
{
        try
        {
                SessionInitializeTransaction ();
                if (etiqueta.Publicacion != null) {
                        for (int i = 0; i < etiqueta.Publicacion.Count; i++) {
                                etiqueta.Publicacion [i] = (DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN)session.Load (typeof(DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN), etiqueta.Publicacion [i].ID);
                                etiqueta.Publicacion [i].Etiqueta.Add (etiqueta);
                        }
                }

                session.Save (etiqueta);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in EtiquetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return etiqueta.ID;
}

public void Modify (EtiquetaEN etiqueta)
{
        try
        {
                SessionInitializeTransaction ();
                EtiquetaEN etiquetaEN = (EtiquetaEN)session.Load (typeof(EtiquetaEN), etiqueta.ID);

                etiquetaEN.Nombre = etiqueta.Nombre;

                session.Update (etiquetaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in EtiquetaCAD.", ex);
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
                EtiquetaEN etiquetaEN = (EtiquetaEN)session.Load (typeof(EtiquetaEN), ID);
                session.Delete (etiquetaEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in EtiquetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<EtiquetaEN> ListadoEtiquetas (int first, int size)
{
        System.Collections.Generic.IList<EtiquetaEN> result = null;
        try
        {
                SessionInitializeTransaction ();
                if (size > 0)
                        result = session.CreateCriteria (typeof(EtiquetaEN)).
                                 SetFirstResult (first).SetMaxResults (size).List<EtiquetaEN>();
                else
                        result = session.CreateCriteria (typeof(EtiquetaEN)).List<EtiquetaEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is DominiolifetagGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new DominiolifetagGenNHibernate.Exceptions.DataLayerException ("Error in EtiquetaCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
}
}
