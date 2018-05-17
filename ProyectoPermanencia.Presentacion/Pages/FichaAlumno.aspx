<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FichaAlumno.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.FichaAlumno" %>

<asp:Content ID="ContentHeadFicha" ContentPlaceHolderID="head" runat="server">
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
            <div class="col-sm-3 jumbotron" style="padding: 15px; border-radius:5px;">
                <!-- COLUMNA LATERAL CON INFORMACION DEL ALUMNO -->
                <div>
                    <div>
                        <img src="~/imgs/avatar.png" height="150" runat="server" style="padding-left: 50px; margin: 10px; position: center;" />
                    </div>
                    <div style="padding-left: 25px; padding-top: 0px; margin-top: 0px; position: center;">
                        <h4>Estado de riesgo: </h4>
                        <asp:Label runat="server" ID="Label1"></asp:Label>
                        <div class="progress" style="width: 200px">
                            <div class="progress-bar progress-bar-striped bg-warning" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                            </div>
                        </div>
                    </div>
                <div id="InformacionAlumno" class="SideColumn" style="float: left; align-content: center;">
                    <h4 style="text-align: center">Información Personal</h4>
                    <asp:Label runat="server">Rut:</asp:Label>
                    <asp:Label ID="lblRut" runat="server"></asp:Label>
                    <br />
                    <asp:Label runat="server">Nombre:</asp:Label>
                    <asp:Label runat="server" ID="lblNombre"></asp:Label>
                    <br />
                    <asp:Label runat="server">Carrera:</asp:Label>
                    <asp:Label runat="server" ID="lblCarrera"></asp:Label>
                    <br />
                    <asp:Label runat="server">Escuela:</asp:Label>
                    <asp:Label runat="server" ID="lblEscuela"></asp:Label>
                    <h4 style="text-align: center">Contacto</h4>
                    <br />
                    <asp:Label runat="server">Teléfono:</asp:Label>
                    <asp:Label runat="server" ID="lblTelefono"></asp:Label>
                    <br />
                    <asp:Label runat="server">Mail:</asp:Label>
                    <asp:Label runat="server" ID="lblMail"></asp:Label>
                </div>

                </div>
            </div>
            <div class="Tabs col-md-6" style="float: left;">
                <ul class="nav nav-tabs">
                    <li class="active"><a href="#">Home</a></li>
                    <li><a href="FichaAlumno.aspx">Ficha</a></li>
                    <li><a href="Historico.aspx">Historico</a></li>
                </ul>
                <br>
            </div>
            <div class="col-sm-9">


                <!-- GRILLAS -->
                <div class="row" style="padding-left: 30px">
                    <div id="ScoreNotas" class="ScoreNotas">
                        <h3>Score notas por asignatura </h3>
                        <asp:GridView ID="grvNotas" runat="server" BackColor="#e1e1e1" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros" Width="800px">
                            <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                            <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>

                <div class="row" style="padding-left: 30px">
                    <div id="ScoreAsistencia" class="ScoreAsistencia">
                        <h3>Score asistencia por asignatura </h3>
                        <asp:GridView ID="grvAsistencia" runat="server" BackColor="#e1e1e1" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros" Width="800px">
                            <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                            <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                        </asp:GridView>
                    </div>
                </div>

                <div class="row" style="padding-left: 30px">
                    <div id="ScoreFinanzas" class="ScoreFinanzas">
                        <h3>Score situación financiera </h3>
                        <asp:GridView ID="grvFinanzas" runat="server" AllowPaging="true" AutoGenerateColumns="false" BackColor="#e1e1e1" GridLines="Both" ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron registros" Width="800px">
                            <HeaderStyle BackColor="#f2f2f7" Font-Bold="True" ForeColor="White" />
                            <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            <Columns>
                                <asp:BoundField DataField="" HeaderText="N° Cuota" />
                                <asp:BoundField DataField="" HeaderText="Fecha Vencimiento" />
                                <asp:BoundField DataField="" HeaderText="Tipo de beneficio" />
                                <asp:BoundField DataField="" HeaderText="% de cobertura" />
                                <asp:BoundField DataField="" HeaderText="Estado" />
                                <asp:BoundField DataField="" HeaderText="Saldo" />
                                <asp:BoundField DataField="" HeaderText="SCORE" />
                            </Columns>
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
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />


    </div>

</asp:Content>

