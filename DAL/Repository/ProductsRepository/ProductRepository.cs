using DAL.Model.Product;
using DAL.Model.User;
using DAL.Repository.UserRepository;
using DAL.Utils.ProductUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.ProductsRepository
{
  public class ProductRepository : IProductRepository<int,Products>
  {

    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;
    public void Activer(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_Activer";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }
    public void Add(Products entity)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_Add";
          command.Parameters.AddWithValue("@nom", entity.Nom);
          command.Parameters.AddWithValue("@Prix", entity.Prix);
          command.Parameters.AddWithValue("@prixDAchatHTVA", entity.PrixDAchatTHTVA);
          command.Parameters.AddWithValue("@TVA", entity.TVA);
          command.Parameters.AddWithValue("@nbPiece", entity.NbPiece);
          command.Parameters.AddWithValue("@details", entity.Details);
          command.Parameters.AddWithValue("@catId", entity.CatId);
          command.Parameters.AddWithValue("@clientId", entity.ClientId);
          command.Parameters.AddWithValue("@isActif", entity.IsActif);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          entity.ID = (int)command.ExecuteScalar();
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
          command.CommandText = "SP_Product_Delete";
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
          command.CommandText = "SP_Product_Desactiver";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }

    public IEnumerable<Products> Get()
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_GetAll";
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Products()
              {
                ID = (int)reader["ProductID"],
                Nom = (string)reader["Nom"],
                Prix = (double)reader["Prix"],
                PrixDAchatTHTVA = (double)reader["PrixDAchatHTVA"],
                TVA = (double)reader["TVA"],
                NbPiece = (int)reader["NbPiece"],
                Details = (string)reader["Details"],
                CatId = (int)reader["CategorieId"],
                ClientId = (int)reader["ClientId"],
                Fournisseur = new Client
                {
                  ID = (int)reader["FournisseurID"],
                  Nom = (string)reader["FournisseurNom"],
                  Prenom = (string)reader["Prenom"],
                  Login = (string)reader["Login"],
                  NumBCE = (string)reader["NumBCE"],
                  EstFournisseur = (bool)reader["EstFournisseur"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["ClientIsActif"]
                },
                Categorie = new Categories
                {
                  ID = (int)reader["CatID"],
                  Nom = (string)reader["CatNom"],
                  Details = (string)reader["CatDetails"],
                  IsActif = (bool)reader["CatIsActif"]
                },
                IsActif = (bool)reader["IsActif"]
              };
            }
          }
        }
      }
    }

    public Products Get(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_GetById";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            if (reader.Read())
            {
              return new Products()
              {
                ID = (int)reader["ProductID"],
                Nom = (string)reader["Nom"],
                Prix = (double)reader["Prix"],
                PrixDAchatTHTVA = (double)reader["PrixDAchatHTVA"],
                TVA = (double)reader["TVA"],
                NbPiece = (int)reader["NbPiece"],
                Details = (string)reader["Details"],
                CatId = (int)reader["CategorieId"],
                ClientId = (int)reader["ClientId"],
                Fournisseur = new Client
                {
                  ID = (int)reader["FournisseurID"],
                  Nom = (string)reader["FournisseurNom"],
                  Prenom = (string)reader["Prenom"],
                  Login = (string)reader["Login"],
                  NumBCE = (string)reader["NumBCE"],
                  EstFournisseur = (bool)reader["EstFournisseur"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["ClientIsActif"]
                },
                Categorie = new Categories
                {
                  ID = (int)reader["CatID"],
                  Nom = (string)reader["CatNom"],
                  Details = (string)reader["CatDetails"],
                  IsActif = (bool)reader["CatIsActif"]
                },
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

    public IEnumerable<Products> GetProductByFournisseur(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_GetByfournisseur";
          command.Parameters.AddWithValue("@clientId", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Products()
              {
                ID = (int)reader["ProductID"],
                Nom = (string)reader["Nom"],
                Prix = (double)reader["Prix"],
                PrixDAchatTHTVA = (double)reader["PrixDAchatHTVA"],
                TVA = (double)reader["TVA"],
                NbPiece = (int)reader["NbPiece"],
                Details = (string)reader["Details"],
                CatId = (int)reader["CategorieId"],
                ClientId = (int)reader["ClientId"],
                Fournisseur = new Client
                {
                  ID = (int)reader["FournisseurID"],
                  Nom = (string)reader["FournisseurNom"],
                  Prenom = (string)reader["Prenom"],
                  Login = (string)reader["Login"],
                  NumBCE = (string)reader["NumBCE"],
                  EstFournisseur = (bool)reader["EstFournisseur"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["ClientIsActif"]
                },
                Categorie = new Categories
                {
                  ID = (int)reader["CatID"],
                  Nom = (string)reader["CatNom"],
                  Details = (string)reader["CatDetails"],
                  IsActif = (bool)reader["CatIsActif"]
                },
                IsActif = (bool)reader["IsActif"]
              };
            }
          }
        }
      }
    }

    public IEnumerable<Products> GetProductByName(string s)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_GetByName";
          command.Parameters.AddWithValue("@nom", s);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Products()
              {
                ID = (int)reader["ProductID"],
                Nom = (string)reader["Nom"],
                Prix = (double)reader["Prix"],
                PrixDAchatTHTVA = (double)reader["PrixDAchatHTVA"],
                TVA = (double)reader["TVA"],
                NbPiece = (int)reader["NbPiece"],
                Details = (string)reader["Details"],
                CatId = (int)reader["CategorieId"],
                ClientId = (int)reader["ClientId"],
                Fournisseur = new Client
                {
                  ID = (int)reader["FournisseurID"],
                  Nom = (string)reader["FournisseurNom"],
                  Prenom = (string)reader["Prenom"],
                  Login = (string)reader["Login"],
                  NumBCE = (string)reader["NumBCE"],
                  EstFournisseur = (bool)reader["EstFournisseur"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["ClientIsActif"]
                },
                Categorie = new Categories
                {
                  ID = (int)reader["CatID"],
                  Nom = (string)reader["CatNom"],
                  Details = (string)reader["CatDetails"],
                  IsActif = (bool)reader["CatIsActif"]
                },
                IsActif = (bool)reader["IsActif"]
              };
            }
          }
        }
      }
    }

    public IEnumerable<Products> GetProductFav(int idclient)
    {

      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_Product_Fav";
          command.Parameters.AddWithValue("@id", idclient);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Products()
              {
                ID = (int)reader["ProductID"],
                Nom = (string)reader["Nom"],
                Prix = (double)reader["Prix"],
                PrixDAchatTHTVA = (double)reader["PrixDAchatHTVA"],
                TVA = (double)reader["TVA"],
                NbPiece = (int)reader["NbPiece"],
                Details = (string)reader["Details"],
                CatId = (int)reader["CategorieId"],
                ClientId = (int)reader["ClientId"],
                Fournisseur = new Client
                {
                  ID = (int)reader["FournisseurID"],
                  Nom = (string)reader["FournisseurNom"],
                  Prenom = (string)reader["Prenom"],
                  Login = (string)reader["Login"],
                  NumBCE = (string)reader["NumBCE"],
                  EstFournisseur = (bool)reader["EstFournisseur"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["ClientIsActif"]
                },
                Categorie = new Categories
                {
                  ID = (int)reader["CatID"],
                  Nom = (string)reader["CatNom"],
                  Details = (string)reader["CatDetails"],
                  IsActif = (bool)reader["CatIsActif"]
                },
                IsActif = (bool)reader["IsActif"]
              };
            }

          }
        }
      }
    }

    public IEnumerable<Products> GetProductListByCaracteristique(int idcaract)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {

          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_Caracteristique_GetByCaracteristique";
          command.Parameters.AddWithValue("@idcaract", idcaract);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Products()
              {
                ID = (int)reader["ProductID"],
                Nom = (string)reader["Nom"],
                Prix = (double)reader["Prix"],
                PrixDAchatTHTVA = (double)reader["PrixDAchatHTVA"],
                TVA = (double)reader["TVA"],
                NbPiece = (int)reader["NbPiece"],
                Details = (string)reader["Details"],
                CatId = (int)reader["CategorieId"],
                ClientId = (int)reader["ClientId"],
                Fournisseur = new Client
                {
                  ID = (int)reader["FournisseurID"],
                  Nom = (string)reader["FournisseurNom"],
                  Prenom = (string)reader["Prenom"],
                  Login = (string)reader["Login"],
                  NumBCE = (string)reader["NumBCE"],
                  EstFournisseur = (bool)reader["EstFournisseur"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["ClientIsActif"]
                },
                Categorie = new Categories
                {
                  ID = (int)reader["CatID"],
                  Nom = (string)reader["CatNom"],
                  Details = (string)reader["CatDetails"],
                  IsActif = (bool)reader["CatIsActif"]
                },
                IsActif = (bool)reader["IsActif"]
              };
            }
          }
        }
      }
    }

    public void Update(int id, Products entity)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_Update";
          command.Parameters.AddWithValue("@nom", entity.Nom);
          command.Parameters.AddWithValue("@prixDAchatHTVA", entity.PrixDAchatTHTVA);
          command.Parameters.AddWithValue("@prix", entity.Prix);
          command.Parameters.AddWithValue("@TVA", entity.TVA);
          command.Parameters.AddWithValue("@nbPiece", entity.NbPiece);
          command.Parameters.AddWithValue("@details", entity.Details);
          command.Parameters.AddWithValue("@catId", entity.CatId);
          command.Parameters.AddWithValue("@clientId", entity.ClientId);
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
