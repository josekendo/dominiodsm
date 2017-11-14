
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.Exceptions;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;


/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CEN.Dominiolifetag_Reporte_confirmar) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CEN.Dominiolifetag
{
public partial class ReporteCEN
{
public bool Confirmar (int p_oid)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CEN.Dominiolifetag_Reporte_confirmar) ENABLED START*/

        // Write here your custom code...
        ReporteEN report = _IReporteCAD.ReadOIDDefault (p_oid);

        report.Confirmacion = true;

        _IReporteCAD.Modify (report);

        throw new NotImplementedException ("Method Confirmar() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
