using DAL.Model.Commande;
using DAL.Model.Etablissement;
using DAL.Repository.CommandesRepository.LignesDeCommandeRepository;
using DAL.Repository.EtablissementRepository;
using DAL.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.CommandesRepository
{
  public class CommandeClientRepository : IRepository<int, CommandeClients>
  {
    private string _constring = ConfigurationManager.ConnectionStrings["BDD_Familit"].ConnectionString;
    public void Add(CommandeClients entity)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Commandes_Add";
          command.Parameters.AddWithValue("@DateDecommande", entity.DateDeCommande);
          command.Parameters.AddWithValue("@Total", entity.Total);
          command.Parameters.AddWithValue("@Acompte", entity.Acompte);
          command.Parameters.AddWithValue("@Solde", entity.Solde);
          command.Parameters.AddWithValue("@MoyenDePaiement", entity.MoyenDePaiement);
          command.Parameters.AddWithValue("@Statut", entity.Statut);
          command.Parameters.AddWithValue("@Livraison", entity.Livraison);
          command.Parameters.AddWithValue("@DateDeLivraison", entity.DateDeLivraison);
          command.Parameters.AddWithValue("@TypeDecommande", entity.TypeDeCommande);
          command.Parameters.AddWithValue("@ClientId", entity.ClientID);
          command.Parameters.AddWithValue("@PersonnelId", entity.VendeurID);
          command.Parameters.AddWithValue("@ShowroomId", entity.Showroom.ID);
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
          command.CommandText = "SP_Commande_Delete";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }

    public IEnumerable<CommandeClients> Get()
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Commande_GetAll";
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new CommandeClients()
              {
                ID = (int)reader["Id"],
                DateDeCommande = (DateTime)reader["DateCommande"],
                Total = (double)reader["Total"],
                Acompte = (double)reader["Acompte"],
                Solde = (double)reader["Solde"],
                MoyenDePaiement = (string)reader["MoyenDePaiement"],
                Statut = (string)reader["Statut"],
                DateDeLivraison = (DateTime)reader["DateDeLivraison"],
                TypeDeCommande = (string)reader["TypeDeCommande"],
                Livraison = (bool)reader["Livraison"],
                Showroom = new Showrooms
                {
                  ID = (int)reader["IDShowroom"],
                  Nom = (string)reader["Nom"],
                  NumBCE = (string)reader["NumBCE"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["IsActif"]
                },
                ShowroomID = (int)reader["ComShowroomID"],
                ClientID = (int)reader["ClientId"],
                VendeurID = (int)reader["PersonnelId"]
              };
            }
          }
        }
      }
    }

    public CommandeClients Get(int id)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Commande_GetByID";
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            if (reader.Read())
            {
              return new CommandeClients()
              {
                ID = (int)reader["Id"],
                DateDeCommande = (DateTime)reader["DateCommande"],
                Total = (double)reader["Total"],
                Acompte = (double)reader["Acompte"],
                Solde = (double)reader["Solde"],
                MoyenDePaiement = (string)reader["MoyenDePaiement"],
                Statut = (string)reader["Statut"],
                DateDeLivraison = (DateTime)reader["DateDeLivraison"],
                TypeDeCommande = (string)reader["TypeDeCommande"],
                Livraison = (bool)reader["Livraison"],
                Showroom = new Showrooms
                {
                  ID = (int)reader["IDShowroom"],
                  Nom = (string)reader["Nom"],
                  NumBCE = (string)reader["NumBCE"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["IsActif"]
                },
                ShowroomID = (int)reader["ComShowroomID"],
                ClientID = (int)reader["ClientId"],
                VendeurID = (int)reader["PersonnelId"]
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
    public void Update(int id, CommandeClients entity)
    {
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Commandes_Update";
          command.Parameters.AddWithValue("@DateDecommande", entity.DateDeCommande);
          command.Parameters.AddWithValue("@Total", entity.Total);
          command.Parameters.AddWithValue("@Acompte", entity.Acompte);
          command.Parameters.AddWithValue("@Solde", entity.Solde);
          command.Parameters.AddWithValue("@MoyenDePaiement", entity.MoyenDePaiement);
          command.Parameters.AddWithValue("@Statut", entity.Statut);
          command.Parameters.AddWithValue("@Livraison", entity.Livraison);
          command.Parameters.AddWithValue("@DateDeLivraison", entity.DateDeLivraison);
          command.Parameters.AddWithValue("@TypeDecommande", entity.TypeDeCommande);
          command.Parameters.AddWithValue("@ClientId", entity.ClientID);
          command.Parameters.AddWithValue("@PersonnelId", entity.VendeurID);
          command.Parameters.AddWithValue("@ShowroomId", entity.Showroom.ID);
          command.Parameters.AddWithValue("@id", id);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          command.ExecuteNonQuery();
        }
      }
    }

    public IEnumerable<CommandeClients> GetCommandeClient(int idclient)
    {
      List<CommandeClients> ListeCommandeClient = new List<CommandeClients>();
      using (SqlConnection connection = new SqlConnection(_constring))
      {
        using (SqlCommand command = connection.CreateCommand())
        {
          command.CommandType = CommandType.StoredProcedure;
          command.CommandText = "SP_Commande_GetCommandeClient";
          command.Parameters.AddWithValue("@id", idclient);
          if (connection.State != ConnectionState.Open)
          {
            connection.Open();
          }
          using (SqlDataReader reader = command.ExecuteReader())
          {
            while (reader.Read())
            {
              yield return new CommandeClients()
              {
                ID = (int)reader["Id"],
                DateDeCommande = (DateTime)reader["DateCommande"],
                Total = (double)reader["Total"],
                Acompte = (double)reader["Acompte"],
                Solde = (double)reader["Solde"],
                MoyenDePaiement = (string)reader["MoyenDePaiement"],
                Statut = (string)reader["Statut"],
                DateDeLivraison = (DateTime)reader["DateDeLivraison"],
                TypeDeCommande = (string)reader["TypeDeCommande"],
                Livraison = (bool)reader["Livraison"],
                Showroom = new Showrooms
                {
                  ID = (int)reader["IDShowroom"],
                  Nom = (string)reader["Nom"],
                  NumBCE = (string)reader["NumBCE"],
                  AdRue = (string)reader["AdRue"],
                  AdNum = (string)reader["AdNum"],
                  AdCP = (int)reader["AdCp"],
                  AdVille = (string)reader["AdVille"],
                  AdPays = (string)reader["AdPays"],
                  NumTel = (int)reader["NumTel"],
                  Email = (string)reader["EMail"],
                  IsActif = (bool)reader["IsActif"]
                },
                ShowroomID = (int)reader["ComShowroomID"],
                ClientID = (int)reader["ClientId"],
                VendeurID = (int)reader["PersonnelId"]
              };
            }
          }
        }
      }
    }
  }
}
