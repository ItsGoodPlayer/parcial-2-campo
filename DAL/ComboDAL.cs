using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using BE;

namespace DAL
{
    public class ComboDAL : AccesoDAL
    {
        public List<Combo> CargarCombos()
        {
            List<Combo> combos = new List<Combo>();
            
            string sql = "SELECT Id, Nombre, Precio, Descripcion, Tipo FROM Combos ORDER BY Id";

            DataTable tabla = Leer(sql);

            foreach (DataRow row in tabla.Rows)
            {
                var combo = ComboFactory.CrearCombo(row["Tipo"].ToString());
                combo.Id = Convert.ToInt32(row["Id"]);
                combo.Nombre = row["Nombre"].ToString();
                combo.Precio = Convert.ToDecimal(row["Precio"]);
                combo.Descripcion = row["Descripcion"].ToString();
                
                combos.Add(combo);
            }

            return combos;
        }

        public Combo ObtenerComboPorId(int comboId)
        {
            string sql = "SELECT Id, Nombre, Precio, Descripcion, Tipo FROM Combos WHERE Id = @ComboId";
            var parametros = new List<SqlParameter> { CrearParametro("@ComboId", comboId) };
            
            DataTable tabla = Leer(sql, parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                var combo = ComboFactory.CrearCombo(row["Tipo"].ToString());
                combo.Id = Convert.ToInt32(row["Id"]);
                combo.Nombre = row["Nombre"].ToString();
                combo.Precio = Convert.ToDecimal(row["Precio"]);
                combo.Descripcion = row["Descripcion"].ToString();
                
                return combo;
            }

            return null;
        }

        public Combo ObtenerComboPorTipo(TipoCombo tipo)
        {
            string sql = "SELECT Id, Nombre, Precio, Descripcion, Tipo FROM Combos WHERE Tipo = @Tipo";
            var parametros = new List<SqlParameter> { CrearParametro("@Tipo", tipo.ToString()) };
            
            DataTable tabla = Leer(sql, parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                var combo = ComboFactory.CrearCombo(row["Tipo"].ToString());
                combo.Id = Convert.ToInt32(row["Id"]);
                combo.Nombre = row["Nombre"].ToString();
                combo.Precio = Convert.ToDecimal(row["Precio"]);
                combo.Descripcion = row["Descripcion"].ToString();
                
                return combo;
            }

            return null;
        }

        public bool ActualizarPrecioCombo(int comboId, decimal nuevoPrecio)
        {
            string sql = "UPDATE Combos SET Precio = @Precio WHERE Id = @ComboId";
            var parametros = new List<SqlParameter> 
            { 
                CrearParametro("@Precio", nuevoPrecio),
                CrearParametro("@ComboId", comboId) 
            };
            
            int resultado = Escribir(sql, parametros);
            return resultado > 0;
        }

        public bool ActualizarCombo(Combo combo)
        {
            string sql = "UPDATE Combos SET Nombre = @Nombre, Precio = @Precio, Descripcion = @Descripcion WHERE Id = @ComboId";
            var parametros = new List<SqlParameter> 
            { 
                CrearParametro("@Nombre", combo.Nombre),
                CrearParametro("@Precio", combo.Precio),
                CrearParametro("@Descripcion", combo.Descripcion),
                CrearParametro("@ComboId", combo.Id) 
            };
            
            int resultado = Escribir(sql, parametros);
            return resultado > 0;
        }
    }
}