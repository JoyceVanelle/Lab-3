using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratoire_3
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Projet> liste;
        static GestionBD gestionBD = null;
        public GestionBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_gr2;Uid=2014985;Pwd=2014985;");
            liste = new ObservableCollection<Projet>();

        }
        public static GestionBD getInstance()// rapport avec le singleton
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        public ObservableCollection<Employe> GetEmployes(string varRech)
        {
            ObservableCollection<Employe> liste = new ObservableCollection<Employe>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from employe where nom like '%"+varRech+"%'";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {

                liste.Add(new Employe(r.GetString(0), r.GetString(1), r.GetString(2)));
            }
            r.Close();
            con.Close();

            return liste;
        }




    }
}

