using Microsoft.Extensions.Configuration;
using Pokedex.Data;
using Pokedex.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Business
{
    public class BusPokedex
    {
        public Task<List<EntPokedex>> ListarPokedex(string _connectionString, string nombre, string numero)
        {
            nombre ??= string.Empty;
            numero ??= string.Empty;
            DatPokedex _DatPokedex = new DatPokedex();
            return _DatPokedex.ListarPokedex(_connectionString, nombre, numero);
        }

        public Task<EntPokedex> ObtenerPokedexIndividual(string _connectionString, int id)
        {
            DatPokedex _DatPokedex = new DatPokedex();
            return _DatPokedex.ObtenerPokedexIndividual(_connectionString, id);
        }

        
    }
}
