using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using neg = ProyectoPermanencia.Negocio.NegocioCargaArchivo;
namespace ProyectoPermanencia.Presentacion
{
    public partial class CargarArchivos : System.Web.UI.Page , IMensajeAlerta
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //fechaCarga();
        }


        /// <summary>
        /// Evento que permite subir un archivo .xls o .xlsx (Excels), 
        /// a la Base de Datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCargarAr_Click(object sender, EventArgs e)
        {
            string opcion = this.ddlTipoArchivo.SelectedValue; //Obtiene el valor de la opcion que eligio el usuario desde el DropDownLisr
            if (fuSubirArchivo.HasFile) //Verifica si se subio un archivo
            {
                try
                {
                    string path = Server.MapPath("~/Uploads/"); //Se obtiene la ruta del servidor en donde se subira el archivo.
                    string extArchivo=System.IO.Path.GetExtension(path + fuSubirArchivo.FileName); //Se obtiene la extension del archivo que se va a subir.
                    if (extArchivo.Equals(".xls") || extArchivo.Equals(".xlsx")) //Se verifica que el archivo tenga las extenciones propuestas (.xls o .xlsx)
                    {
                        fuSubirArchivo.SaveAs(path + fuSubirArchivo.FileName); //Se guarda el archivo en la ruta anterirmente propuesta.
                        switch (opcion) //Switch-case de la opcion elegida.
                                        //Caso 1, agrega los archivos de asistencia,
                                        //Caso 2, agrega el archivo de notas.
                                        //Caso 3, agrega el archivo de deudas.
                                        //Caso 4, agrega el archivo de indice. 
                        {
                            case "1":
                                new neg().agregarArchivoAsistencia(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                                mostrarAlerta("Archivo cargado correctamente");
                                break;
                            case "2":
                                new neg().agregarArchivoNotas(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                                mostrarAlerta("Archivo cargado correctamente");
                                break;
                            case "3":
                                new neg().agregarArchivoDeuda(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                                mostrarAlerta("Archivo cargado correctamente");
                                break;
                            case "4":
                                new neg().agregarArchivoIndice(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                                mostrarAlerta("Archivo cargado correctamente");
                                break;
                        }
                    }
                    else
                    {
                        mostrarAlerta("El archivo adjunto debe ser en formato Excels, "
                            +"con extension .xls o .xlsx");
                    }
                    
                }
                catch (Exception ex)
                {
                    mostrarAlerta(ex.Message + ex.InnerException);
                }
            }
            else
            {
               mostrarAlerta("Por favor, Ingrese un archivo para continuar");
            }
        }

        public void mostrarAlerta(string mensaje) 
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", string.Format("alert('{0}');", mensaje), true);
        }

        /// <summary>
        /// Evento que segun que tipo de archvo se alla elegido, se descargara mediante el metodo y parametro de entrada
        /// asignados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnArchivo_Click(object sender, EventArgs e)
        {
            switch (ddlTipoArchivoEjemplo.SelectedValue)
            {
                case "1":
                    descargarArchivo("Asistencia.xlsx");
                    break;
                case "2":
                    descargarArchivo("Cursos.xlsx");
                    break;
                case "3":
                    descargarArchivo("Reporte Morosidad.xlsx");
                    break;
                case "4":
                    descargarArchivo("INDICE.xls");
                    break;
            }
        }

        /// <summary>
        /// Metodo privado que permitira descargar un archivo de prueba.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        private void descargarArchivo(string nombreArchivo)
        {
            Response.Clear();
            Response.ContentType = "application/octect-stream";
            Response.AppendHeader("content-disposition", "filename= "+ nombreArchivo);
            Response.TransmitFile(Server.MapPath("~/Archivos_Brutos/") + nombreArchivo);
            Response.End();
        }

        private void fechaCarga()
        {
            if (lblFecha.Text != "Fecha de la última carga: ")
            {
                lblFecha.Text = "Fecha de la última carga: ";
            }

            System.Data.DataSet fecha = new System.Data.DataSet();
            fecha = new neg().CargarFechaCarga();
            lblFecha.Text += String.IsNullOrEmpty(fecha.Tables[0].Rows[0].ItemArray[0].ToString()) ? "---" : fecha.Tables[0].Rows[0].ItemArray[0].ToString(); //si no hay fechas muestra guiones
            /*string fecha;
            lblFecha.Text += new neg().CargarFechaCarga(out fecha);*/
        }
    }
}