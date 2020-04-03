using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Model.Etablissement;

namespace DAL.Model.User
{

  public class Personnel : User
  {

    public Personnel()
    {
      DateDeNaissance = new DateTime();
      HireDate = new DateTime();
    }
    public DateTime DateDeNaissance { get; set; }
    public string Fonction { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime HireDate { get; set; }
    public int NbJoursAbsence { get; set; }
    public int NbJourVacance { get; set; }
    public double Salaire { get; set; }
    public Showrooms LieuDeTravail { get; set; }
    public int ShowroomId { get; set; }

  }

  }
