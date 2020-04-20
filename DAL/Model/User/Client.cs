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
   
    public string NumBCE { get; set; }
    public bool EstFournisseur { get; set; }
    public IEnumerable<Products> ListFav { get; set; }
    public IEnumerable<Products> ListeProduct { get; set; }
    public IEnumerable<CommandeClients> ListCommande { get; set; }
  }
}
