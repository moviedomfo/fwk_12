<%@ Page Title="" Language="C#" MasterPageFile="~/Site2c.Master" AutoEventWireup="true" CodeBehind="disp_new.aspx.cs" Inherits="VivaldiSite.disp_new" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
    
    <script type="text/javascript" language="javascript">
        var varType;
        var varUrl;
        var varData;
        var varContentType;
        var varDataType;
        var varProcessData;
        //refresh windows
        $(window).load(function () {

            varContentType = "application/json; charset=utf-8";
            varDataType = "json";
            varType = "POST";
            varProcessData = true;
            //$.ajaxSetup({ error: myfunc });

            $('#divUrlWebservice').css('display', 'block');

            $('#divPort').css('display', 'none');
            $('#divIp').css('display', 'none');
            $('#divObjectUri').css('display', 'none');

        });

        function WrapperTypeOnChange() {
           //$('#sussefullMsg').hide();
            var combo = document.getElementById("wrappercombo");
            var code = combo.value;

            if (code == 'remoting') {
                $('#divUrlWebservice').css('display', 'none');

                $('#divPort').css('display', 'block');
                $('#divIp').css('display', 'block');
                $('#divObjectUri').css('display', 'block');
            }
            else {
                $('#divUrlWebservice').css('display', 'block');

                $('#divPort').css('display', 'none');
                $('#divIp').css('display', 'none');
                $('#divObjectUri').css('display', 'none');
            }
            return false;
        }

//        function ReceiveServerData_btnAcept(arg, context) {
//            alert(arg);
//            location.replace("~/disp_dash.aspx");
//        }


        function CallService() {
            $.ajax({
                type: varType, //GET or POST or PUT or DELETE verb
                url: varUrl, // Location of the service
                data: varData, //Data sent to server
                contentType: varContentType, // content type sent to server
                dataType: varDataType, //Expected data format from server
                processdata: varProcessData, //True or False
                success: function (msg) {
                    ServiceSucceeded(msg);
                },
                error: function(xhr, errorType, exception) {
                ServiceFailed(xhr, errorType, exception);
                }
               
            });
           
        }

        function ServiceSucceeded(result) {

            if (result.ChekDisponibilityResult != null) {

                if (result.ChekDisponibilityResult == "") {

                    $('#sussefullMsg_1').css('display', 'block');
                }
                else {
                    $('#errorMsg_1').css('display', 'block');
                    $('#errorMsg_1').html('');
                    $('#errorMsg_1').html('<p>' + result.ChekDisponibilityResult + '</p>');
                }

            }
          
            if (result.ConnectToWebServiceResult != null) {
                
                if (result.ConnectToWebServiceResult == "") {
                    $('#sussefullMsg').css('display', 'block');
                }
                else {
                    $('#errorMsg').css('display', 'block');
                    $('#errorMsg').html('');
                    $('#errorMsg').html('<p>' + result.ConnectToWebServiceResult + '</p>');
                } 
            }
        }

        function ServiceFailed(response, textStatus, errorThrown) {

            if (urrentMethod == 'ConnectToWebService') {

                $('#errorMsg').css('display', 'block');
                $('#errorMsg').html('');
                $('#errorMsg').html('<p>No es posible la conexión con el servicio</p>');
                return;
            }
            if (urrentMethod == 'ChekDisponibility') {
                $('#errorMsg_1').css('display', 'block');
                $('#errorMsg_1').html('');
                $('#errorMsg_1').html('<p>No es posible la conexión con el servicio</p>');
                return;
            }
      
    
        }

        var currentMethod;
        function ConnectToWebService() {
        
            $('#sussefullMsg').hide();
            $('#errorMsg').hide('');
            currentMethod = 'ConnectToWebService'
//            if (validate_cotrols() == false) {
//                alert('Por favor verifique todos los datos !!!');
//                return;
            //            
            varUrl = "../../service/wcf_service.svc/ConnectToWebService";
            varData = '{"url": "' + $('#ContentCenter_txtUrl').val() + '"}';
            CallService();
        }
        function ChekDisponibility() {
            currentMethod = 'ChekDisponibility'
            $('#sussefullMsg_1').hide();
            $('#errorMsg_1').hide('');
                   
            varUrl = "../../service/wcf_service.svc/ChekDisponibility";
            varData = '{"instanceName": "' + $('#ContentCenter_txtInstanceName').val() + '"}';
            CallService();
        }
            
    </script>
    <div style="margin-left: 100px;">
        <div style="background-color: #FFFFFF; margin-top: 10px; margin-bottom: 5px">
            <div class="frm_label_2">
                Instance dispatcher name
            </div>
            <div class="grid_8">
                <asp:TextBox ID="txtInstanceName" runat="server" Font-Bold="True" TabIndex="1" TextMode="SingleLine"
                    Width="300" Height="25px" CssClass="frm_fieldvalue" />
            </div>
            <div class="grid_3">
                <input id="Submit2" class="grid_Button grid_Button_confirm" type="submit" tabindex="11"
                    style="width: 190px; height: 30px" value="Virificar disponibilidad" onclick="ChekDisponibility();return false;" />
            </div>
            <div class="clearfix">
            </div>
            <div id="sussefullMsg_1" class="frm-message" style="margin-left: 30px; width: 400px;
                display: none; height: 20px; background-color: #F7F7F7;">
                <p>
                    The instance name is available </p>
            </div>
            <div id="errorMsg_1" class="frm-error-message" style="margin-left: 36px; width: 400px;
                height: 20px; display: none; color: Black;">
            </div>
        </div>
        <div style="margin-top: 10px; margin-bottom: 5px">
            <div class="frm_label_2">
                Company
            </div>
            <div>
                <asp:TextBox ID="txtCompany" runat="server" Font-Bold="True" TabIndex="2" TextMode="SingleLine"
                    Width="300" Height="25px" CssClass="frm_fieldvalue" />
            </div>
        </div>
        <div class="">
            <asp:Label ID="Msg" ForeColor="maroon" runat="server" /><br />
        </div>
        <div style="margin-top: 5px">
            <div class="frm_label_2">
                Server name
            </div>
            <div>
                <asp:TextBox ID="txtServerName" runat="server" Font-Bold="True" TabIndex="3" TextMode="SingleLine"
                    Width="300" Height="25px" CssClass="frm_fieldvalue" />
            </div>
        </div>
        <div style="margin-top: 15px">
            <div class="frm_label_2">
                Service audit mode
            </div>
            <div style="width: 300px">
                <asp:DropDownList ID="cmbAuditMode" CssClass="loging_textbox frm_fieldvalue" runat="server"
                    Width="300px" DataTextField="Nombre" DataValueField="Id" Height="25px" TabIndex="4">
                    <asp:ListItem Value="0">Required</asp:ListItem>
                    <asp:ListItem Value="1">Optional</asp:ListItem>
                    <asp:ListItem Value="2">None</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div style="margin-top: 15px">
            <div class="frm_label_2">
                Technology
            </div>
            <div style="width: 300px">
                <select id="wrappercombo" tabindex="5" class="loging_textbox frm_fieldvalue" style="width: 300px"
                    onchange="javascript:WrapperTypeOnChange()">
                    <option value="webservice">Web Service </option>
                    <option value="remoting">Remoting </option>
                </select>
            </div>
        </div>
        <div class="frm_row" style="height: 150px">
            <div id="divUrlWebservice" style="margin: 15px; display: block;">
                <div class="frm_label_1">
                    Url Web service
                </div>
                
                <div class="grid_8">
                    <asp:TextBox ID="txtUrl" runat="server" Height="23px" Width="453px" TabIndex="10"
                        CssClass="loging_textbox frm_fieldvalue"></asp:TextBox>
                          
                </div>
                <div class="grid_3">
                        <input id="Submit1" class="grid_Button grid_Button_confirm" type="submit" tabindex="11" style="width:100px ;height:30px" value="Check url" onclick="ConnectToWebService();return false;" />
                 </div>
                
            </div>
            <div class="clearfix"></div>
            <div id="sussefullMsg" class="frm-message" style="margin-left:30px;  width:400px ; display: none;height:20px; background-color:#F7F7F7;" >
                <p> 
                   The connection to the web service dispatcher was successful</p>
            </div>
             <div id="errorMsg" class="frm-error-message" style="margin-left:36px;  width:400px ; height:20px; display: none; color: Black;">
                
                   Unable to connect to the service
            </div>
            <div id="divPort" style="margin: 15px; display: none;">
                <div class="frm_label_1">
                    Port</div>
                <div>
                    <asp:TextBox ID="txtPort" runat="server" Height="23px" Width="500px" TabIndex="201"
                        CssClass="loging_textbox frm_fieldvalue"></asp:TextBox>
                </div>
            </div>
            <div id="divIp" style="margin: 15px; display: none;">
                <div class="frm_label_1">
                     Ip or Hostname</div>
                <div>
                    <asp:TextBox ID="txtIp" runat="server" Height="23px" Width="300px" TabIndex="21"
                        CssClass="loging_textbox frm_fieldvalue"></asp:TextBox>
                </div>
            </div>
    
        </div>
        <div style="margin-top: 10px;">
            <div class=" frm_label_2">
                General service description
            </div>
            <div class="frm_fieldvalue" style="margin-top: 4px">
                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Width="600px"
                    Height="80px" CssClass="frm_fieldvalue" TabIndex="22" />
            </div>
        </div>
    </div>
       <div style="height: 70px; margin-top: 30px; margin-left: 100px;float:left;" >
        <asp:Button ID="btnAcept" runat="server" OnClick="Button1_Click" Text="Registrar"
            TabIndex="100" CssClass="frm_btGrisNegrita" Width="120" Height="2em" />
    </div>
</asp:Content>
