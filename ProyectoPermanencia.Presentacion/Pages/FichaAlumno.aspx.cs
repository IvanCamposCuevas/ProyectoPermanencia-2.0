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
                this.lblRut.Text = Request.QueryString[0];
                this.lblNombre.Text = Request.QueryString[1];
                this.lblCarrera.Text = Request.QueryString[2];
                this.lblEscuela.Text = Request.QueryString[3];
                grvAsistencia.DataSource = new Negocio.Negocio().consultaAsignatura(lblRut.Text);
                grvAsistencia.DataBind();
            }

        }
    }
}