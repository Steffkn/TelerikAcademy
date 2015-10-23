define(['jquery', 'q'], function ($, q) {
    var HttpRequester = (function () {
        var makeRequest = function (url, type, data, headers) {
            var deffered = q.defer();

            $.ajax({
                url: url,
                type: type,
                data: data ? JSON.stringify(data) : "",
                contentType: 'application/json',
                headers: headers ? headers : '',
                timeout: 5000,
                success: function (resultData) {
                    deffered.resolve(resultData);
                },
                error: function (errorData) {
                    deffered.reject(errorData);
                }
            });

            return deffered.promise;
        };

        var getJSON = function (url) {
            return makeRequest(url, 'GET');
        };

        var postJSON = function (url, data, headers) {
            return makeRequest(url, 'POST', data, headers);
        };

        var put = function (url, headers) {
            return makeRequest(url, 'PUT', null, headers);
        };

        return {
            getJSON: getJSON,
            postJSON: postJSON,
            put: put
        }
    }());

    return HttpRequester;
});