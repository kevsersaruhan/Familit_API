using DAL.Model.User;
using DAL.Repository.CommandesRepository;
using DAL.Repository.ProductsRepository;
using DAL.Repository.RepertoireRepository;
using DAL.Utils.UserUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.UserRepository
{
  public class ClientRepository : IClientRepository<int, Client>
  {
    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;
    private AdresseRepository _repoAdresse = new AdresseRepository();
    //Ok
    public void Activer(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_Activer";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }
  
    //Ok
    public void Add(Client entity)
    {
      int adresseId = _repoAdresse.AddAdresse(entity.AdRue, entity.AdNum, entity.AdCP, entity.AdVille, entity.AdPays, entity.Email, entity.NumTel);
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_Add";
          command.Parameters.AddWithValue("@nom", entity.Nom);
          command.Parameters.AddWithValue("@Prenom", entity.Prenom);
          command.Parameters.AddWithValue("@login", entity.Login);
          command.Parameters.AddWithValue("@Password", entity.Password);
          command.Parameters.AddWithValue("@EstFournisseur", entity.EstFournisseur);
          command.Parameters.AddWithValue("@NumBCE", entity.NumBCE);
          command.Parameters.AddWithValue("@AdresseId", adresseId);
          command.Parameters.AddWithValue("@isActif", entity.IsActif);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          entity.ID = (int)command.ExecuteScalar();
        }
      }
    }

    //Ok
    public void ChangePassword(int id, string password)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_ChangePassword";
          command.Parameters.AddWithValue("@id", id);
          command.Parameters.AddWithValue("@password", password);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();

        }
      }
    }

    //Ok
    public int CheckClient(string login, string password)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_Check";
          command.Parameters.AddWithValue("@login", login);
          command.Parameters.AddWithValue("@password", password);
          command.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
          return Convert.ToInt32(command.Parameters["@id"].Value);
        }
      }
    }

    //Ok
    public void Delete(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_Delete";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }

    //Ok
    public void Desactiver(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_Desactiver";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }

    //Ok
    public IEnumerable<Client> Get()
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_GetAll";
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Client()
              {
                ID = (int)reader["ClientID"],
                Nom = (string)reader["Nom"],
                Prenom = (string)reader["Prenom"],
                Login = (string)reader["Login"],
                AdresseID =(int)reader["AdresseId"],
                NumBCE=(string)reader["NumBCE"],
                EstFournisseur=(bool)reader["EstFournisseur"],
                AdRue = (string)reader["AdRue"],
                AdNum = (string)reader["AdNum"],
                AdCP = (int)reader["AdCp"],
                AdVille = (string)reader["AdVille"],
                AdPays = (string)reader["AdPays"],
                NumTel = (reader["NumTel"] == DBNull.Value) ? null : (int?)reader["NumTel"],
                Email = (string)reader["EMail"],
                IsActif =(bool)reader["IsActif"]
              };
            }
          }
        }
      }
    }

    //Get Fournisseur
    public IEnumerable<Client> GetFournisseur()
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_GetFournisseur";
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Client()
              {
                ID = (int)reader["ClientID"],
                Nom = (string)reader["Nom"],
                Prenom = (string)reader["Prenom"],
                Login = (string)reader["Login"],
                AdresseID = (int)reader["AdresseId"],
                NumBCE = (string)reader["NumBCE"],
                EstFournisseur = (bool)reader["EstFournisseur"],
                AdRue = (string)reader["AdRue"],
                AdNum = (string)reader["AdNum"],
                AdCP = (int)reader["AdCp"],
                AdVille = (string)reader["AdVille"],
                AdPays = (string)reader["AdPays"],
                NumTel = (reader["NumTel"] == DBNull.Value) ? null : (int?)reader["NumTel"],
                Email = (string)reader["EMail"],
                IsActif = (bool)reader["IsActif"]
              };
            }
          }
        }
      }
    }
    //Ok
    public Client Get(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_GetByID";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            if (reader.Read())
            {
              return new Client()
              {
                ID = (int)reader["ClientID"],
                Nom = (string)reader["Nom"],
                Prenom = (string)reader["Prenom"],
                Login = (string)reader["Login"],
                AdresseID = (int)reader["AdresseId"],
                NumBCE = (string)reader["NumBCE"],
                EstFournisseur = (bool)reader["EstFournisseur"],
                AdRue = (string)reader["AdRue"],
                AdNum = (string)reader["AdNum"],
                AdCP = (int)reader["AdCp"],
                AdVille = (string)reader["AdVille"],
                AdPays = (string)reader["AdPays"],
                NumTel = (reader["NumTel"] == DBNull.Value) ? null : (int?)reader["NumTel"],
                Email = (string)reader["EMail"],
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

    //Ok
    public IEnumerable<Client> GetByName(string name)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_GetByName";
          command.Parameters.AddWithValue("@nom", name);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Client()
              {
                ID = (int)reader["ClientID"],
                Nom = (string)reader["Nom"],
                Prenom = (string)reader["Prenom"],
                Login = (string)reader["Login"],
                AdresseID = (int)reader["AdresseId"],
                NumBCE = (string)reader["NumBCE"],
                EstFournisseur = (bool)reader["EstFournisseur"],
                AdRue = (string)reader["AdRue"],
                AdNum = (string)reader["AdNum"],
                AdCP = (int)reader["AdCp"],
                AdVille = (string)reader["AdVille"],
                AdPays = (string)reader["AdPays"],
                NumTel = (reader["NumTel"] == DBNull.Value) ? null : (int?)reader["NumTel"],
                Email = (string)reader["EMail"],
                IsActif = (bool)reader["IsActif"]
              };
            }
          }
        }
      }
    }

    //Ok
    public void Update(Client entity)
    {
      _repoAdresse.UpdateAdresse(entity.AdresseID, entity.AdRue, entity.AdNum,entity.AdCP, entity.AdVille, entity.AdPays, entity.NumTel, entity.Email);
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_Update";
          command.Parameters.AddWithValue("@nom", entity.Nom);
          command.Parameters.AddWithValue("@prenom", entity.Prenom);
          command.Parameters.AddWithValue("@login", entity.Login);
          command.Parameters.AddWithValue("@EstFournisseur", entity.EstFournisseur);
          command.Parameters.AddWithValue("@NumBCE", entity.NumBCE);
          command.Parameters.AddWithValue("@id",entity.ID);
          command.Parameters.AddWithValue("@isActif", entity.IsActif);
          command.Parameters.AddWithValue("@adresseId", entity.AdresseID);
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
