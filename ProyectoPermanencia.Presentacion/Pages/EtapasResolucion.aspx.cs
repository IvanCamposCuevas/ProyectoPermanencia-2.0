using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class EtapasResolucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarCasoSinFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIngresoBusqueda.Text))
                {
                    grvIntervenciones.DataSource = new Negocio.NegocioResolucion().buscarCasoSinFiltro(ddlTipoBusqueda.SelectedValue, txtIngresoBusqueda.Text);
                    grvIntervenciones.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}