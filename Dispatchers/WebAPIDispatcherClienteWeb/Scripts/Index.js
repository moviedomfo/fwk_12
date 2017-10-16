$(function () {
    var hostedRootPath = 'http://localhost:17854';
    var hostedRootPath_webapi = 'http://localhost:47647';
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
    
    $('#btnCallService_thisSite_POST_WebAPI').click(function () {
        CallService_thisSite_POST_WebAPI();
    });
    $('#btnAjaxCall_POST_jsonp_WebAPI').click(function () {
        Call_POST_jsonp_WebAPI();
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

    function Call_POST_jsonp_WebAPI() {
        //$.ajax({
        //    type: 'GET',
      
        //    url: 'http://localhost:47647' + '/api/SingleServiceApi/Ping/test123")',
        //    //data: JSON.stringify(data),
        //    contentType: 'application/json; charset=utf-8',
        //    jsonp: "logResults",
        //    dataType: "jsonp",
        //    //crossDomain: true,
        //    success: function (result) {
        //        var resultParced = JSON.parse(result);
        //        alert('llamada al servicio OK ' + result);
        //    },
        //    error: ServiceFailed
        //});
        $.ajax({
            type: 'POST',
            url: 'http://localhost:47647' + '/api/SingleServiceApi/Execute/',
            data: "pepe",//JSON.stringify(data),
            contentType: 'application/json',
            //jsonp: "logResults",
            dataType: "jsonp",
           // headers: { 'Access-Control-Allow-Origin': '*', 'Access-Control-Allow-Methods': 'POST' },
            //processData: false,
            //crossDomain: true,
            success: function (result) {
                var resultParced = JSON.parse(result);
                alert('llamada al servicio OK ' + result);
            },
            error: ServiceFailed
        });

       
    }

    function CallService_thisSite_POST_WebAPI() {
      
        
     
        //Realiza un POST al propio server 
        $.ajax({
            type: 'POST',
            url: hostedRootPath + '/api/HomeAPI/Execute/',
            data:  JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                var resultParced = JSON.parse(result);
                alert('llamada al servicio OK ' + result);
            },
            error: ServiceFailed
        });


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
        
        var businessData = response.BusinessData;
        alert('llamada al servicio OK ' + businessData[0].PatientId);
    }
  
    function CallService_WS_Cruzado_FwkWebCLientWrapper() {

        var wrapper = new FwkWebCLientWrapper();
        wrapper.ExecuteService(url, requetObj, wrapper_Callback);

      

    }

    function wrapper_Callback(response) {
       
        
        if (response.error)
        {
            alert(response.error.MessageText);
            return;
        }
        var businessData = response.BusinessData;
        alert('llamada al servicio OK ');
        alert(JSON.stringify( businessData));
    }



    function ServiceFailed(xhr, status, p3, p4) {
        var errMsg = status + " " + p3;
        errMsg = errMsg + "\n" + xhr.responseText;
        alert(errMsg);
    }
});
