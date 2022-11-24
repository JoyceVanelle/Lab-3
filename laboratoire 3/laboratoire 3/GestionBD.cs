using MySql.Data.MySqlClient;
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
        ObservableCollection<Employe> liste;
        static GestionBD gestionBD = null;
        public GestionBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_gr2;Uid=2014985;Pwd=2014985;");
            liste = new ObservableCollection<Employe>();

        }
        public static GestionBD getInstance()// rapport avec le singleton
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }

        public void AjouterEmployer(string matricule, string nom, string prenom)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                /// commande.CommandText = "insert into clients values(10,'doe','john','mail@mail.com')";
                commande.CommandText = "insert into employe values( @matricule, @nom, @prenom) ";

                //commande.Parameters.AddWithValue("@id", id);
                commande.Parameters.AddWithValue("@matricule", matricule);
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();

            }
            catch (MySqlException ex)
            {
                con.Close();
            }


        }

        public void AjouterProjet(string numero, DateOnly date ,int budget,  string employe)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                /// commande.CommandText = "insert into clients values(10,'doe','john','mail@mail.com')";
                commande.CommandText = "insert into projet values( @numero, @date, @budget,@employe) ";

                //commande.Parameters.AddWithValue("@id", id);
                commande.Parameters.AddWithValue("@numero", numero);
                commande.Parameters.AddWithValue("@date", date);
                commande.Parameters.AddWithValue("@budget", budget);
                commande.Parameters.AddWithValue("@employe", employe);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();

            }
            catch (MySqlException ex)
            {
                con.Close();
            }


        }

    }
}
