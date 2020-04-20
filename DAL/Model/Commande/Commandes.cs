using DAL.Model.Commande;
using DAL.Model.Etablissement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Commande
{
  public class Commandes
  {
 
    public int ClientID { get; set; }
    public int ID { get; set; }
    public DateTime DateDeCommande { get; set; }
    public double Total { get; set; }
    public double Acompte { get; set; }
    public double Solde { get; set; }
    public int? ShowroomID { get; set; }
    public string TypeDeCommande { get; set; }
  }
}
