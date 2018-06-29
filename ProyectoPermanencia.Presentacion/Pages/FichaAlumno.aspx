<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FichaAlumno.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.FichaAlumno" %>

<asp:Content ID="ContentHeadFicha" ContentPlaceHolderID="head" runat="server">
    <title>Ficha Alumno</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../css/FichaStyleSheet.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure" > Ficha Alumno  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentFicha" ContentPlaceHolderID="ContentPlaceHolderFicha" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-3 jumbotron modal-content" style="padding: 15px; border-radius: 5px; box-shadow: none">
                <!-- COLUMNA LATERAL CON INFORMACION DEL ALUMNO -->
                <div>
                    <div>
                        <img src="~/imgs/avatar.png" height="150" runat="server" style="padding-left: 50px; margin: 10px; position: center;" />
                    </div>
                    <div style="padding-left: 25px; padding-top: 0px; margin-top: 0px; position: center;">
                        <h4>Estado de riesgo: </h4>
                        <div class="progress" style="width: 200px">
                            <div class="progress-bar progress-bar-success progress-bar-striped" role="progressbar" style="width: 30%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                            </div>
                            <!--<div class="progress-bar progress-bar-warning progress-bar-striped" role="progressbar" style="width: 40%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                            </div>
                            <div class="progress-bar progress-bar-danger progress-bar-striped" role="progressbar" style="width: 30%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                            </div>-->
                        </div>
                    </div>
                    <div id="InformacionAlumno" class="SideColumn" style="float: left; align-content: center; padding-left: 20px">
                        <h4 style="text-align: center">Información Personal</h4>
                        <asp:Label runat="server" Font-Bold="true">Rut:</asp:Label>
                        <asp:Label ID="lblRut" runat="server"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Nombre:</asp:Label>
                        <asp:Label runat="server" ID="lblNombre"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Carrera:</asp:Label>
                        <asp:Label runat="server" ID="lblCarrera"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Jornada:</asp:Label>
                        <asp:Label runat="server" ID="lblJornada"></asp:Label>
                        <br />

                        <asp:Label runat="server" Font-Bold="true">Escuela:</asp:Label>
                        <asp:Label runat="server" ID="lblEscuela"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Sede:</asp:Label>
                        <asp:Label runat="server" ID="lblSede"></asp:Label>
                        <br />
                        <br />
                        <h4 style="text-align: center">Situación Financiera</h4>
                        <asp:Label runat="server" Font-Bold="true">Tipo de beneficio:</asp:Label>
                        <asp:Label runat="server" ID="lblBeneficio"></asp:Label>
                        <br />
                        <h4 style="text-align: center">Contacto</h4>
                        <asp:Label runat="server" Font-Bold="true">Teléfono:</asp:Label>
                        <asp:Label runat="server" ID="lblTelefono"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Mail:</asp:Label>
                        <asp:Label runat="server" ID="lblMail"> username@alumnos.duoc.cl</asp:Label>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
            <div class="Tabs col-md-6" style="float: left;">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#">Ficha</a></li>
                    <li><a href="#">Historico</a></li>
                </ul>
                <br>
            </div>


            <div class="col-sm-9">
                <!-- GRILLAS-->
                <div class="row" style="padding-left: 30px">
                    <div id="ScoreNotas" class="ScoreNotas">
                        <h3>Score notas por asignatura </h3>
                        <asp:GridView ID="grvNotas" runat="server" BackColor="#EFF4F8" ShowHeaderWhenEmpty="True"
                            EmptyDataText="No se encontraron registros" Width="800px" OnSelectedIndexChanged="grvNotas_SelectedIndexChanged"
                            CssClass="table table-bordered bs-table table-condensed table-responsive" Font-Size="12px">
                            <HeaderStyle BackColor="#092845" Font-Bold="false" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        </asp:GridView>
                        <!-- POP CLIENT SIDE -->
                        <asp:Button ID="ClientButton" runat="server" Text="Ver Detalle" CssClass="btn btn-info" />
                        <asp:Panel ID="ModalPanel" runat="server" BackColor="White" CssClass="modal-content container-fluid" Width="800px">
                            <div class="row" style="padding:20px; padding-top: 5px;">
                                <h3 style="font-family:'Open Sans',sans-serif">Detalle de notas por asignatura </h3>
                                <div id="DetalleNotas" style="overflow: auto; width: 100%" class="ScoreNotas">
                                    <asp:GridView ID="grvDetalleNotas" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True"
                                        EmptyDataText="No se encontraron registros" Width="800px"
                                        CssClass="table table-bordered bs-table table-condensed table-responsive" Font-Size="12px">
                                        <HeaderStyle BackColor="#092845" Font-Bold="false" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>
                                
                                <asp:Button ID="OKButton" CssClass="btn-info center-block" Height="30px" runat="server" Text="Cerrar" />
                            </div>

                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender ID="mpe" BehaviorID="mpeID" runat="server" TargetControlID="ClientButton"
                            PopupControlID="ModalPanel" OkControlID="OKButton" />
                        <asp:ScriptManager ID="asm" runat="server" />
                        <!-- FIN POP CLIENT-->
                        <!-- POP SERVER SIDE -->
                        <!--<asp:Button ID="ServerButton" runat="server" Text="Ver Detalle (Server)" OnClick="ServerButton_Click" />
                        <script runat="server">
                            protected void ServerButton_Click(object sender, EventArgs e)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "key", "launchModal();", true);
                            }
                        </script>
                        <script type="text/javascript">
                            var launch = false;

                            function launchModal() {
                                launch = true;
                            }

                            function pageLoad() {
                                if (launch) {
                                    $find("mpeID").show();
                                }
                            }
                        </script>
                            -->
                        <!--FIN POP SERVER -->
                    </div>
                </div>

                <div class="row" style="padding-left: 30px">
                    <div id="ScoreAsistencia" class="ScoreAsistencia">
                        <h3>Score asistencia por asignatura </h3>
                        <asp:GridView ID="grvAsistencia" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True"
                            EmptyDataText="No se encontraron registros" Width="800px"
                            CssClass="table table-bordered bs-table table-condensed table-responsive" Font-Size="12px">
                            <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                            <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>

                <div class="row" style="padding-left: 30px">
                    <div id="ScoreFinanzas" class="ScoreFinanzas">
                        <h3>Score situación financiera </h3>
                        <asp:GridView ID="grvFinanzas" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True"
                            EmptyDataText="No se encontraron registros" Width="800px" OnRowDataBound="grvFinanzas_RowDataBound"
                            CssClass="table table-bordered bs-table table-condensed table-responsive" Font-Size="12px">
                            <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                            <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>

            </div>

        </div>
    </div>


    <div>

        <br />
        <br />
        <br />
        <br />

    </div>
</asp:Content>
