using DAL.Model.Product;
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
  public class CaracteristiqueRepository : ICaracteristiqueRepository<int, Caracteristique>
  {
    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;

   //Ok
    public void Add(Caracteristique entity)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Caracteristique_Add";
          command.Parameters.AddWithValue("@Nom", entity.Nom);
          command.Parameters.AddWithValue("@Details", entity.Details);
          command.Parameters.AddWithValue("@Categorie", entity.CatId);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          entity.Id = (int)command.ExecuteScalar();

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
          command.CommandText = "SP_Caracteristique_Delete";
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
    public IEnumerable<Caracteristique> Get()
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Caracteristique_GetAll";
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Caracteristique()
              {
                Id = (int)reader["Id"],
                Nom = (string)reader["Nom"],
                Details = (string)reader["Details"],
                CatId =(reader["CategorieId"] == DBNull.Value) ? null : (int?)reader["CategorieId"]
              };
            }
          }
        }
      }
    }

    //Ok
    public Caracteristique Get(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Caracteristique_GetById";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            if (reader.Read())
            {
              return new Caracteristique()
              {
                Id = (int)reader["Id"],
                Nom = (string)reader["Nom"],
                Details = (string)reader["Details"],
                CatId = (reader["CategorieId"] == DBNull.Value) ? null : (int?)reader["CategorieId"]
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
    public IEnumerable<Caracteristique> GetCaracteristiqueByCategorie(int idcat)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Caracteristique_GetByCategorie";
          command.Parameters.AddWithValue("@id", idcat);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Caracteristique()
              {
                Id = (int)reader["Id"],
                Nom = (string)reader["Nom"],
                Details = (string)reader["Details"],
                CatId = (reader["CategorieId"] == DBNull.Value) ? null : (int?)reader["CategorieId"]
              };
            }
          }
        }
      }
    }

    //Ok
    public IEnumerable<Caracteristique> GetCaracteristiqueByProduct(int idproduct)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_Caracteristique_GetByProduct";
          command.Parameters.AddWithValue("@idproduct", idproduct);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new Caracteristique()
              {
                Id = (int)reader["Id"],
                Nom = (string)reader["Nom"],
                Details = (string)reader["Details"],
                CatId = (reader["CategorieId"] == DBNull.Value) ? null : (int?)reader["CategorieId"]
              };
            }
          }
        }
      }
    }

    //Ok
    public void Update(Caracteristique entity)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Caracteristique_Update";
          command.Parameters.AddWithValue("@id", entity.Id);
          command.Parameters.AddWithValue("@nom", entity.Nom);
          command.Parameters.AddWithValue("@details", entity.Details);
          command.Parameters.AddWithValue("@categorieId", entity.CatId);
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
