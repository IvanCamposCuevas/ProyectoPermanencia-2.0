<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="VisionGlobal.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.VisionGlobal" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Visión Global  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentGlobal" ContentPlaceHolderID="ContentPlaceHolderGlobal" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <!-- BUSQUEDA Y FILTROS -->
                    <div class="jumbotron modal-content col-md-4" style="height: 150px; padding: 5px; box-shadow: none; box-sizing: border-box; margin: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
                        <!-- Buscar por rut o nombre -->
                        <div class="row filtrobox input-group" style="height: 100px; padding: 20px; ">
                            <div class="row container">
                                <h5>Buscar Alumno:</h5>
                                <br />
                            </div>
                            <div class="row container">
                                <asp:DropDownList ID="ddlRutNom" runat="server" Width="130px" CssClass="form-control form-control-sm">
                                    <asp:ListItem Value="1" Text="Rut Alumno">Rut Alumno</asp:ListItem>
                                    <asp:ListItem Value="2">Nombre Alumno</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox runat="server" CssClass="form-control" Width="115px" Height="30px" ID="txtRutNombre"></asp:TextBox>
                                <asp:Button runat="server" Text="Buscar" ID="btoFiltrar" CssClass="btn btn-info btn-sm " OnClick="btoFiltrar_Click" />
                            </div>
                        </div>
                    </div>
                    <div class="jumbotron modal-content col-md-8" style="height: 150px; padding: 5px; box-shadow: none; box-sizing: border-box; margin: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
                        <!-- FILTROS DE BUSQUEDA -->
                        <div class="row filtrobox input-group" style="height: 100px; padding: 20px; ">
                            <!-- Filtrar por Sede -->
                            <div ID="Sede" class="col-md-3" style="padding-left: 20px; ">
                                <div class="form row align-items-center">
                                    <h5>Sede: </h5>
                                </div>
                                <div>
                                    <asp:DropDownList ID="ddlSede" runat="server" Width="130px" CssClass="form-control form-control-sm ">
                                        <asp:ListItem Value="">Todas</asp:ListItem>
                                        <asp:ListItem Value="3">Antonio Varas</asp:ListItem>
                                        <asp:ListItem Value="4">San Carlos</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div ID="Jornada" class="col-md-3" style="padding-left: 20px;">
                                <div class="form row align-items-center">
                                    <h5>Jornada: </h5>
                                </div>
                                <div>
                                    <asp:DropDownList ID="ddlJornada" runat="server" Width="130px" CssClass="form-control form-control-sm">
                                        <asp:ListItem Value="">Ambas</asp:ListItem>
                                        <asp:ListItem Value="D">Diurno</asp:ListItem>
                                        <asp:ListItem Value="V">Vespertino</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            

                            <asp:Button ID="btnBuscarCarreras" runat="server" Text="Seleccionar Escuela" Font-Size="Small" CssClass="btn btn-info" />
                            <asp:Panel ID="Panel1" runat="server" BackColor="White" CssClass="modal-content container-fluid" Width="800px">
                                <div class="col-sm-4 filtrobox" style="height: 90px">
                                    <!-- Filtrar por escuela -->
                                    <div id="Escuela" style="width: 100px; align-self: center;">
                                        <h5>Escuela: </h5>
                                        <asp:DropDownList ID="ddlEscuelas" runat="server" DataSourceID="sqlEscuela" DataTextField="Desc_Escuela" DataValueField="Id_Escuela" OnSelectedIndexChanged="ddlEscuelas_SelectedIndexChanged" AutoPostBack="True" AppendDataBoundItems="true">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="sqlEscuela" runat="server" ConnectionString="<%$ ConnectionStrings:Permanencia_2_Conexion-Ivan %>" SelectCommand="SELECT DISTINCT * FROM [LK_Escuela] ORDER BY [Desc_Escuela]" OnSelected="sqlEscuela_Selected"></asp:SqlDataSource>
                                    </div>
                                </div>
                                <div id="Carrera">
                                    <asp:CheckBoxList ID="chkListaCarreras" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                                <asp:Button ID="OKButton" CssClass="btn-info center-block" Height="30px" runat="server" Text="Cerrar" />
                            </asp:Panel>
                            <ajaxToolkit:ModalPopupExtender ID="mpe" BehaviorID="mpeID" runat="server" TargetControlID="btnBuscarCarreras"
                                PopupControlID="Panel1" OkControlID="OKButton" />
                            <!-- Filtrar resultados -->
                            <div class="col-md-1" style="float: right; height: 50px;">
                                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-warning" Text="Filtrar" OnClick="LinkButton_Click"></asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>


                <h3>Scores</h3>
                <div class="row container-fluid" style="margin: 0px">
                    <div id="ScoreGlobal" class="ScoreGlobal">
                        <asp:GridView ID="grvGlobal" CssClass="col-md-12 table table-sm table-bordered bs-table table-hover table-responsive"
                            Font-Size="12px" runat="server" BorderStyle="Solid" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros" 
                            OnSelectedIndexChanged="grvGlobal_SelectedIndexChanged" Width="100%" OnRowDataBound="grvGlobal_RowDataBound">
                            <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" ItemStyle-Width="200px" ItemStyle-Wrap="true" ButtonType="Button" ControlStyle-CssClass="btn btn-info btn-sm" SelectText="Ver detalle">
                                    <ItemStyle Wrap="True" Width="100px"></ItemStyle>
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
                <!-- GRILLA PRINCIPAL -->

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
