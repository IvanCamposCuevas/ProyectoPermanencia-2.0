<%@ Page Title="Cambiar Semestre Actual" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MantenedorSemestre.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.MantenedorSemestre" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Cambio de Semestre
        </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContenteMantenedorSemestre" ContentPlaceHolderID="ContentPlaceHolderMantenedorSemestre" runat="server">
    <div class="container">
        <div class="row jumbotron" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px; margin-bottom: 0px;">
            <div class="panel panel-primary" style="margin: 0px">
                <div class="panel-heading" style="background-color: rgb(1,40,69);">Información del Alumno</div>

            </div>
        </div>
    </div>
</asp:Content>
