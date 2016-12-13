$(function () {
    
    var hostedRootPath_webapi = 'http://localhost:47647';
    
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
    
    //$('#btnCallService_thisSite_POST_WebAPI').click(function () {
    //    CallService_thisSite_POST_WebAPI();
    //});

    $('#btnCall_POST_jsonp_WebAPI').click(function () {
        Call_POST_jsonp_WebAPI_test();
      
    });
 
 


  function Call_POST_jsonp_WebAPI_test() {
     
        var params = {
            ProviderName: 'marcelo Oviedo',
            JsonRequets: 'wrapper_Callback',
            ServiceName:'asd'
        };
        var callback = wrapper_Callback;
        $.ajax({
            type: 'post',
            url: hostedRootPath_webapi + '/api/SingleServiceApi/EjecutarTest2/',
            data: JSON.stringify(params),
            contentType: 'application/json; charset=utf-8',
            dataType: "jsonp",
            crossDomain: true,
            jsonpCallback: 'CallbackResponse',
            success: CallbackResponse,
            error: ServiceFailed
        });

       
    }
  function CallbackResponse(response) {
      alert('llamada al servicio OK ');
      var businessData = response.BusinessData;
      alert('llamada al servicio OK ' + businessData[0].PatientId);
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

  
   
  
    function CallService_WS_Cruzado_FwkWebCLientWrapper() {

        var wrapper = new FwkWebCLientWrapper();
        wrapper.ExecuteService(url, requetObj, wrapper_Callback);

      

    }

    function wrapper_Callback(response) {
       
        alert('llamada al servicio OK ');
        if (response.error)
        {
            alert(response.error.MessageText);
            return;
        }
        var businessData = response.BusinessData;
       
        alert(JSON.stringify( businessData));
    }



    function ServiceFailed(xhr, status, p3, p4) {
        var errMsg = status + " " + p3;
        errMsg = errMsg + "\n" + xhr.responseText;
        alert(errMsg);
    }
});
