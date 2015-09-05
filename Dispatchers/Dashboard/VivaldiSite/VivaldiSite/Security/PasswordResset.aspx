<%@ Page Title="" Language="C#" MasterPageFile="~/Health_Master.Master" AutoEventWireup="true" CodeBehind="PasswordResset.aspx.cs" Inherits="VivaldiSite.Security.PasswordResset" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCenter" runat="server">

    <asp:Panel CssClass ="logingcontrol" ID="panelLogin" runat="server" DefaultButton="btnAcept">
    <p>
        <br />
    </p>
    <div id="page-title">
        <h2>
            Password Assistance</h2>
    </div>
    <div class="wrapper">
        <div id="global-error">
        </div>
        <div id="main">
            <p class="loging_label">
                <label for="email-requestPasswordReset">
                    Por favor ingrese la direccion de correo electronico con la que se registro cuando
                    creo su cuenta de usuario Health y le enviaremos un correo con su password.
                </label>
            </p>
            <p class="loging_label">
                &nbsp;</p>
        </div>
        <div class="loging_label" style="font-weight: bold">
            E-mail
        </div>
        <div>
            <asp:TextBox ID="txtEmail" runat="server" Width="431px" 
                CssClass="loging_textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                ForeColor="red" Display="Static" ErrorMessage="Requerido" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="El formato de e-mail no es correcto.-" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </div>
    </div>
    <br />
    <br />
    <div>
        <asp:Button ID="btnAcept" runat="server" OnClick="Button1_Click" Text="Enviar dirección"
            CssClass="frm_btGrisNegrita" Width="200px" />
    </div>
    <div class="loging_label">
        <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
    </div>
    </asp:Panel>
</asp:Content>
