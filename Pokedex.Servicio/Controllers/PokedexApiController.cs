using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pokedex.Business;
using Pokedex.Entity;
using Pokedex.Servicio.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokedex.Servicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokedexApiController : ControllerBase
    {
        private readonly string _connectionString;

        public PokedexApiController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        [HttpPost]
        public async Task<List<EntPokedex>> Post(FiltroRequest oModel)
        {
            BusPokedex _BusPokedex = new BusPokedex();
            return await _BusPokedex.ListarPokedex(_connectionString, oModel.Nombre, oModel.Numero);
        }
        
        [HttpGet("{id}")]
        public async Task<EntPokedex> Get(int id)
        {
            BusPokedex _BusPokedex = new BusPokedex();
            return await _BusPokedex.ObtenerPokedexIndividual(_connectionString, id);
        }

    }
}
