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

                new Negocio.NegocioFichaAlumno().consultaGeneral(lblRut.Text, out System.Data.DataSet notas,
                    out System.Data.DataSet detalleNotas, out System.Data.DataSet asistencias, out System.Data.DataSet morosos);
                
                grvNotas.DataSource = notas;
                grvNotas.DataBind();
                grvDetalleNotas.DataSource = detalleNotas;
                grvDetalleNotas.DataBind();
                grvAsistencia.DataSource = asistencias;
                grvAsistencia.DataBind();
                grvFinanzas.DataSource = morosos;
                grvFinanzas.DataBind();

                //this.lblTelefono.Text = (string)new Negocio.NegocioFichaAlumno().getTelefono(lblRut.Text).ToString();
                //this.lblTelefono.Text = tele.ToString();
                //this.lblTelefono.Text = tele.Tables[0].Rows[0]["tele"].ToString();
                

            }
        }
    }
}