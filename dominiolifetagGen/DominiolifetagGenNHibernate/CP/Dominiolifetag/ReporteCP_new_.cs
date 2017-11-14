
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;



/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CP.Dominiolifetag_Reporte_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CP.Dominiolifetag
{
public partial class ReporteCP : BasicCP
{
public DominiolifetagGenNHibernate.EN.Dominiolifetag.ReporteEN New_ (Nullable<DateTime> p_fecha, bool p_confirmacion, int p_publicacion)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CP.Dominiolifetag_Reporte_new_) ENABLED START*/

        IReporteCAD reporteCAD = null;
        ReporteCEN reporteCEN = null;

        DominiolifetagGenNHibernate.EN.Dominiolifetag.ReporteEN result = null;


        try
        {
                SessionInitializeTransaction ();
                reporteCAD = new ReporteCAD (session);
                reporteCEN = new  ReporteCEN (reporteCAD);




                int oid;
                //Initialized ReporteEN
                ReporteEN reporteEN;
                reporteEN = new ReporteEN ();
                reporteEN.Fecha = p_fecha;

                reporteEN.Confirmacion = p_confirmacion;


                if (p_publicacion != -1) {
                        reporteEN.Publicacion = new DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN ();
                        reporteEN.Publicacion.ID = p_publicacion;
                }

                //Call to ReporteCAD

                oid = reporteCAD.New_ (reporteEN);
                result = reporteCAD.ReadOIDDefault (oid);



                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
