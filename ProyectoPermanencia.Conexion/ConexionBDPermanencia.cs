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

        private SqlDataReader dbReader;

        public SqlDataReader DbReader
        {
            get { return dbReader; }
            set { dbReader = value; }
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
            //Se ingresara tanto la cadena de SQL y de conexion y se instanciara a la Variable SQLCommand.
            SqlCommand variableSQL = new SqlCommand(this.cadenaSQL, this.dbConnection);
            //Si es una consulta, se instanciara DataReader con SqlCommand. Si no, se leera como un Update, Delete e Insert
            //solo se tendra que executar la cadena.
            if (this.EsSelect)
            {
                try
                {
                    this.DbReader = variableSQL.ExecuteReader();
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
