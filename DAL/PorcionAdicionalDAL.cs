using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using BE;

namespace DAL
{
    public class PorcionAdicionalDAL : AccesoDAL
    {
        public List<PorcionAdicional> CargarPorcionesAdicionales()
        {
            List<PorcionAdicional> porciones = new List<PorcionAdicional>();
            
            string sql = "SELECT Id, Tipo, Precio FROM PorcionesAdicionales ORDER BY Id";
            DataTable tabla = Leer(sql);

            foreach (DataRow row in tabla.Rows)
            {
                TipoPorcion tipo;
                Enum.TryParse(row["Tipo"].ToString(), out tipo);

                var porcion = new PorcionAdicional(tipo, Convert.ToDecimal(row["Precio"]))
                {
                    Id = Convert.ToInt32(row["Id"])
                };
                porciones.Add(porcion);
            }

            return porciones;
        }

        public PorcionAdicional ObtenerPorcionPorId(int porcionId)
        {
            string sql = "SELECT Id, Tipo, Precio FROM PorcionesAdicionales WHERE Id = @PorcionId";
            var parametros = new List<SqlParameter> { CrearParametro("@PorcionId", porcionId) };
            
            DataTable tabla = Leer(sql, parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                TipoPorcion tipo;
                Enum.TryParse(row["Tipo"].ToString(), out tipo);

                return new PorcionAdicional(tipo, Convert.ToDecimal(row["Precio"]))
                {
                    Id = Convert.ToInt32(row["Id"])
                };
            }

            return null;
        }

        public PorcionAdicional ObtenerPorcionPorTipo(TipoPorcion tipo)
        {
            string sql = "SELECT Id, Tipo, Precio FROM PorcionesAdicionales WHERE Tipo = @Tipo";
            var parametros = new List<SqlParameter> { CrearParametro("@Tipo", tipo.ToString()) };
            
            DataTable tabla = Leer(sql, parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                return new PorcionAdicional(tipo, Convert.ToDecimal(row["Precio"]))
                {
                    Id = Convert.ToInt32(row["Id"])
                };
            }

            return null;
        }

        public int ObtenerIdPorcion(TipoPorcion tipo)
        {
            string sql = "SELECT Id FROM PorcionesAdicionales WHERE Tipo = @Tipo";
            var parametros = new List<SqlParameter> { CrearParametro("@Tipo", tipo.ToString()) };
            
            object resultado = EscribirEscalar(sql, parametros);
            return resultado != null ? Convert.ToInt32(resultado) : 0;
        }

        public decimal ObtenerPrecioPorcion(TipoPorcion tipo)
        {
            string sql = "SELECT Precio FROM PorcionesAdicionales WHERE Tipo = @Tipo";
            var parametros = new List<SqlParameter> { CrearParametro("@Tipo", tipo.ToString()) };
            
            object resultado = EscribirEscalar(sql, parametros);
            return resultado != null ? Convert.ToDecimal(resultado) : 0m;
        }

        public bool ActualizarPrecioPorcion(TipoPorcion tipo, decimal nuevoPrecio)
        {
            string sql = "UPDATE PorcionesAdicionales SET Precio = @Precio WHERE Tipo = @Tipo";
            var parametros = new List<SqlParameter> 
            { 
                CrearParametro("@Precio", nuevoPrecio),
                CrearParametro("@Tipo", tipo.ToString()) 
            };
            
            int resultado = Escribir(sql, parametros);
            return resultado > 0;
        }

        public bool ExistePorcion(TipoPorcion tipo)
        {
            string sql = "SELECT COUNT(*) FROM PorcionesAdicionales WHERE Tipo = @Tipo";
            var parametros = new List<SqlParameter> { CrearParametro("@Tipo", tipo.ToString()) };
            
            object resultado = EscribirEscalar(sql, parametros);
            return resultado != null && Convert.ToInt32(resultado) > 0;
        }

        public List<PorcionAdicional> ObtenerPorcionesPorPedido(int pedidoId)
        {
            List<PorcionAdicional> porciones = new List<PorcionAdicional>();
            
            string sql = @"SELECT pa.Id, pa.Tipo, pa.Precio, pp.Cantidad
                          FROM PedidoPorciones pp
                          INNER JOIN PorcionesAdicionales pa ON pp.PorcionId = pa.Id
                          WHERE pp.PedidoId = @PedidoId";

            var parametros = new List<SqlParameter> { CrearParametro("@PedidoId", pedidoId) };
            DataTable tabla = Leer(sql, parametros);

            foreach (DataRow row in tabla.Rows)
            {
                TipoPorcion tipo;
                Enum.TryParse(row["Tipo"].ToString(), out tipo);

                var porcion = new PorcionAdicional(tipo, Convert.ToDecimal(row["Precio"]))
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Cantidad = Convert.ToInt32(row["Cantidad"])
                };
                porciones.Add(porcion);
            }

            return porciones;
        }
    }
}