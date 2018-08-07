using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class FichaAlumno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] info = (string[])Session["Info Alumnos"];
                System.Data.DataSet notas = new System.Data.DataSet();
                System.Data.DataSet asistencias = new System.Data.DataSet();
                System.Data.DataSet morosos = new System.Data.DataSet();
                System.Data.DataSet detalleNotas = new System.Data.DataSet();

                new Negocio.NegocioFichaAlumno().consultaGeneral(info[0], out notas, out detalleNotas,
                    out asistencias, out morosos);
                grvAsistencia.DataSource = asistencias;
                grvAsistencia.DataBind();
                grvNotas.DataSource = notas;
                grvNotas.DataBind();
                grvDetalleNotas.DataSource = detalleNotas;
                grvDetalleNotas.DataBind();
                grvFinanzas.DataSource = morosos;
                grvFinanzas.DataBind();
                
                //Master.obtenerLblTipoBeneficio.Text = grvFinanzas.
            }
        }

        protected void grvFinanzas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
        }
    }
}