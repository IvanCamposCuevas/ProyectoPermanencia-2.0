using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion
{
    public partial class VisionGlobal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    CargarGrilla();
                }
                else
                {
                    //lblMensaje.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                //lblMensaje.Text = "Ocurrio un error inesperado favor contactese con el administrado";
            }
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {

        }

        private void CargarGrilla()
        {
            //var objetoNegocio = new Negocio();
            //grvGlobal.DataSource = objetoNegocio.consultaScore();
            //grvGlobal.DataBind();
        }

    }
}