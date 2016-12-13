'use strict';
$(function () {
    
    
    var url = 'http://localhost:38091/SingleService.asmx' ;
    var currentDate = new Date();

    var contextInformation = new ContextInformation();
    contextInformation.Culture = "ES-AR";
    contextInformation.HostName = 'localhost';
    contextInformation.HostIp = '10.10.200.168';
    contextInformation.HostTime = currentDate;
    contextInformation.ServerName = 'WebAPIDispatcherClienteWeb',
    contextInformation.ServerTime = currentDate;
    contextInformation.UserName = 'moviedo';
    contextInformation.UserId = '';
    contextInformation.AppId = 'WebAPIDispatcherClienteWeb';
    contextInformation.ProviderName = 'health';

    var requetObj = {
        SecurityProviderName: null,
        ServiceName: 'RetrivePatientsService',
        BusinessData: {
            Nombre: "Jimmy  L. ",
            Apellido: "Hendryx",
            NroDocumento: 25365441,
            Id: 33
            
        },
        ContextInformation: contextInformation
    };

    var data = {
        providerName: requetObj.ContextInformation.ProviderName,
        serviceName: requetObj.ServiceName,
        jsonRequets: JSON.stringify(requetObj)
    };
    $('#btnCreate_es6_class').click(function () {
        Create_es6_class();
    });
    
    $('#btnCallService_WS_Cruzado').click(function () {
        CallService_WS_Cruzado();
    });
    $('#btnCallService_WS_Cruzado2').click(function () {
        CallService_WS_Cruzado_FwkWebCLientWrapper();
    });
    function logResults(json) {
        alert(json);
    }

  
    function Create_es6_class()
    {
        let ctx = new ContextInformation( );
        ctx.HostName = 'Clases de Ecmascript 6';
        ctx.UserId=8783;
        console.log(ctx.UserId + '   ' + ctx.HostName);
        $('#Create_es6_class_result').val(ctx.UserId + '   ' + ctx.HostName);


    }
    function CallService_WS_Cruzado() {
     
   
        $.ajax({
            
            type: 'POST',
            url: url + '/EjecutarTest',
            dataType: 'jsonp',
            
            //contentType: "text/javascript; charset=utf-8",
            data: data,
            crossDomain: true,
            jsonpCallback: 'CallbackResponse',
            success: CallbackResponse,
            error: function (pJqXHR, pTextStatus, pErrorThrown) {
                alert(pJqXHR.responseText);
                return null;
            }
        });
        
    }

    function CallbackResponse(response) {
        
        let businessData = response.BusinessData;
        alert('llamada al servicio OK ' + businessData[0].PatientId);
    }
  
    function CallService_WS_Cruzado_FwkWebCLientWrapper() {

        let wrapper = new FwkWebCLientWrapper();
        wrapper.ExecuteService(url, requetObj, wrapper_Callback);
    }

    function wrapper_Callback(response) {
       
        
        if (response.error)
        {
            alert(response.error.MessageText);
            return;
        }
        let businessData = response.BusinessData;
        alert('llamada al servicio OK ');
        alert(JSON.stringify( businessData));
    }



    function ServiceFailed(xhr, status, p3, p4) {
        let errMsg = status + " " + p3;
        errMsg = errMsg + "\n" + xhr.responseText;
        alert(errMsg);
    }
});
