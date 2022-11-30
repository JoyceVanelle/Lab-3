using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Bcpg.Attr.ImageAttrib;

namespace laboratoire_3
{
    internal class GestionBD
    {

        MySqlConnection con;
        ObservableCollection<Employe> listeEmployes;
        ObservableCollection<Projet> liste;
        static GestionBD gestionBD = null;
        public GestionBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_gr2_2014985-sorelle-francine-matho-ngoualadjo;Uid=2014985;Pwd=2014985;");
            liste = new ObservableCollection<Projet>();
            listeEmployes = new ObservableCollection<Employe>();

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

        public void AjouterProjet(string numero, DateTime date, double budget, string description, string employe)
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
            listeEmployes.Clear();
            try
            {

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "select * from employec";

                con.Open();
                MySqlDataReader r = commande.ExecuteReader();

                while (r.Read())
                {

                    listeEmployes.Add(new Employe()
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
            return listeEmployes;

        }


        public ObservableCollection<Projet> GetProjet()
        {
            try
            {
                liste.Clear();// pour vider la liste

                MySqlCommand commande = new MySqlCommand("AfficherNomComplet");
                commande.Connection = con;// indique le chemin à commande 
                commande.CommandType = System.Data.CommandType.StoredProcedure;


                con.Open();// ouvre la connection 
                MySqlDataReader r = commande.ExecuteReader();// permet de lire le retour qui ewst stocké dans r

                //   public static bool TryParseExact(string? s, string? format, out DateOnly result);

                while (r.Read())

                {

                    DateTime d = r.GetDateTime("debut");

                    d.AddYears(d.Year);
                    d.AddMonths(d.Month);
                    d.AddDays(d.Day);
                    /*
                                        DateOnly d = new DateOnly();
                                        DateTime dateTime = r.GetDateTime("debut");

                                        d.AddYears(dateTime.Year);
                                        d.AddMonths(dateTime.Month);
                                        d.AddDays(dateTime.Day);
                    */

                    liste.Add(new Projet()
                    {
                        Numero = r.GetString(0),
                        Debut = d,
                        Budget = r.GetInt32(2),
                        Description = r.GetString(3),
                        Employe = r.GetString(4),
                        NomEmploye = r.GetString(5),
                        PrenomEmploye = r.GetString(6),

                    });


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
        public ObservableCollection<Projet> RechercheProjet(DateTime debut)
        {
            liste.Clear();
            try
            {


                MySqlCommand commande = new MySqlCommand("Rechercher_Projet");
                commande.Connection = con;// indique le chemin à commande 
                commande.CommandType = System.Data.CommandType.StoredProcedure;

                commande.Parameters.AddWithValue("@datedeb", debut.ToString("yyyy-MM-dd"));// met l'id dans l'espace qui lui a été réservé




                con.Open();// ouvre la connection 
                //commande.Prepare();// empêche les caractères spéciaux donc prends tout ca comme chaine de caractères
                int i = commande.ExecuteNonQuery();
                MySqlDataReader r = commande.ExecuteReader();// permet de lire le retour qui ewst stocké dans r

                //   public static bool TryParseExact(string? s, string? format, out DateOnly result);

                while (r.Read())

                {


                    /* DateOnly d = new DateOnly();
                     DateTime dateTime = r.GetDateTime("debut");

                     d.AddYears(dateTime.Year);
                     d.AddMonths(dateTime.Month);
                     d.AddDays(dateTime.Day);
 */
                    liste.Add(new Projet()
                    {
                        Numero = r.GetString(0),
                        Debut = r.GetDateTime("debut"),
                        Budget = r.GetInt32(2),
                        Description = r.GetString(3),
                        Employe = r.GetString(4),
                        NomEmploye = r.GetString(5),
                        PrenomEmploye = r.GetString(6),

                    });

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
