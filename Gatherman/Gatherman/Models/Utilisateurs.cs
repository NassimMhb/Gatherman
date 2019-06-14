using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gatherman.Models
{
    public class Utilisateurs
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string NomUtilisateur { get; set; }
        public string MotDePasse { get; set; }

        public Utilisateurs() { }
        public Utilisateurs(string NomUtilisateur, string MotDePasse)
        {
            this.NomUtilisateur = NomUtilisateur;
            this.MotDePasse = MotDePasse;
        }
        public bool CheckInformation()
        {
            if (!this.NomUtilisateur.Equals(" ") && !this.MotDePasse.Equals(" "))
                return true;
            else
                return false;
        }

    }
}
