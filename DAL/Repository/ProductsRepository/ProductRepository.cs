using DAL.Model.Product;
using DAL.Utils.ProductUtils;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repository.ProductsRepository
{
  public class ProductRepository : IProductRepository<int, Products>
  {
    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;
   
    //Ok
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

    //Ok
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

    //Ok
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

    //Ok
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

    //Ok
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
              yield return new Products() {
                ID = (int)reader["ProductID"],
                Nom = (string)reader["Nom"],
                Prix = (double)reader["Prix"],
                PrixDAchatTHTVA = (double)reader["PrixDAchatHTVA"],
                TVA = (double)reader["TVA"],
                NbPiece = (int)reader["NbPiece"],
                Details = (string)reader["Details"],
                CatId = (int)reader["CategorieId"],
                ClientId = (int)reader["ClientId"],
                IsActif = (bool)reader["IsActif"]
              };
            }
          }
        }
      }
    }

    //Ok
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
                ID = (int)reader["Id"],
                Nom = (string)reader["Nom"],
                Prix = (double)reader["Prix"],
                PrixDAchatTHTVA = (double)reader["PrixDAchatHTVA"],
                TVA = (double)reader["TVA"],
                NbPiece = (int)reader["NbPiece"],
                Details = (string)reader["Details"],
                CatId = (int)reader["CategorieId"],
                ClientId = (int)reader["ClientId"],
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
                IsActif = (bool)reader["IsActif"]
              };
            }
          }
        }
      }
    }

    //Ok
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
                IsActif = (bool)reader["IsActif"]
              };
            }
          }
        }
      }
    }

    //Ok
    public IEnumerable<Products> GetProductFav(int idclient)
    {

      using (SqlConnection connection = new SqlConnection(_constring))
      {
        List<Products> ListeProduct = new List<Products>();
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_Product_Fav";
          command.Parameters.AddWithValue("@idclient", idclient);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              ListeProduct.Add(Get((int)reader["ProductId"]));
            }
            return ListeProduct;
          }

        }
      }
    }

    //Ok
    public IEnumerable<Products> GetProductListByCaracteristique(int idcaract)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        List<Products> ListeProduct = new List<Products>();
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_Caracteristique_GetByCaracteristique";
          command.Parameters.AddWithValue("@idcarcat", idcaract);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            
              while (reader.Read())
              {
                ListeProduct.Add(Get((int)reader["ProductId"]));
              }
              return ListeProduct;
          }
        }
      }
    }

    //Ok
    public void Update(Products entity)
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
