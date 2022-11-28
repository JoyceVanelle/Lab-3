using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratoire_3
{
    internal class Projet
    {
        String numero;
        DateTime debut;
        int budget;
        String description;
        String employe;
        public Projet()
        {
            this.Numero = "";
            this.Debut = new DateTime();
            this.Budget = 0;
            this.Description = "";
            this.Employe = "";
        }
        public Projet(string numero, int _adebut, int _moisdebut, int _jourdebut, int budget, string description, string employe)
        {
            this.Numero = numero;
            this.Debut = new DateTime(_adebut, _moisdebut, _jourdebut);
            this.Budget = budget;
            this.Description = description;
            this.Employe = employe;
        }

        public string Numero { get => numero; set => numero = value; }
        public DateTime Debut { get => debut; set => debut = value; }
        public int Budget { get => budget; set => budget = value; }
        public string Description { get => description; set => description = value; }
        public string Employe { get => employe; set => employe = value; }

        public override string ToString()
        {
            return numero + " " + debut.ToString() + " " + budget + " " + description + " " + employe;
        }

    }
}
