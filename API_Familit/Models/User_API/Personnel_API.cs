using API_Familit.Models.Etablissement_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Models.User_API
{
  public class Personnel_API : User_API
  {
    public DateTime DateDeNaissance { get; set; }
    public string Fonction { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime HireDate { get; set; }
    public int? NbJoursAbsence { get; set; }
    public int? NbJourVacance { get; set; }
    public double Salaire { get; set; }
    public int ShowroomId { get; set; }


  }
}
