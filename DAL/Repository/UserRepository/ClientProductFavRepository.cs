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
  public class ClientProductFavRepository : IClientProductFavRepository
  {
    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;
    public void AddProductToFav(int idProduct, int idClient)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_Product_Add";
          command.Parameters.AddWithValue("@idclient", idClient);
          command.Parameters.AddWithValue("@idproduct", idProduct);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteScalar();
        }
      }
    }

    public void DeleteProductFav(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Client_Product_Delete";
          command.Parameters.AddWithValue("@id", id);
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
