using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratoire_3
{
    internal class Employe
    {

        String matricule;
        String nom;
        String prenom;

        public Employe()
        {
            this.Matricule = "";
            this.Nom = "";
            this.Prenom = "";
        }

        public Employe(string _matricule, string _nom, string _prenom)
        {
            this.Matricule = _matricule;
            this.Nom = _nom;
            this.Prenom = _prenom;
        }

        public string Matricule { get => matricule; set => matricule = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }

        public override string ToString()
        {
            return matricule + " " + nom + " " + prenom;
        }
    }
}
