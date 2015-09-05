function amply(img, divId) {
    var elem1 = $("#" + divId);
    //Amplia
    if (img.width < 570) {
        elem1.removeClass("news_divImag_190_210");
        elem1.addClass("news_divImag_500_570");
        elem1.fadeSliderE({ speed: 500, easing: "swing" }, "true");
        img.width = 570;
        img.height = 500;
    }
    else {//Reduce
        elem1.removeClass("news_divImag_500_570");
        elem1.addClass("news_divImag_190_210");
        elem1.fadeSliderE({ speed: 500, easing: "swing" }, "false");
        img.width = 210;
        img.height = 190;
    }
}

/*
* Fade Slider Toggle plugin
*
* Copyright(c) 2009, Cedric Dugas
* http://www.position-relative.net
*
* A sliderToggle() with opacity
* Licenced under the MIT Licence
*/
jQuery.fn.fadeSliderToggle = function (settings) {
    /* Damn you jQuery opacity:'toggle' that dosen't work!~!!!*/
    settings = jQuery.extend({
        speed: 500,
        easing: "swing"
    }, settings)
    caller = this
    if ($(caller).css("display") == "none") {
        $(caller).animate({
            opacity: 1,
            height: 'toggle'
        }, settings.speed, settings.easing);
    } else {
        $(caller).animate({
            opacity: 0,
            height: 'toggle'
        }, settings.speed, settings.easing);
    }
};

jQuery.fn.fadeSliderE = function (settings, exp) {

    settings = jQuery.extend({ speed: 500, easing: "swing" }, settings);

    caller = this;
    if (exp == "true") {
        $(caller).animate({
            opacity: 1,
            height: '500px'
        }, settings.speed, settings.easing);
    } else {
        $(caller).animate({
            opacity: 1,
            height: '190px'
        }, settings.speed, settings.easing);
    }
};


/// Helper Functions

function Getrootpath(href) {

    var url = document.location.protocol + '//' + document.location.host;
    var root = document.location + '/';
    var aux = '';
    var temp = new Array();
    temp = root.split('/');
    aux = temp[2].toString();

    if (aux.indexOf('localhost:', 0) == -1) {
        url = url + '/' + temp[3] + href;
    }
    else {
        url = url + href;
    }

    return url;
}

function Validate_Email(email) {
    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
    if (!emailReg.test(email)) {
        return false;
    } else {
        return true;
    }
}

