<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CargarArchivos.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.CargarArchivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Cargar Archivos  </h3>
    </asp:Label>
</asp:Content>

<asp:Content ID="ContentCargar" ContentPlaceHolderID="ContentPlaceHolderCargar" runat="server">
    <div class="container">
        <div class="row jumbotron" style="background-color: white; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
            <div class="row container">
                <div class="col-md-3" style="height: 50px;">
                    <h5>Seleccione el tipo de archivo a subir:</h5>
                </div>
                <div class="col-md-3" style="height: 50px;">

                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlTipoArchivo">
                        <asp:ListItem Value="0"> Seleccione </asp:ListItem>
                        <asp:ListItem Value="1"> Asistencia </asp:ListItem>
                        <asp:ListItem Value="2"> Notas </asp:ListItem>
                        <asp:ListItem Value="3"> Situación Financiera </asp:ListItem>
                        <asp:ListItem Value="4"> Indice Alumno </asp:ListItem>
                        <asp:ListItem Value="5"> Deserción </asp:ListItem>

                    </asp:DropDownList>
                </div>
                <div class="col-md-4" style="height: 50px;">
                    <asp:FileUpload runat="server" Width="350px" CssClass="form-control" ID="fuSubirArchivo" accept=".xls , .xlsx" />
                    <br />
                </div>
                <div class="col-md-2" style="height: 50px; padding-left: 60px">
                    <asp:Button ID="btnCargarAr" runat="server" Text="Cargar" CssClass="btn btn-danger" OnClick="btnCargarAr_Click" OnClientClick="return confirm('¿Desea cargar la iformacion dentro del archivo?');"/>
                </div>
            </div>
            <div class="row container" style="margin:20px">
                <br />
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="* Solo se pueden ingresar archivos Excels, con extension .xls o .xlsx"></asp:Label>
            </div>


        </div>
    </div>
</asp:Content>
