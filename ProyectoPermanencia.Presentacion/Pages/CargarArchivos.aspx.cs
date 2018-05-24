using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using neg = ProyectoPermanencia.Negocio.Negocio;
namespace ProyectoPermanencia.Presentacion
{
    public partial class CargarArchivos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCargarAr_Click(object sender, EventArgs e)
        {
            if (fuSubirArchivo.HasFile)
            {
                string path = Server.MapPath("~/Uploads/");
                fuSubirArchivo.SaveAs(path+fuSubirArchivo.FileName);
                new neg().agregarArchivo(fuSubirArchivo.FileName, ddlTipoArchivo.SelectedValue, path);
            }
            else
            {

            }
        }
    }
}