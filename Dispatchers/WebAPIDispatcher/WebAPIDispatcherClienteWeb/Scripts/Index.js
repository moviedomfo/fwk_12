$(function () {
    var hostedRootPath = 'http://localhost:17854';
    var hostedRootPath_webapi = 'http://localhost:47647';
    var currentDate = new Date();

    var jsonRequets = {
        SecurityProviderName: null,
        ServiceName: 'RetrivePatientsService',
        BusinessData: {
            Nombre: "Jimmy  L. ",
            Apellido: "Hendryx",
            NroDocumento: 25365441,
            Id: 33
            
        },
        ContextInformation: {
            Culture: null,
            ProviderNameWithCultureInfo: null,
            HostName: null,
            HostIp: null,
            HostTime: currentDate,
            ServerName: null,
            ServerTime: currentDate,
            UserName: "moviedo",
            UserId: "123432",
            AppId: "test allus dev",
            ProviderName: null
        }
    };

    var data = {
        providerName: 'health',
        serviceName: 'RetrivePatientsService',
        jsonRequets: JSON.stringify(jsonRequets)
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
            url: 'http://localhost:38091/SingleService.asmx' + '/Ejecutar',
            //jsonp: "logResults",
           jsonp: false,
           jsonpCallback: function(res)
           {
               //var asgndata = JSON.parse(res);
               //console.log( "jsonp asgndata: "+asgndata );
              // alert("jsonp data: " + res);// undefined - parsererror in returned res
           },
           dataType: 'JSONP',
            contentType: "application/json; charset=utf-8",
            //contentType: "text/javascript;charset=utf-8",
            data: data,
            processData :true,
            crossDomain: true,
            success: function (data) {

                var data = $.parseJSON(data);
                alert('llamada al servicio OK ' + data.Name);
               // alert('llamada al servicio OK ' + JSON.stringify(result));
            },
            error: ServiceFailed
        });
        
    }

  





    function ServiceFailed(xhr, status, p3, p4) {
        var errMsg = status + " " + p3;
        errMsg = errMsg + "\n" + xhr.responseText;
        alert(errMsg);
    }
});