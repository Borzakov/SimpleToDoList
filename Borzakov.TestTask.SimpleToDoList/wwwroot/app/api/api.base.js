(function (angular) {
    'use strict';
    angular.module("SimpleToDoListClient.Api")
        .factory("baseApi", ["$http", baseApi]);
    function baseApi($http) {
        function nop() {
        }
        function mapResponseData(response) {
            return response.data;
        }
        function errorHandler(msg) {
            msg = msg || "Unexpected Error";
            return function (response) {
                if (response.status === 401) {
                    throw 'You are not authorized to use this service.';
                }
                if (!response.data)
                    response.data = {};
                if (response.data.exceptionMessage) {
                    throw response.data.exceptionMessage;
                }
                throw (response.data.errors || response.data.message || msg);
            }
        }
        function baseApi() {
            var self = this;
            self.invokePost = function (url, data) {
                //var token = svdTokenManager.access_token;
                //var config = {};

                //if (token) {
                //    config = { headers: { 'Authorization': 'Bearer ' + token } };
                //}config
                return $http.post(url, data)
                    .then(mapResponseData, errorHandler('Error in ' + url + ' providers'));
            }
        }
        return new baseApi();
    };
})(angular);