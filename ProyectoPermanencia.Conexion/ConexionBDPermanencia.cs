using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace ProyectoPermanencia.Conexion
{
    public class ConexionBDPermanencia
    {
        //Varibles de instancia
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

        private String cadenaSQL;

        public String CadenaSQL
        {
            get { return cadenaSQL; }
            set { cadenaSQL = value; }
        }

        private Boolean esSelect;

        public Boolean EsSelect
        {
            get { return esSelect; }
            set { esSelect = value; }
        }

        private SqlConnection dbConnection;

        public SqlConnection DbConnection
        {
            get { return dbConnection; }
            set { dbConnection = value; }
        }

        private System.Data.DataSet dbDataSet;

        public System.Data.DataSet DbDataSet
        {
            get { return dbDataSet; }
            set { dbDataSet = value; }
        }


        private SqlDataAdapter dbDataAdapter;

        public SqlDataAdapter DbDataAdapter
        {
            get { return dbDataAdapter; }
            set { dbDataAdapter = value; }
        }


        //abrir la conexion

        public void Abrir()
        {
            try
            {
                this.DbConnection.Open();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la conexion", ex);
            }

        } //Fin abrir

        //Cerra la conexion

        public void Cerrar()
        {
            try
            {
                this.DbConnection.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexion", ex);
            }

        } //Fin cerrar

        //Metodo mas importante

        public void Conectar()
        {
            //Se validan las variables de   
            if (this.NombreBaseDeDatos.Length == 0)
            {
                throw new Exception("Falta nombre base de datos");
            }


            if (this.NombreTabla.Length == 0)
            {
                throw new Exception("Falta nombre tabla");
            }

            if (this.CadenaConexion.Length == 0)
            {
                throw new Exception("Falta cadena Conexion");
            }
            if (this.CadenaSQL.Length == 0)
            {
                throw new Exception("Falta cadena SQL");
            }

            //SE instancia la Conexion

            try
            {
                this.DbConnection = new SqlConnection(this.CadenaConexion);
            }
            catch (Exception ex)
            {
                throw new Exception("Error de Conexion", ex);
            }

            //SE abre la conexion
            this.Abrir();

            //Se instancia el DataAdapter

            if (this.EsSelect)
            {
                //SE instancia dataSet

                this.DbDataSet = new System.Data.DataSet();
                try
                {
                    this.DbDataAdapter = new SqlDataAdapter(this.CadenaSQL, this.DbConnection);
                    this.DbDataAdapter.Fill(this.DbDataSet, this.NombreTabla);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar los datos", ex);

                }
            }
            else
            {
                try
                {
                    SqlCommand variableSQL = new SqlCommand(this.CadenaSQL, this.DbConnection);
                    variableSQL.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception("Error en SQL", ex);
                }
            } //Fin if



            this.Cerrar();

        } //Fin conectar
    }
}
