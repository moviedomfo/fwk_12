function FwkWebCLientWrapper() {
   
    this.ExecuteService = function (url, requetObj, callback) {
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
            jsonpCallback:  callback.name ,
            success: callback,
            error: function (pJqXHR, pTextStatus, pErrorThrown) {
                alert(pJqXHR.responseText);
                return null;
            }
        });

        return wServiceResponse;
    }
}

function ContextInformation() {
    this.Culture = null;;
    this.ProviderNameWithCultureInfo = null;
    this.HostName = null;
    this.HostIp = null;
    this.HostTime = null;
    this.ServerName = null,
    this.ServerTime = null;
    this.UserName = null;
    this.UserId = '';
    this.AppId = '';
    this.ProviderName = null;
}

