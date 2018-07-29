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


                ddlTipoCaso.DataSource = new Negocio.NegocioRegistroInteraccion().CargarddlTipoCaso();
                ddlTipoCaso.DataValueField = "Id_TipoCaso";
                ddlTipoCaso.DataTextField = "Desc_TipoCaso";
                ddlTipoCaso.DataBind();

                ddlTipoInteraccion.DataSource = new Negocio.NegocioRegistroInteraccion().CargarddlTipoInteraccion();
                ddlTipoInteraccion.DataValueField = "Id_TipoInteraccion";
                ddlTipoInteraccion.DataTextField = "Desc_TipoInteraccion";
                ddlTipoInteraccion.DataBind();

                ddlCurso.DataSource = new Negocio.NegocioRegistroInteraccion().CargarddlCurso(lblRut.Text);
                ddlCurso.DataValueField = "Id_Asignatura";
                ddlCurso.DataTextField = "CURSO";
                ddlCurso.DataBind();

                ddlCasos.DataSource = new Negocio.NegocioRegistroInteraccion().CargarddlCasos(lblRut.Text);
                ddlCasos.DataValueField = "Id_Caso";
                ddlCasos.DataTextField = "CASO";
                ddlCasos.DataBind();

                ckblParticipan.DataSource = new Negocio.NegocioRegistroInteraccion().cargarckbxParticipante();
                ckblParticipan.DataValueField = "Id_Participante";
                ckblParticipan.DataTextField = "Desc_Participante";
                ckblParticipan.DataBind();

            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string rutalumno = lblRut.Text;
            string idcaso = ddlCasos.SelectedValue.ToString();
            string tipointer = ddlTipoInteraccion.SelectedValue.ToString();
            string idarea = null;
            string comentarios = tbComentarios.Text;
            string participantes = null;

            foreach (ListItem item in ckblParticipan.Items)
            {
                if (item.Selected)
                {
                    participantes += item.Text + ", ";
                }
            }

            if (ddlTipoInteraccion.SelectedItem.Value.Equals("2"))
            {
                idarea = ddlArederiv.SelectedValue.ToString();
                if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(idcaso)) || (!String.IsNullOrEmpty(tipointer)) || (!String.IsNullOrEmpty(idarea)) || (!String.IsNullOrEmpty(comentarios)))
                {
                    new Negocio.NegocioRegistroInteraccion().AgregaInteraccion(rutalumno, idcaso, tipointer, idarea, comentarios, participantes);
                }
            }
            else
            {
                if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(idcaso)) || (!String.IsNullOrEmpty(tipointer)) || (!String.IsNullOrEmpty(comentarios)))
                {
                    new Negocio.NegocioRegistroInteraccion().AgregaInteraccion(rutalumno, idcaso, tipointer, idarea, comentarios, participantes);
                }
            }
            Response.Redirect("/Pages/Interacciones.aspx");
        }

        protected void rbtnExistentes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnExistentes.Checked)
            {
                ddlCasos.Enabled = true;
                ddlTipoCaso.Enabled = false;
                ddlCurso.Enabled = false;
            }
        }

        protected void rbtnNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNuevo.Checked)
            {
                ddlCasos.Enabled = false;
                ddlTipoCaso.Enabled = true;
                ddlCurso.Enabled = true;
            }
        }

        protected void ddlTipoInteraccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoInteraccion.SelectedItem.Value.Equals("2"))
            {
                ddlArederiv.Enabled = true;
            }
            else
            {
                ddlArederiv.Enabled = false;
            }

        }

        protected void ddlTipoCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoCaso.SelectedItem.Value.Equals("2"))
            {
                ddlCurso.Enabled = false;
            }
            else
            {
                ddlCurso.Enabled = true;
            }
        }

        protected void btnCreaCaso_Click(object sender, EventArgs e)
        {
            if (rbtnExistentes.Checked == true)
            {
                //Significa que no está creando ningun caso, hay que poner un mensajito o aviso.
            }
            if (rbtnNuevo.Checked == true)
            {
                string rutalumno = lblRut.Text;
                string tipo = ddlTipoCaso.SelectedValue.ToString();
                string idcurso = null;

                if (ddlTipoCaso.SelectedItem.Value.Equals("2"))
                {
                    if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(tipo)))
                    {
                        new Negocio.NegocioRegistroInteraccion().CreaCaso(rutalumno, tipo, idcurso);
                    }
                }
                else
                {
                    idcurso = ddlCurso.SelectedValue.ToString();
                    if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(tipo)) || (!String.IsNullOrEmpty(idcurso)))
                    {
                        new Negocio.NegocioRegistroInteraccion().CreaCaso(rutalumno, tipo, idcurso);
                    }
                }
                Response.Redirect("/Pages/RegistroInteraccion.aspx");
            }
        }
    }
}