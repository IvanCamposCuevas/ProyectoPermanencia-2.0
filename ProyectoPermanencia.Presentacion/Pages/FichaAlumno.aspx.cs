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
                System.Data.DataSet scores = new System.Data.DataSet();

                new Negocio.NegocioFichaAlumno().consultaGeneral(info[0], out notas, out detalleNotas,
                    out asistencias, out morosos, out scores);
                grvAsistencia.DataSource = asistencias;
                grvAsistencia.DataBind();
                grvNotas.DataSource = notas;
                grvNotas.DataBind();
                grvDetalleNotas.DataSource = detalleNotas;
                grvDetalleNotas.DataBind();
                grvFinanzas.DataSource = morosos;
                grvFinanzas.DataBind();
                LblScoreFinanzas.Text = scores.Tables[0].Rows[0]["ScoreDeuda"].ToString();
                LblScoreAsistencia.Text = scores.Tables[0].Rows[0]["ScoreAsistencia"].ToString();
                lblScoreNotas.Text = scores.Tables[0].Rows[0]["ScoreNotas"].ToString();
                //info[8] = morosos.Tables[0].Rows[0].ItemArray[3].ToString();
                //Master.obtenerLblTipoBeneficio.Text = info[8];
                Session["Info Alumnos"] = info;
            }
        }

        protected void grvFinanzas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[3].Visible = false;
        }
    }
}