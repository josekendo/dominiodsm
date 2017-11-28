<<<<<<< HEAD

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
                UsuarioCEN usuarioCEN = new UsuarioCEN ();
<<<<<<< Updated upstream
                UsuarioCEN usuarioCEN2 = new UsuarioCEN ();
                PublicacionCEN puCEN = new PublicacionCEN ();
                EtiquetaCEN etiCEN = new EtiquetaCEN ();
                CategoriaCEN cateCEN = new CategoriaCEN ();
                ReporteCEN reCEN = new ReporteCEN ();//----------------------
                ComentarioCEN coCEN = new ComentarioCEN ();
                //fin de logica

                //llamamos a modulos de base de datos CAD
                PublicacionCAD puCAD = new PublicacionCAD ();
                CategoriaCAD cateCAD = new CategoriaCAD ();
                EtiquetaCAD etiCAD = new EtiquetaCAD ();
                ReporteCAD repCAD = new ReporteCAD();//----------------------
                //fin cad

                //IList<int> report1 = new List<int>();//----------------------
                IList<int> catel = new List<int>();
                IList<EtiquetaEN> etil = new List<EtiquetaEN>();
                
                int categoria1 = cateCEN.New_ ("GATOS", "Para los amantes de los gatos.", 0);
                int categoria2 = cateCEN.New_ ("PERROS", "Para los que quieren a estos maravillosos caninos.", 0);
                catel.Add (categoria1);

                int user1 = usuarioCEN.New_ ("enrique", "enri@gmail.com", "622633667", "spain", 622667339, "enri", "/img/perfildb.png", true, "", "", false, null);
                //int user2 = usuarioCEN2.New_ ("jose vicente", "jv@gmail.com", "54665465465", "cataluya", 123456789, "jv", "/img/perfiljv.png", true, "", "", false, new List<PublicacionEN>()); //error pero no se de que
                //int user3 = usuarioCEN.New_ ("david ramon", "dr@gmail.com", "622633667", "spain", 622667339, "dr", "/img/perfildb.png", true, "", "", false, null);
                Console.WriteLine ("creado usuario con id -> " + user1);
                int publicacion1 = puCEN.New_ (DateTime.Today, "Gato Mono", "Imagen", "/publicaciones/imagenes/" + user1 + "monogato/", user1, etil, catel);
                
                int reporte1 = reCEN.New_(DateTime.Today, false, publicacion1);//(fecha,confirmacion, publicacion)-----------------------------
                //int reporte2 = reCEN.New_(DateTime.Today, true, publicacion1);

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

                /*Vamos a probar listado categorias*/

                Console.WriteLine("Listado de categorias: ---->"+cateCEN.ListadoCategorias(1,6));

                /*vamos a probar confirmar Reporte*/

                Console.WriteLine("Confirmamos reporte: ---->" + reCEN.Confirmar(publicacion1));


                //vamos a probar listadoComentarios
                int comentario1 = coCEN.New_ ("que gato mas mono", publicacion1, user1);
                int comentario2 = coCEN.New_("que gato mas monisimo", publicacion1, user1);
                Console.WriteLine ("se ha creado comentario de user1 en la publicacion1, id comentario -> " + comentario1);
                foreach (ComentarioEN i in puCEN.ListadoComentarios (publicacion1)) {
                        Console.WriteLine (i.Contenido);
                }
                //ok

                
=======
                int user1 = usuarioCEN.New_ ("maria", "maria@prueba.com", "maria", "SPAIN", 666666666, "mariita", "/fotos/maria.png", true, "125,125", "12,15,8", false, null);
                int user2 = usuarioCEN.New_ ("jose ramon", "joser@prueba.com", "jose ramon", "SPAIN", 666666666, "joser", "/fotos/joser.png", true, "125,125", "12,15,8", false, null);
                
                  /*ReporteEN reporteEN = new ReporteEN (1, DateTime.Today, false, null);
                 * PublicacionCEN publicacionCEN = new PublicacionCEN ();
                 * int publi1 = publicacionCEN.New_ (DateTime.Today, "Los gatos son monos", "Imagen", "/publicaciones/imagenes/losgatos.jpg", user1, null, null);
                 * int publi2 = publicacionCEN.New_ (DateTime.Today, "Los gatos son monos 2", "Imagen", "/publicaciones/imagenes/losgatos2.jpg", user1, null, null);
                 * int publi3 = publicacionCEN.New_ (DateTime.Today, "Mi isla", "Imagen", "/publicaciones/imagenes/islaco.jpg", user2, null, null);
                 * AdministradorCEN administradorCEN = new AdministradorCEN ();
                 * administradorCEN.New_ ("admin", "davidr", "admindr", "davidr@prueba.com");
                 * administradorCEN.New_ ("modera", "davidb", "moderadb", "davidb@prueba.com");
                 * CategoriaCEN categoriaCEN = new CategoriaCEN ();
                 * EtiquetaCEN etiquetaCEN = new EtiquetaCEN ();
                 * categoriaCEN.New_ ("Perros", "Categoria de los preciosos caninos llamados perros.", 5);
                 * IList<int> lista = new List<int>();
                 * lista.Add (publi1);
                 * lista.Add (publi2);
                 * etiquetaCEN.New_ ("Gatos", lista);*/
>>>>>>> Stashed changes
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
=======

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

                int publicacion1 = puCEN.New_ (DateTime.Today, "Gato Mono", "Imagen", "/publicaciones/imagenes/" + user1 + "monogato/", user1, etil, catel);

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

                int categ1 = categCEN.New_("Perros", "Para los amantes de los perros.", 0);
                cat.Add(categ1);

                int usr1 = usrCEN.New_("josera", "josera@gmail.com", "697400104", "spain", 697400104, "josera", "/img/perfildb.png", true, "", "", false, null);
                int pub1 = pubCEN.New_(DateTime.Today, "Mono grillo", "Imagen", "/publicaciones/imagenes/" + user1 + "monogrillo/", usr1, etil, catel);
                int etiq1 = etiqCEN.New_("Mono grillo", cat);


                categCEN.Modify(categoria1, "perritos", "muy perros", 13);
                categCEN.ListadoCategorias(1, 12);
                categCEN.Destroy(categoria1);
                Console.WriteLine(categCEN);

                etiqCEN.Modify(pub1, "Etiquetao");
                Console.WriteLine(etiqCEN);
                etiqCEN.Destroy(etiq1);
                Console.WriteLine(etiqCEN);



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
>>>>>>> master
