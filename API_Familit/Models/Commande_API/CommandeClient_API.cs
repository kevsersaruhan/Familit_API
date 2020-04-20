using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Models.Commande_API
{
  public class CommandeClient_API : Commandes_API
  {
    public int? VendeurID { get; set; }
    public string MoyenDePaiement { get; set; }
    public string Statut { get; set; }
    public bool? Livraison { get; set; }
    public DateTime? DateDeLivraison { get; set; }
  }
}
