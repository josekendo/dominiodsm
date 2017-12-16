
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DominiolifetagGenNHibernate.EN.Dominiolifetag;
using DominiolifetagGenNHibernate.CEN.Dominiolifetag;
using DominiolifetagGenNHibernate.CAD.Dominiolifetag;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                //Usuarios pre-cargados en la base de datos

                //cargamos modulos de logica
                AdministradorCEN adminCEN = new AdministradorCEN ();
                UsuarioCEN usuarioCEN = new UsuarioCEN ();
                UsuarioCEN usuarioCEN2 = new UsuarioCEN ();
                PublicacionCEN puCEN = new PublicacionCEN ();
                EtiquetaCEN etiCEN = new EtiquetaCEN ();
                CategoriaCEN cateCEN = new CategoriaCEN ();
                ReporteCEN reCEN = new ReporteCEN ();
                ComentarioCEN coCEN = new ComentarioCEN ();
                //fin de logica

                //llamamos a modulos de base de datos CAD
                PublicacionCAD puCAD = new PublicacionCAD ();
                CategoriaCAD cateCAD = new CategoriaCAD ();
                EtiquetaCAD etiCAD = new EtiquetaCAD ();
                //fin cad

                //Catetorias
                IList<int> catel = new List<int>();
                IList<EtiquetaEN> etil = new List<EtiquetaEN>();
                int categoria1 = cateCEN.New_ ("GATOS", "Para los amantes de los gatos.", 0);
                int categoria2 = cateCEN.New_ ("PERROS", "Para los que quieren a estos maravillosos caninos.", 0);
                catel.Add (categoria1);

                //Administrador 
                int admin1 = adminCEN.New_("Administrador", "david", "12345", "davids@gmail.com");
                int admin2 = adminCEN.New_("Administrador", "jose", "54321", "josev@gmail.com");
                int admin3 = adminCEN.New_("Moderador", "pepito", "11123", "pepito@gmail.com");
                Console.WriteLine("creado administrador con id -> " + admin1);
                Console.WriteLine("creado administrador con id -> " + admin2);
                Console.WriteLine("creado administrador con id -> " + admin3);

                int user1 = usuarioCEN.New_ ("enrique", "enri@gmail.com", "622633667", "spain", 622667339, "enri", "/img/perfildb.png", false, "", "", false, null);
                //int user2 = usuarioCEN2.New_ ("jose vicente", "jv@gmail.com", "54665465465", "cataluya", 123456789, "jv", "/img/perfiljv.png", true, "", "", false, new List<PublicacionEN>()); //error pero no se de que
                //int user3 = usuarioCEN.New_ ("david ramon", "dr@gmail.com", "622633667", "spain", 622667339, "dr", "/img/perfildb.png", true, "", "", false, null);
                Console.WriteLine ("creado usuario con id -> " + user1);
                
                //Activacion de usuario
                bool activa1 = usuarioCEN.Activacion(user1,"1234");
                Console.WriteLine("¿user1 activado? -> " + activa1);

                //Cambiar imagen
                bool cambiaimg1 = usuarioCEN.CambiarImagen(user1, "/img/nuevaimagen.png");
                Console.WriteLine("¿Nueva imagen del usuario? -> " + cambiaimg1);

                //Cambiar Datos del usuario
                bool cambiardat1 = usuarioCEN.CambiarDatos(user1,"123456789","newenri@gmail.com","enriquenuevo",966231423);
                Console.WriteLine("¿Datos de usuario cambiado? -> " + cambiardat1);

                int publicacion1 = puCEN.New_ (DateTime.Today, "Gato Mono", "Imagen", "https://coo3.tuvotacion.com/imagenes_unicas/que-gato-es-mas-mono-967242.jpg", user1, etil, catel);
                int publicacion2 = puCEN.New_(DateTime.Today, "Gato Mono 2", "Imagen", "http://fondosdepantallashd.com/wp-content/uploads/2017/06/Peque%C3%B1o-gato-mono-frotando-su-cabeza-en-el-piso.jpg", user1, etil, catel);
                int publicacion3 = puCEN.New_(DateTime.Today, "Gato Mono 3", "Imagen", "https://s-media-cache-ak0.pinimg.com/originals/50/17/10/501710db7440b6d2f35ee96c34afccb7.jpg", user1, etil, catel);
                int publicacion4 = puCEN.New_(DateTime.Today, "Gato Mono 4", "Imagen", "http://3.bp.blogspot.com/-kf5Kk01uosA/T51WVYW81II/AAAAAAAACaA/LyRrrzEDWMU/s1600/SAM_4047.JPG", user1, etil, catel);
                int publicacion5 = puCEN.New_(DateTime.Today, "Gato Mono 5", "Imagen", "https://previews.123rf.com/images/magphoto/magphoto0810/magphoto081000042/3657483-gato-gato-mono-animal-ni-o-joven-pelo-ojos-azules-el-gato-la-raza-siameses-mira--Foto-de-archivo.jpg", user1, etil, catel);
                int publicacion6 = puCEN.New_(DateTime.Today, "Gato Mono 6", "Imagen", "https://upload.wikimedia.org/wikipedia/commons/c/ca/Niobe050905-Siamese_Cat.jpeg", user1, etil, catel);
                int publicacion7 = puCEN.New_(DateTime.Today, "Gato Mono 7", "Imagen", "https://coo4.tuvotacion.com/imagenes_unicas/cual-es-mas-mono-de-los-gatos-165173.jpg", user1, etil, catel);
                int publicacion8 = puCEN.New_(DateTime.Today, "Gato Mono 8", "Imagen", "https://img.buzzfeed.com/buzzfeed-static/static/2015-06/25/10/campaign_images/webdr12/este-puede-ser-el-gato-mas-triste-y-mono-de-la-hi-2-5356-1435241579-5_dblbig.jpg", user1, etil, catel);

                PublicacionEN publi1 = puCAD.ReadOIDDefault (publicacion1);
                Console.WriteLine ("creada publicacion con id -> " + publicacion1);
                Console.WriteLine ("creada publicacion con id (recuperada) -> " + publi1.ID);
                Console.WriteLine ("(recuperada) informacion -> titulo:" + publi1.Nombre + "; tipo:" + publi1.Tipo + "; ruta del archivo:" + publi1.Archivo + ";");
                
                //vamos agregar etiquetas
                IList<int> lista = new List<int>();
                lista.Add (publicacion1);
                int etiqueta1 = etiCEN.New_ ("mono", lista);
                int etiqueta2 = etiCEN.New_ ("neko", lista);

                //vamos a probar UltimasPublicaciones
                IList<PublicacionEN> listaultimas = puCEN.UltimasPublicaciones ("GATOS"); //quitar id
                IList<PublicacionEN> listaultimas2 = puCEN.UltimasPublicaciones ("PERROS"); //quitar id
                Console.WriteLine ("Busqueda ultimas categoria GATOS (1)-> " + listaultimas.Count);
                foreach (PublicacionEN i in listaultimas) {
                        Console.WriteLine (i.Nombre);
                }
                Console.WriteLine ("Busqueda ultimas categoria PERROS (0)-> " + listaultimas2.Count);
                foreach (PublicacionEN i in listaultimas2) {
                        Console.WriteLine (i.Nombre);
                }
                //ok
                Console.WriteLine ("BuscarPublicaciones gato y fecha publicacion (1)-> " + puCEN.BuscarPublicaciones (true, publi1.Fecha, "Gato").Count);
                //vamos a probar buscarPublicaciones
                foreach (PublicacionEN i in puCEN.BuscarPublicaciones (true, publi1.Fecha, "Gato")) {
                        Console.WriteLine (i.Nombre);
                }
                //ok
                Console.WriteLine ("BuscarAvanzada gato y fecha publicacion (1)-> " + puCEN.BuscarAvanzado (true, "Gato", publi1.Fecha, "GATOS").Count);
                //vamos a probar BuscarAvanzada
                foreach (PublicacionEN i in puCEN.BuscarAvanzado (true, "Gato", publi1.Fecha, "GATOS")) {
                        Console.WriteLine (i.Nombre);
                }
                //ok


                //vamos a probar listadoComentarios
                int comentario1 = coCEN.New_ ("que gato mas mono", publicacion1, user1);
                int comentario2 = coCEN.New_("que gato mas monisimo", publicacion1, user1);
                Console.WriteLine ("se ha creado comentario de user1 en la publicacion1, id comentario -> " + comentario1);
                foreach (ComentarioEN i in puCEN.ListadoComentarios (publicacion1)) {
                        Console.WriteLine (i.Contenido);
                }
                //ok

            
                PublicacionCEN pubCEN = new PublicacionCEN();
                CategoriaCEN categCEN = new CategoriaCEN();
                EtiquetaCEN etiqCEN = new EtiquetaCEN();
                UsuarioCEN usrCEN = new UsuarioCEN();
                //fin de logica

                //llamamos a modulos de base de datos CAD
                PublicacionCAD pubCAD = new PublicacionCAD();
                CategoriaCAD categCAD = new CategoriaCAD();
                EtiquetaCAD etiqCAD = new EtiquetaCAD();
                //fin cad

                IList<int> cat = new List<int>();
                IList<EtiquetaEN> eti = new List<EtiquetaEN>();

                int categ1 = categCEN.New_("Girafas", "Para los amantes de las girafas locas.", 0);//CUIDADO!!  "Perros" que esta categoria ya se crea arriba(el nombre es unico)
                cat.Add(categ1);

               // int usr1 = usrCEN.New_("josera", "josera@gmail.com", "697400104", "spain", 697400104, "josera", "/img/perfildb.png", true, "", "", false, null);
               // int pub1 = pubCEN.New_(DateTime.Today, "Mono grillo", "Imagen", "/publicaciones/imagenes/" + user1 + "monogrillo/", usr1, etil, catel);
               // int etiq1 = etiqCEN.New_("Mono grillo", cat);


                //categCEN.Modify(categoria1, "perritos", "muy perros", 13);
                //categCEN.ListadoCategorias(1, 12);
                //categCEN.Destroy(categoria1);
                //Console.WriteLine(categCEN);

                //etiqCEN.Modify(pub1, "Etiquetao");
                //Console.WriteLine(etiqCEN);
                //etiqCEN.Destroy(etiq1);
                //Console.WriteLine(etiqCEN);



                // Insert the initilizations of entities using the CEN classes


                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");



                /*PROTECTED REGION END*/
            }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
