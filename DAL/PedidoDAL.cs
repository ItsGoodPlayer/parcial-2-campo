using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using BE;

namespace DAL
{
    public class PedidoDAL : AccesoDAL
    {
        private PorcionAdicionalDAL porcionDAL;

        public PedidoDAL()
        {
            porcionDAL = new PorcionAdicionalDAL();
        }

        public int GuardarPedido(Pedido pedido)
        {
            try
            {
                AbrirConexion();
                IniciarTransaccion();

                var parametros = new List<SqlParameter>
                {
                    CrearParametro("@ComboId", pedido.Combo.Id),
                    CrearParametro("@Total", pedido.Total),
                    CrearParametro("@FechaPedido", pedido.Fecha)
                };

                string sql = "INSERT INTO Pedidos (ComboId, Total, FechaPedido) OUTPUT INSERTED.Id VALUES (@ComboId, @Total, @FechaPedido)";
                
                object resultado = EscribirEscalar(sql, parametros);
                int pedidoId = Convert.ToInt32(resultado);

                foreach (var porcion in pedido.PorcionesAdicionales)
                {
                    var parametrosPorcion = new List<SqlParameter>
                    {
                        CrearParametro("@PedidoId", pedidoId),
                        CrearParametro("@PorcionId", porcionDAL.ObtenerIdPorcion(porcion.Tipo)),
                        CrearParametro("@Cantidad", porcion.Cantidad)
                    };

                    string sqlPorcion = "INSERT INTO PedidoPorciones (PedidoId, PorcionId, Cantidad) VALUES (@PedidoId, @PorcionId, @Cantidad)";
                    Escribir(sqlPorcion, parametrosPorcion);
                }

                ConfirmarTransaccion();
                CerrarConexion();
                return pedidoId;
            }
            catch
            {
                DeshacerTransaccion();
                CerrarConexion();
                throw;
            }
        }

        public List<Pedido> CargarPedidos()
        {
            List<Pedido> pedidos = new List<Pedido>();
            
            string sql = @"SELECT p.Id, p.FechaPedido, p.Total, c.Id as ComboId, c.Nombre, c.Precio, c.Descripcion, c.Tipo
                          FROM Pedidos p 
                          INNER JOIN Combos c ON p.ComboId = c.Id
                          ORDER BY p.FechaPedido DESC";

            DataTable tabla = Leer(sql);

            foreach (DataRow row in tabla.Rows)
            {
                var combo = ComboFactory.CrearCombo(row["Tipo"].ToString());
                combo.Id = Convert.ToInt32(row["ComboId"]);
                combo.Nombre = row["Nombre"].ToString();
                combo.Precio = Convert.ToDecimal(row["Precio"]);
                combo.Descripcion = row["Descripcion"].ToString();

                var pedido = new Pedido
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Fecha = Convert.ToDateTime(row["FechaPedido"]),
                    Total = Convert.ToDecimal(row["Total"]),
                    Combo = combo
                };

                pedido.PorcionesAdicionales = CargarPorcionesPedido(pedido.Id);
                pedidos.Add(pedido);
            }

            return pedidos;
        }

        private List<PorcionAdicional> CargarPorcionesPedido(int pedidoId)
        {
            List<PorcionAdicional> porciones = new List<PorcionAdicional>();
            
            string sql = @"SELECT pa.Tipo, pa.Precio, pp.Cantidad
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
                    Cantidad = Convert.ToInt32(row["Cantidad"])
                };
                porciones.Add(porcion);
            }

            return porciones;
        }

        public bool EliminarPedido(int pedidoId)
        {
            try
            {
                AbrirConexion();
                IniciarTransaccion();

                var parametros = new List<SqlParameter> { CrearParametro("@PedidoId", pedidoId) };

                string sqlPorciones = "DELETE FROM PedidoPorciones WHERE PedidoId = @PedidoId";
                Escribir(sqlPorciones, parametros);

                string sqlPedido = "DELETE FROM Pedidos WHERE Id = @PedidoId";
                int resultado = Escribir(sqlPedido, parametros);

                ConfirmarTransaccion();
                CerrarConexion();
                return resultado > 0;
            }
            catch
            {
                DeshacerTransaccion();
                CerrarConexion();
                return false;
            }
        }

        public Pedido ObtenerPedidoPorId(int pedidoId)
        {
            string sql = @"SELECT p.Id, p.FechaPedido, p.Total, c.Id as ComboId, c.Nombre, c.Precio, c.Descripcion, c.Tipo
                          FROM Pedidos p 
                          INNER JOIN Combos c ON p.ComboId = c.Id
                          WHERE p.Id = @PedidoId";

            var parametros = new List<SqlParameter> { CrearParametro("@PedidoId", pedidoId) };
            DataTable tabla = Leer(sql, parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                var combo = ComboFactory.CrearCombo(row["Tipo"].ToString());
                combo.Id = Convert.ToInt32(row["ComboId"]);
                combo.Nombre = row["Nombre"].ToString();
                combo.Precio = Convert.ToDecimal(row["Precio"]);
                combo.Descripcion = row["Descripcion"].ToString();

                var pedido = new Pedido
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Fecha = Convert.ToDateTime(row["FechaPedido"]),
                    Total = Convert.ToDecimal(row["Total"]),
                    Combo = combo
                };

                pedido.PorcionesAdicionales = CargarPorcionesPedido(pedido.Id);
                return pedido;
            }

            return null;
        }
    }
}