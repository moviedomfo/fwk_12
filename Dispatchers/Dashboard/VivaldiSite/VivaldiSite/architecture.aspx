<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCenter" runat="server">
     
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
            varType = "GET";
            varProcessData = true;
           

        });

        function CallService() {
            $.ajax({
                type: varType, //GET or POST or PUT or DELETE verb
                url: varUrl, // Location of the service
                data: varData, //Data sent to server
                contentType: varContentType, // content type sent to server
                dataType: varDataType, //Expected data format from server
                processdata: varProcessData, //True or False
                success: function (msg) {//On Successfull service call
                    ServiceSucceeded(msg);
                },
                error: ServiceFailed// When Service call fails
            });

        }

        function ServiceSucceeded(result) {

            alert("ok");
            var connected = result.ConnectToWebServiceResult
            if (connected == true) {
                $('#sussefullMsg').css('display', 'block');
            }
            else {
                $('#errorMsg').css('display', 'block');
            }
        }
        function ServiceFailed(response) {

            $('#errorMsg').css('display', 'block');
           
        }

        function ConnectToWebService() {

            //$('#sussefullMsg').hide();
            varUrl = "../../service/wcf_service.svc/ConnectToWebServiceGet?url=" + $('#ContentCenter_txtUrl').val();
            varData = null;
            //varUrl = "../../service/wcf_service.svc/ConnectToWebServiceGet";
            //varData = '{"url": "' + $('#ContentCenter_txtUrl').val() + '"}';
            CallService();
        }

            
    </script>
    <div style="margin-left: 100px;">
   
 
        <div class="frm_row" style="height: 150px">
            <div id="divUrlWebservice" style="margin: 15px; display: block;">
                <div class="frm_label_1">
                    Url Web service
                </div>
                <div>
                    <asp:TextBox ID="txtUrl" runat="server" Height="23px" Width="400px" TabIndex="11"
                        CssClass="loging_textbox frm_fieldvalue">http://localhost:38091/SingleService.asmx</asp:TextBox>
                          
                </div>
                <input id="Submit1" type="submit" value="submit" onclick="ConnectToWebService();return false;" />
            </div>
            <div id="sussefullMsg" class="frm-message" style="margin-left:30px;  width:400px ; display: none;height:20px; background-color:#F7F7F7;" >
                <p>
                    La conexión al despachador de servicio web fue exitosa</p>
            </div>
             <div id="errorMsg" class="frm-error-message" style="display: none; color: Black;">
                <p>
                    No es posible la conexión con el servicio</p>
            </div>
           
         
    
        </div>
 
    </div>
       
</asp:Content>
