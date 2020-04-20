using DAL.Model.Commande;
using DAL.Model.Product;
using DAL.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Etablissement
{
  public class Showrooms 
  {
    public int ID { get; set; }
    public string Nom { get; set; }
    public string NumBCE { get; set; }
    public string AdRue { get; set; }
    public string AdNum { get; set; }
    public int AdCP { get; set; }
    public string AdVille { get; set; }
    public string AdPays { get; set; }
    public int? NumTel { get; set; }
    public string Email { get; set; }
    public bool IsActif { get; set; }
    public int AdresseID { get; set; }
  }
}
