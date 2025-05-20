using Parcial1Prog3.Models;
using System.Data.SqlClient;

namespace Parcial1Prog3.Datos
{
    public class CompetidorDatos
    {
        private string connectionString = "Data Source=DESKTOP-AH48DTG;Initial Catalog=Parcial1Prog3;Integrated Security=True";

        public List<Competidor> ListarCompetidores()
        {
            List<Competidor> lista = new List<Competidor>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Competidor.Id as IdCompetidor, Competidor.Nombre as NombreCompetidor, Competidor.Edad,Competidor.Ciudad, Competidor.IdDisciplina as IdDisciplina, Disciplina.NombreDisciplina FROM Competidor INNER JOIN Disciplina ON Competidor.IdDisciplina = Disciplina.Id ORDER BY Competidor.Nombre";
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    lista.Add(new Competidor()
                    {
                        Id = (int)reader["IdCompetidor"],
                        Nombre = reader["NombreCompetidor"].ToString(),
                        Edad = (int)reader["Edad"],
                        Ciudad = reader["Ciudad"].ToString(),
                        Disciplina = new Disciplina()
                        {
                            Id = (int)reader["IdDisciplina"],
                            Nombre = reader["NombreDisciplina"].ToString()
                        }
                    });
                }
                return lista;
            }
        }

        public string CrearCompetidor(Competidor competidor)
        {
            string query = $"INSERT INTO Competidor (Nombre, Edad, Ciudad, IdDisciplina) VALUES ('{competidor.Nombre}', {competidor.Edad}, '{competidor.Ciudad}', {competidor.IdDisciplina})";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand command = new SqlCommand (query, con);
                    command.ExecuteNonQuery();
                    return "";
                }
            }catch (Exception ex) { return ex.Message; }
        }

        public List<Disciplina> ListarDisciplina()
        {
            List<Disciplina> lista = new List<Disciplina>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Disciplina";
                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Disciplina()
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["NombreDisciplina"].ToString()
                    });
                }
                return lista;
            }
        }
    }
}
