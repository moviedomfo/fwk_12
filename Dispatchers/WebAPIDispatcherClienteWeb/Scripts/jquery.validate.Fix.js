//$.validator.methods.range = function (value, element, param) {
//    var globalizedValue = value.replace(",", ".");
//    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
//}

//$.validator.methods.number = function (value, element) {
//    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
//}

$.validator.methods.number = function (value, element) {
    return this.optional(element) || !isNaN(Globalize.parseFloat(value));
}

$.validator.methods.date = function (value, element) {
    if (this.optional(element))
        return true;
    var result = Globalize.parseDate(value);
    return !isNaN(result) && (result != null);
}

$.validator.methods.min = function (value, element, param) {
    return this.optional(element) || Globalize.parseFloat(value) >= param;
}

$.validator.methods.max = function (value, element, param) {
    return this.optional(element) || Globalize.parseFloat(value) <= param;
}

$.validator.methods.range = function (value, element, param) {
    if (this.optional(element))
        return true;
    var result = Globalize.parseFloat(value);
    return (result >= param[0] && result <= param[1]);
}