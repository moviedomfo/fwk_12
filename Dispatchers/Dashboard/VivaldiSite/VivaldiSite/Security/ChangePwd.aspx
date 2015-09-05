<%@ Page Title="" Language="C#" MasterPageFile="~/Health_Admin.Master" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="VivaldiSite.Security.ChangePwd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="panelLogin" runat="server" DefaultButton="">
  <div style="background-color: #FFFFFF" class="EnvelopeCont">
      
      <asp:ChangePassword ID="ChangePassword1" runat="server" Width="656px" 
          ChangePasswordButtonText="Cambiar clave"
          ChangePasswordButtonStyle-CssClass ="btGrisNegrita logind_button"
          CancelButtonStyle-CssClass="btGrisNegrita logind_button" CancelButtonText="Cancelar" 
          ChangePasswordTitleText="Cambio de clave" 
          ConfirmNewPasswordLabelText="Confirme nueva clave:" 
          ConfirmPasswordRequiredErrorMessage="Confirmacion de clave es requerida" 
          NewPasswordLabelText="Nueva clave:" PasswordLabelText="Clave actual:" 
          PasswordRequiredErrorMessage="Su clave es requerida" 
          SuccessText="Su clave se cambió exitosamente" 
          
          ConfirmPasswordCompareErrorMessage="La confirmación de clave debe concidir con la nueva clave" 
          
          ChangePasswordFailureText="Clave incorrecta. Largo mínimo de la clave {0}. Se requieren caracteres no alfanumericos: {1}." 
          CssClass="logingcontrol"
           TitleTextStyle-CssClass ="loging_tittle"
           LabelStyle-CssClass ="loging_label" DisplayUserName="False">
      </asp:ChangePassword>
      
  </div>
 </asp:Panel>
</asp:Content>

