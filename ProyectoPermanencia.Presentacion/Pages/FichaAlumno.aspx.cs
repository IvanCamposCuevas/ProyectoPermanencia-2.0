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
                this.lblRut.Text = info[0];
                System.Data.DataSet notas = new System.Data.DataSet();
                System.Data.DataSet asistencias = new System.Data.DataSet();
                System.Data.DataSet morosos = new System.Data.DataSet();
                System.Data.DataSet detalleNotas = new System.Data.DataSet();

                new Negocio.NegocioFichaAlumno().consultaGeneral(lblRut.Text, out notas, out detalleNotas,
                    out asistencias, out morosos);
                grvAsistencia.DataSource = asistencias;
                grvAsistencia.DataBind();
                grvNotas.DataSource = notas;
                grvNotas.DataBind();
                grvDetalleNotas.DataSource = detalleNotas;
                grvDetalleNotas.DataBind();
                grvFinanzas.DataSource = morosos;
                grvFinanzas.DataBind();
                //string[] info_notas = (string[])Session["Info Notas"];
                //grvDetalleNotas.DataSource = new Negocio.NegocioFichaAlumno().consultaDetNotas(info_notas[1], info_notas[0]);
                //grvDetalleNotas.DataBind();
            }
        }

        protected void grvFinanzas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
        }

        protected void grvNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grvNotas.SelectedRow;
            string [] info_notas =  new string[] { row.Cells[1].Text, lblRut.Text };
            Session["Info Notas"] = info_notas;
            Response.Redirect("Historico.aspx");
        }
    }
}