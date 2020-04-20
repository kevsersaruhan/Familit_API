using API_Familit.Models.Commande_API;
using API_Familit.Models.Products_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Models.User_API
{
  public class Client_API :User_API
  {
  
    public Client_API()
    {
      ListFav = new List<Product_API>();
      ListCommande = new List<CommandeClient_API>();
      ListeProduct = new List<Product_API>();
    }
    public string NumBCE { get; set; }
    public bool EstFournisseur { get; set; }
    public IEnumerable<Product_API> ListFav { get; set; }
    public IEnumerable<CommandeClient_API> ListCommande { get; set; }
    public IEnumerable<Product_API> ListeProduct { get; set; }
  }
}
