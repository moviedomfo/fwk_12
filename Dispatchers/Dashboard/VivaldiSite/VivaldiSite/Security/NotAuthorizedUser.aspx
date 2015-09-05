<%@ Page Title="" Language="C#" MasterPageFile="~/Health_Master.Master" AutoEventWireup="true" CodeBehind="NotAuthorizedUser.aspx.cs" Inherits="VivaldiSite.Security.NotAuthorizedUser" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
    <div class="EnvelopeCont">
        
        <div class = "grid_8" style="font-size: medium; color: #666666;margin-left:20px;margin-top:10px">
           <div class = "grid_1">
             <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/warning.png" EnableTheming="False"
                EnableViewState="False" Height="50px" Width="44px" />
           </div>
           <div class = "grid_7" style="margin-top:10px">No es un usuario autorizado para realizar
             esta acción. Por favor inicie sesión.-
           </div>
        </div>
        <div class="clearfix"></div>
         <div >
                <asp:Panel ID="panelLogin" runat="server" DefaultButton="Login1$LoginButton">
            <asp:Login ID="Login1" runat="server" Height="199px" Width="85%" FailureText="Su intento de inicio de sesión no se realizó correctamente. Por favor, inténtelo de nuevo."
                LoginButtonText="Iniciar" PasswordRequiredErrorMessage="La password es requerida."
                RememberMeText="Recordar mis datos la próxima vez" UserNameLabelText="Nombre de usuario:"
                UserNameRequiredErrorMessage="El nombre ed usuario es requerido." CssClass="logingcontrol"
                TitleText="Iinicie sesión" LabelStyle-CssClass="loging_label" TitleTextStyle-CssClass="loging_tittle"
                MembershipProvider="Healthsec" 
                DestinationPageUrl="~/Modules/Admin/Admin_ReqAutList.aspx">
                
                <LabelStyle CssClass="loging_label" />
                <LayoutTemplate>
                    <table cellpadding="1" cellspacing="0" class="logingcontrol_tbody" style="margin-left:50px">
                        <tr>
                            <td style="width: 567px">
                                <table cellpadding="0" style="height:100px; width:86%;">
                                    <tr style="height: 67px">
                                        <td align="center" class="loging_tittle" colspan="2">
                                            <br />
                                            Iinicie sesión</td>
                                    </tr>
                                     <tr style="height: 40px">
                                        <td align="right" class="loging_label">
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nombre de usuario:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" Font-Bold="False" CssClass="loging_textbox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                ControlToValidate="UserName" ErrorMessage="El nombre ed usuario es requerido." 
                                                ToolTip="El nombre ed usuario es requerido." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                     <tr style="height: 40px">
                                        <td align="right" class="loging_label">
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" 
                                                TextMode="Password" CssClass="loging_textbox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                ControlToValidate="Password" ErrorMessage="La password es requerida." 
                                                ToolTip="La password es requerida." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                     <tr style="height: 40px">
                                        <td class="login_check" colspan="2">
                                            <asp:CheckBox ID="RememberMe" runat="server" 
                                                Text="Recordar mis datos la próxima vez" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color:Red;">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                         
                                        <td align="left" colspan="1">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" 
                                                CssClass="frm_btGrisNegrita" Text="Iniciar" ValidationGroup="Login1" 
                                                Width="120px" onclick="LoginButton_Click"  />
                                        </td>
                                       <td align="left" colspan="1">
                                         
                                         <a class="nav-link"  href="PasswordResset.aspx">Olvide mi contraseña !!</a>
                                         </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <LoginButtonStyle CssClass="frm_btGrisNegrita" />
                <CheckBoxStyle CssClass="login_check" />
                <TitleTextStyle  CssClass="loging_tittle" />
            </asp:Login>
            <div style="background-color: #FFFFFF">
            </div>
        </asp:Panel>
   </div>
    </div>
</asp:Content>

