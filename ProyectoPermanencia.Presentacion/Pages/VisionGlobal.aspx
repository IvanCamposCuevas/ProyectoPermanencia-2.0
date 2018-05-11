<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VisionGlobal.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.VisionGlobal" %>

<asp:Content ID="ContentHeadGlobal" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="../css/VisionGlobalStyleSheet.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Vision Global  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentGlobal" ContentPlaceHolderID="ContentPlaceHolderGlobal" runat="server">
    <div class="container">
        <!-- TITULOS DE BUSQUEDA -->
        <div class="row">
            <div class="col-md-3">
                <h3>Buscar Alumno por:</h3>
            </div>
            <div class="col-md-3">
                <h3>Filtrar Alumno por:</h3>
            </div>

        </div>

        <!-- FILTROS DE BUSQUEDA -->
        <div class="row">
            <div class="col-md-3 filtrobox"     >
                <!-- Buscar por rut o nombre -->
                <div class="input-group">
                    <asp:DropDownList ID="ddlRutNom" runat="server" Width="120px">
                        <asp:ListItem Value="1" Text="Rut Alumno">Rut Alumno</asp:ListItem>
                        <asp:ListItem>Nombre Alumno</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox runat="server" CssClass="”form-control”" Width="115px" ID="txtRut"></asp:TextBox>
                    <asp:Button runat="server" Text="Buscar" ID="btoFiltrar" CssClass="btn btn-info" OnClick="btoFiltrar_Click1" />
                </div>
            </div>

            <div class="col-md-8">
                <div class="col-md-4 filtrobox" >
                    <!-- Filtrar por jornada -->
                    <div id="Jornada" class="form-row align-items-center" style="width: 100px;">
                        <h3>Jornada: </h3>
                        <asp:DropDownList ID="ddlJornada" runat="server" Width="120px">
                            <asp:ListItem Value="">Ambas</asp:ListItem>
                            <asp:ListItem Value="D">Diurno</asp:ListItem>
                            <asp:ListItem Value="V">Vespertino</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                </div>

                <div class="col-md-4 filtrobox" >
                    <!-- Filtrar por escuela -->
                    <div id="Escuela" style="width: 100px; align-self: center;">
                        <h3>Escuela: </h3>
                        <asp:DropDownList ID="ddlEscuelas" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-md-4 filtrobox" >
                    <!-- Filtrar por carrera -->
                    <div id="Carrera" style="width: 100px; float: none;">
                        <h3>Carrera: </h3>
                        <asp:DropDownList ID="ddlCarrera" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <!-- Filtrar resultados -->
                <div style="float: right">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Filtrar"></asp:LinkButton>
                    <br />
                    <br />
                </div>

            </div>
        </div>
        <hr />
        <!-- GRILLA PRINCIPAL -->
        <div class="row">           
            <div >
                <div id="ScoreGlobal" class="ScoreGlobal">
                    <h2>Scores </h2>
                    <asp:GridView ID="grvGlobal" CssClass="col-md-12 table table-bordered bs-table table-hover" runat="server" BorderStyle="Solid" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros" OnSelectedIndexChanged="grvGlobal_SelectedIndexChanged" Width="1200px">
                        <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ItemStyle-Width="200px" ItemStyle-Wrap="true" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
       




    </div>

</asp:Content>
