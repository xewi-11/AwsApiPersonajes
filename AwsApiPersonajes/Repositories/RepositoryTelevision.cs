using AwsApiPersonajes.Data;
using AwsApiPersonajes.Models;
using Microsoft.EntityFrameworkCore;
namespace AwsApiPersonajes.Repositories
{
    public class RepositoryTelevision
    {
        private TelevisionContext context;

        public RepositoryTelevision(TelevisionContext context)
        {
            this.context = context;
        }

        public async Task<List<Personaje>> GetAllPersonajesAsyc()
        {
            return await this.context.Personajes.ToListAsync();
        }
        private async Task<int> GetPersonajeMaxIdAsync()
        {

            return await this.context.Personajes.MaxAsync(x => x.IdPersonaje) + 1;

        }

        public async Task CreatePersonajeAsync(string nombre, string imagen)
        {
            int id = await this.GetPersonajeMaxIdAsync();
            Personaje personaje = new Personaje
            {
                IdPersonaje = id,
                Nombre = nombre,
                Imagen = imagen
            };
            this.context.Personajes.Add(personaje);
            await this.context.SaveChangesAsync();
        }
    }
}
