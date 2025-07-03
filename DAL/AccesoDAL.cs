using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace DAL
{
    public abstract class AccesoDAL
    {
        protected SqlConnection conexion;
        protected SqlTransaction transaccion;

        protected void AbrirConexion()
        {
            conexion = new SqlConnection($@"Data Source=DESKTOP-7ESF09C\SQLEXPRESS;Initial Catalog=McDonalds;Trusted_Connection=True");
            conexion.Open();
        }


        protected void CerrarConexion()
        {
            conexion.Close();
            conexion = null;
            GC.Collect();
        }

        protected void IniciarTransaccion()
        {
            transaccion = conexion.BeginTransaction();
        }

        protected void ConfirmarTransaccion()
        {
            transaccion.Commit();
            transaccion = null;
        }

        protected void DeshacerTransaccion()
        {
            transaccion.Rollback();
            transaccion = null;
        }

        protected DataTable Leer(string sql, List<SqlParameter> parametros = null)
        {
            AbrirConexion();
            DataTable table = new DataTable();
            SqlDataAdapter adaptador = new SqlDataAdapter();

            adaptador.SelectCommand = CrearComando(sql, parametros);
            adaptador.Fill(table);
            CerrarConexion();
            return table;
        }

        protected int Escribir(string sql, List<SqlParameter> parametros = null)
        {
            int res;
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

            return res;
        }

        protected SqlParameter CrearParametro(string name, int value)
        {
            SqlParameter parametro = new SqlParameter(name, value);
            parametro.DbType = DbType.Int32;
            return parametro;
        }

        protected SqlParameter CrearParametro(string name, float value)
        {
            SqlParameter parametro = new SqlParameter(name, value);
            parametro.DbType = DbType.Single;
            return parametro;
        }

        protected SqlParameter CrearParametro(string name, decimal value)
        {
            SqlParameter parametro = new SqlParameter(name, value);
            parametro.DbType = DbType.Decimal;
            return parametro;
        }

        protected SqlParameter CrearParametro(string name, DateTime value)
        {
            SqlParameter parametro = new SqlParameter(name, value);
            parametro.DbType = DbType.DateTime;
            return parametro;
        }

        protected SqlParameter CrearParametro(string name, string value)
        {
            SqlParameter parametro = new SqlParameter(name, value);
            parametro.DbType = DbType.String;
            return parametro;
        }

        protected SqlCommand CrearComando(string sql, List<SqlParameter> parametros = null)
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

        protected object EscribirEscalar(string sql, List<SqlParameter> parametros = null)
        {
            object res;
            SqlCommand cmd = CrearComando(sql, parametros);

            res = cmd.ExecuteScalar();
            

            cmd.Parameters.Clear();
            cmd.Dispose();

            return res;
        }

        protected object LeerEscalar(string sql, List<SqlParameter> parametros = null)
        {
            object res;
            
        
            AbrirConexion();
            SqlCommand cmd = CrearComando(sql, parametros);
            res = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            cmd.Dispose();
        

        
            CerrarConexion();
        

            return res;
        }

    }
}
