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
                this.lblScore.Text = info[8];
                this.lblRut.Text = info[0];
                this.lblNombre.Text = info[1];
                this.lblCarrera.Text = info[2];
                this.lblJornada.Text = info[7];
                this.lblEscuela.Text = info[5];
                this.lblSede.Text = info[6];
                this.lblTelefono.Text = info[3];
                this.lblMail.Text = info[4];

                Negocio.NegocioFichaAlumno nfa = new Negocio.NegocioFichaAlumno();
                decimal score=Decimal.Parse(info[8]);
                string[] valores = nfa.setBarraProgreso(score);

                barra.Style.Add("width", valores[0]);
                barra.Attributes["class"] = valores[1];
                lblProgreso.Text = valores[2];
                
                
                // if (info[9] != null)
               //{
               //this.lblBeneficio.Text = info[9];
               //}

            }
        }


        public Label obtenerLblTipoBeneficio
        {
            get
            {
                return this.lblBeneficio;
            }
        }

        
    }
}