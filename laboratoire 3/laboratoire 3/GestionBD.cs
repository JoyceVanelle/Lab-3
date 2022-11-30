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
        public GestionBD()
        {
            con = new MySqlConnection("Server=cours.cegep3r.info;Database=a2022_420326ri_gr2_2014985-sorelle-francine-matho-ngoualadjo;Uid=2014985;Pwd=2014985;");

        }
        public static GestionBD getInstance()// rapport avec le singleton
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }
        {

            try
            {

               
                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                
                {
                con.Close();
            }

                    DateTime d = r.GetDateTime("debut");


                    {
                        Numero = r.GetString(0),
                        Debut = d,
                        Budget =r.GetInt32(2),
                        Description =r.GetString(3),
                        Employe = r.GetString(4),
                        NomEmploye = r.GetString(5),
                        PrenomEmploye = r.GetString(6),

                   

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                r.Close();
                con.Close();

            }

              

           
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
        {
            liste.Clear();
            try
            {
              

                
                while (r.Read())

                {
      
                    {

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
