using System;
using System.Collections.Generic;
using System.Data;
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
                    DataView dv = new Negocio.NegocioResolucion().buscarCasoSinFiltro(ddlTipoBusqueda.SelectedValue, txtIngresoBusqueda.Text).Tables["clientes"].AsDataView();
                    Session["dvGeneral"] = dv;
                    dv.RowFilter = "Estado = 'Pendiente'";
                    grvIntervenciones.DataSource = dv;
                    grvIntervenciones.DataBind();
                }
                else {
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)Session["dvGeneral"];
            dv.RowFilter = "Estado = 'Pendiente'";
            grvIntervenciones.DataSource = dv;
            grvIntervenciones.DataBind();
        }

        protected void btnEnCurso_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)Session["dvGeneral"];
            dv.RowFilter = "Estado = 'En Curso'";
            grvIntervenciones.DataSource = dv;
            grvIntervenciones.DataBind();
        }

        protected void btnFinalizadas_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)Session["dvGeneral"];
            dv.RowFilter = "Estado = 'Finalizadas'";
            grvIntervenciones.DataSource = dv;
            grvIntervenciones.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<string> listaCasos = new List<string>();
            List<string> listaIntervenciones = new List<string>();

            foreach (ListItem item in ckblTipoCaso.Items)
            {
                if (item.Selected == true)
                {
                    listaCasos.Add(item.Text);
                }
            }

            foreach (ListItem item in ckblTipoIntervención.Items)
            {
                if (item.Selected == true)
                {
                    listaIntervenciones.Add(item.Text);
                }
            }

            string fechaInicio = string.Format("{0}", Request.Form["Fecha_Inicio"]);

            string[] arrayFechaInicio = fechaInicio.Split('-');

            string fechaTermino = string.Format("{0}", Request.Form["Fecha_Termino"]);

            string[] arrayFechaTermino = fechaTermino.Split('-');

            DateTime dtFechaInicio = new DateTime() ;

            DateTime dtFechaTermino = new DateTime();

            if (arrayFechaTermino[0] != "" && arrayFechaInicio[0] != "")
            {
                dtFechaInicio = new DateTime(int.Parse(arrayFechaInicio[0]), int.Parse(arrayFechaInicio[1]), int.Parse(arrayFechaInicio[2]));

                dtFechaTermino = new DateTime(int.Parse(arrayFechaTermino[0]), int.Parse(arrayFechaTermino[1]), int.Parse(arrayFechaTermino[2]));
            }

            DataView dv = new Negocio.NegocioResolucion().buscarCasoConFiltro(listaCasos, listaIntervenciones, dtFechaInicio, dtFechaTermino).Tables["clientes"].AsDataView();
            Session["dvGeneral"] = dv;
            dv.RowFilter = "Estado = 'Pendiente'";
            grvIntervenciones.DataSource = dv;
            grvIntervenciones.DataBind();
            
        }
    }
}