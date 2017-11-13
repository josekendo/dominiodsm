
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;



/*PROTECTED REGION ID(usingDominiolifetagGenNHibernate.CP.Dominiolifetag_Comentario_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace DominiolifetagGenNHibernate.CP.Dominiolifetag
{
public partial class ComentarioCP : BasicCP
{
public DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN New_ (string p_contenido, int p_publicacion, int p_usuario)
{
        /*PROTECTED REGION ID(DominiolifetagGenNHibernate.CP.Dominiolifetag_Comentario_new_) ENABLED START*/

        IComentarioCAD comentarioCAD = null;
        ComentarioCEN comentarioCEN = null;

        DominiolifetagGenNHibernate.EN.Dominiolifetag.ComentarioEN result = null;


        try
        {
                SessionInitializeTransaction ();
                comentarioCAD = new ComentarioCAD (session);
                comentarioCEN = new  ComentarioCEN (comentarioCAD);




                int oid;
                //Initialized ComentarioEN
                ComentarioEN comentarioEN;
                comentarioEN = new ComentarioEN ();
                comentarioEN.Contenido = p_contenido;


                if (p_publicacion != -1) {
                        comentarioEN.Publicacion = new DominiolifetagGenNHibernate.EN.Dominiolifetag.PublicacionEN ();
                        comentarioEN.Publicacion.ID = p_publicacion;
                }


                if (p_usuario != -1) {
                        comentarioEN.Usuario = new DominiolifetagGenNHibernate.EN.Dominiolifetag.UsuarioEN ();
                        comentarioEN.Usuario.ID = p_usuario;
                }

                //Call to ComentarioCAD

                oid = comentarioCAD.New_ (comentarioEN);
                result = comentarioCAD.ReadOIDDefault (oid);



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
