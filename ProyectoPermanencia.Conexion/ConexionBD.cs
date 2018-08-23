using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows;
using ProyectoPermanencia.DTO;
namespace ProyectoPermanencia.Conexion
{
    public class ConexionBD
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

        private SqlCommand variableSQL { get; set; }

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

        private void comprobarConexion()
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
        }

        public void conectar()
        {

            comprobarConexion();

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
                    variableSQL = new SqlCommand(this.IntruccioneSQL, this.DbConnection);
                    variableSQL.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en el SQL ", ex);

                }

            }
            this.cerrarConexion();
        }

        public void conectarProcInsertarInteraccion(DataTable datosInteraccion, DataTable idParticipantes) {

            comprobarConexion();

            try
            {
                variableSQL = new SqlCommand(this.IntruccioneSQL, this.DbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                SqlParameter paramDatos = new SqlParameter();
                paramDatos.ParameterName = "@datos";
                paramDatos.Value = datosInteraccion;
                SqlParameter paramParticipantes = new SqlParameter();
                paramParticipantes.ParameterName = "@valores";
                paramParticipantes.Value = idParticipantes;
                SqlParameter paramIdCaso = new SqlParameter();
                paramIdCaso.ParameterName = "@idCaso";
                paramIdCaso.Value = 0;
                variableSQL.Parameters.Add(paramDatos);
                variableSQL.Parameters.Add(paramParticipantes);
                variableSQL.Parameters.Add(paramIdCaso);
                variableSQL.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en el SQL "+ex.Message);
            }
            cerrarConexion();
        }

        public void conectarProcInsertarCasoInteraccion(DataTable datosInteraccion, DataTable idParticipantes, int tipoCaso, int idcurso)
        {
            comprobarConexion();
            try
            {
                variableSQL = new SqlCommand(this.IntruccioneSQL, this.DbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                SqlParameter paramDatos = new SqlParameter();
                paramDatos.ParameterName = "@datos";
                paramDatos.Value = datosInteraccion;
                SqlParameter paramParticipantes = new SqlParameter();
                paramParticipantes.ParameterName = "@valores";
                paramParticipantes.Value = idParticipantes;
                SqlParameter paramAsignatura = new SqlParameter();
                paramAsignatura.ParameterName = "@idAsignatura";
                paramAsignatura.Value = idcurso;
                SqlParameter paramTipoCaso = new SqlParameter();
                paramTipoCaso.ParameterName = "@idTipoCaso";
                paramTipoCaso.Value = tipoCaso;
                variableSQL.Parameters.Add(paramDatos);
                variableSQL.Parameters.Add(paramParticipantes);
                variableSQL.Parameters.Add(paramAsignatura);
                variableSQL.Parameters.Add(paramTipoCaso);
                variableSQL.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw new Exception("Error en el SQL " + ex.Message);
            }

            cerrarConexion();
        }

        public void conectarProcFinalizarCasoInteraccion(int idCaso)
        {
            comprobarConexion();
            try
            {
                variableSQL = new SqlCommand(this.IntruccioneSQL, this.DbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                SqlParameter paramIdCaso = new SqlParameter();
                paramIdCaso.ParameterName = "@idCaso";
                paramIdCaso.Value = idCaso;
                variableSQL.Parameters.Add(paramIdCaso);
                variableSQL.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

                throw new Exception("Error en el SQL " + ex.Message);
            }

            cerrarConexion();
        }
    }
}

