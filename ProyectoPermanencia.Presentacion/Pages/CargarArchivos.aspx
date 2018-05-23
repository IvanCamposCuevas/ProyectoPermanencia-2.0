<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CargarArchivos.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.CargarArchivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Cargar Archivos  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFicha" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolderGlobal" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderHistorico" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderCargar" runat="server">
    <div class="container">
        <div class="row jumbotron">
            <div class="col-md-4" style="height:50px; padding-top:10px">
                <h4>Tipo de archivo a subir:</h4>
            </div>
            <div class="col-md-4" style="height:50px">
                <br />
                <asp:DropDownList runat="server" ID="ddlTipoArchivo">
                    <asp:ListItem Value="1"> Hoja de Asistencia </asp:ListItem>
                    <asp:ListItem Value="2"> Hoja de Notas </asp:ListItem>
                    <asp:ListItem Value="3"> Hoja de Finanzas </asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-md-4" style="height:50px">
                <br />
                <asp:FileUpload runat="server" ID="fuSubirArchivo" accept=".xls , .xlsx"/>
                <br />
                <asp:Button ID="btnCargarAr" runat="server" Text="Cargar" CssClass="btn btn-danger" OnClick="btnCargarAr_Click"/>
            </div>
        </div>

    </div>


</asp:Content>
