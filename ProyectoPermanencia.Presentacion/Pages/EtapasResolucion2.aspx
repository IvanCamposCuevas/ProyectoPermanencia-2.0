<%@ Page Title="Estapas de Resolucion" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EtapasResolucion.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.EtapasResolucion" %>
<asp:Content ID="ContentHeadEtapas" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Etapas de Resolución  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentEtapasResolucion" ContentPlaceHolderID="ContentPlaceHolderEtapasResolucion" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <!-- BUSQUEDA Y FILTROS -->
                <div class="jumbotron modal-content" style="height: 250px; padding: 5px; box-shadow: none; box-sizing: border-box; margin: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
                    <!-- Buscar por rut o nombre -->
                    <div class="row filtrobox input-group" style="height: 100px; padding-left: 20px;">
                        <h4>Buscar Alumno:</h4>
                        <asp:DropDownList ID="ddlRutNom" runat="server" Width="138px" Height="30px" CssClass="form-control">
                            <asp:ListItem Value="1" Text="Rut Alumno">Rut Alumno</asp:ListItem>
                            <asp:ListItem Value="2">Nombre Alumno</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox runat="server" CssClass="”form-control”" Width="115px" Height="30px" ID="txtRutNombre"></asp:TextBox>
                        <asp:Button runat="server" Text="Buscar" ID="btoFiltrar" CssClass="btn btn-info" OnClick="btoFiltrar_Click" />
                    </div>

                    <!-- FILTROS DE BUSQUEDA -->
                    <div class="row" style="height: 90px">
                        <div class="col-sm-2 filtrobox" style="padding-left: 20px; height: 90px">
                            <!-- Filtrar por Sede -->
                            <div id="Sede" class="form-row align-items-center" style="width: 150px;">
                                <h4>Sede: </h4>
                                <asp:DropDownList ID="ddlSede" runat="server" Width="100%" CssClass="form-control ">
                                    <asp:ListItem Value="">Todas</asp:ListItem>
                                    <asp:ListItem Value="3">Antonio Varas</asp:ListItem>
                                    <asp:ListItem Value="4">San Carlos</asp:ListItem>
                                </asp:DropDownList>

                            </div>
                        </div>

                        <div class="col-sm-2 filtrobox" style="padding-left: 20px; height: 90px; top: 0px; left: 0px;">
                            <!-- Filtrar por jornada -->
                            <div id="Jornada" class="form-row align-items-center" style="width: 100%;">
                                <h4>Jornada: </h4>
                                <asp:DropDownList ID="ddlJornada" runat="server" Width="100%" CssClass="form-control">
                                    <asp:ListItem Value="">Ambas</asp:ListItem>
                                    <asp:ListItem Value="D">Diurno</asp:ListItem>
                                    <asp:ListItem Value="V">Vespertino</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-sm-4 filtrobox" style="height: 90px">
                            <!-- Filtrar por escuela -->
                            <div id="Escuela" style="width: 100%; align-self: center;">
                                <h4>Escuela: </h4>
                                <asp:DropDownList ID="ddlEscuelas" Width="100%" runat="server" DataSourceID="sqlEscuela" DataTextField="Desc_Escuela" DataValueField="Id_Escuela" OnSelectedIndexChanged="ddlEscuelas_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true" CssClass="form-control">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="sqlEscuela" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT DISTINCT * FROM [LK_Escuela] ORDER BY [Desc_Escuela]" OnSelected="sqlEscuela_Selected"></asp:SqlDataSource>
                            </div>
                        </div>

                        <div class="col-sm-4 filtrobox" style="margin-left: 0px; padding-left: 0px; height: 90px">
                            <!-- Filtrar por carrera -->
                            <div id="Carrera" style="width: 100%;">
                                <h4>Carrera: </h4>
                                <asp:DropDownList ID="ddlCarrera" Width="100%" runat="server" DataTextField="Desc_Carrera" DataValueField="Desc_Carrera" CssClass="form-control">
                                    <asp:ListItem>--Escoja Una Escuela--</asp:ListItem>
                                </asp:DropDownList>
                                <!--<asp:SqlDataSource ID="sqlCarrera" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2ConnectionString2 %>" SelectCommand="SELECT DISTINCT [Desc_Carrera] FROM [LK_Carrera] ORDER BY [Desc_Carrera]"></asp:SqlDataSource>-->
                            </div>
                        </div>
                        <!-- Filtrar resultados -->
                        <div class="col-md-1" style="float: right; height: 50px;">
                            <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Filtrar" OnClick="LinkButton_Click"></asp:LinkButton>
                        </div>
                    </div>
                </div>


            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>