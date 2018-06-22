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
                this.lblNombre.Text = info[1];
                this.lblCarrera.Text = info[2];
                this.lblEscuela.Text = info[3];
                this.lblSede.Text = info[4];
                this.lblTelefono.Text = info[5];
                this.lblMail.Text = info[6];
                new Negocio.NegocioFichaAlumno().consultaGeneral(lblRut.Text, out System.Data.DataSet notas, 
                    out System.Data.DataSet asistencias, out System.Data.DataSet morosos);
                grvAsistencia.DataSource = asistencias;
                grvAsistencia.DataBind();
                grvFinanzas.DataSource = morosos;
                grvFinanzas.DataBind();
                lblBeneficio.Text = morosos.Tables[0].Rows[0].ItemArray[3].ToString();
            }
        }

        protected void grvFinanzas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[3].Visible = false;
        }
    }
}