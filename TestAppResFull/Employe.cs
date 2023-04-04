namespace TestAppResFull
{
    public class Employe
    {
        private int id;
        private string nom;
        private string prenom;
        private string login;
        private double salaire;


        // Les nouveaux get et set version C# et VS.Net. Remplacent getLogin() et setLogin(string unLogin)
        public string Login { get => login; set => login = value; }

        public string Nom { get => nom; set => nom = value; }
        public double Salaire { get => salaire; set => salaire = value; }

        // remplace getId()
        public int Id { get => id; set => id = value; }

        // Constructeur de la classe Employe
        public Employe(int unId, string unNom, string unPrenom, string unLogin, double unSalaire)
        {
            this.id = unId;
            this.nom = unNom;
            this.Prenom = unPrenom;
            this.login = unLogin;
            this.salaire = unSalaire;
        }

        // Constructeur vide
        public Employe()
        {


        }


        public Employe(int unId, string unLogin)
        {
            this.id = unId;

            this.login = unLogin;

        }

        // pour afficher la liste par la suite
        public string Description
        {
            get => "Id : " + this.id + " Nom :" + this.nom + " Prenom : " + this.Prenom + " Login : " + this.login + " Salaire : " + this.salaire;
        }
        public string Prenom { get => prenom; set => prenom = value; }

    }
}
