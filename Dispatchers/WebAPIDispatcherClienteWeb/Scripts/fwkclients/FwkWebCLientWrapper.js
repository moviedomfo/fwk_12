'use strict';
//calls ExecuteServiceJsonp in remote dispatcher
class FwkWebCLientWrapper {
    constructor() {       
    }

    ExecuteService (url, requetObj, callback) {
        var wServiceResponse = null;

        var data = {
            providerName: requetObj.ContextInformation.ProviderName,
            serviceName: requetObj.ServiceName,
            jsonRequets: JSON.stringify(requetObj)
        };


        $.ajax({

            type: 'POST',
            url: url + '/ExecuteServiceJsonp',
            dataType: 'jsonp',
            data: data,
            crossDomain: true,
            jsonpCallback: callback.name,
            success: callback,
            error: function (pJqXHR, pTextStatus, pErrorThrown) {
                //you should modify this code for your own purposes 
                //you can constructo error callback too
                alert(pJqXHR.responseText);
                return null;
            }
        });

        return wServiceResponse;
    }
}



class ContextInformation {

    constructor( )
    {
        this.Culture = null;;
        this.ProviderNameWithCultureInfo = null;
        this.HostName =  '';
        this.HostIp = null;
        this.HostTime = null;
        this.ServerName = null,
        this.ServerTime = null;
        this.UserName = null;
        this.UserId = '';
        this.AppId = '';
        this.ProviderName = null;
    }
 
}

