'use strict';

var customer = (function () {
    var searchFormContainer = '#search-form-container',
        customersContainer = '#customers';

    var init = function () {
        $(searchFormContainer).delegate('form', 'submit', function (e) {
            e.preventDefault();
            var name = $(this).find('#Name').val();
            var requestUrl = "/Customer/Search?name=" + name;
            $.ajax({
                url: requestUrl,
                type: 'GET',
                async: false,
                success: function (data) {
                    $(customersContainer).html(data);
                }
            });
        })
    };

    return {
        init: init
    }
})();