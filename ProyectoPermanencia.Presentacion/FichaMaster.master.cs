using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion
{
    public partial class FichaMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                //string[] info_notas = (string[])Session["Info Notas"];
                //grvDetalleNotas.DataSource = new Negocio.NegocioFichaAlumno().consultaDetNotas(info_notas[1], info_notas[0]);
                //grvDetalleNotas.DataBind();
            }
        }

       

    }
}