using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Models.User_API
{
  public abstract class User_API
  {
    public int ID { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    [JsonIgnore]
    public string Login { get; set; }
    [JsonIgnore]
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
