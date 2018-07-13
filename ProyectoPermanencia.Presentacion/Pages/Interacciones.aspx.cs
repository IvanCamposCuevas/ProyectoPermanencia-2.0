using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class Interacciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNuevaInteraccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/RegistroInteraccion.aspx");
        }
    }
}