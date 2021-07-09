using Microsoft.Extensions.Configuration;
using Pokedex.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Data
{
    public class DatPokedex
    {

        public async Task<List<EntPokedex>> ListarPokedex(string _connectionString, string _nombre, string _numero)
        {
            List<EntPokedex> lstPokedex = new List<EntPokedex>();
            EntPokedex entidad;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UspListarPokedex", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Nombre", _nombre));
                    cmd.Parameters.Add(new SqlParameter("@Numero", _numero));
                    await con.OpenAsync();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            entidad = new EntPokedex
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                Nombre = dr["Nombre"].ToString(),
                                Numero = dr["Numero"].ToString(),
                                Foto = dr["Numero"].ToString() + ".png"
                            };
                            lstPokedex.Add(entidad);
                        }
                    }

                    return lstPokedex;
                }
            }

        }

        public async Task<EntPokedex> ObtenerPokedexIndividual(string _connectionString, int id)
        {
            EntPokedex entidad = new EntPokedex();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UspObtenerPokedex", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    await con.OpenAsync();
                    using (var dr = await cmd.ExecuteReaderAsync())
                    {
                        while (await dr.ReadAsync())
                        {
                            entidad.Id = Convert.ToInt32(dr["Id"]);
                            entidad.Nombre = dr["Nombre"].ToString();
                            entidad.Descripcion = dr["Descripcion"].ToString();
                            entidad.Numero = dr["Numero"].ToString();
                            entidad.Foto = dr["Numero"].ToString() + ".png";
                        }   
                    }
                }
            }
            return entidad;
        }


    }
}
