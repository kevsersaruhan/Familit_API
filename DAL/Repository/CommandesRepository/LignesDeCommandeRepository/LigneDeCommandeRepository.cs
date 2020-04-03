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
          command.Parameters.AddWithValue("@ProductID", entity.Product.ID);
          command.Parameters.AddWithValue("@CommandeId", entity.IDCommande);
          command.Parameters.AddWithValue("@productName", entity.Product.Nom);
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
                ProductID = (int)reader["LigneProductID"],
                Product = new Products()
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
                  }
                }
              };
            }
          }
        }
      }
    }

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
                ProductID = (int)reader["LigneProductID"],
                Product = new Products()
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
                  }
                }
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
                ProductName = (string)reader["ProductName"],
                ProductID = (int)reader["LigneProductID"],
                Product = new Products()
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
                  }
                }
              };
            }
          }
        }
      }
    }
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
                ProductID = (int)reader["LigneProductID"],
                Product = new Products()
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
                  }
                }
              };
            }
          }
        }
      }
    }
    public void Update(int id, LigneDeCommande entity)
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
          command.Parameters.AddWithValue("@ProductID", entity.Product.ID);
          command.Parameters.AddWithValue("@CommandeId", entity.IDCommande);
          command.Parameters.AddWithValue("@productName", entity.Product.Nom);
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
