using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1.Models
{
    public class FormulaireModel
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string Adresse { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Mail { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        public DateTime DateForm { get; set; }
        public string TypeForm { get; set; }
        public string FormCob { get; set; }
        public string FormObj { get; set; }
    }
    public class Verification
    {
        public static bool ValidMail(string email)
        {
            if (email == null)
            {
                return false;
            }
            else
            {
                Regex myRegex = new Regex(@"^([\w]+)@([\w]+)\.([\w]+)$");
                return myRegex.IsMatch(email);
            }
        }
        public static bool ValidCodPost(string cod)
        {
            if (cod == null)
            {
                return false;
            }
            else
            {
                Regex myRegex = new Regex(@"^[0-9]{5}$");
                return myRegex.IsMatch(cod);
            }
        }
    }
    
}