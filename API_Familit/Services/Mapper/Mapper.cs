using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using API = API_Familit.Models;
using D = DAL.Model;

namespace API_Familit.Services.Mapper
{
  public static class Mapper
  {
    private static CommandeClientService _serviceCommande = new CommandeClientService();
    private static ProductService _serviceProduit = new ProductService();
    private static CaracteristiqueService _serviceCaracteristique = new CaracteristiqueService();
    private static PersonnelService _servicePersonnel = new PersonnelService();
    private static LigneDeCommandeService _serviceLigne = new LigneDeCommandeService();
    public static D.User.Personnel ToDAL(this API.User_API.Personnel_API p)
    {
      return new D.User.Personnel
      {
        ID = p.ID,
        Nom = p.Nom,
        Prenom = p.Prenom,
        DateDeNaissance = p.DateDeNaissance,
        HireDate = p.HireDate,
        Fonction = p.Fonction,
        Login = p.Login,
        Password = p.Password,
        NbJoursAbsence = p.NbJoursAbsence,
        NbJourVacance = p.NbJourVacance,
        Salaire = p.Salaire,
        AdRue = p.AdRue,
        AdNum = p.AdNum,
        AdCP = p.AdCP,
        AdVille = p.AdVille,
        AdPays = p.AdPays,
        NumTel = p.NumTel,
        Email = p.Email,
        ShowroomId = p.ShowroomId,
        LieuDeTravail =ToDAL(p.LieuDeTravail),
        IsActif = p.IsActif,
        IsAdmin = p.IsAdmin
      };
    }
    public static API.User_API.Personnel_API ToAPI(this D.User.Personnel p)
    {
      return new API.User_API.Personnel_API
      {
        ID = p.ID,
        Nom = p.Nom,
        Prenom = p.Prenom,
        DateDeNaissance = p.DateDeNaissance,
        HireDate = p.HireDate,
        Fonction = p.Fonction,
        Login = p.Login,
        Password = p.Password,
        NbJoursAbsence = p.NbJoursAbsence,
        NbJourVacance = p.NbJourVacance,
        Salaire = p.Salaire,
        AdRue = p.AdRue,
        AdNum = p.AdNum,
        AdCP = p.AdCP,
        AdVille = p.AdVille,
        AdPays = p.AdPays,
        NumTel = p.NumTel,
        Email = p.Email,
        ShowroomId = p.ShowroomId,
        LieuDeTravail =ToAPI(p.LieuDeTravail),
        IsActif = p.IsActif,
        IsAdmin = p.IsAdmin
      };
    }
    public static D.User.Client ToDAL(this API.User_API.Client_API p)
    {

      return new D.User.Client
      {
        ID = p.ID,
        Nom = p.Nom,
        Prenom = p.Prenom,
        Login = p.Login,
        Password = p.Password,
        NumBCE = p.NumBCE,
        EstFournisseur = p.EstFournisseur,
        AdRue = p.AdRue,
        AdNum = p.AdNum,
        AdCP = p.AdCP,
        AdVille = p.AdVille,
        AdPays = p.AdPays,
        NumTel = p.NumTel,
        Email = p.Email,
        ListCommande = ListConverter(_serviceCommande.GetCommandeClient(p.ID), ToDAL),
        ListFav = ListConverter(_serviceProduit.GetProductFav(p.ID),ToDAL),
        IsActif = p.IsActif
      };
    }
    public static API.User_API.Client_API ToAPI(this D.User.Client p)
    {
      return new API.User_API.Client_API
      {
        ID = p.ID,
        Nom = p.Nom,
        Prenom = p.Prenom,
        Login = p.Login,
        Password = p.Password,
        NumBCE = p.NumBCE,
        EstFournisseur = p.EstFournisseur,
        AdRue = p.AdRue,
        AdNum = p.AdNum,
        AdCP = p.AdCP,
        AdVille = p.AdVille,
        AdPays = p.AdPays,
        NumTel = p.NumTel,
        Email = p.Email,
        ListCommande = _serviceCommande.GetCommandeClient(p.ID),
        ListFav =_serviceProduit.GetProductFav(p.ID),
        IsActif = p.IsActif
      };
    }
    public static D.Product.Products ToDAL(this API.Products_API.Product_API p)
    {
      return new D.Product.Products
      {
        ID = p.ID,
        Nom = p.Nom,
        Prix = p.Prix,
        PrixDAchatTHTVA = p.PrixDAchatTHTVA,
        TVA = p.TVA,
        NbPiece = p.NbPiece,
        Details = p.Details,
        CatId = p.CatId,
        ClientId = p.ClientId,
        Fournisseur = ToDAL(p.Fournisseur),
        Categorie = ToDAL(p.Categorie),
        IsActif = p.IsActif,
        ListeCaracteristiques =ListConverter(_serviceCaracteristique.GetCaracteristiqueByProduct(p.ID),ToDAL)
      };
    }
    public static API.Products_API.Product_API ToAPI(this D.Product.Products p)
    {
      return new API.Products_API.Product_API
      {
        ID = p.ID,
        Nom = p.Nom,
        Prix = p.Prix,
        PrixDAchatTHTVA = p.PrixDAchatTHTVA,
        TVA = p.TVA,
        NbPiece = p.NbPiece,
        Details = p.Details,
        CatId = p.CatId,
        ClientId = p.ClientId,
        Fournisseur = ToAPI(p.Fournisseur),
        Categorie = ToAPI(p.Categorie),
        IsActif = p.IsActif,
        ListeCaracteristiques = _serviceCaracteristique.GetCaracteristiqueByProduct(p.ID)
      };
    }
    public static D.Product.Categories ToDAL(this API.Products_API.Categorie_API p)
    {
      return new D.Product.Categories
      {

        ID = p.ID,
        Nom = p.Nom,
        Details = p.Details,
        IsActif = p.IsActif,
        ListeCaracteristique = ListConverter(_serviceCaracteristique.GetCaracteristiqueByCategorie(p.ID),ToDAL)
      };
    }
    public static API.Products_API.Categorie_API ToAPI(this D.Product.Categories p)
    {
      return new API.Products_API.Categorie_API
      {
        ID = p.ID,
        Nom = p.Nom,
        Details = p.Details,
        IsActif = p.IsActif,
        ListeCaracteristique = _serviceCaracteristique.GetCaracteristiqueByCategorie(p.ID)
      };
    }
    public static D.Product.Caracteristique ToDAL(this API.Products_API.Caracteristique_API p)
    {
      return new D.Product.Caracteristique
      {
        Id = p.Id,
        Nom = p.Nom,
        Details = p.Details,
        CatId = p.CatId,
        Categorie = ToDAL(p.Categorie)
      };
    }
    public static API.Products_API.Caracteristique_API ToAPI(this D.Product.Caracteristique p)
    {
      return new API.Products_API.Caracteristique_API
      {
        Id = p.Id,
        Nom = p.Nom,
        Details = p.Details,
        CatId = p.CatId,
        Categorie = ToAPI(p.Categorie)
      };
    }
    public static D.Etablissement.Showrooms ToDAL(this API.Etablissement_API.Showroom_API p)
    {
      return new D.Etablissement.Showrooms
      {
        ID = p.ID,
        Nom = p.Nom,
        NumBCE = p.NumBCE,
        AdRue = p.AdRue,
        AdNum = p.AdNum,
        AdCP = p.AdCP,
        AdVille = p.AdVille,
        AdPays = p.AdPays,
        NumTel = p.NumTel,
        Email = p.Email,
        IsActif = p.IsActif,
        PersonnelList = ListConverter(_servicePersonnel.GetPersonnelByShowroom(p.ID),ToDAL)
      };

    }
    public static API.Etablissement_API.Showroom_API ToAPI(this D.Etablissement.Showrooms p)
    {
      return new API.Etablissement_API.Showroom_API
      {
        ID = p.ID,
        Nom = p.Nom,
        NumBCE = p.NumBCE,
        AdRue = p.AdRue,
        AdNum = p.AdNum,
        AdCP = p.AdCP,
        AdVille = p.AdVille,
        AdPays = p.AdPays,
        NumTel = p.NumTel,
        Email = p.Email,
        IsActif = p.IsActif,
        PersonnelList =_servicePersonnel.GetPersonnelByShowroom(p.ID)
      };
    }
    public static D.Commande.Commandes ToDAL(this API.Commande_API.Commandes_API p)
    {
      return new D.Commande.Commandes
      {
        ID = p.ID,
        DateDeCommande = p.DateDeCommande,
        Total = p.Total,
        Acompte = p.Acompte,
        Solde =p.Solde,
        TypeDeCommande = p.TypeDeCommande,
        DetailsCommande = ListConverter(_serviceLigne.GetByCommandeId(p.ID),ToDAL),
        Showroom = ToDAL(p.Showroom),
        ClientID = p.ClientID
      };
    }
    public static API.Commande_API.Commandes_API ToAPI(this D.Commande.Commandes p)
    {
      return new API.Commande_API.Commandes_API
      {
        ID = p.ID,
        DateDeCommande = p.DateDeCommande,
        Total = p.Total,
        Acompte = p.Acompte,
        Solde = p.Solde,
        TypeDeCommande = p.TypeDeCommande,
        DetailsCommande = _serviceLigne.GetByCommandeId(p.ID),
        Showroom = ToAPI(p.Showroom),
        ClientID = p.ClientID
      };
    }
    public static D.Commande.CommandeClients ToDAL(this API.Commande_API.CommandeClient_API p)
    {
      return new D.Commande.CommandeClients
      {
        ID = p.ID,
        DateDeCommande = p.DateDeCommande,
        Total = p.Total,
        Acompte = p.Acompte,
        Solde = p.Solde,
        MoyenDePaiement =p.MoyenDePaiement,
        Statut = p.Statut,
        DateDeLivraison = p.DateDeLivraison,
        TypeDeCommande = p.TypeDeCommande,
        Livraison = p.Livraison,
        DetailsCommande = ListConverter(_serviceLigne.GetByCommandeId(p.ID), ToDAL),
        Showroom = ToDAL(p.Showroom),
        ClientID = p.ClientID,
        VendeurID = p.VendeurID
      };
    }
    public static API.Commande_API.CommandeClient_API ToAPI(this D.Commande.CommandeClients p)
    {
      return new API.Commande_API.CommandeClient_API
      {
        ID = p.ID,
        DateDeCommande = p.DateDeCommande,
        Total = p.Total,
        Acompte = p.Acompte,
        Solde = p.Solde,
        MoyenDePaiement = p.MoyenDePaiement,
        Statut = p.Statut,
        DateDeLivraison = p.DateDeLivraison,
        TypeDeCommande = p.TypeDeCommande,
        Livraison = p.Livraison,
        DetailsCommande = _serviceLigne.GetByCommandeId(p.ID),
        Showroom = ToAPI(p.Showroom),
        ClientID = p.ClientID,
        VendeurID = p.VendeurID
      };
    }
    public static D.Commande.LigneDeCommande ToDAL(this API.Commande_API.LigneDeCommande_API p)
    {
      return new D.Commande.LigneDeCommande {
        ID =p.ID,
        TOTAL =p.TOTAL,
        HTVA = p.HTVA,
        TVAC =p.TVAC,
        Quantite = p.Quantite,
        IDCommande = p.IDCommande,
        Product = ToDAL(p.Product)
      };
    }
    public static API.Commande_API.LigneDeCommande_API ToAPI(this D.Commande.LigneDeCommande p)
    {
      return new API.Commande_API.LigneDeCommande_API
      {
        ID = p.ID,
        TOTAL = p.TOTAL,
        HTVA = p.HTVA,
        TVAC = p.TVAC,
        Quantite = p.Quantite,
        IDCommande = p.IDCommande,
        Product = ToAPI(p.Product)
      };
    }
    public static IEnumerable<TOut> ListConverter<TOut,TIn>(IEnumerable<TIn> liste,Func<TIn,TOut> selector) 
    {
      
      foreach (TIn item in liste)
      {
       yield return selector(item);
      }
     
    }
  }
}
