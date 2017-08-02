(function (angular) {
    'use strict';
    angular.module("SimpleToDoListClient.Api")
        .factory("ourApi", ["baseApi", ourApi]);
    function ourApi(baseApi) {
        return {
            getTaskList: function () {
                return baseApi.invokePost("./Api/GetTaskList", {});
            },
            addTask: function (param) {
                return baseApi.invokePost("./Api/AddTask", param);
            },
            checkTask: function (param) {
                return baseApi.invokePost("./Api/CheckTask", param);
            }
        };
    }
})(angular);