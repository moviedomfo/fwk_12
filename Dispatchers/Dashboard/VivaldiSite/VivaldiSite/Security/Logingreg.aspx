<%@ Page Title="" Language="C#" MasterPageFile="~/Health_Master.Master" AutoEventWireup="true" CodeBehind="Logingreg.aspx.cs" Inherits="VivaldiSite.Security.Logingreg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCenter" runat="server">
       <div class="loging_label">
             <asp:Label id="Msg" ForeColor="maroon" runat="server" /><br />
             Bienvenido al sitio de Health usted es la primera vez que ingresa como usuario registrado. Esta informacion se le solicitara por unica vez y 
             es para su propia seguridad. En adelante su inicio de sesion sera por medio de usuario y clave .-
             </div>
        <asp:Panel ID="panelLogin" runat="server" DefaultButton="LoginButton">
           
                    <table cellpadding="1" cellspacing="0" class="logingcontrol_tbody" style="margin-left:50px">
                        <tr>
                            <td style="width: 567px">
                                <table cellpadding="0" style="height:100px; width:86%;">
                                    <tr style="height: 67px">
                                        <td align="center" class="loging_tittle" colspan="2">
                                            <br />
                                            Registro de usuario</td>
                                    </tr>
                                     <tr style="height: 40px">
                                        <td align="right" class="loging_label">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" Font-Bold="False" Font-Size="11pt"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                ControlToValidate="UserName" ErrorMessage="El nombre ed usuario es requerido." 
                                                ToolTip="El nombre ed usuario es requerido." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                     <tr style="height: 40px">
                                        <td align="right" class="loging_label">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Codigo">Codigo:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Codigo" runat="server" Font-Bold="False" Font-Size="11pt" 
                                                TextMode="SingleLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                ControlToValidate="Codigo" ErrorMessage="El codigo de registro es requerida." 
                                                ToolTip="La password es requerida." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                     <tr style="height: 40px">
                                        <td class="login_check" colspan="2">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                         
                                        <td align="left" colspan="1">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" 
                                                CssClass="frm_btGrisNegrita" Text="Aceptar" ValidationGroup="Login1" 
                                                Width="120px" onclick="LoginButton_Click"  />
                                        </td>
                                      
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
               
            <div style="background-color: #FFFFFF">
            </div>
        </asp:Panel>
    
</asp:Content>

