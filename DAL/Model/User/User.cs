using DAL.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.User
{
  public abstract class User
  {
    public int ID { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public string AdRue { get; set; }
    public string AdNum { get; set; }
    public int AdCP { get; set; }
    public string AdVille { get; set; }
    public string AdPays { get; set; }
    public int NumTel { get; set; }
    public string Email { get; set; }
    public bool IsActif { get; set; }
  }
}
