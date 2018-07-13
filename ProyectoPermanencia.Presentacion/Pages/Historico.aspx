<%@ Page Title="" Language="C#" MasterPageFile="~/FichaMaster.master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.Historico" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Historia Académica  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentHistorico" ContentPlaceHolderID="ContentPlaceHolderHistorico" runat="server">
    <div class="Tabs col-md-6" style="float: left;">
        <ul class="nav nav-tabs">
            <li><a href="/Pages/FichaAlumno.aspx">Ficha</a></li>
            <li class="active"><a href="/Pages/Historico.aspx">Historico</a></li>
            <li><a href="/Pages/Interacciones.aspx">Interacciónes</a></li>

        </ul>
        <br>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-sm-9">
                <!-- Información Histórico-->

                <h4>Registros historicos de asistencia, notas y finanzas.</h4>
            </div>

        </div>
    </div>

</asp:Content>
