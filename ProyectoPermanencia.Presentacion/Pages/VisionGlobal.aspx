<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VisionGlobal.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.VisionGlobal" %>

<asp:Content ID="ContentHeadGlobal" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentGlobal" ContentPlaceHolderID="ContentPlaceHolderGlobal" runat="server">
    <h2>Vision Global</h2>
    <!-- FILTROS DE BUSQUEDA -->
    <hr />
    <div id="Filtros" class="Filtros" style="padding: 10px">
        
        <h3>Filtrar resultados</h3>
        <!-- Filtrar por rut o nombre -->
        <div>
            <asp:DropDownList ID="ddlRutNom" runat="server">
                <asp:ListItem Value="1" Text="Rut Alumno">Rut Alumno</asp:ListItem>
                <asp:ListItem>Nombre Alumno</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox runat="server">
            </asp:TextBox>
            <asp:Button runat="server" Text="Filtrar" />
        </div>
        <!-- Filtrar por jornada -->
        <div>
            <h4>Jornada: </h4>
            <asp:CheckBox runat="server" ID="chkDiurno" Text="Diurno" />
            <br />
            <asp:CheckBox runat="server" ID="chkVespertino" Text="Vespertino" />
        </div>
        <!-- Filtrar por escuela -->
        <div>
            <h4>Escuela: </h4>
            <asp:DropDownList ID="ddlEscuelas" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>

            </asp:DropDownList>
        </div>
        <!-- Filtrar por carrera -->
        <div>
            <h4>Carrera: </h4>
            <asp:DropDownList ID="ddlCarrera" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>
                <asp:ListItem></asp:ListItem>

            </asp:DropDownList>
        </div>

        <br />
        <hr />
    </div>

    <!-- GRILLA PRINCIPAL -->
    <div>
        <div id="ScoreGlobal" class="ScoreGlobal">
            <h2>Scores </h2>
            <asp:GridView ID="grvGlobal" runat="server" AllowPaging="true" AutoGenerateColumns="false" BorderStyle="Solid" GridLines="Both" ShowHeaderWhenEmpty="true" EmptyDataText="No se encontraron registros">
                <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="" HeaderText="ID Alumno" />
                    <asp:BoundField DataField="" HeaderText="Rut" />
                    <asp:BoundField DataField="" HeaderText="Nombre" />
                    <asp:BoundField DataField="" HeaderText="Carrera" />
                    <asp:BoundField DataField="" HeaderText="Escuela" />
                    <asp:BoundField DataField="" HeaderText="Sede" />
                    <asp:BoundField DataField="" HeaderText="Semestre" />
                    <asp:BoundField DataField="" HeaderText="Jornada" />
                    <asp:BoundField DataField="" HeaderText="SCORE" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
