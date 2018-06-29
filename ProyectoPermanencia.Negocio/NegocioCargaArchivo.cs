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
    public class NegocioCargaArchivo
    {
        private String obtenerNombreHoja(OleDbConnection conexionExcel)
        {
            DataTable dbSchema = conexionExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string nombreHoja = dbSchema.Rows[0]["TABLE_NAME"].ToString();
            return nombreHoja;
        }

        public void agregarArchivoAsistencia(String nombreArchivo, String tipoArchivo, String path)
        {
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path + nombreArchivo);
            using (OleDbConnection conExcel = new OleDbConnection(excelConnectionString))
            {
                try
                {
                    conExcel.Open();
                    OleDbCommand comando = new OleDbCommand("SELECT * FROM [" + obtenerNombreHoja(conExcel) + "]", conExcel);
                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        NegocioConexionBD con = new NegocioConexionBD();
                        con.configuraConexion();
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con.Conec1.CadenaConexion))
                        {
                            bulkCopy.DestinationTableName = "dbo.AsistenciaSTG";
                            bulkCopy.WriteToServer(dr);
                            System.Windows.Forms.MessageBox.Show("Archivo cargado correctamente");
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

        public void agregarArchivoDeuda(String nombreArchivo, String tipoArchivo, String path)
        {
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path + nombreArchivo);
            using (OleDbConnection conExcel = new OleDbConnection(excelConnectionString))
            {
                try
                {
                    conExcel.Open();
                    OleDbCommand comando = new OleDbCommand("SELECT * FROM [" + obtenerNombreHoja(conExcel) + "]", conExcel);
                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        NegocioConexionBD con = new NegocioConexionBD();
                        con.configuraConexion();
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con.Conec1.CadenaConexion))
                        {
                            bulkCopy.DestinationTableName = "dbo.Morosos_STG";
                            bulkCopy.WriteToServer(dr);
                            System.Windows.Forms.MessageBox.Show("Archivo cargado correctamente");
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

        public void agregarArchivoNotas(String nombreArchivo, String tipoArchivo, String path)
        {
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES'", path + nombreArchivo);
            using (OleDbConnection conExcel = new OleDbConnection(excelConnectionString))
            {
                try
                {
                    conExcel.Open();
                    OleDbCommand comando = new OleDbCommand("SELECT * FROM [" + obtenerNombreHoja(conExcel) + "]", conExcel);
                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        NegocioConexionBD con = new NegocioConexionBD();
                        con.configuraConexion();
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con.Conec1.CadenaConexion))
                        {
                            bulkCopy.DestinationTableName = "dbo.Curso_STG";
                            bulkCopy.WriteToServer(dr);
                            System.Windows.Forms.MessageBox.Show("Archivo cargado correctamente");
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

        public void agregarArchivoIndice(String nombreArchivo, String tipoArchivo, String path)
        {
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path + nombreArchivo);
            using (OleDbConnection conExcel = new OleDbConnection(excelConnectionString))
            {
                try
                {
                    conExcel.Open();
                    OleDbCommand comando = new OleDbCommand("SELECT * FROM [" + obtenerNombreHoja(conExcel) + "]", conExcel);
                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        NegocioConexionBD con = new NegocioConexionBD();
                        con.configuraConexion();
                        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(con.Conec1.CadenaConexion))
                        {
                            bulkCopy.DestinationTableName = "dbo.Indice_STG";
                            bulkCopy.WriteToServer(dr);
                            System.Windows.Forms.MessageBox.Show("Archivo cargado correctamente");
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
