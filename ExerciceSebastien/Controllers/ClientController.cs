using System.Data;
using ExerciceSebastien.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExerciceSebastien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost]

        public IActionResult CreateClient(Client client)
        {
                if (!VerifyClientId(client))
                {
                    return BadRequest();
                }

                if (!VerifiyClientName(client))
                {
                    return BadRequest();
                }

                if (!VerifyClientAddress(client))
                {
                     BadRequest();
                }

                return Ok();
        }

        private bool VerifyClientId(Client client)
        {
            if (client.Id<1)
            {
                return false;
            }
            return true;
        }

        private bool VerifiyClientName(Client client)
        {
            if (string.IsNullOrEmpty(client.Nom))
            {
                return false;
            }

            return true;
        }

        private bool VerifyClientAddress(Client client)
        {
            if (string.IsNullOrEmpty(client.Adresse))
            {
                return false;
            }
            return true;
        }




        [HttpPut]

        public IActionResult UpdateClient(Client client)
        { 
            UpdateName(client);
            return Ok();
        }

        private string UpdateName(Client client)
        {
            string newName = null;
            string oldName = client.Nom;
            if (oldName is not null && oldName != newName)
            {
                newName = client.Nom;
            }
            

            return newName;
        }
    }
}
