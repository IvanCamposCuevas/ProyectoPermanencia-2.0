using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using neg = ProyectoPermanencia.Negocio.NegocioCargaArchivo;
namespace ProyectoPermanencia.Presentacion
{
    public partial class CargarArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCargarAr_Click(object sender, EventArgs e)
        {
            string opcion = this.ddlTipoArchivo.SelectedValue;
            if (fuSubirArchivo.HasFile)
            {
                try
                {
                    string path = Server.MapPath("~/Uploads/");
                    string extArchivo=System.IO.Path.GetExtension(path + fuSubirArchivo.FileName);
                    if (extArchivo.Equals(".xls") || extArchivo.Equals(".xlsx"))
                    {
                        fuSubirArchivo.SaveAs(path + fuSubirArchivo.FileName);
                        switch (opcion)
                        {
                            case "1":
                                new neg().agregarArchivoAsistencia(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                                break;
                            case "2":
                                new neg().agregarArchivoNotas(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                                break;
                            case "3":
                                new neg().agregarArchivoDeuda(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                                break;
                            case "4":
                                new neg().agregarArchivoIndice(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                                break;
                        }
                        //if (opcion.Equals("1"))
                        //{
                        //    new neg().agregarArchivoAsistencia(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                        //}
                        //if (opcion.Equals("2"))
                        //{
                        //    new neg().agregarArchivoNotas(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                        //}
                        //if (opcion.Equals("3"))
                        //{
                        //    new neg().agregarArchivoDeuda(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                        //}
                        //if (opcion.Equals("4"))
                        //{
                        //    new neg().agregarArchivoIndice(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
                        //}
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("El archivo adjunto debe ser en formato Excels, "
                            +"con extension .xls o .xlsx");
                    }
                    
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message+ " " + ex.InnerException);
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Por favor, Ingrese un archivo para continuar");
            }
        }
    }
}