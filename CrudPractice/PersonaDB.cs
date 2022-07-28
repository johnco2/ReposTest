using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CrudPractice
{
    public class PersonaDB
    {

        
        private string connectionString = "Data Source=DESKTOP-0Q1OPLD; Initial Catalog=CrudWindFormDB; Integrated Security=True";
        //Server=DESKTOP-0Q1OPLD;Database=CrudWindFormDB;Trusted_Connection=true;MultipleActiveResultSets=True
        //Data Source=DESKTOP-0Q1OPLD; Initial Catalog=CrudWindFormDB
        //"Server= DESKTOP-0Q1OPLD; Database= CrudWindFormDB; Integrated Security=True;
        public bool Ok()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        
        public List<Persona> Get()
        {
            List<Persona> persona = new List<Persona>();

            string query = "select id,nombre,edad from persona";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(); 
                    while (reader.Read())
                    {
                        Persona oPersona = new Persona();
                        oPersona.Id = reader.GetInt32(0);
                        oPersona.Nombre = reader.GetString(1);
                        oPersona.Edad = reader.GetInt32(2);
                        persona.Add(oPersona);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos " + ex.Message);
                }
            }  

            return persona;
        }

        public Persona Get(int? Id)
        {

            string query = "select id,nombre,edad from persona where id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    reader.Read();

                    Persona oPersona = new Persona();
                    oPersona.Id = reader.GetInt32(0);
                    oPersona.Nombre = reader.GetString(1);
                    oPersona.Edad = reader.GetInt32(2);
                    
                    reader.Close();
                    connection.Close();
                    return oPersona;

                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos " + ex.Message);
                }
            }
        }

        public void Add(string nombre, int edad)
        {

            string query = "insert into persona(nombre, edad) values (@nombre, @edad)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@edad", edad);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos " + ex.Message);
                }
            }
        }

        public void Update(string nombre, int edad, int id)
        {

            string query = "update persona set nombre = @nombre, edad=@edad where id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@edad", edad);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos " + ex.Message);
                }
            }
        }

        public void Delete(int id)
        {

            string query = "delete from persona where id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Hay un error en la base de datos " + ex.Message);
                }
            }
        }

    }
                
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }
}
