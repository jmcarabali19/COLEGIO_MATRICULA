using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COLEGIO_MATRICULA
{
    internal class Program
    {
        static void Main(string[] args)
        
            {
                string opc = "1";

                Console.WriteLine("Bienvenido al sistema COLEGIO: ");

                conexionbd();

                Console.WriteLine("\n Que deseas Realizar?\n  \n 1. Listar Estudiantes \n 2. Insertar Estudiante \n 3. Actualizar Estudiante \n 4. Borrar Estdiante ");
                opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                        listarbd();
                        break;
                    case "2":
                        insertbd();
                        break;
                    case "3":
                        updatebd();
                        break;
                    case "4":
                        deletebd();
                        break;
                    default:

                        Console.WriteLine("Opcion Invalida: ");
                        break;

                }
            }

        // Creando conexion a la BD
        public static void conexionbd()
        {
            try
            {

                Console.WriteLine("Ingrese Usuario:");
                string user = Console.ReadLine();

                Console.WriteLine("Ingrese Contraseña:");
                string pass = Console.ReadLine();

                string connectionString = $"Server=SALSA-MM\\SALSAMSERVER;Database=COLEGIO;User Id={user};Password={pass};";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine(" Bienvenido \n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
            }
        }
        // Listando datos de la BD
        static void listarbd()
        {
            try
            {
                string connectionString = "Server=SALSA-MM\\SALSAMSERVER;Database=COLEGIO;User id=admin;Password=admin; ";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Lista de Matriculados. \n");
                    string query = "SELECT * FROM MATRICULA";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("Identificacion: " + reader["IDENTIFICACION"] +
                                    ", Nombre: " + reader["NOMBRE"] + ", Apellido: " + reader["APELLIDO"]
                                    + ", Direccion: " + reader["DIRECCION"] + ", Telefono: " +
                                    reader["TELEFONO"] + ", Grado: " + reader["GRADO"] + ", Acudiente 1: " +
                                    reader["ACUDIENTE_1"] + ", Contacto Acudiente 1: " + reader["CONTACTO_ACUDIENTE_1"]);
                            }
                        }
                    }
                    conn.Close();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("error: " + ex);

            }
        }
        // Insertando datos a la BD
        static void insertbd()
        {
            try
            {
                string connectionString = "Server=SALSA-MM\\SALSAMSERVER;Database=COLEGIO;User id=admin;Password=admin;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Console.WriteLine("Conexion Exitosa");

                    Console.WriteLine("Inserte al nuevo Estudiante: \n");

                    Console.WriteLine(" Ingrese Identificacion:");
                    string identificacion = Console.ReadLine();
                    Console.WriteLine("Ingrese Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese Apellido: ");
                    string apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese Direccion: ");
                    string direccion = Console.ReadLine();
                    Console.WriteLine("Ingrese Telefono: ");
                    int telefono = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el Grado; ");
                    int grado = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese Acudiente Primer Acudiente: ");
                    string acud1 = Console.ReadLine();
                    Console.WriteLine("Ingrese Telefono de Contacto de Primer Acudiente: ");
                    string contac1 = Console.ReadLine();


                    string Insert = "INSERT INTO MATRICULA (IDENTIFICACION,NOMBRE,APELLIDO,DIRECCION,TELEFONO,GRADO,ACUDIENTE_1,CONTACTO_ACUDIENTE_1)"
                        + "VALUES (@IDENTIFICACION,@NOMBRE,@APELLIDO,@DIRECCION,@TELEFONO,@GRADO,@ACUDIENTE_1,@CONTACTO_ACUDIENTE_1)";
                    using (SqlCommand cmd = new SqlCommand(Insert, conn))
                    {
                        cmd.Parameters.AddWithValue("@IDENTIFICACION", identificacion);
                        cmd.Parameters.AddWithValue("@NOMBRE", nombre);
                        cmd.Parameters.AddWithValue("@APELLIDO", apellido);
                        cmd.Parameters.AddWithValue("@DIRECCION", direccion);
                        cmd.Parameters.AddWithValue("@TELEFONO", telefono);
                        cmd.Parameters.AddWithValue("@GRADO", grado);
                        cmd.Parameters.AddWithValue("@ACUDIENTE_1", acud1);
                        cmd.Parameters.AddWithValue("@CONTACTO_ACUDIENTE_1", contac1);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Datos ingresados");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine("error: " + ex); }
        }
        static void updatebd()
        {
            try
            {
                string connectionString = "Server=SALSA-MM\\SALSAMSERVER;Database=COLEGIO;User id=admin;Password=admin;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Console.WriteLine("Conexion Exitosa");
                    Console.WriteLine("Actualizar datos del Estudiante: \n");
                    Console.WriteLine(" Ingrese Identificacion del Estudiante a Actualizar:");
                    string identificacion = Console.ReadLine();
                    Console.WriteLine("Ingrese Nombre: ");
                    string nombre = Console.ReadLine();
                    Console.WriteLine("Ingrese Apellido: ");
                    string apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese Direccion: ");
                    string direccion = Console.ReadLine();
                    Console.WriteLine("Ingrese Telefono: ");
                    int telefono = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese el Grado; ");
                    int grado = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese Acudiente Primer Acudiente: ");
                    string acud1 = Console.ReadLine();
                    Console.WriteLine("Ingrese Telefono de Contacto de Primer Acudiente: ");
                    string contac1 = Console.ReadLine();


                    Console.WriteLine("Datos Actualizados !");
                }
            }
            catch (Exception ex) { Console.WriteLine("error: " + ex); }
        }
        static void deletebd()
        {
            try
            {
                string connectionString = "Server=SALSA-MM\\SALSAMSERVER;Database=COLEGIO;User id=admin;Password=admin;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //Console.WriteLine("Conexion Exitosa");
                    Console.WriteLine("Borrar datos del Estudiante: \n");
                    Console.WriteLine(" Ingrese Identificacion del Estudiante a Borrar:");
                    string identificacion = Console.ReadLine();

                }
            }
            catch (Exception ex) { Console.WriteLine("error: " + ex); }
        }
    }
    
}
