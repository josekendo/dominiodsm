

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
 *      Definition of the class EtiquetaCEN
 *
 */
public partial class EtiquetaCEN
{
private IEtiquetaCAD _IEtiquetaCAD;

public EtiquetaCEN()
{
        this._IEtiquetaCAD = new EtiquetaCAD ();
}

public EtiquetaCEN(IEtiquetaCAD _IEtiquetaCAD)
{
        this._IEtiquetaCAD = _IEtiquetaCAD;
}

public IEtiquetaCAD get_IEtiquetaCAD ()
{
        return this._IEtiquetaCAD;
}

public int New_ (string p_nombre, System.Collections.Generic.IList<int> p_publicacion)
{
        EtiquetaEN etiquetaEN = null;
        int oid;

        //Initialized EtiquetaEN
        etiquetaEN = new EtiquetaEN ();
        etiquetaEN.Nombre = p_nombre;


        etiquetaEN.Publicacion = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
        if (p_publicacion != null) {
                foreach (int item in p_publicacion) {
                        DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN en = new DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN ();
                        en.ID = item;
                        etiquetaEN.Publicacion.Add (en);
                }
        }

        else{
                etiquetaEN.Publicacion = new System.Collections.Generic.List<DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN>();
        }

        //Call to EtiquetaCAD

        oid = _IEtiquetaCAD.New_ (etiquetaEN);
        return oid;
}

public void Modify (int p_Etiqueta_OID, string p_nombre)
{
        EtiquetaEN etiquetaEN = null;

        //Initialized EtiquetaEN
        etiquetaEN = new EtiquetaEN ();
        etiquetaEN.ID = p_Etiqueta_OID;
        etiquetaEN.Nombre = p_nombre;
        //Call to EtiquetaCAD

        _IEtiquetaCAD.Modify (etiquetaEN);
}

public void Destroy (int ID
                     )
{
        _IEtiquetaCAD.Destroy (ID);
}
}
}
