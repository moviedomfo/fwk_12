$(function () {
    var hostedRootPath = 'http://localhost:17854';
    var hostedRootPath_webapi = 'http://localhost:47647';
    var currentDate = new Date();
    var data = {
        CodigoCampania: "ALLUS-98",
        CodigoOrigen: "0012.",
        Fecha: currentDate,
        Horario: "true",
        Telefonos: "0351-1548788",
        Texto: "Hola gente de allus"
    };

    $('#btnAjaxCall').click(function () {
        CallService_thisSite();
    });
    $('#btnAjaxCall_POST_Directo').click(function () {
        CallService_thisSite_POST_Cruzado();
    });
    $('#btnAjaxCall_POST').click(function () {
        CallService_thisSite_POST();
    });
    $('#btnAjaxCall_POST_WebAPI').click(function () {
        CallService_POST_WebAPI();
    });



    function CallService_POST_WebAPI() {

         
        $.ajax({
            type: 'POST',
            url: hostedRootPath + '/api/HomeAPI/RegistrarLlamadaPOST_webapi/',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                var resultParced = JSON.parse(result);
                alert('llamada al servicio OK ' + result);
            },
            error: ServiceFailed
        });


    }

    function CallService_thisSite_POST() {
      

        //Realiza un POST al propio server 
        $.ajax({
            type: 'POST',
            url: hostedRootPath + '/api/HomeAPI/RegistrarLlamadaPOST/',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                var resultParced = JSON.parse(result);
                alert('llamada al servicio OK ' + result);
            },
            error: ServiceFailed
        });


    }
    function CallService_thisSite_POST_Cruzado() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:16731/MiniAvatarService.svc' + '/RegistrarLlamadaPost/")',
            dataType: 'json',
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(data),
            success: function (result) {
                alert('llamada al servicio OK ' + JSON.stringify(result));
            },
            error: ServiceFailed
        });

    }

    function CallService_thisSite() {
        //var currentDate = new Date();
        //var data = {
        //    CodigoCampania: "ALLUS-98",
        //    CodigoOrigen: "0012.",
        //    Fecha: currentDate,
        //    Horario: "true",
        //    Telefonos: "0351-1548788",
        //    Texto: "Hola gente de allus"
        //};
       

      
        //Realiza un POST al propio server 
        $.ajax({
            type: 'POST',
            url: hostedRootPath + '/api/HomeAPI/RegistrarLlamada/',
            data: JSON.stringify(data),
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (result) {
                var resultParced = JSON.parse(result);
                alert('llamada al servicio OK ' + result);
            },
            error: ServiceFailed
        });

  
    }





    ///Response to preflight request doesn't pass access control check: No 'Access-Control-Allow-Origin' header is present on the requested resource.
    function CallService_CORS() {
        var currentDate = new Date();
        var data = {
            CodigoCampania: "ALLUS-98",
            CodigoOrigen: "0012.",
            Fecha: currentDate,
            Horario: "",
            Telefonos: "",
            Text: ""
        };

        
        
        $.ajax({
            type: 'POST', 
            url: 'http://localhost:16731/MiniAvatarService.svc/RegistrarLlamada', 
            data: JSON.stringify(data), 
            contentType: 'application/json; charset=utf-8', 
            dataType: 'json', 
            success: function (result) {
                var resultParced =  JSON.parse(result);
                alert('llamada al servicio OK ' + result);
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