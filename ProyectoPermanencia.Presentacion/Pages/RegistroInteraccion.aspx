<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="RegistroInteraccion.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.RegistroInteraccion" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Registrar Interacción </h3>
    </asp:Label>
</asp:Content>
<asp:Content runat="server" ID="ContentRegistroInter" ContentPlaceHolderID="ContentPlaceHolderRegistroInter">
    <div class="container">
        <div class="row jumbotron" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px; margin-bottom: 0px;">
            <div class="card card-primary container" >
                <div class="card-header" style="background-color: rgb(1,40,69); color:white; ">Información del Alumno</div>
                <div class="row card-body" style="padding-left=100px">
                        <div class="col-md-4">
                            <asp:Label runat="server" Font-Bold="true">Rut:</asp:Label>
                            <asp:Label ID="lblRut" runat="server"></asp:Label>

                            <br />
                            <asp:Label runat="server" Font-Bold="true">Nombre:</asp:Label>
                            <asp:Label ID="lblNombre" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Carrera:</asp:Label>
                            <asp:Label ID="lblCarrera" runat="server"></asp:Label>
                            <br />
                        </div>
                        <div class="col-md-5">
                            <asp:Label runat="server" Font-Bold="true">Escuela:</asp:Label>
                            <asp:Label ID="lblEscuela" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Jornada:</asp:Label>
                            <asp:Label ID="lblJornada" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Sede:</asp:Label>
                            <asp:Label ID="lblSede" runat="server"></asp:Label>
                            <br />
                        </div>
                        <div class="col-md-3" style="border-left-style: solid; border-left-width: 1; border-left-color: rgb(7, 47, 115);">
                            <asp:Label runat="server" Font-Bold="true">_  Contacto</asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Telefono:</asp:Label>
                            <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Correo:</asp:Label>
                            <asp:Label ID="lblMail" runat="server"></asp:Label>
                            <br />
                        </div>

                    </div>
                
            </div>
        </div>

        <div class="row jumbotron" style="margin-top: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px;">
            <div class="col-md-4 panel-group" style="padding-left: 0px;">
                <div class="card card-primary">
                    <div class="card-header" style="background-color: rgb(1,40,69); color: white;">A qué caso corresponde?</div>
                    <div class="card-body">
                        <div class="row" style="align-content: center; margin-bottom: 20px;">
                            <div class="col-md-4">
                                <asp:RadioButton runat="server" ID="rbtnExistentes" Text="Existente " CssClass="radio-inline" />
                            </div>
                            <div class="col-md-8">
                                <asp:DropDownList runat="server" ID="ddlCasos" CssClass="form-control">
                                    <asp:ListItem>Seleccione</asp:ListItem>
                                    <asp:ListItem>03-Finanzas-info-info</asp:ListItem>
                                    <asp:ListItem>05-Asistencia-info-info</asp:ListItem>

                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" style="align-content: center; margin-bottom: 0px;">
                            <div class="col-md-6">
                                <asp:RadioButton runat="server" ID="rbtnNuevo" Text="Nuevo Caso" CssClass="radio-inline" />
                            </div>
                        </div>
                        <div class="row" style="align-content: flex-end; margin-bottom: 20px;">
                            <div class="col-md-4" style="align-content: center; text-align: end;">
                                <div class="row" style="margin-top: 10px; padding-left:40px;">
                                    <asp:Label runat="server" ID="lblTipoCaso" Text="Tipo: " />
                                </div>
                            </div>
                            <div class="col-md-7" style="padding-right: 0px; justify-content: flex-end;">
                                <asp:DropDownList runat="server" ID="ddlTipoCaso" CssClass="form-control">
                                    <asp:ListItem>Seleccione</asp:ListItem>
                                    <asp:ListItem>Asistencia</asp:ListItem>
                                    <asp:ListItem>Financiamiento</asp:ListItem>
                                    <asp:ListItem>Notas</asp:ListItem>
                                    <asp:ListItem>Otro</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row" style="align-content: flex-end;">
                            <div class="col-md-4" style="align-content: center; text-align: end;">
                                <div class="row" style="padding-left:40px">
                                    <asp:Label runat="server" ID="lblCurso" Text="Curso: " />
                                </div>
                            </div>
                            <div class="col-md-7" style="padding-right: 0px; justify-content: flex-end;">
                                <asp:DropDownList runat="server" ID="ddlCurso" CssClass="form-control">
                                    <asp:ListItem>Seleccione</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row d-flex justify-content-center" style="margin-top: 30px;">
                            <asp:Button runat="server"  ID="btnAgregarInter" CssClass="btn btn-warning center-block" Text="Agregar Intervención " />
                        </div>
                    </div>
                </div>

            </div>
            <div class="col-md-8 panel-group" style="padding-right: 0px">
                <div class="card card-primary">
                    <div class="card-header" style="background-color: rgb(1,40,69); color:white;">Interacción</div>
                    <div class="card-body">
                        <div class="row center-block">
                            <div class="col-md-4" style="margin-left: 20px;">
                                <asp:Label runat="server" Font-Bold="true">Tipo de Intervención :</asp:Label>
                                <div class="dropdown dropdown-toggle" style="width: 70%;">
                                    <asp:DropDownList runat="server" ID="ddlTipoIntervencion" CssClass="form-control">
                                        <asp:ListItem>Seleccione</asp:ListItem>
                                        <asp:ListItem>Correo</asp:ListItem>
                                        <asp:ListItem>Derivación</asp:ListItem>
                                        <asp:ListItem>Presencial</asp:ListItem>
                                        <asp:ListItem>Telefono</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:Label runat="server" Font-Bold="true">Participa(n) :</asp:Label>
                                <asp:CheckBoxList runat="server" ID="ckblParticipan"
                                    CssClass="checkbox">
                                    <asp:ListItem>Alumno</asp:ListItem>
                                    <asp:ListItem>Coordinador</asp:ListItem>
                                    <asp:ListItem>Director</asp:ListItem>
                                    <asp:ListItem>Docente</asp:ListItem>
                                    <asp:ListItem>--Cargo_n--</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                            <div class="col-md-4">
                                <asp:Label runat="server" Font-Bold="true">Área de derivación :</asp:Label>
                                <div class="dropdown dropdown-toggle" style="width: 90%;">
                                    <asp:DropDownList runat="server" ID="ddlArederiv" CssClass="form-control">
                                        <asp:ListItem>Seleccione</asp:ListItem>
                                        <asp:ListItem>Asuntos Estudiantiles</asp:ListItem>
                                        <asp:ListItem>CETIR</asp:ListItem>
                                        <asp:ListItem>Secretaría Académica</asp:ListItem>
                                        <asp:ListItem>Finanzas</asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row center-block" style="margin-top: 20px;">
                            <div class="col-md-11 center-block" style="margin-left: 20px;">
                                <asp:Label runat="server" Font-Bold="true">Comentarios:</asp:Label>
                                <asp:TextBox runat="server" ID="tbComentarios" CssClass="form-control" Rows="6" MaxLength="1000" Height="100px" TextMode="MultiLine"></asp:TextBox>

                            </div>
                        </div>
                        <div class="row center-block" style="margin-top: 30px;">
                            <div class="col-md-6 center-block" style="margin-left: 20px;">
                                <asp:Label runat="server" Font-Bold="true">Fecha:</asp:Label></br>
                                <input type="date" id="fecha" class="glyphicon-calendar" />
                            </div>
                            <div class="col-md-5 center-block">
                                <asp:Label runat="server" Font-Bold="true">Subir archivo:</asp:Label>
                                <asp:FileUpload runat="server" ID="flInteraccion" />
                            </div>

                        </div>
                        <div class="row d-flex justify-content-center" style="margin-top: 30px;">
                            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" CssClass="btn btn-success center-block" OnClick="btnGuardar_Click" />
                        </div>
                    </div>
                </div>
            </div>

        </div>



    </div>

</asp:Content>
