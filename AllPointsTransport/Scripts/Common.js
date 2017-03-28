var Common = {};
Common.AjaxCall = function (url, data, SuccessCallBack, async) {
    $.ajax({
        url: url,
        async: async !== undefined && async !== '' ? async : true,
        type: 'post',
        cache: false,
        data: data,
        success: function (data) {
            SuccessCallBack(data);
        },
        failure: Common.FailedCallBack,
        error: Common.ErrorCallBack,
    });
};

Common.AjaxCallAsync = function (url, data, SuccessCallBack) {
    Common.AjaxCall(url, data, SuccessCallBack, true);
};

Common.AjaxCallSync = function (url, data, SuccessCallBack) {
    Common.AjaxCall(url, data, SuccessCallBack, false);
};

Common.FailedCallBack = function (a,b,c,d,e) {

};

Common.ErrorCallBack = function (a,b,c,d,e) {

};

Common.IsNullOrWhiteSpace = function (str) {
    return str == null || str == '' || str == undefined || str == 'undefined';
};