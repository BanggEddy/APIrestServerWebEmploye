using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace TestAppResFull
{
   public class EmployeDAO
    {

        // attributs de connexion statiques
        private static string provider = "localhost";

        private static string dataBase = "entreprise1";

        private static string uid = "root";

        private static string mdp = "";



        private static ConnexionSql maConnexionSql;


        private static MySqlCommand Ocom;


        // Insertion d'un employé

        public static void deleteEmploye(int id)
        {

            try
            {


                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("delete from employe where id = " + id);


                int i = Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }

        // Mise à jour d'un employé

        public static void updateEmploye(Employe e)
        {

            try
            {


                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();


                Ocom = maConnexionSql.reqExec("update employe set login= '" + e.Login + "' where id = " + e.Id);


                int i = Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }

        // Mise à jour d'un employé

        public static void insertEmploye(Employe e)
                {

            try
            {


                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();

                string req = "insert into Employe values (" + e.Id + ",'"+e.Nom +"','"+e.Prenom+"','" + e.Login + "',"+ e.Salaire+")";


                Ocom = maConnexionSql.reqExec(req);


                int i = Ocom.ExecuteNonQuery();



                maConnexionSql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }

        // Mise à jour d'un employé

        public static Employe trouveEmploye(int id)
        {

            try
            {


                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                maConnexionSql.openConnection();

                string req = "Select * from Employe where id = " + id;

                Ocom = maConnexionSql.reqExec(req);

                MySqlDataReader reader = Ocom.ExecuteReader();

                Employe emp = null;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string login = (string)reader.GetValue(3);
                    double salaire = (double)reader.GetValue(4);

                    //Instanciation d'un Employe
                    emp = new Employe(numero, nom, prenom, login, salaire);





                }

                // fermeture du reader
                reader.Close();

                //fermeture de la connexion
                maConnexionSql.closeConnection();

                // Envoi de l'employé au Manager
                return (emp);


            }

            catch (Exception ex)
            {

                throw (ex);

            }

        }

            // Récupération de la liste des employés
            public static List<Employe> getEmployes()
        {

            List<Employe> lc = new List<Employe>();

            try
            {
                // Pour se connecter à la base
                maConnexionSql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);

                // ouverture de la connexion
                maConnexionSql.openConnection();

                // exécution de la requete avec l'objer Command
                Ocom = maConnexionSql.reqExec("Select * from Employe");

// lire les données ligne par ligne avec le reader

                MySqlDataReader reader = Ocom.ExecuteReader();

                Employe e;



                // Tant qu'il existe une ligne dans la table
                while (reader.Read())
                {
                    // récupération de la ligne
                    int numero = (int)reader.GetValue(0);
                    string nom = (string)reader.GetValue(1);
                    string prenom = (string)reader.GetValue(2);
                    string login = (string)reader.GetValue(3);
                    double salaire = (double)reader.GetValue(4);

                    //Instanciation d'un Employe
                    e = new Employe(numero, nom, prenom, login,salaire);

                    // Ajout de cet employe à la liste 
                    lc.Add(e);


                }


                // fermeture du reader
                reader.Close();

                //fermeture de la connexion
                maConnexionSql.closeConnection();

                // Envoi de la liste au Manager
                return (lc);


            }

            catch (Exception emp)
            {

                throw (emp);

            }

           
        }

    }




}

