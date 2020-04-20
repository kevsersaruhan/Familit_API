using DAL.Model.Commande;
using DAL.Model.Product;
using DAL.Model.User;
using DAL.Repository.ProductsRepository;
using DAL.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.CommandesRepository.LignesDeCommandeRepository
{
  public class LigneDeCommandeRepository : IRepository<int, LigneDeCommande>
  {
    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;

    //Ok
    public void Add(LigneDeCommande entity)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_LignesDeCommande_Add";
          command.Parameters.AddWithValue("@Total", entity.TOTAL);
          command.Parameters.AddWithValue("@quantite", entity.Quantite);
          command.Parameters.AddWithValue("@HTVA", entity.HTVA);
          command.Parameters.AddWithValue("@TVAC", entity.TVAC);
          command.Parameters.AddWithValue("@CommandeId", entity.IDCommande);
          command.Parameters.AddWithValue("@ProductID", entity.ProductID);
          command.Parameters.AddWithValue("@productName", entity.ProductName);
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
          command.CommandText = "SP_LignesDeCommande_Delete";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }

    //Ok en poco -> A alimenter dans le mapper
    public IEnumerable<LigneDeCommande> Get()
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_LignesDeCommande_GetAll";
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new LigneDeCommande()
              {
                ID = (int)reader["Id"],
                TOTAL = (double)reader["Total"],
                HTVA = (double)reader["HTVA"],
                TVAC = (double)reader["TVAC"],
                Quantite = (int)reader["Quantite"],
                IDCommande = (int)reader["CommandeId"],
                ProductName = (string)reader["ProductName"],
                ProductID = (int)reader["LigneProductID"]
              };
            }
          }
        }
      }
    }

    //Ok en poco -> A alimenter dans le mapper
    public LigneDeCommande Get(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_LignesDeCommande_GetByID";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            if (reader.Read())
            {
              return new LigneDeCommande()
              {
                ID = (int)reader["Id"],
                TOTAL = (double)reader["Total"],
                HTVA = (double)reader["HTVA"],
                TVAC = (double)reader["TVAC"],
                Quantite = (int)reader["Quantite"],
                IDCommande = (int)reader["CommandeId"],
                ProductName = (string)reader["ProductName"],
                ProductID = (int)reader["LigneProductID"]
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

    //Ok en poco -> A alimenter dans le mapper
    public IEnumerable<LigneDeCommande> GetByCommandeId(int idCommande)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_LignesDeCommande_GetByCommande";
          command.Parameters.AddWithValue("@idCommande", idCommande);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new LigneDeCommande()
              {
                ID = (int)reader["Id"],
                TOTAL = (double)reader["Total"],
                HTVA = (double)reader["HTVA"],
                TVAC = (double)reader["TVAC"],
                Quantite = (int)reader["Quantite"],
                IDCommande = (int)reader["CommandeId"],
                ProductName=(string)reader["ProductName"],
                ProductID=(int)reader["LigneProductID"]
               };
              }
            }
          }
        }
       }

    //Ok en poco -> A alimenter dans le mapper
    public IEnumerable<LigneDeCommande> GetByProductId(int idProduct)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_LignesDeCommande_GetByProduct";
          command.Parameters.AddWithValue("@idProduct", idProduct);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new LigneDeCommande()
              {
                ID = (int)reader["Id"],
                TOTAL = (double)reader["Total"],
                HTVA = (double)reader["HTVA"],
                TVAC = (double)reader["TVAC"],
                Quantite = (int)reader["Quantite"],
                IDCommande = (int)reader["CommandeId"],
                ProductName = (string)reader["ProductName"],
                ProductID = (int)reader["LigneProductID"]
              };
            }
          }
        }
      }
    }

    //Ok
    public void Update(LigneDeCommande entity)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_LignesDeCommande_Update";
          command.Parameters.AddWithValue("@Total", entity.TOTAL);
          command.Parameters.AddWithValue("@quantite", entity.Quantite);
          command.Parameters.AddWithValue("@HTVA", entity.HTVA);
          command.Parameters.AddWithValue("@TVAC", entity.TVAC);
          command.Parameters.AddWithValue("@ProductID", entity.ProductID);
          command.Parameters.AddWithValue("@CommandeId", entity.IDCommande);
          command.Parameters.AddWithValue("@productName", entity.ProductName);
          command.Parameters.AddWithValue("@id", entity.ID);
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
