using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Repositorios
{
    public class BebidaRepositorio : IBebidaRepositorio
    {
        private string CadenaConexion;

        public BebidaRepositorio(string _cadenaConexion)
        {
            CadenaConexion = _cadenaConexion;
        }
        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        public async Task<bool> Actualizar(Bebida bebida)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"UPDATE bebida SET Descripcion = @Descripcion, Existencia = @Existencia,
                               Precio = @Precio, EstaActivo = @EstaActivo WHERE Codigo = @Codigo;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, bebida));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<bool> Eliminar(string codigo)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"DELETE FROM bebida WHERE Codigo = @Codigo;";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, new { codigo }));
            }
            catch (Exception)
            {
            }
            return resultado;
        }

        public async Task<IEnumerable<Bebida>> GetLista()
        {
            IEnumerable<Bebida> lista = new List<Bebida>();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM bebida;";
                lista = await _conexion.QueryAsync<Bebida>(sql);
            }
            catch (Exception)
            {
            }
            return lista;
        }

        public async Task<Bebida> GetPorCodigo(string codigo)
        {
            Bebida bebida = new Bebida();
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"SELECT * FROM bebida WHERE Codigo = @Codigo;";
                bebida = await _conexion.QueryFirstAsync<Bebida>(sql, new { codigo });
            }
            catch (Exception)
            {
            }
            return bebida;
        }

        public async Task<bool> Nuevo(Bebida bebida)
        {
            bool resultado = false;
            try
            {
                using MySqlConnection _conexion = Conexion();
                await _conexion.OpenAsync();
                string sql = @"INSERT INTO bebida (Codigo,Descripcion,Existencia,Precio,EstaActivo) 
                                VALUES (@Codigo,@Descripcion,@Existencia,@Precio,@EstaActivo);";
                resultado = Convert.ToBoolean(await _conexion.ExecuteAsync(sql, bebida));
            }
            catch (Exception)
            {
            }
            return resultado;
        }
    }
}
