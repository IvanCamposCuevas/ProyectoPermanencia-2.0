<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.Reportes" %>
<asp:Content ID="ContentHeadReportes" ContentPlaceHolderID="head" runat="server">
    <title>Reportes</title>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Reportes  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentReportes" ContentPlaceHolderID="ContentPlaceHolderReportes" runat="server">
    <div class="conteiner">
        <div class="row">
            <div class="col-md-3 jumbotron modal-content" style="margin:10px; margin-left:45px; border-radius:2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow:none;">
                
            </div>
            <div class="col-md-8 jumbotron modal-content" style="border:solid; margin:10px">
                
            </div>
        </div>
    </div>




</asp:Content>
