using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace DAL
{
    public class AccesoDAL
    {
        private SqlConnection conexion;
        private SqlTransaction transaccion;

        public void AbrirConexion()
        {
            conexion = new SqlConnection($@"Data Source=DESKTOP-7ESF09C\SQLEXPRESS;Initial Catalog=InsurMaster;Trusted_Connection=True");
            conexion.Open();
        }


        public void CerrarConexion()
        {
            conexion.Close();
            conexion = null;
            GC.Collect();
        }


        public void IniciarTransaccion()
        {
            transaccion = conexion.BeginTransaction();
        }

        public void ConfirmarTransaccion()
        {
            transaccion.Commit();
            transaccion = null;
        }
        public void DeshacerTransaccion()
        {
            transaccion.Rollback();
            transaccion = null;
        }

        public DataTable Leer(string sql, List<SqlParameter> parametros = null)
        {
            AbrirConexion();

            DataTable table = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter();

            adaptador.SelectCommand = CrearComando(sql, parametros);
            adaptador.Fill(table);
            CerrarConexion();
            return table;
        }

        public int Escribir(string sql, List<SqlParameter> parametros = null)
        {
            int res;
            AbrirConexion();
            SqlCommand cmd = CrearComando(sql, parametros);

            try
            {
                res = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                res = -1;

            }

            cmd.Parameters.Clear();
            cmd.Dispose();

            CerrarConexion();
            return res;
        }

        public SqlParameter CrearParametro(string name, int value)
        {
            SqlParameter parametro = new SqlParameter(name, value);
            parametro.DbType = DbType.Int32;
            return parametro;
        }

        public SqlParameter CrearParametro(string name, float value)
        {
            SqlParameter parametro = new SqlParameter(name, value);
            parametro.DbType = DbType.Single;
            return parametro;
        }

        public SqlParameter CrearParametro(string name, string value)
        {
            SqlParameter parametro = new SqlParameter(name, value);
            parametro.DbType = DbType.String;
            return parametro;
        }
        public SqlCommand CrearComando(string sql, List<SqlParameter> parametros = null)
        {
            SqlCommand command = new SqlCommand(sql, conexion);
            command.CommandType = CommandType.Text;
            if (parametros != null)
            {
                command.Parameters.AddRange(parametros.ToArray());
            }
            if (transaccion != null)
            {
                command.Transaction = transaccion;
            }

            return command;
        }

        public object EscribirEscalar(string sql, List<SqlParameter> parametros = null)
        {
            object res;
            AbrirConexion();
            SqlCommand cmd = CrearComando(sql, parametros);

            try
            {
                res = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                res = null;
            }

            cmd.Parameters.Clear();
            cmd.Dispose();

            CerrarConexion();
            return res;
        }
    }
}
