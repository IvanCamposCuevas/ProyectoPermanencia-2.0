using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
namespace ProyectoPermanencia.Negocio
{
    public class NegocioCargaArchivo : NegocioConexionBD
    {

        /// <summary>
        /// Método para insertar la info de la carga
        /// </summary>
        public void InsertarLogCarga(DateTime fecha,string tipo ) //tipo archivo. 
        {
            try
            {
                Conexion.IntruccioneSQL = String.Format("INSERT INTO Log_Cargas '{0}', '{1}' ", fecha,tipo );
                Conexion.EsSelect = false;
                Conexion.conectar();
            }
        catch(Exception ex)
            {
                throw new Exception("Error, mensaje: ", ex);
            }
        }

        public DataSet CargarFechaCarga()
        {
            Conexion.IntruccioneSQL = String.Format("SELECT MAX(Fecha_Carga) FROM dbo.Log_Cargas;");
            Conexion.EsSelect = true;
            Conexion.conectar();
            //fecha = Conexion.DbDat.Tables[0].Rows[0].ItemArray[0].ToString(); //con esto hago referencia a la fecha de carga que llame
            //return fecha;
            return Conexion.DbDat;
        } 



        /// <summary>
        /// Obtiene el nombre de la hoja a traves del archivo excel.
        /// </summary>
        /// <param name="conexionExcel"></param>
        /// <returns></returns>
        private String obtenerNombreHoja(OleDbConnection conexionExcel)
        {
            DataTable dbSchema = conexionExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string nombreHoja = dbSchema.Rows[0]["TABLE_NAME"].ToString();
            return nombreHoja;
        }

        /// <summary>
        /// Metodo que se dedicara a subir los archivos de asistencia en la Base de datos.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="tipoArchivo"></param>
        /// <param name="path"></param>
        public void agregarArchivoAsistencia(String nombreArchivo, String tipoArchivo, String path)
        {
            string tipo = "Asistencias";
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", path + nombreArchivo);
            using (OleDbConnection conExcel = new OleDbConnection(excelConnectionString))
            {
                try
                {
                    conExcel.Open();
                    InsertarLogCarga(new DateTime(), tipo);
                    OleDbCommand comando = new OleDbCommand("SELECT * FROM [" + obtenerNombreHoja(conExcel) + "]", conExcel);
                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(Conexion.CadenaConexion))
                        {
                            bulkCopy.DestinationTableName = "dbo.AsistenciaSTG";
                            bulkCopy.WriteToServer(dr);
                        }
                    }
                }
                catch (OleDbException ex)
                {

                    throw new Exception("Error en el archivo Excel, Excepcion:", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar el archivo, Excepcion:", ex);
                }
            }
        }


        /// <summary>
        /// Metodo que se dedicara a subir los archivos de deudas en la Base de Datos.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="tipoArchivo"></param>
        /// <param name="path"></param>
        public void agregarArchivoDeuda(String nombreArchivo, String tipoArchivo, String path)
        {
            string tipo = "Deudas";
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", path + nombreArchivo);
            using (OleDbConnection conExcel = new OleDbConnection(excelConnectionString))
            {
                try
                {
                    conExcel.Open();
                    InsertarLogCarga(new DateTime(), tipo);
                    OleDbCommand comando = new OleDbCommand("SELECT * FROM [" + obtenerNombreHoja(conExcel) + "]", conExcel);
                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(Conexion.CadenaConexion))
                        {
                            bulkCopy.DestinationTableName = "dbo.Morosos_STG";
                            bulkCopy.WriteToServer(dr);
                        }
                    }
                }
                catch (OleDbException ex)
                {

                    throw new Exception("Error en el archivo Excel, Excepcion:", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar el archivo, Excepcion:", ex);
                }
            }
        }


        /// <summary>
        /// Metodo que sirve para cargar los archivos de Notas en la Base de Datos.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="tipoArchivo"></pa0ram>
        /// <param name="path"></param>
        public void agregarArchivoNotas(String nombreArchivo, String tipoArchivo, String path)
        {
            string tipo = "Notas";
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", path + nombreArchivo);
            using (OleDbConnection conExcel = new OleDbConnection(excelConnectionString))
            {
                try
                {
                    conExcel.Open();
                    InsertarLogCarga(new DateTime(), tipo);
                    OleDbCommand comando = new OleDbCommand("SELECT * FROM [" + obtenerNombreHoja(conExcel) + "]", conExcel);
                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(Conexion.CadenaConexion))
                        {
                            bulkCopy.DestinationTableName = "dbo.Curso_STG";
                            bulkCopy.WriteToServer(dr);
                        }
                    }
                }
                catch (OleDbException ex)
                {

                    throw new Exception("Error en el archivo Excel, Excepcion:", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar el archivo, Excepcion:", ex);
                }
            }
        }

        /// <summary>
        /// Metodo que sirve para cargar los Archivos de Indice en la Base de datos.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <param name="tipoArchivo"></param>
        /// <param name="path"></param>
        public void agregarArchivoIndice(String nombreArchivo, String tipoArchivo, String path)
        {
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'", path + nombreArchivo);
            using (OleDbConnection conExcel = new OleDbConnection(excelConnectionString))
            {
                try
                {
                    conExcel.Open();
                    OleDbCommand comando = new OleDbCommand("SELECT * FROM [" + obtenerNombreHoja(conExcel) + "]", conExcel);
                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(Conexion.CadenaConexion))
                        {
                            bulkCopy.DestinationTableName = "dbo.Indice_STG";
                            
                            bulkCopy.WriteToServer(dr);
                        }

                    }
                }
                catch (OleDbException ex)
                {

                    throw new Exception("Error en el archivo Excel, Excepcion:", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar el archivo, Excepcion:", ex);
                }
            }

        }
    }
}
