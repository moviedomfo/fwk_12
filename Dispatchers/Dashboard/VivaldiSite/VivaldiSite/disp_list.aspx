<%@ Page Title="" Language="C#" MasterPageFile="~/Site2c.master" AutoEventWireup="true" CodeBehind="disp_list.aspx.cs" Inherits="VivaldiSite.disp_list" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">

<div class ="article_wrap">
<h4>
                        Server settings </h4>
                    <p>
                        Here we have all the settings, these are physically in the file  Web.congfig o exe.config
                    </p>
                    <asp:UpdatePanel ID="GridViewUpdatePanel" runat="server">
                        <ContentTemplate>
                            <div class="YodaGrilla">
                                <asp:GridView ID="grid_ServerSettings" runat="server" AutoGenerateColumns="False"
                                    BorderWidth="2" ToolTip="Enviropment list" Width="600px" 
                                    CellPadding="4" GridLines="Vertical" CssClass="" >
                            
                                    <Columns>
                                      
                                        <asp:HyperLinkField  DataTextField="InstanseName" HeaderText="Instanse name" DataNavigateUrlFields="InstanseName"
                                DataNavigateUrlFormatString="~/disp_main.aspx?disp_inst={0}" 
                                Target="_parent"></asp:HyperLinkField>
                                     <asp:BoundField DataField="CompanyName" HeaderText="Company name" />
                                     <asp:BoundField DataField="HostIp" HeaderText="Host Ip" />
                                     <asp:BoundField DataField="HostName" HeaderText="Hostname" />
                                     <asp:BoundField DataField="HostIp" HeaderText="Host Ip" />
                                    </Columns>
                                 <%--   <HeaderStyle CssClass="grid_Header" />
                                    <RowStyle CssClass="grid_Row" />
                                    <AlternatingRowStyle CssClass="grid_Row" />--%>
                                </asp:GridView>
                                <br />
                                <br />
                                
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
</div>
</asp:Content>
