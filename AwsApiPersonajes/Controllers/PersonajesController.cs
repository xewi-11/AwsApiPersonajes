using AwsApiPersonajes.Models;
using AwsApiPersonajes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AwsApiPersonajes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonajesController : ControllerBase
    {
        private RepositoryTelevision repo;

        public PersonajesController(RepositoryTelevision repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetPersonajes()
        {
            return Ok(await this.repo.GetAllPersonajesAsyc());
        }


        [HttpPost]

        public async Task<ActionResult> CreatePersonaje(Personaje personaje)
        {
            await this.repo.CreatePersonajeAsync(personaje.Nombre, personaje.Imagen);
            return Ok();
        }
    }
}
