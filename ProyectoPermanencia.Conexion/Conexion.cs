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

        public void conectarProcInsertarInteraccion(DTOInteraccion interaccion) {

            comprobarConexion();

            try
            {
                variableSQL = new SqlCommand(this.IntruccioneSQL, this.DbConnection);
                variableSQL.CommandType = CommandType.StoredProcedure;
                SqlParameter paramRut = new SqlParameter();
                paramRut.ParameterName = "@rut";
                paramRut.Value = interaccion.rutAlumno;
                SqlParameter paramIdCaso = new SqlParameter();
                paramIdCaso.ParameterName = "@idCaso";
                paramIdCaso.Value = interaccion.idCaso;
                SqlParameter paramTipoint = new SqlParameter();
                paramTipoint.ParameterName = "@tipoInteraccion";
                paramTipoint.Value = interaccion.tipoInteraccion;
                SqlParameter paramIdArea = new SqlParameter();
                paramIdArea.ParameterName = "@idArea";
                paramIdArea.Value = interaccion.idArea;
                SqlParameter paramComentario = new SqlParameter();
                paramComentario.ParameterName = "@comentario";
                paramComentario.Value = interaccion.comentarios;
                SqlParameter paramParticipantes = new SqlParameter();
                paramParticipantes.ParameterName = "@valores";
                paramParticipantes.Value = interaccion.participantes;
                SqlParameter paramFechaInt = new SqlParameter();
                paramFechaInt.ParameterName = "@fechaInteraccion";
                paramFechaInt.Value = interaccion.fechaInteraccion;
                SqlParameter paramArchivo = new SqlParameter();
                paramArchivo.ParameterName = "@rutaArchivo";
                paramArchivo.Value = interaccion.rutaArchivo;
                variableSQL.Parameters.Add(paramRut);
                variableSQL.Parameters.Add(paramIdCaso);
                variableSQL.Parameters.Add(paramTipoint);
                variableSQL.Parameters.Add(paramIdArea);
                variableSQL.Parameters.Add(paramComentario);
                variableSQL.Parameters.Add(paramParticipantes);
                variableSQL.Parameters.Add(paramFechaInt);
                variableSQL.Parameters.Add(paramArchivo);
                variableSQL.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error en el SQL ", ex);
            }
            cerrarConexion();
        }
    }
}

