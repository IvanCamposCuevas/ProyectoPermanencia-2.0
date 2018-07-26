using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class MantenedorSemestre : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlSemestres.DataSource = new Negocio.NegocioMantSemestre().CargarddlSemestres();
            ddlSemestres.DataTextField = "Desc_Semestre";
            ddlSemestres.DataBind();
        }

        protected void btnAgregaSemestre_Click(object sender, EventArgs e)
        {
            string anioActual = String.Format("{0}", DateTime.Now.Year);
            if (txtPeriodo.Text.Equals("1") || txtPeriodo.Text.Equals("2") && txtAnio.Text.Equals(anioActual))
            {
                string semestre = String.Format("{0}-{1}", txtAnio.Text, txtPeriodo.Text);
                new Negocio.NegocioMantSemestre().CreaSemestre(semestre);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Ingrese un valor válido");
            }
            txtAnio.Text = string.Empty;
            txtPeriodo.Text = string.Empty;
            Response.Redirect("/Pages/MantenedorSemestre.aspx");

        }


    }
}