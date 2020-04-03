using DAL.Model.Commande;
using DAL.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.User
{
 public class Client : User
  {
    public Client()
    {
      ListFav = new List<Products>();
      ListCommande = new List<CommandeClients>();
    }
    public string NumBCE { get; set; }
    public bool EstFournisseur { get; set; }
    public IEnumerable<Products> ListFav { get; set; }
    public IEnumerable<CommandeClients> ListCommande { get; set; }
  }
}
