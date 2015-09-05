<%@ Page Title="" Language="C#" MasterPageFile="~/Site2c.Master" AutoEventWireup="true"
    CodeBehind="ErrorMessageViewer.aspx.cs" Inherits="VivaldiSite.ErrorMessageViewer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCenter" runat="server">
    

    

    
    <table width="100%">
        <tr>
            <td align="left" valign="bottom" style="padding-left: 15px; font-size: 17px; font-weight: bold;
                color: #676A6C;">
                <asp:Label ID="lblTitlePageError" runat="server" Text="Manejo de errores" />
            </td>
            
        </tr>
        <tr>
            <td colspan="2" align="center">
                <hr style="border-style: solid; border-width: 1px; border-color: #A8A8A8; width: 99%;" />
            </td>
        </tr>
        <tr>
            <td style="width: 258px; padding-left: 22px; font-weight: bold; color: #676A6C;"
                colspan="2">
                <asp:Label runat="server" Text="Error " Font-Size="15px" ID="lblErrorTitle" />
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td align="right" style="width: 62px" valign="top">
                <asp:Image ID="imgErrorInfo" ImageUrl="~/Images/iconError.png" runat="server" />
            </td>
            <td align="left" valign="top">
                <table style="width: 100%; padding-left: 20px;" cellpadding="0px" cellspacing="0px">
                    <tr>
                        <td>
                            <asp:Label runat="server" Font-Size="12px" Text="Información:" Width="80%" Height="100%"
                                ID="lblErrorInfo" Font-Bold="true" ForeColor="#676A6C" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px">
                            <asp:Label runat="server" Font-Size="11px" 
                                Text="Error message there" Width="80%" Height="100%" Font-Bold="true" ID="lblErrorMessage"
                                ForeColor="#676A6C" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            
                            <asp:Label runat="server" Font-Size="10px" Text="Detalle:" Width="80%" Height="100%"
                                ID="lblErrorDetails" ForeColor="#A8A8A8" />
                        </td>
                    </tr>
                    <tr>
                        <td style="padding-left: 10px">
                            <asp:Label runat="server"  Font-Size="9px"
                                Text="Stack error message there" Width="80%" Height="100%" ID="lblErrorStack"
                                ForeColor="#A8A8A8" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
