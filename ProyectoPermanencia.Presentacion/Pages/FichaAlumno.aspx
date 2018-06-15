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
                            <div class="progress-bar progress-bar-warning progress-bar-striped" role="progressbar" style="width: 40%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                            </div>
                            <div class="progress-bar progress-bar-danger progress-bar-striped" role="progressbar" style="width: 30%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                            </div>
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
                        <asp:Label runat="server" Font-Bold="true">% cobertura:</asp:Label>
                        <asp:Label runat="server" ID="lblPorce"></asp:Label>
                        <h4 style="text-align: center">Contacto</h4>
                        <asp:Label runat="server" Font-Bold="true">Teléfono:</asp:Label>
                        <asp:Label runat="server" ID="lblTelefono"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Mail:</asp:Label>
                        <asp:Label runat="server" ID="lblMail"></asp:Label>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
            <div class="Tabs col-md-6" style="float: left;">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#">Ficha</a></li>
                    <li><a href="Historico.aspx" >Historico</a></li>
                </ul>
                <br>
            </div>


            <div class="col-sm-9">
                <!-- GRILLAS-->
                <div class="row" style="padding-left: 30px">
                    <div id="ScoreNotas" class="ScoreNotas">
                        <h3>Score notas por asignatura </h3>
                        <asp:GridView ID="grvNotas" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros" Width="800px">
                            <HeaderStyle BackColor="#092845" Font-Bold="false" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>

                <div class="row" style="padding-left: 30px">
                    <div id="ScoreAsistencia" class="ScoreAsistencia">
                        <h3>Score asistencia por asignatura </h3>
                        <asp:GridView ID="grvAsistencia" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros" Width="800px">
                            <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                            <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>

                <div class="row" style="padding-left: 30px">
                    <div id="ScoreFinanzas" class="ScoreFinanzas">
                        <h3>Score situación financiera </h3>
                        <asp:GridView ID="grvFinanzas" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros" Width="800px">
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
