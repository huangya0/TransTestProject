function gotoWithBackQuery(path) {
    var query = window.location.search;
    var tmpForm = $('<form action="' + path + '" method="post"></form>');
    tmpForm.append('<input type="hidden" value="' + query + '" name="backQuery"/>');
    tmpForm.appendTo(document.body).submit();
}

function setSort(sortField) {
    var SortBy = $("#SortBy");
    var SortDirection = $("#SortDirection");
    var sortFieldOld = SortBy.val();
    SortBy.val(sortField);
    var sortDirection = SortDirection.val();
    if (sortDirection == "") {
        SortDirection.val("ASC");
    } else {
        if (sortFieldOld == sortField) {
            if (sortDirection == "ASC") {
                SortDirection.val("DESC");
            }
            else {
                SortDirection.val("ASC");
            }
        } else {
            SortDirection.val("ASC");
        }
    }
    $("#form-search").submit();
}


var autoUIAjaxWaitingSwitch = false;
function waitajaxload() {
    return autoUIAjaxWaitingSwitch;
}
function turnAjaxWaitOn() {
    autoUIAjaxWaitingSwitch = true;
}
function turnAjaxWaitDown(hasChildAjaxRequest) {
    if (hasChildAjaxRequest == true) {
        autoUIAjaxWaitingSwitch = true;
    } else {
        autoUIAjaxWaitingSwitch = false;
    }
}


// 2013/9/2 Aaron
function loadHtml(url, target, params, callback, hasChildAjaxRequest) {
    try {
        $.ajax({
            url: url,
            dataType: "html",
            type: "GET",
            data: params,
            beforeSend: function () {
                turnAjaxWaitOn();
                //showLoading();
            },
            success: function (result) {
                if (typeof result == "string" && result.indexOf("AjaxNoPermissionMsgKey:") != -1) {
                    var arr = result.split("AjaxNoPermissionMsgKey:");
                    result = arr[1];
                }

                if (target.jquery != null && target.jquery != undefined) { // jquery object
                    target.html(result);
                } else if (typeof target == "string") { // selector
                    $(target).html(result);
                } else {
                    alert("targe arg error");
                }
                if (callback) { callback(target); }
            },
            error: function () {
                buildError()
            },
            complete: function () {
                //hideLoading();
                turnAjaxWaitDown(hasChildAjaxRequest);
            }
        });
    } catch (e) {
        alert(e);
    }
}

// 2015/3/3 Aaron
function loadHtmlByPost(url, target, params, callback, hasChildAjaxRequest) {
    try {
        $.ajax({
            url: url,
            dataType: "html",
            type: "POST",
            data: params,
            beforeSend: function () {
                turnAjaxWaitOn();
                showLoading();
            },
            success: function (result) {
                if (typeof result == "string" && result.indexOf("AjaxNoPermissionMsgKey:") != -1) {
                    var arr = result.split("AjaxNoPermissionMsgKey:");
                    result = arr[1];
                }

                if (target.jquery != null && target.jquery != undefined) { // jquery object
                    target.html(result);
                } else if (typeof target == "string") { // selector
                    $(target).html(result);
                } else {
                    alert("targe arg error");
                }
                if (callback) { callback(target); }
            },
            error: function () {
                buildError()
            },
            complete: function () {
                hideLoading();
                turnAjaxWaitDown(hasChildAjaxRequest);
            }
        });
    }
    catch (e) {
        alert(e);
    }
}

// 2013/11/12
function get(url, data, handler, dataType, hasChildAjaxRequest) {
    var paramObj = {
        url: url,
        data: data,
        type: "GET",
        beforeSend: function () {
            turnAjaxWaitOn();
            showLoading();
        },
        success: function (result) {
            if (typeof result == "string" && result.indexOf("AjaxNoPermissionMsgKey:") != -1) {
                var arr = result.split("AjaxNoPermissionMsgKey:");
                result = arr[1];
                buildError(result);
            }else{
                handler(result);
            }
        },
        error: function () {
            buildError();
        },
        complete: function () {
            hideLoading();
            turnAjaxWaitDown(hasChildAjaxRequest);
        }
    };

    if (dataType != undefined && dataType != null) {
        paramObj.dataType = dataType;
    }

    $.ajax(paramObj);
}

// 2013/11/12
function post(url, data, handler, dataType, hasChildAjaxRequest) {
    var paramObj = {
        url: url,
        data: data,
        type: "POST",
        beforeSend: function () {
            turnAjaxWaitOn();
            showLoading();
        },
        success: function (result) {
            if (typeof result == "string" && result.indexOf("AjaxNoPermissionMsgKey:") != -1) {
                var arr = result.split("AjaxNoPermissionMsgKey:");
                result = arr[1];
                buildError(result);
            } else {
                handler(result);
            }
        },
        error: function () {
            buildError();
        },
        complete: function () {
            hideLoading();
            turnAjaxWaitDown(hasChildAjaxRequest);
        }
    };

    if (dataType != undefined && dataType != null) {
        paramObj.dataType = dataType;
    }

    $.ajax(paramObj);
}

function getAjaxNoPermissionMsg(result) {
    if (typeof result == "string" && result.indexOf("AjaxNoPermissionMsgKey:") != -1) {
        var arr = result.split("AjaxNoPermissionMsgKey:");
        result = arr[1];
        buildError(result);
    }
}

// 2013/9/2 Aaron
// callback after delete, you can refresh you page or do other thing
function commonDelete(confirmMsg, deleteUrl, callback, hasChildAjaxRequest) {
    if (confirm(confirmMsg)) {
        try {
            get(deleteUrl, {}, function (result) {
                try {
                    result = eval("(" + result + ")");
                    if (result.IsSuccess != null && result.IsSuccess == false) {
                        showresult("error", result.result); // operate failure
                    } else if (result.IsSuccess != null && result.IsSuccess == true) {
                        //if (callback) { callback(result); }
                        showresult("info", result.result);
                    }
                    //else {
                    //    //if (callback) { callback(result); }
                    //    buildInfo(); // operate success
                    //};
                }
                catch (e) {
                }
                showMessageFromCookie();
                if (callback) { callback(result); }

                //if (eval("(" + result + ")") == true) {
                //} else { // compatibility for old message tip
                //}
            }, null, hasChildAjaxRequest);
        } catch (e) { }
    }
}

// 2013/9/2 Aaron
function showModal(modalId, title, requestUrl, callback, hasChildAjaxRequest) {
    var $modal = $(modalId);
    var $body = $modal.find(".modal-body");
    var $header = $modal.find(".modal-title");
    $header.html(title);
    $modal.modal("show");

    get(requestUrl, {}, function (result) {
        $body.html(result);
        if (callback) { callback($modal, result); }
    }, null, hasChildAjaxRequest);
}

// 2013/11/12
function showFormModal(modal, title, requestUrl, requestData, postUrl, callback, requestType, hasChildAjaxRequest) {
    var $modal;
    if (modal.jquery != null || modal.jquery != undefined) { // jquery object
        $modal = modal;
    } else {
        $modal = $(modal); // selector
    }
    var $body = $modal.find(".modal-body");
    var $header = $modal.find(".modal-title");
    var $form = $modal.find("form");
    $header.html(title);
    $form.attr("action", postUrl);
    $modal.modal("show");

    if (requestType != undefined && requestType != null && requestType.toLowerCase() == "post") {
        post(requestUrl, requestData, function (result) {
            $body.html(result);
            if (callback) { callback($modal, $form, $body, result); }
        }, null, hasChildAjaxRequest);
    } else {
        get(requestUrl, requestData, function (result) {
            $body.html(result);
            if (callback) { callback($modal, $form, $body, result); }
        }, null, hasChildAjaxRequest);
    }
}

// aaron 2014/10/14
function showFormModalWithButtons(modal, title, requestUrl, requestData, postUrl, callback, requestType, hasChildAjaxRequest) {
    var $modal;
    if (modal.jquery != null || modal.jquery != undefined) { // jquery object
        $modal = modal;
    } else {
        $modal = $(modal); // selector
    }
    var $body = $modal.find(".modal-body");
    var $header = $modal.find(".modal-title");
    var $form = $modal.find("form");
    var $buttons = $modal.find(".additionalButtons");
    $header.html(title);
    $form.attr("action", postUrl);
    $modal.modal("show");

    if (requestType != undefined && requestType != null && requestType.toLowerCase() == "post") {
        post(requestUrl, requestData, function (result) {
            var $divWrap = $("<div>" + result + "</div>");
            var htmlcontents = $divWrap.find(".modal-htmlcontent");
            var htmlcontent = "";
            for (var i = 0; i < htmlcontents.length; i++) {
                htmlcontent += $(htmlcontents[i]).html();
            }
            $body.html(htmlcontent);
            $buttons.html($divWrap.find(".modal-buttons").html());
            if (callback) { callback($modal, $form, $body, result); }
        }, null, hasChildAjaxRequest);
    } else {
        try {
            get(requestUrl, requestData, function (result) {
                var $divWrap = $("<div>" + result + "</div>");
                var htmlcontents = $divWrap.find(".modal-htmlcontent");
                var htmlcontent = "";
                for (var i = 0; i < htmlcontents.length; i++) {
                    htmlcontent += $(htmlcontents[i]).html();
                }
                $body.html(htmlcontent);
                $buttons.html($divWrap.find(".modal-buttons").html());
                if (callback) { callback($modal, $form, $body, result); }
            }, null, hasChildAjaxRequest);
        } catch (e) { }
    }
}

function showFormModalWithReplacePart(modal, title, requestUrl, requestData, postUrl, callback, requestType, hasChildAjaxRequest) {
    var $modal;
    if (modal.jquery != null || modal.jquery != undefined) { // jquery object
        $modal = modal;
    } else {
        $modal = $(modal); // selector
    }
    var $body = $modal.find(".modal-body");
    var $header = $modal.find(".modal-title");
    var $form = $modal.find("form");
    var $buttons = $modal.find(".additionalButtons");
    $header.html(title);
    $form.attr("action", postUrl);
    $modal.modal("show");

    if (requestType != undefined && requestType != null && requestType.toLowerCase() == "post") {
        post(requestUrl, requestData, function (result) {
            var $divWrap = $("<div>" + result + "</div>");
            var htmlcontents = $divWrap.find(".modal-htmlcontent");
            var htmlcontent = "";
            for (var i = 0; i < htmlcontents.length; i++) {
                htmlcontent += $(htmlcontents[i]).html();
            }
            $body.html(htmlcontent);
            replaceWithContent($divWrap, $modal);
            if (callback) { callback($modal, $form, $body, result); }
        }, null, hasChildAjaxRequest);
    } else {
        try {
            get(requestUrl, requestData, function (result) {
                var $divWrap = $("<div>" + result + "</div>");
                var htmlcontents = $divWrap.find(".modal-htmlcontent");
                var htmlcontent = "";
                for (var i = 0; i < htmlcontents.length; i++) {
                    htmlcontent += $(htmlcontents[i]).html();
                }
                $body.html(htmlcontent);
                replaceWithContent($divWrap, $modal);
                if (callback) { callback($modal, $form, $body, result); }
            }, null, hasChildAjaxRequest);
        } catch (e) { }
    }
}

function replaceWithContent($divWrap, $modal) {
    var placeHoders = $modal.find(".placehoder");
    for (var i = 0; i < placeHoders.length; i++) {
        var placeHoderId = placeHoders[i].id;
        var placePre = placeHoderId.split("-")[0];
        var contentClassName = placePre + "-content";

        // replace one placeHolder, one placeHoder map to multip palceContent
        var placeContents = $divWrap.find("." + contentClassName);
        var htmlContents = "";
        for (var j = 0; j < placeContents.length; j++) {
            htmlContents += $(placeContents[j]).html();
        }
        $("#" + placeHoderId).html(htmlContents);
    }
}


// remove ' ' on value's left side
// ansens lu, 2014-11-10
function leftTrim(str) {
    var i;
    for (i = 0; i < str.length; i++) {
        if (str.charAt(i) != " ")
            break;
    }
    str = str.substring(i, str.length);
    return str;
}

// remove ' ' on value's right side
// ansens lu, 2014-11-10
function rightTrim(str) {
    var i;
    for (i = str.length - 1; i >= 0; i--) {
        if (str.charAt(i) != " ")
            break;
    }
    str = str.substring(0, i + 1);
    return str;
}

// trim string
// ansens lu, 2014-11-10
function stringTrim(str) {
    return leftTrim(rightTrim(str));
}

// 2013/9/2 Aaron
function hideModal(modal, callback) {
    //UploadFileNumberLimit();
    //AddFileButtonSettings();
    var $modal;
    if (modal.jquery != null && modal.jquery != undefined) {
        $modal = modal;
    } else {
        $modal = $(modal);
    }
    var $body = $modal.find(".modal-body");
    var $form = $modal.find("form"); // is exist
    //var $modal_buttons = $modal.find("#modal-buttons");
    //var $modal_overform = $modal.find("#modal-overform");
    //var $modal_underform = $modal.find("#modal-underform");
    var placeholders = $modal.find(".placehoder");
    placeholders.empty();
    $modal.modal("hide");
    $body.html('<img class="loading" src="../../../Images/Main/loading.gif" alt="" />');
    //$modal_buttons.html("");
    //$modal_overform.html("");
    //$modal_underform.html("");

    if (callback) { callback($modal, $form); }
}

// 2013/11/15
function addParamToUrl(url, key, value) {
    if (url.indexOf("?") == -1) {
        if (value == undefined)
            url += "?" + key + "=";
        else
            url += "?" + key + "=" + encodeURI(value);
    } else {
        if (value == undefined)
            url += "&" + key + "=";
        else
            url += "&" + key + "=" + encodeURI(value);
    }
    return url;
}

Array.prototype.remove = function (value, key) {
    if (key == undefined) { // simple values array
        for (var i = 0; i < this.length; i++) {
            if (this[i] == value) {
                this.splice(i, 1);
            }
        }
    } else { // object array
        for (var i = 0; i < this.length; i++) {
            if (this[i][key] == value) { // get value according the key
                this.splice(i, 1);
            }
        }
    }
}

Array.prototype.contain = function (value, key) {
    if (key == undefined) { // simple values array
        for (var i = 0; i < this.length; i++) {
            if (this[i] == value) {
                return true;
            }
        }
        return false;
    } else { // get value according the key
        for (var i = 0; i < this.length; i++) {
            if (this[i][key] == value) {
                return true;
            }
        }
        return false;
    }
}

var CookieHelper = {
    getCookies: function () {
        return document.cookie.split("; ");
    },
    getCookieObj: function (cookieName) { // return a json object
        var cookieStr = this.getCookieStr(cookieName);
        if (cookieStr === "") return null;

        var keyValurArr = cookieStr.split("&");
        var cookieObj = {};
        for (var j = 0; j < keyValurArr.length; j++) {
            var keyValue = keyValurArr[j].split("=");
            var key = keyValue[0];
            var value = (keyValue[1] == undefined || keyValue[1] == null) ? "" : keyValue[1];
            cookieObj[key] = unescape(value);
        }
        return cookieObj;
    },
    getJsonObj: function (cookieName) {
        var cookieStr = this.getCookieStr(cookieName);
        if (cookieStr === "") return null;

        cookieStr = decodeURI(cookieStr);
        cookieStr = cookieStr.replace(/%3a/gi, ":").replace(/%2c/gi, ",");

        var json = JSON.parse(cookieStr);
        return json;
    },
    getCookieStr: function (cookieName) {
        var cookies = this.getCookies();
        for (var i = 0; i < cookies.length; i++) {
            var cookieArr = cookies[i].split("=");
            if (cookieArr[0] == cookieName) {
                cookieArr = cookieArr.slice(1);
                return cookieArr.join("=");
            }
        }
        return "";
    },
    getCookieValue: function (cookieName, key) {
        var cookieObj = this.getCookie(cookieName);
        return unescape(cookieObj[key]);
    },
    setCookie: function (cookieName, value, expire, domain, path, secure) {
        if (cookieName == null || value == null) {
            alert("atleast two arguments");
        }
        var cookieStr = cookieName + "=" + escape(value);
        if (expire != null) {
            cookieStr += ";expires=" + expire;
        }
        if (domain != null) {
            cookieStr += ";domain=" + domain;
        }
        if (path != null) {
            cookieStr += ";path=" + path;
        }
        if (secure != null) {
            cookieStr += ";secure=" + secure;
        }
        document.cookie = cookieStr;
    },
    removeCookie: function (cookieName, domain, path) {
        var expir = new Date();
        expir.setDate(expir.getDate() - 1);
        this.setCookie(cookieName, "", expir.toGMTString(), domain, path);
    }
};


function ChartCodeToString(charCodeStr) {
    var result = "";
    var charCodes = charCodeStr.split(',');
    for (i = 0; i < charCodes.length; i++) {
        result += String.fromCharCode(charCodes[i]);
    }
    return result;
}

/// date helper
function DateAdd(currentdate, days) {
    var tempdate = new Date(currentdate);
    var val = tempdate.valueOf();
    val += days * 24 * 60 * 60 * 1000;
    return new Date(val);
}

function WeekAdd(currentdate, weeks) {
    var tempdate = new Date(currentdate);
    var val = tempdate.valueOf();
    val += weeks * 7 * 24 * 60 * 60 * 1000;
    return new Date(val);
}

//function MonthAdd(currentdate, months) {
//    var tempdate = new Date(currentdate);
//    var year = tempdate.getYear();
//    var month = tempdate.getMonth();
//    var date = tempdate.getDate();

//    if (month + months > 12) {
//        year += 1;
//        month = month + months - 12;
//    } else {
//        month = month + months;
//    }

//    return new Date(year, month, date);
//}

function YearAdd(currentdate, years) {
    var tempdate = new Date(currentdate);
    var year = tempdate.getYear();
    var month = tempdate.getMonth();
    return new Date(year, month);
}

Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1, //month 
        "d+": this.getDate(), //day 
        "h+": this.getHours(), //hour 
        "m+": this.getMinutes(), //minute 
        "s+": this.getSeconds(), //second 
        "q+": Math.floor((this.getMonth() + 3) / 3), //quarter 
        "S": this.getMilliseconds() //millisecond 
    }

    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }

    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
}
String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, '');
}

Number.prototype.retaindecimals = function (decimal) {
    switch (decimal) {
        case 1:
            return Math.round(this * 10) / 10;
            break;
        case 2:
            return Math.round(this * 100) / 100;
            break;
        case 3:
            return Math.round(this * 1000) / 1000;
            break;
        case 4:
            return Math.round(this * 10000) / 10000;
            break;
            break;
    }

};
///
function valid_int_keydown(e, txtbox, length) {
    var keynum;
    var keychar;
    var numcheck;

    if (window.event) // IE
    {
        keynum = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        keynum = e.which;
    };

    keychar = String.fromCharCode(keynum);
    numcheck = /\d/;
    return (numcheck.test(keychar) || keynum == 8 || (keynum <= 105 && keynum >= 96));
}

function valid_int_change(txtbox, length) {
    var $txtbox = $(txtbox);
    var txt = $txtbox.val();
    var reg = /^[1-9][0-9]*$/;
    if (txt == "" || txt == undefined) {
    } else {
        if (!reg.test(txt)) {
            $txtbox.val("");
        }
    }
}


function valid_number_keydown(e, txtbox, length) {
    var keynum;
    var keychar;
    var numcheck;
    var hasRadixPoint = false;

    var $txtbox = $(txtbox);
    if ($txtbox.attr("radixPoint") != undefined && $txtbox.attr("radixPoint") == "true") {
        hasRadixPoint = true;
    }

    if (window.event) // IE
    {
        keynum = e.keyCode;
    }
    else if (e.which) // Netscape/Firefox/Opera
    {
        keynum = e.which;
    }

    keychar = String.fromCharCode(keynum);
    numcheck = /\d/;


    var txt = $txtbox.val();

    if ((keynum == 190 || keynum == 110) || /\./.test($txtbox.val())) {
        $txtbox.attr("radixPoint", true);
    } else {
        $txtbox.attr("radixPoint", false);
    }
    return (numcheck.test(keychar) || keynum == 8 || (keynum <= 105 && keynum >= 96) || (hasRadixPoint == false && (keynum == 190 || keynum == 110)));
}

function valid_number_change(txtbox, length) {
    var $txtbox = $(txtbox);
    var txt = $txtbox.val();

    var pointSplit = txt.split(".");
    if (pointSplit.length > 1) {
        if (pointSplit[1].length >= length) {
            txt = pointSplit[0] + "." + pointSplit[1].substr(0, 2);
        }
        if (pointSplit[1] == 0) {
            txt = pointSplit[0];
        }
    }

    var reg = /^\d*\.*\d{0,2}$/;
    if (txt == "" || txt == undefined) {
    } else {
        if (!reg.test(txt)) {
            $txtbox.val("");
        } else {
            $txtbox.val(txt);
        }
    }
}

$.fn.smartFloat = function () {
    var position = function (element) {
        var top = element.position().top + 100, pos = element.css("position");
        var os = getOsNew();
        if (os.browser == "IE") {
            var buttonwidth = $(".titlemenu-width").first().width();
            $(".titlemenu-div-width").first().css({
                width: buttonwidth - 130
            });
        }

        $(window).scroll(function () {
            var scrolls = $(this).scrollTop();
            if (scrolls > top) {
                if (window.XMLHttpRequest) {
                    element.css({
                        position: "fixed",
                        top: 20,
                        display: "block"
                    });
                    $(".float-title").css({
                        position: "fixed",
                        top: 105,

                    });
                } else {
                    element.css({
                        top: scrolls
                    });
                    $(".float-title").css({
                        top: scrolls
                    });
                }
            } else {
                element.css({
                    position: "relative",
                    top: 0,
                    display: "none"
                });
                $(".float-title").css({
                    position: "relative",
                    top: 0,
                });
            }
        });
    };
    return $(this).each(function () {
        position($(this));
    });
};
//DIV浮动效果
$.fn.smartpopupFloat = function () {
    var position = function (element) {
        var top = element.position().top + 30, pos = element.css("position");
        $(".form-modal-float").first().scroll(function () {
            var scrolls = $(this).scrollTop();
            var os = getOsNew();
            if (os.browser == "IE") {
                var buttonwidth = $(".form-modal-float .float-popuptitle-button").not("[aria-hidden=\"true\"]").first().width();
                var buttons = $(".float-title-button-content");
                var buttonswidth = 0;
                buttons.each(function () {
                    buttonswidth = buttonswidth + $(this).width() + 60;
                });

                $(".form-modal-float .float-popuptitle-button-div").not("[aria-hidden=\"true\"]").first().css({
                    width: buttonswidth
                });
            }
            var headwidth = $(".form-modal-float .section-head-width").not("[aria-hidden=\"true\"]").first().width();
            $(".form-modal-float .under-popupline").not("[aria-hidden=\"true\"]").first().css({
                width: headwidth
            });
            if (scrolls > top) {
                if (window.XMLHttpRequest) {
                    if (os.browser == "IE") {
                        element.css({
                            position: "fixed",
                            top: -1,
                            display: "block"
                        });
                        $(".form-modal-float .float-popuptitle").not("[aria-hidden=\"true\"]").first().css({
                            position: "fixed",
                            top: 42
                        });
                        $(".float-popuptitle-button-margin").first().css({
                            'margin-top': -40
                        });

                    }
                    else {
                        element.css({
                            position: "fixed",
                            top: scrolls,
                            display: "block"
                        });
                        $(".form-modal-float .float-popuptitle").not("[aria-hidden=\"true\"]").first().css({
                            position: "fixed",
                            top: scrolls + 42,
                        });
                        $(".float-popuptitle-button-margin").first().css({
                            'margin-top': -40
                        });
                    }

                } else {
                    element.css({
                        top: scrolls
                    });
                    $(".form-modal-float .float-popuptitle").not("[aria-hidden=\"true\"]").first().css({
                        top: scrolls
                    });
                }
            } else {
                element.css({
                    position: "relative",
                    top: 0,
                    display: "none"
                });
                $(".form-modal-float .float-popuptitle").not("[aria-hidden=\"true\"]").first().css({
                    position: "relative",
                    top: 0,
                });
                $(".float-popuptitle-button-margin").first().css({
                    'margin-top': -59
                });
            }
        });
    };
    return $(this).each(function () {
        position($(this));
    });
};
//绑定
//DIV浮动置顶效果初始化
function InitElementPosition() {
    var os = getOsNew()
    if (os.browser == "IE") {
        var buttons = $(".float-title-button-content");
        var buttonswidth = buttons.length * 125;
        $(".form-modal-float .float-popuptitle-button-div").not("[aria-hidden=\"true\"]").first().css({
            width: buttonswidth
        });
    }
    var headwidth = $(".form-modal-float .section-head-width").not("[aria-hidden=\"true\"]").first().width();
    $(".form-modal-float .under-popupline").not("[aria-hidden=\"true\"]").first().css({
        width: headwidth
    });
    $(".page-title-popupfloat").css({
        position: "relative",
        top: 0,
        display: "none"
    });
    $(".form-modal-float .float-popuptitle").not("[aria-hidden=\"true\"]").first().css({
        position: "relative",
        top: 0,
    });
    $(".float-popuptitle-button-margin").first().css({
        'margin-top': -59
    });
}
$(".page-title-float").smartFloat();
$(".page-title-popupfloat").first().smartpopupFloat();

//浏览器类型判定  
function uaMatch(ua) {
    var rMsie = /(msie\s|trident.*rv:)([\w.]+)/;
    var rFirefox = /(firefox)\/([\w.]+)/;
    var rOpera = /(opera).+version\/([\w.]+)/;
    var rChrome = /(chrome)\/([\w.]+)/;
    var rSafari = /version\/([\w.]+).*(safari)/;
    var match = rMsie.exec(ua);
    if (match != null) {
        return { browser: "IE", version: match[2] || "0" };
    }
    var match = rFirefox.exec(ua);
    if (match != null) {
        return { browser: match[1] || "", version: match[2] || "0" };
    }
    var match = rOpera.exec(ua);
    if (match != null) {
        return { browser: match[1] || "", version: match[2] || "0" };
    }
    var match = rChrome.exec(ua);
    if (match != null) {
        return { browser: match[1] || "", version: match[2] || "0" };
    }
    var match = rSafari.exec(ua);
    if (match != null) {
        return { browser: match[2] || "", version: match[1] || "0" };
    }
    if (match != null) {
        return { browser: "", version: "0" };
    }
}
function getOsNew() {
    var userAgent = navigator.userAgent;
    var browser;
    var version;
    var browserMatch = uaMatch(userAgent.toLowerCase());
    if (browserMatch.browser) {
        browser = browserMatch.browser;
        version = browserMatch.version;
    }
    return browserMatch;
}
function getOs() {
    if (navigator.userAgent.indexOf("MSIE") > 0) {
        return "IE"; //InternetExplor  
    }
    else if (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) {
        return "FF"; //firefox  
    }
    else if (isSafari = navigator.userAgent.indexOf("Safari") > 0) {
        return "SF"; //Safari  
    }
    else if (isCamino = navigator.userAgent.indexOf("Camino") > 0) {
        return "C"; //Camino  
    }
    else if (isMozilla = navigator.userAgent.indexOf("Gecko/") > 0) {
        return "G"; //Gecko  
    }
    else if (isMozilla = navigator.userAgent.indexOf("Opera") >= 0) {
        return "O"; //opera  
    } else {
        return 'Other';
    }

}
/***** 判断是否为json对象 *******
* @param obj: 对象（可以是jq取到对象）
* @return isjson: 是否是json对象 true/false
*/
isJson = function (obj) {
    var isjson = typeof (obj) == "object" && Object.prototype.toString.call(obj).toLowerCase() == "[object object]" && !obj.length;
    return isjson;
}

isJqueryObj = function (obj) {
    if (obj instanceof jQuery) {
        return true;
    } else {
        return false;
    }
}

function setValToInput(jsonStr) {
    var json = JSON.parse(jsonStr);
    var auto = $("#" + json.id);
    if (auto && json.value) {
        auto.val(json.value);
    }
}

function autoCompleteSetVal(jsonStr) {
    setValToInput(jsonStr);
}

function autoCompleteSetHiddenVal(jsonStr) {
    setValToInput(jsonStr);
}

function rightClick(jsonStr) {
    try {
        debugger;
        var json = JSON.parse(jsonStr);
        var treeId = json.treeId;
        var text = json.text;
        var textIndex = json.textIndex;
        var rightClickText = json.rightClickText;

        var tree = $("#" + treeId);
        var selectedNode = tree.find("a").filter(function (index) {
            return this.innerHTML == text;
        }).eq(textIndex - 1);

        selectedNode.triggerHandler("contextmenu");

    } catch (e) {

    }
}

function getToken() {
    return $("[name=__RequestVerificationToken]").val();
}


function showMessageFromCookie() {

    var cookieObj = CookieHelper.getCookieObj("MessageKey");
    if (cookieObj != null) {
        if (cookieObj.MessageType != null && cookieObj.MessageType != undefined && cookieObj.MessageType.indexOf("Failure") != -1) {
            showMessage("error", ChartCodeToString(cookieObj.Message));
            //buildError();
        } else {
            showMessage("info", ChartCodeToString(cookieObj.Message));
            //buildInfo();
        }
    }
}

//var utility = {
//    fillPlaceHolder : function(placeHolderContainer, fillerDatas){
//        var $placeHolderContainer;
//        var fillerDatas;
//        var $fillerDatasWrap;

//        if (isJqueryObj(placeHolderContainer)) {
//            $placeHolderContainer = placeHolderContainer;
//        } else {
//            $placeHolderContainer = $("#" + placeHolderContainer.trim());
//        }

//        if (isJson(fillerDatas)) {

//        } else if(fillerDatas instanceof String){
//            $fillerDatasWrap = $("<div>" + fillerDatas + "</div>");
//            var placeHoders = $placeHolderContainer.find(".placehoder");
//            for (var i = 0; i < placeHoders.length; i++) {
//                var placeHoderId = $(placeHoders[i]).attr("data-element");
//                var placePre = placeHoderId.split("-")[0];
//                var contentClassName = placePre + "-content";

//                // replace one placeHolder, one placeHoder map to multip palceContent
//                var placeContents = $divWrap.find("." + contentClassName);
//                var htmlContents = "";
//                for (var j = 0; j < placeContents.length; j++) {
//                    htmlContents += $(placeContents[j]).html();
//                }
//                $("#" + placeHoderId).html(htmlContents);
//            }
//        }
//    }
//}