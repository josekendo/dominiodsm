
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
        SqlConnection cnn = new SqlConnection (@"Server=(local); database=master; integrated security=yes");

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
                UsuarioCEN usuarioCEN = new UsuarioCEN ();
                int user1 = usuarioCEN.New_ ("maria", "maria@prueba.com", "maria", "SPAIN", 666666666, "mariita", "/fotos/maria.png", true, "125,125", "12,15,8", false, null);
                int user2 = usuarioCEN.New_ ("jose ramon", "joser@prueba.com", "jose ramon", "SPAIN", 666666666, "joser", "/fotos/joser.png", true, "125,125", "12,15,8", false, null);
                ReporteEN reporteEN = new ReporteEN (1, DateTime.Today, false, null);
                PublicacionCEN publicacionCEN = new PublicacionCEN ();
                int publi1 = publicacionCEN.New_ (DateTime.Today, "Los gatos son monos", "Imagen", "/publicaciones/imagenes/losgatos.jpg", user1, null, null, null);
                int publi2 = publicacionCEN.New_ (DateTime.Today, "Los gatos son monos 2", "Imagen", "/publicaciones/imagenes/losgatos2.jpg", user1, null, null, null);
                int publi3 = publicacionCEN.New_ (DateTime.Today, "Mi isla", "Imagen", "/publicaciones/imagenes/islaco.jpg", user2, null, null, reporteEN);
                AdministradorCEN administradorCEN = new AdministradorCEN ();
                administradorCEN.New_ ("admin", "davidr", "admindr", "davidr@prueba.com");
                administradorCEN.New_ ("modera", "davidb", "moderadb", "davidb@prueba.com");
                CategoriaCEN categoriaCEN = new CategoriaCEN ();
                EtiquetaCEN etiquetaCEN = new EtiquetaCEN ();
                categoriaCEN.New_ ("Perros");
                IList<int> lista = new List<int>();
                lista.Add (publi1);
                lista.Add (publi2);
                etiquetaCEN.New_ ("Gatos", lista);
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
