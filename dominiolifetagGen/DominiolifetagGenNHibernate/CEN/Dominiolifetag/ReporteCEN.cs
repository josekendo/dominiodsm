

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
 *      Definition of the class ReporteCEN
 *
 */
public partial class ReporteCEN
{
private IReporteCAD _IReporteCAD;

public ReporteCEN()
{
        this._IReporteCAD = new ReporteCAD ();
}

public ReporteCEN(IReporteCAD _IReporteCAD)
{
        this._IReporteCAD = _IReporteCAD;
}

public IReporteCAD get_IReporteCAD ()
{
        return this._IReporteCAD;
}

public int New_ (Nullable<DateTime> p_fecha, bool p_confirmacion, int p_publicacion)
{
        ReporteEN reporteEN = null;
        int oid;

        //Initialized ReporteEN
        reporteEN = new ReporteEN ();
        reporteEN.Fecha = p_fecha;

        reporteEN.Confirmacion = p_confirmacion;


        if (p_publicacion != -1) {
                // El argumento p_publicacion -> Property publicacion es oid = false
                // Lista de oids ID
                reporteEN.Publicacion = new DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN ();
                reporteEN.Publicacion.ID = p_publicacion;
        }

        //Call to ReporteCAD

        oid = _IReporteCAD.New_ (reporteEN);
        return oid;
}

public void Modify (int p_Reporte_OID, Nullable<DateTime> p_fecha, bool p_confirmacion)
{
        ReporteEN reporteEN = null;

        //Initialized ReporteEN
        reporteEN = new ReporteEN ();
        reporteEN.ID = p_Reporte_OID;
        reporteEN.Fecha = p_fecha;
        reporteEN.Confirmacion = p_confirmacion;
        //Call to ReporteCAD

        _IReporteCAD.Modify (reporteEN);
}

public void Destroy (int ID
                     )
{
        _IReporteCAD.Destroy (ID);
}
}
}
