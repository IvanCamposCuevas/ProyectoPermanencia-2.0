<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FichaAlumno.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.FichaAlumno" %>

<asp:Content ID="ContentHeadFicha" ContentPlaceHolderID="head" runat="server">
    <!-- <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script> -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../css/FichaStyleSheet.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="ContentFicha" ContentPlaceHolderID="ContentPlaceHolderFicha" runat="server">
    <div id="BodyFicha" class="BodyFicha" runat="server">
        <!-- TABS DE NAVEGACION ENTRE GRILLAS E HISTORICO
        <div class="Tabs">
            <h3>Tabs</h3>
            <ul class="nav nav-tabs" >
                <li class="active"><a href="#">Home</a></li>
                <li><a href="FichaAlumno.aspx">Ficha</a></li>
                <li><a href="Historico.aspx">Historico</a></li>
            </ul>
            <br>
        </div>
        -->

        <!-- COLUMNA LATERAL CON INFORMACION DEL ALUMNO -->
        <div>
            <div id="InformacionAlumno" class="SideColumn" style="border: 2px solid rgb(9,40,69); width:200px; float:left; align-content:center; padding: 20px;" >
                <h3 style="text-align:center">Información Personal</h3>
                <asp:Label runat="server">Rut:</asp:Label>
                <asp:Label ID="txtRut" runat="server"> </asp:Label>
        <br />
                <asp:Label runat="server">Nombre:</asp:Label>
                <asp:Label runat="server"> </asp:Label>
        <br />
                <asp:Label runat="server">Carrera:</asp:Label>
                <asp:Label runat="server"> </asp:Label>
        <br />
                <asp:Label runat="server">Escuela:</asp:Label>
                <asp:Label runat="server"> </asp:Label>
        <h3 style="text-align:center">Contacto</h3>
                <br />
                <asp:Label runat="server">Teléfono:</asp:Label>
                <asp:Label runat="server"> </asp:Label>
        <br />
                <asp:Label runat="server">Mail:</asp:Label>
                <asp:Label runat="server"> </asp:Label>
            </div>

        </div>

        <!-- COLUMNA PRINCIPAL CON GRILLAS DE SCORE -->
        <div>
            <div id="Grillas" runat="server" class="row" 
                style="border: 1px solid rgb(9,40,69); background-color: azure; width:850px; float:right">
                <div >
                    <div id="ScoreNotas" class="ScoreNotas">
                        <h2>Score notas por asignatura </h2>
                        <asp:GridView ID="grvNotas" runat="server" CssClass="ScoreNotas" AllowPaging="true" 
                            AutoGenerateColumns="false" BorderStyle="Solid" BorderWidth="3px" GridLines="Both" ShowHeaderWhenEmpty="true" 
                            EmptyDataText="No se encontraron registros">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="" HeaderText="ID Asignatura" />
                                <asp:BoundField DataField="" HeaderText="Nombre asignatura" />
                                <asp:BoundField DataField="" HeaderText="Notas" />
                                <asp:BoundField DataField="" HeaderText="Promedio" />
                                <asp:BoundField DataField="" HeaderText="SCORE" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div id="ScoreAsistencia" class="ScoreAsistencia">
                        <h2>Score asistencia por asignatura </h2>
                        <asp:GridView ID="grvAsistencia" runat="server" AllowPaging="true" AutoGenerateColumns="false" BorderStyle="Solid" GridLines="Both" ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron registros">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:BoundField DataField="" HeaderText="ID Asignatura" />
                                <asp:BoundField DataField="" HeaderText="Nombre asignatura" />
                                <asp:BoundField DataField="" HeaderText="N° de clases registradas" />
                                <asp:BoundField DataField="" HeaderText="N° de clases asitidas" />
                                <asp:BoundField DataField="" HeaderText="% actual de asistencia" />
                                <asp:BoundField DataField="" HeaderText="SCORE" />
                            </Columns>
                        </asp:GridView>
                    </div>

                    <div id="ScoreFinanzas" class="ScoreFinanzas">
                        <h2>Score situación financiera </h2>
                        <asp:GridView ID="grvFinanzas" runat="server" AllowPaging="true" AutoGenerateColumns="false" BorderStyle="Solid" GridLines="Both" ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron registros">
                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
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
        <br />EL FOOTER NO SE QUEDA AQUI ABAJO SIN LOS SALTOS DE LINEAAAAAAA SACARRAAAAAAA
        <br />
        <br />

    </div>
</asp:Content>

