using API_Familit.Models.User_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Models.Etablissement_API
{
  public class Showroom_API
  {
    public Showroom_API()
    {
      PersonnelList = new List<Personnel_API>();
    }
    public int ID { get; set; }
    public string Nom { get; set; }
    public string NumBCE { get; set; }
    public string AdRue { get; set; }
    public string AdNum { get; set; }
    public int AdCP { get; set; }
    public string AdVille { get; set; }
    public string AdPays { get; set; }
    public int NumTel { get; set; }
    public string Email { get; set; }
    public IEnumerable<Personnel_API> PersonnelList { get; set; }
    public bool IsActif { get; set; }
  }
}
