using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using TurismoReal_Utils.Core.Interfaces;
using TurismoReal_Utils.Infra.Context;
using TurismoReal_Utils.Core.Entities;

namespace TurismoReal_Utils.Infra.Repositories
{
    public class UtilsRepository : IUtilsRepository
    {
        protected readonly OracleContext _context;

        public UtilsRepository()
        {
            _context = new OracleContext();
        }

        public async Task<List<string>> GetPaises()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_paises", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("paises", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader) await cmd.ExecuteReaderAsync();
            List<string> paises = new List<string>();

            while (reader.Read())
            {
                string pais = reader.GetValue(reader.GetOrdinal("pais")).ToString();
                paises.Add(pais);
            }
            _context.CloseConnection();
            return paises;
        }

        public async Task<List<string>> GetRegiones()
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_regiones", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("regiones", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            OracleDataReader reader = (OracleDataReader) await cmd.ExecuteReaderAsync();
            List<string> regiones = new List<string>();

            while (reader.Read())
            {
                string region = reader.GetValue(reader.GetOrdinal("region")).ToString();
                regiones.Add(region);
            }
            _context.CloseConnection();
            return regiones;
        }

        public async Task<List<string>> GetComunasByRegion(Region region)
        {
            _context.OpenConnection();
            OracleCommand cmd = new OracleCommand("sp_obten_comuna_por_region", _context.GetConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("region_in", OracleDbType.Varchar2).Direction = ParameterDirection.Input;
            cmd.Parameters.Add("comunas", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            cmd.Parameters["region_in"].Value = region.region;

            OracleDataReader reader = (OracleDataReader)await cmd.ExecuteReaderAsync();
            List<string> comunas = new List<string>();

            while (reader.Read())
            {
                string comuna = reader.GetValue(reader.GetOrdinal("comuna")).ToString();
                comunas.Add(comuna);
            }
            _context.CloseConnection();
            return comunas;
        }
    }
}
