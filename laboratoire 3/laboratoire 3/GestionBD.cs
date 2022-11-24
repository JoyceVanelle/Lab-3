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
        ObservableCollection<Projet> liste;// pas automatique , on le fait car on fera un select de liste plustard
        static GestionBD gestionBD = null;// ce qui crée le singleton pour avoir un seul objet à utiliser
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
        public ObservableCollection<Projet> GetProjet()
        {
            try
            {
                liste.Clear();// pour vider la liste

                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;// indique le chemin à commande 
                commande.CommandText = "Select * from Projet";// ce qu,il faut aller chercher

                con.Open();// ouvre la connection 
                MySqlDataReader r = commande.ExecuteReader();// permet de lire le retour qui ewst stocké dans r
                r.Read();
             //   public static bool TryParseExact(string? s, string? format, out DateOnly result);

                while (r.Read())
                   
                {
                    liste.Add(new Projet()
                    {
                        Numero = r.GetString(0),
                        Debut = (DateOnly)r["debut"],
                        Budget =r.GetInt32(2),
                        Description =r.GetString(3),
                        Employe = r.GetString(4),

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
