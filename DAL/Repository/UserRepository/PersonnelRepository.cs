
using DAL.Model.Etablissement;
using DAL.Model.User;
using DAL.Repository.EtablissementRepository;
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
  public class PersonnelRepository : IPersonnelRepository<int, Personnel>
  {
    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;

    public void Activer(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_Activer";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }
    public void Add(Personnel entity)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_Add";
          command.Parameters.AddWithValue("@nom", entity.Nom);
          command.Parameters.AddWithValue("@Prenom", entity.Prenom);
          command.Parameters.AddWithValue("@dateDeNaissance", entity.DateDeNaissance);
          command.Parameters.AddWithValue("@Login", entity.Login);
          command.Parameters.AddWithValue("@Password", entity.Password);
          command.Parameters.AddWithValue("@Function", entity.Fonction);
          command.Parameters.AddWithValue("@IsAdmin", entity.IsAdmin);
          command.Parameters.AddWithValue("@DateDengagement", entity.HireDate);
          command.Parameters.AddWithValue("@NbJourAbsence", entity.NbJoursAbsence);
          command.Parameters.AddWithValue("@NbJourVacances", entity.NbJourVacance);
          command.Parameters.AddWithValue("@ShowroomId", entity.ShowroomId);
          command.Parameters.AddWithValue("@adRue", entity.AdRue);
          command.Parameters.AddWithValue("@adNum", entity.AdNum);
          command.Parameters.AddWithValue("@adCp", entity.AdCP);
          command.Parameters.AddWithValue("@adVille", entity.AdVille);
          command.Parameters.AddWithValue("@adPays", entity.AdPays);
          command.Parameters.AddWithValue("@email", entity.Email);
          command.Parameters.AddWithValue("@numTel", entity.NumTel);
          command.Parameters.AddWithValue("@isActif", entity.IsActif);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          entity.ID = (int)command.ExecuteScalar();

        }
      }
    }
    public void ChangePassword(int id, string s)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_ChangePassword";
          command.Parameters.AddWithValue("@id", id);
          command.Parameters.AddWithValue("@password", s);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();

        }
      }
    }
    public void CheckPersonnel(int id, string login, string password)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_Check";
          command.Parameters.AddWithValue("@login", login);
          command.Parameters.AddWithValue("@password", password);
          command.Parameters.AddWithValue("@persoId", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();

        }
      }
    }
    public void Delete(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_Delete";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }
    public void Desactiver(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_Desactiver";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }
    public void DoAdmin(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_DoAdmin";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }
    public IEnumerable<Personnel> Get()
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_GetAll";
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Personnel()
              {
                ID = (int)reader["PersonnelID"],
                Nom = (string)reader["Nom"],
                Prenom = (string)reader["Prenom"],
                DateDeNaissance = (DateTime)reader["DateDeNaissance"],
                HireDate = (DateTime)reader["DateDengagement"],
                Fonction = (string)reader["Fonction"],
                Login = (string)reader["Login"],
                NbJoursAbsence = (int)reader["NbJourAbsence"],
                NbJourVacance = (int)reader["NbJourVacances"],
                Salaire = (double)reader["Salaire"],
                AdRue = (string)reader["PersonnelAdRue"],
                AdNum = (string)reader["PersonnelAdNum"],
                AdCP = (int)reader["PersonnelAdCp"],
                AdVille = (string)reader["PersonnelAdVille"],
                AdPays = (string)reader["PersonnelAdPays"],
                NumTel = (int)reader["PersonnelNumTel"],
                Email = (string)reader["PersonnelEmail"],
                ShowroomId = (int)reader["ShowroomId"],
                LieuDeTravail = new Showrooms
                {
                  ID = (int)reader["ShowroomID"],
                  Nom = (string)reader["ShowroomName"],
                  NumBCE = (string)reader["ShowroomNumBCE"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["ShowroomIsActif"]

                },
                IsActif = (bool)reader["IsActif"],
                IsAdmin = (bool)reader["IsAdmin"]
              };
            }
          }
        }
      }
    }
    public Personnel Get(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_GetByID";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            if (reader.Read())
            {
              return new Personnel()
              {
                ID = (int)reader["Id"],
                Nom = (string)reader["Nom"],
                Prenom = (string)reader["Prenom"],
                DateDeNaissance = (DateTime)reader["DateDeNaissance"],
                HireDate = (DateTime)reader["DateDengagement"],
                Fonction = (string)reader["Fonction"],
                Login = (string)reader["Login"],
                NbJoursAbsence = (int)reader["NbJourAbsence"],
                NbJourVacance = (int)reader["NbJourVacances"],
                Salaire = (double)reader["Salaire"],
                AdRue = (string)reader["AdRue"],
                AdNum = (string)reader["AdNum"],
                AdCP = (int)reader["AdCp"],
                AdVille = (string)reader["AdVille"],
                AdPays = (string)reader["AdPays"],
                NumTel = (int)reader["NumTel"],
                Email = (string)reader["EMail"],
                ShowroomId = (int)reader["ShowroomId"],
                LieuDeTravail = new Showrooms
                {
                  ID = (int)reader["ShowroomID"],
                  Nom = (string)reader["ShowroomName"],
                  NumBCE = (string)reader["ShowroomNumBCE"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["ShowroomIsActif"]

                },
                IsActif = (bool)reader["IsActif"],
                IsAdmin = (bool)reader["IsAdmin"]
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
    public IEnumerable<Personnel> GetByName(string name)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_GetByName";
          command.Parameters.AddWithValue("@nom", name);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Personnel()
              {
                ID = (int)reader["Id"],
                Nom = (string)reader["Nom"],
                Prenom = (string)reader["Prenom"],
                DateDeNaissance = (DateTime)reader["DateDeNaissance"],
                HireDate = (DateTime)reader["DateDengagement"],
                Fonction = (string)reader["Fonction"],
                Login = (string)reader["Login"],
                NbJoursAbsence = (int)reader["NbJourAbsence"],
                NbJourVacance = (int)reader["NbJourVacances"],
                Salaire = (double)reader["Salaire"],
                AdRue = (string)reader["AdRue"],
                AdNum = (string)reader["AdNum"],
                AdCP = (int)reader["AdCp"],
                AdVille = (string)reader["AdVille"],
                AdPays = (string)reader["AdPays"],
                NumTel = (int)reader["NumTel"],
                Email = (string)reader["EMail"],
                ShowroomId = (int)reader["ShowroomId"],
                LieuDeTravail = new Showrooms
                {
                  ID = (int)reader["ShowroomID"],
                  Nom = (string)reader["ShowroomName"],
                  NumBCE = (string)reader["ShowroomNumBCE"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["ShowroomIsActif"]

                },
                IsActif = (bool)reader["IsActif"],
                IsAdmin = (bool)reader["IsAdmin"]
              };
            }
          }
        }
      }
    }
    public IEnumerable<Personnel> GetPersonnelByShowroom(int idShowroom)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_GetByShowroom";
          command.Parameters.AddWithValue("@idshowroom", idShowroom);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Personnel()
              {
                ID = (int)reader["Id"],
                Nom = (string)reader["Nom"],
                Prenom = (string)reader["Prenom"],
                DateDeNaissance = (DateTime)reader["DateDeNaissance"],
                HireDate = (DateTime)reader["DateDengagement"],
                Fonction = (string)reader["Fonction"],
                Login = (string)reader["Login"],
                NbJoursAbsence = (int)reader["NbJourAbsence"],
                NbJourVacance = (int)reader["NbJourVacances"],
                Salaire = (double)reader["Salaire"],
                AdRue = (string)reader["AdRue"],
                AdNum = (string)reader["AdNum"],
                AdCP = (int)reader["AdCp"],
                AdVille = (string)reader["AdVille"],
                AdPays = (string)reader["AdPays"],
                NumTel = (int)reader["NumTel"],
                Email = (string)reader["EMail"],
                ShowroomId = (int)reader["ShowroomId"],
                LieuDeTravail = new Showrooms
                {
                  ID = (int)reader["ShowroomID"],
                  Nom = (string)reader["ShowroomName"],
                  NumBCE = (string)reader["ShowroomNumBCE"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["ShowroomIsActif"]

                },
                IsActif = (bool)reader["IsActif"],
                IsAdmin = (bool)reader["IsAdmin"]
              };
            }
          }
        }
      }
    }
    public void UnsetAdmin(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_UnsetAdmin";
          command.Parameters.AddWithValue("@Id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }
    public void Update(int id, Personnel entity)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Personnel_Update";
          command.Parameters.AddWithValue("@nom", entity.Nom);
          command.Parameters.AddWithValue("@Prenom", entity.Prenom);
          command.Parameters.AddWithValue("@dateDeNaissance", entity.DateDeNaissance);
          command.Parameters.AddWithValue("@Login", entity.Login);
          command.Parameters.AddWithValue("@Password", entity.Password);
          command.Parameters.AddWithValue("@Function", entity.Fonction);
          command.Parameters.AddWithValue("@IsAdmin", entity.IsAdmin);
          command.Parameters.AddWithValue("@DateDengagement", entity.HireDate);
          command.Parameters.AddWithValue("@NbJourAbsence", entity.NbJoursAbsence);
          command.Parameters.AddWithValue("@NbJourVacances", entity.NbJourVacance);
          command.Parameters.AddWithValue("@ShowroomId", entity.ShowroomId);
          command.Parameters.AddWithValue("@adRue", entity.AdRue);
          command.Parameters.AddWithValue("@adNum", entity.AdNum);
          command.Parameters.AddWithValue("@adCp", entity.AdCP);
          command.Parameters.AddWithValue("@adVille", entity.AdVille);
          command.Parameters.AddWithValue("@adPays", entity.AdPays);
          command.Parameters.AddWithValue("@email", entity.Email);
          command.Parameters.AddWithValue("@numTel", entity.NumTel);
          command.Parameters.AddWithValue("@id", id);
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
