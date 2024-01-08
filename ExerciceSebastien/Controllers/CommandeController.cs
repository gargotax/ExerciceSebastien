using ExerciceSebastien.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciceSebastien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        [HttpPost]

        public IActionResult CreateCommande(Commande commande)
        {
            if (!VerifyNumeroCommande(commande))
            {
                BadRequest();
            }

            if (!VerifyDateCommande(commande))
            {
                BadRequest();
            }

            if (!VerifyAdresseLivraison(commande))
            {
                BadRequest();
            }

            if (!VerifyContenuCommande(commande))
            {
                BadRequest();
            }
           
            if (!VerifyEtatCommande(commande))
            {
                BadRequest();
            }
           
            if (!VerifyPrixTotal(commande))
            {
                BadRequest();
            }

            return Ok();
        }
    
        private bool VerifyNumeroCommande(Commande commande)
        {
            if (commande?.NumeroCommande is null)
            {
                return false;
            }
            return true;
        }

        private bool VerifyDateCommande(Commande commande)
        {
            if (commande.DateCommande > DateTime.Now)
            {
                return false;
            }

            return true;
        }

        private bool VerifyAdresseLivraison(Commande commande)
        {
            if (string.IsNullOrEmpty(commande.AdresseLivraison))
            {
               return false;
            }

            return true;
        }

        private bool VerifyEtatCommande(Commande commande)
        {
            if (string.IsNullOrEmpty(commande.EtatCommande))
            {
               return false;
            }

            return true;
        }

        private bool VerifyContenuCommande(Commande commande)
        {
            if (commande.ContenuCommandes.Count < 1 )
            {
                return false;
            }
            return true;
        }

        private bool VerifyPrixTotal(Commande commande)
        {
            if (commande.PrixTotal < 0)
            {
                return false;
            }
            return true;
        }

      

        [HttpDelete]
        public IActionResult DeleteCommande(Commande commande)
        {
            string commandeSupprimee = null;
            string result = null;
            if (commande is not null)
            {
                var numeroCommande = commande.NumeroCommande;
                //commandeSupprimee = numeroCommande.Remove(result);
                
            }
            return Ok();
        }


        [HttpPut]
        public IActionResult UpdateCommande(Commande commande)
        {
            try
            {
                string nouvelleAdresse = UpdateAdresseLivraison(commande);

                return Ok(new { NouvelleAdresseLivraison = nouvelleAdresse });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        private string UpdateAdresseLivraison(Commande commande)
        {
            string vieilleAdresseLivraison = commande.AdresseLivraison;
            string newAdresseLivraison = null;
            if (vieilleAdresseLivraison is null)
            {
                throw new Exception("adresse de livraison inexistante!");
            }

            if (vieilleAdresseLivraison == newAdresseLivraison)
            {
                throw new Exception("l'adresse de livraison n'a pas changé");
            }

            if (vieilleAdresseLivraison != newAdresseLivraison)
            {
                commande.AdresseLivraison = newAdresseLivraison;
            }

            return newAdresseLivraison;
        }
    }


    
}
