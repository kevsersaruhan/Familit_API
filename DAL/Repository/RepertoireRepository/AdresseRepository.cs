using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.RepertoireRepository
{
  public class AdresseRepository 
  {
    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;
    public int AddAdresse(string rue, string num, int cp, string ville, string pays, string email, int? numtel)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Adresse_Add";
          command.Parameters.AddWithValue("@adRue", rue);
          command.Parameters.AddWithValue("@adNum", num);
          command.Parameters.AddWithValue("@adCp", cp);
          command.Parameters.AddWithValue("@adVille", ville);
          command.Parameters.AddWithValue("@adPays", pays);
          command.Parameters.AddWithValue("@email", email);
          command.Parameters.AddWithValue("@numTel", numtel);
          command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteScalar();
          return Convert.ToInt32(command.Parameters["@id"].Value);
        }
      }
    }
    public void DeleteAdresse(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Adresse_Delete";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }

    }
    public void UpdateAdresse(int id, string rue, string num, int cp, string ville, string pays, int? numtel, string email)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Adresse_Update";
          command.Parameters.AddWithValue("@Id", id);
          command.Parameters.AddWithValue("@adRue", rue);
          command.Parameters.AddWithValue("@adNum", num);
          command.Parameters.AddWithValue("@adCp", cp);
          command.Parameters.AddWithValue("@adVille", ville);
          command.Parameters.AddWithValue("@adPays", pays);
          command.Parameters.AddWithValue("@email", email);
          command.Parameters.AddWithValue("@numTel", numtel);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();

        }
      }
    }

  }
}
