using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace ProyectoPermanencia.Conexion
{
    public class Conexion
    {
        private String nombreBaseDeDatos;

        public String NombreBaseDeDatos
        {
            get { return nombreBaseDeDatos; }
            set { nombreBaseDeDatos = value; }
        }

        private String nombreTabla;

        public String NombreTabla
        {
            get { return nombreTabla; }
            set { nombreTabla = value; }
        }

        private String cadenaConexion;

        public String CadenaConexion
        {
            get { return cadenaConexion; }
            set { cadenaConexion = value; }
        }

        private String intruccioneSQL;

        public String IntruccioneSQL
        {
            get { return intruccioneSQL; }
            set { intruccioneSQL = value; }
        }

        private SqlConnection dbConnection;

        public SqlConnection DbConnection
        {
            get { return dbConnection; }
            set { dbConnection = value; }
        }

        private System.Data.DataSet dbDat;

        public System.Data.DataSet DbDat
        {
            get { return dbDat; }
            set { dbDat = value; }
        }

        private SqlDataAdapter dbDataAdapter;

        public SqlDataAdapter DbDataAdapter
        {
            get { return dbDataAdapter; }
            set { dbDataAdapter = value; }
        }

        private Boolean esSelect;

        public Boolean EsSelect
        {
            get { return esSelect; }
            set { esSelect = value; }
        }

        public void abrirConexion()
        {
            try
            {
                this.DbConnection.Open();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al abrir la conexion ", ex);

            }
        }

        public void cerrarConexion()
        {
            try
            {
                this.DbConnection.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al cerrar la conexion ", ex);

            }
        }

        public void conectar()
        {
            if (this.NombreBaseDeDatos == "")
            {
                throw new Exception("Base de datos en blanco");

            }

            if (this.NombreTabla == "")
            {
                throw new Exception("Tabla en blanco");

            }

            if (this.CadenaConexion == "")
            {
                throw new Exception("Cadena Conexion en blanco");

            }

            if (this.IntruccioneSQL == "")
            {
                throw new Exception("SQL en blanco");

            }

            try
            {
                this.DbConnection = new SqlConnection(this.CadenaConexion);
            }

            catch (SqlException ex)
            {
                throw new Exception("Error al conectar ", ex);

            }

            this.abrirConexion();

            //if(this.EsSelect == true)

            if (this.EsSelect)
            {
                this.DbDat = new System.Data.DataSet();
                try
                {
                    this.DbDataAdapter = new SqlDataAdapter(this.IntruccioneSQL, this.DbConnection);
                    this.DbDataAdapter.Fill(this.DbDat, this.NombreTabla);
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en el SQL ", ex);

                }
            }
            else
            {
                try
                {
                    SqlCommand variableSQL = new SqlCommand(this.IntruccioneSQL, this.DbConnection);
                    variableSQL.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en el SQL ", ex);

                }

            }
            this.cerrarConexion();
        }
    }
}

