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
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_gr2_2014985-sorelle-francine-matho-ngoualadjo;Uid=2014985;Pwd=2014985;");
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
                commande.CommandText = "insert into employec values(@matricule,@nom,@prenom) ";

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

        public void AjouterProjet(string numero, DateTime date ,double budget,string description,  string employe)
        {

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                /// commande.CommandText = "insert into clients values(10,'doe','john','mail@mail.com')";
                commande.CommandText = "insert into projetc values( @numero, @date, @budget, @description, @employe) ";

                //commande.Parameters.AddWithValue("@id", id);
                commande.Parameters.AddWithValue("@numero", numero);
                commande.Parameters.AddWithValue("@date", date.ToString("yyyy/MM/dd"));
                commande.Parameters.AddWithValue("@budget", budget);
                commande.Parameters.AddWithValue("@description", description);
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

        public ObservableCollection<Employe> AffficheComboBox()
        {
            liste.Clear();
            try
            {

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "select * from employec";
               
                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {

                    liste.Add(new Employe()
                    {
                        Matricule = r.GetString(0),
                        Nom = r.GetString(1),
                        Prenom = r.GetString(2),
                       
                    });



                    //lvliste.Items. System.Threading.Thread.Sleep(100);Add(r["id"] + " " + r["nom"] + " "+ r["prenom"] + " " + r["email"]);
                }

                r.Close();
                con.Close();

            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            return liste;

        }

    }
}
