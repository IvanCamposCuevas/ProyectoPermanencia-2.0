<%@ Page Title="Cambiar Semestre Actual" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MantenedorSemestre.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.MantenedorSemestre" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h4 style="color:azure"> Cambio de Semestre </h4>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContenteMantenedorSemestre" ContentPlaceHolderID="ContentPlaceHolderMantenedorSemestre" runat="server">
    <div class="container">
        <div class="row jumbotron" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px; margin-bottom: 0px;">
            <div class=" col-md-12 card card-primary" style="margin: 0px">
                <div class="row card-header" style="background-color: rgb(1,40,69); color: white">Cambiar semestre actual</div>
                <div class="row card-body">
                    <div class="col-md-4" >
                        <div>
                            <h6>1. Crear Nuevo Semestre</h6>
                            <br />
                            <div class="row">
                                <div class="col-md-1">
                                    <label>Año:</label>
                                </div>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control form-control-sm" Width="100px"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="justify-content:flex-end">
                                    <label>Período:</label>
                                </div>
                                <div class="col-md-4" style="padding-left:40px" >
                                    <asp:TextBox ID="txtPeriodo" runat="server"  CssClass="form-control form-control-sm" Width="100px"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <br />
                        <div class="row d-flex justify-content-center" style="padding-left:150px">
                            <asp:Button ID="btnAgregaSemestre"  runat="server" CssClass="btn btn-sm btn-info" Text="Agregar Semestre" OnClick="btnAgregaSemestre_Click" />
                        </div>
                    </div>
                    <div class="col-md-1"></div>
                    <div class="col-md-4">
                        <div>
                            <h6>2. Seleccionar Semestre</h6>
                            <br />
                            <asp:DropDownList ID="ddlSemestres" runat="server" CssClass="form-control form-control-sm" Width="150px">
                                <asp:ListItem> Seleccione:  </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-m-d3">
                        <br />
                        <br />
                        <asp:Button ID="btnActualizaSemestre" runat="server" CssClass="btn btn-success" Text="Actualizar Semestre" />
                    </div>

                </div>
            </div>

        </div>

    </div>

</asp:Content>
