<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="disp_main_services.aspx.cs" Inherits="VivaldiSite.disp_main_services" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
    <div class="article_wrap">
        <div style="margin-top: 10px; margin-bottom: 5px; height: 50px">
            <div class="grid_4 frm_label_2">
                Dispatcher
            </div>
            <div class="grid_8">
                <asp:TextBox ID="txtInstanceName" runat="server" Font-Bold="True" TabIndex="1" TextMode="SingleLine"
                    Width="300" Height="25px" Enabled="false" CssClass="frm_fieldvalue" />
            </div>
        </div>
        <div style="margin-top: 10px; margin-bottom: 5px; height: 50px">
            <div class="grid_4 frm_label_2">
                Server Name
            </div>
            <div>
                <asp:TextBox ID="txtServerName" runat="server" Enabled="false" Font-Bold="True" TabIndex="3"
                    TextMode="SingleLine" Width="300" Height="25px" CssClass="frm_fieldvalue" />
            </div>
        </div>
        <div style="margin-top: 10px; margin-bottom: 5px; height: 50px">
            <div id="divUrlWebservice" style="display: block;">
                <div class="grid_4 frm_label_2">
                    Url Web service
                </div>
                <div class="grid_8">
                    <asp:Label ID="txtUrl" runat="server" Height="23px" Width="453px" TabIndex="10" CssClass="loging_textbox frm_fieldvalue"></asp:Label>
                </div>
            </div>
        </div>
        <div class="frm_row" style="margin-top: 10px; margin-left: 5px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pHeader" runat="server" CssClass="cpHeaderExpand">
                        <asp:Label ID="Label4" runat="server" Text="Ocurrio un error al conctarce al dispatcher"
                            ForeColor="#CC0066" />
                    </asp:Panel>
                    <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                        <div id="divError">
                            <div class="frm-error-message">
                                <asp:Label ID="msgError" CssClass="" Height="40" Width="600" Visible="true" ForeColor="Maroon"
                                    runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                    <ajax:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pBody"
                        CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText"
                        CollapsedText="+ Contraer" ExpandedText="- Expandir" CollapsedSize="0">
                    </ajax:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div>
            <h4>
                Metadata providers</h4>
            <p>
                Aqui se listan todos los proveedores configurados en el Web.congfig o exe.config
                del dispatcher
            </p>
            <asp:GridView ID="grdMetadataProvider" runat="server" AutoGenerateColumns="False"
                BorderWidth="2" ToolTip="Metadata providers" Width="900px" AllowPaging="True"
                CellPadding="4" GridLines="Vertical" OnRowCommand="grdMetadataProvider_RowCommand">
                <PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                    Mode="NextPreviousFirstLast"></PagerSettings>
                <Columns>
                    <asp:TemplateField HeaderText="Provider name" SortExpression="Name">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkProviderName" CommandArgument='<%# Eval("Name") %>' CommandName="View"
                                runat="server" CssClass="icon_edit" Width="40" Text='<%# Bind("Name") %>'> 
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label ID="lblConfigProviderType" runat="server" Width="90" Text='<%# Bind("ConfigProviderType") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SecurityProviderName ">
                        <ItemTemplate>
                            <asp:Label ID="lblSecurityProviderName" runat="server" Width="200" Text='<%# Bind("SecurityProviderName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ApplicationId">
                        <ItemTemplate>
                            <asp:Label ID="lblApplicationId" runat="server" Width="160" Text='<%# Bind("ApplicationId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SourceInfo">
                        <ItemTemplate>
                            <asp:Label ID="lblSourceInfo" runat="server" Width="350" Text='<%# Bind("SourceInfo") %>'></asp:Label>
                        </ItemTemplate>
                             <ItemStyle Wrap="True" />
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass="grid_Header" />
                <RowStyle CssClass="grid_Row" />
                <AlternatingRowStyle CssClass="grid_AlternateRow" />
            </asp:GridView>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" CssClass="message"></asp:Label>
        </div>
        <div class="frm_row" style="height: 50px; margin-top: 7px; margin-left: 5px;">
            <h5>
                Service list</h5>
            <p>
                Services that are registered on spesisfic dispatcher
            </p>
        </div>
        <br />
        <br />
        <asp:UpdatePanel ID="GridViewUpdatePanel" runat="server">
            <ContentTemplate>
                <div>
                    <asp:GridView ID="grid_ProviderServices" runat="server" AutoGenerateColumns="False"
                        BorderWidth="1" ToolTip="Servicios" Width="710px" AllowPaging="False" CellPadding="1"
                        GridLines="Vertical" OnRowDataBound="grid_ServerSettings_RowDataBound">
                        <%--<PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                        Mode="NextPreviousFirstLast"></PagerSettings>--%>
                        <Columns>
                              
                            <asp:HyperLinkField  DataTextField="Name" HeaderText="Nombre" DataNavigateUrlFields="Name"
                                DataNavigateUrlFormatString="~/disp_main_service_admin.aspx" 
                                Target="_parent"></asp:HyperLinkField>
                            <asp:TemplateField HeaderText="Nombre" SortExpression="CreatedUserName">
                                <ItemTemplate>
                                    <asp:Label ID="CreatedUserName" runat="server" Width="90" Text='<%# Bind("CreatedUserName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha" SortExpression="CreatedDateTime">
                                <ItemTemplate>
                                    <asp:Label ID="CreatedDateTime" runat="server" Width="190" Text='<%# Bind("CreatedDateTime") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Se audita" ItemStyle-HorizontalAlign="Center"  ItemStyle-Wrap="False">
                                <ItemTemplate>
                                    <asp:CheckBox ID="audit"  runat="server" Width="100" Enabled="false" Checked='<%# Bind("Audit") %>'>
                                    </asp:CheckBox>
                                </ItemTemplate>
                                     <ItemStyle Wrap="True"  HorizontalAlign="Center" VerticalAlign="Middle"/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TransactionalBehaviour" HeaderText="Transactional" />
                            <asp:BoundField DataField="ApplicationId" HeaderText="ApplicationId" />
                        </Columns>
                        <HeaderStyle CssClass="grid_Header" />
                        <RowStyle CssClass="grid_Row" />
                        <AlternatingRowStyle CssClass="grid_AlternateRow" />
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <br />
        <asp:Label ID="Message" runat="server" CssClass="message"></asp:Label>
    </div>

</asp:Content>
