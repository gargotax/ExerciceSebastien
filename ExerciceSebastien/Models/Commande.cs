


namespace ExerciceSebastien.Models
{
    public class Commande
    {
        public string NumeroCommande { get; set; }
        public DateTime DateCommande { get; set; }
        public string AdresseLivraison { get; set; }
        public string EtatCommande { get; set; }
        public List<ContenuCommande> ContenuCommandes { get; set; }
        public int PrixTotal
        {
            get
            {
                return ContenuCommandes.Sum(l => l.Produit.PU * l.Quantite);
            }

        }
    }
}
