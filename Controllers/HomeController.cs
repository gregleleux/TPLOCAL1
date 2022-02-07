using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TPLOCAL1.Models;

//L'énoncé du tp et le logo hn sont livrés dans le répertoire /ressources de la solution
//--------------------------------------------------------------------------------------
//Attention, le modèle MVC est un modèle dit de convention plutot que configuration, 
//Le controller doit donc obligatoirement se nommer avec "Controller" à la fin!!!
namespace TPLOCAL1.Controllers
{
    public class HomeController : Controller
    {
        // méthode appelée par la routeur "naturellement"
        public ActionResult Index(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                //renvoie vers la vue Index (voir routage dans RouteConfig.cs)
                return View();
            else
            {
                //en fonction du paramètre id, on appelle les différentes pages
                switch (id)
                {
                    case "ListeAvis":
                        //reste à faire : coder la lecture du fichier xml fourni
                        return View(id);
                    case "Formulaire":
                        //reste à faire : appeler la vue Formulaire avec le modèle de données vide
                        return View(id);
                    default:
                        //renvoie vers Index (voir routage dans RouteConfig.cs)
                        return View();
                }
            }
        }


        //méthode pour envoyer les données du formulaire vers la page de validation
        [HttpPost]
        public ActionResult ValidationFormulaire(FormulaireModel u)
        {
            if (u.Nom == null || u.Prenom == null || u.Sexe == "Selectionner un sexe" || u.Adresse == null || u.CodePostal == null || u.Ville == null
                || u.Mail == null || u.DateForm == Convert.ToDateTime("01/01/0001") || u.TypeForm == "Selectionner une formation" || u.FormCob == null || u.FormObj == null)   
            {
                ModelState.AddModelError("", "Une information n'a pas été renseignée");
                return View("Formulaire");
            }
            else
            if (Verification.ValidCodPost(u.CodePostal) == false)
            {
                ModelState.AddModelError("", "Code Postal erroné (attendu : 5 chiffres).");
                return View("Formulaire");
            }
            else
            if (Verification.ValidMail(u.Mail) == false)
            {
                ModelState.AddModelError("", "Format de mail erroné (attendu : nom@domaine.xxx).");
                return View("Formulaire");
            }
            else
            if (DateTime.Compare(u.DateForm, Convert.ToDateTime("01/01/2022")) >= 0)
            {
                ModelState.AddModelError("", "Date de début de formation erronée (doit être antérieure au 01/01/2022).");
                return View("Formulaire");
            }
            else
                return View("ValidationFormulaire",u);
        }
    }
}