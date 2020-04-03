using API_Familit.Models.Etablissement_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Models.Commande_API
{

    public class Commandes_API
    {
      public Commandes_API()
      {
        DetailsCommande = new List<LigneDeCommande_API>();
      }
      public int ClientID { get; set; }
      public int ID { get; set; }
      public IEnumerable<LigneDeCommande_API> DetailsCommande { get; set; }
      public DateTime DateDeCommande { get; set; }
      public double Total { get; set; }
      public double Acompte { get; set; }
      public double Solde { get; set; }
      public Showroom_API Showroom { get; set; }
      public string TypeDeCommande { get; set; }
    }
  
}
