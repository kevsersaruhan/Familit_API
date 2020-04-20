using DAL.Model.Etablissement;
using DAL.Repository.RepertoireRepository;
using DAL.Utils.EtablissementUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace DAL.Repository.EtablissementRepository
{
  public class ShowroomRepository : IShowroomRepository<int, Showrooms>
  {
    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;
    private AdresseRepository _repoAdresse = new AdresseRepository();
    // Activation du showroom OK pour la stored procedure
    public void Activer(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Showroom_Activer";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }

    // Ajout du Showroom dans la table Showroom et de son adresse dans la table Adresse OK ( renvoie Scope Identity pour AdresseID)
    public void Add(Showrooms entity)
    {
      int adresseId= _repoAdresse.AddAdresse(entity.AdRue, entity.AdNum, entity.AdCP, entity.AdVille, entity.AdPays, entity.Email, entity.NumTel);
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Showroom_Add";
          command.Parameters.AddWithValue("@nom", entity.Nom);
          command.Parameters.AddWithValue("@numBCE", entity.NumBCE);
          command.Parameters.AddWithValue("@adresseId", adresseId);
          command.Parameters.AddWithValue("@isActif", entity.IsActif);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          entity.ID = (int)command.ExecuteScalar();
        }
      }
    }

    // Suppression Du Showroom ok
    public void Delete(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Showroom_Delete";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }

    // Désactivation du showroom ok
    public void Desactiver(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Showroom_Desactiver";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }

    // Get Ok au niveau des paramètres
    public IEnumerable<Showrooms> Get()
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Showroom_GetAll";
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Showrooms()
              {
                ID = (int)reader["ShowroomId"],
                Nom = (string)reader["Nom"],
                NumBCE = (string)reader["NumBCE"],
                AdresseID = (int)reader["AdresseId"],
                AdRue = (string)reader["AdRue"],
                AdNum = (string)reader["AdNum"],
                AdCP = (int)reader["AdCp"],
                AdVille = (string)reader["AdVille"],
                AdPays = (string)reader["AdPays"],
                NumTel = (reader["NumTel"] == DBNull.Value) ? null : (int?)reader["NumTel"],
                Email = (string)reader["Email"],
                IsActif = (bool)reader["IsActif"]
              }; 
            }
          }
        }
      }
    }

    // Get Ok au niveau des paramètres
    public Showrooms Get(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Showroom_GetByID";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            if (reader.Read())
            {
              return new Showrooms()
              {
                ID = (int)reader["ShowroomId"],
                Nom = (string)reader["Nom"],
                NumBCE = (string)reader["NumBCE"],
                AdresseID = (int)reader["AdresseId"],
                AdRue = (string)reader["AdRue"],
                AdNum = (string)reader["AdNum"],
                AdCP = (int)reader["AdCp"],
                AdVille = (string)reader["AdVille"],
                AdPays = (string)reader["AdPays"],
                NumTel = (reader["NumTel"] == DBNull.Value) ? null : (int?)reader["NumTel"],
                Email = (string)reader["Email"],
                IsActif = (bool)reader["IsActif"]
              };
            }
            else
            {
              return null;
            }
          }
        }
      }
    }

    // Ok au niveau des paramètres
    public IEnumerable<Showrooms> GetShowroomByName(string name)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Showroom_GetByName";
          command.Parameters.AddWithValue("@nom", name);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Showrooms()
              {
                ID = (int)reader["ShowroomId"],
                Nom = (string)reader["Nom"],
                NumBCE = (string)reader["NumBCE"],
                AdRue = (string)reader["AdRue"],
                AdNum = (string)reader["AdNum"],
                AdCP = (int)reader["AdCp"],
                AdVille = (string)reader["AdVille"],
                AdPays = (string)reader["AdPays"],
                IsActif = (bool)reader["IsActif"],
                NumTel = (reader["NumTel"] == DBNull.Value) ? null : (int?)reader["NumTel"],
                Email = (string)reader["Email"]
              };
            }
          }
        }
      }
    }

    // Ok au niveau des paramètres
    public void Update(Showrooms entity)
    {
      _repoAdresse.UpdateAdresse(entity.AdresseID, entity.AdRue, entity.AdNum, entity.AdCP, entity.AdVille, entity.AdPays, entity.NumTel, entity.Email);

      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Showroom_Update";
          command.Parameters.AddWithValue("@nom", entity.Nom);
          command.Parameters.AddWithValue("@NumBCE", entity.NumBCE);
          command.Parameters.AddWithValue("@adresseId", entity.AdresseID);
          command.Parameters.AddWithValue("@id", entity.ID);
          command.Parameters.AddWithValue("@isActif", entity.IsActif);
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
