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
  public class ProductCaracteristiqueRepository : IProductCaracteristiqueRepository
  {
    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;

    //OK
    public void AddCaracteristiqueToProduct(int idCaract, int idProduct)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_Caracteristique_Add";
          command.Parameters.AddWithValue("@idProduct",idProduct);
          command.Parameters.AddWithValue("@idCaracteristique", idCaract);
          connection.Open();
          command.ExecuteScalar();

        }
      }
    }

    //Ok
    public void DeleteCaracteristiqueFromProduct(int idCaract, int idProduct)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Product_Caracteristique_delete";
          command.Parameters.AddWithValue("@idproduct", idProduct);
          command.Parameters.AddWithValue("@idCaract", idCaract);
          connection.Open();
          command.ExecuteNonQuery();
        }
      }
    }
  }
}
