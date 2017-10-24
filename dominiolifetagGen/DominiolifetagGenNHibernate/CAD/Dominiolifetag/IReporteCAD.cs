
using System;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;

namespace DominiolifetagGenNHibernate.CAD.Dominiolifetag
{
public partial interface IReporteCAD
{
ReporteEN ReadOIDDefault (int ID
                          );

void ModifyDefault (ReporteEN reporte);



int New_ (ReporteEN reporte);

void Modify (ReporteEN reporte);


void Destroy (int ID
              );
}
}
