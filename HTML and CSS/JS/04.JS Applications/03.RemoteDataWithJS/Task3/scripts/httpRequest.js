/// <reference path="libs/jquery-2.1.1.min.js" />
define(['../scripts/libs/jquery-2.1.1.min'], function () {
    var HTTPRequester = (function () {
        function getPromise(requestURL, header, data) {
            var type, _data;
            if (data) {
                type = 'POST';
                _data = JSON.stringify(data)
            } else {
                if (header) {
                    type = 'GET';
                    _data = {};
                }
                else {
                    type = 'POST';
                    _data = { _method: 'delete' };
                }
            }

            return $.ajax({
                beforeSend: function (xhrObj) {
                    if (header) {
                        xhrObj.setRequestHeader("Content-Type", header);
                        xhrObj.setRequestHeader("Accept", header);
                    }
                },
                data: _data,
                url: requestURL,
                type: type
            });

        }

        function HTTPRequester() {

        }

        HTTPRequester.getJSON = function (requestURL, header) {
            return getPromise(requestURL, header);
        };

        HTTPRequester.postJSON = function (requestURL, header, data) {
            return getPromise(requestURL, header, data);
        };

        return HTTPRequester;
    }());
    return HTTPRequester;
});


