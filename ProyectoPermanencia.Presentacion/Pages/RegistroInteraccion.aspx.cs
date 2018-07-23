using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class RegistroInteraccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] info = (string[])Session["Info Alumnos"];
            this.lblRut.Text = info[0];
            this.lblNombre.Text = info[1];
            this.lblCarrera.Text = info[2];
            this.lblJornada.Text = info[7];
            this.lblEscuela.Text = info[5];
            this.lblSede.Text = info[6];
            this.lblTelefono.Text = info[3];
            this.lblMail.Text = info[4];

            ddlCurso.DataSource = new Negocio.NegocioRegistroInteraccion().cargarddlCurso(lblRut.Text);
            ddlCurso.DataTextField = "CURSO";
            ddlCurso.DataBind();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Interacciones.aspx");
        }

        protected void rbtnExistentes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnExistentes.Checked)
            {
                rbtnNuevo.Enabled = false;
            }
        }



    }
}