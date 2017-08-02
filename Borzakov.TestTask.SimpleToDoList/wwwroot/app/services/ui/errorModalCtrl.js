(function (angular) {
    'use strict';
    var app = angular.module("SimpleToDoListClient");
    function modalFunction($uibModalInstance, items) {
        var $ctrl = this;
        $ctrl.message = items.message;

        $ctrl.ok = function () {
            $uibModalInstance.close('');
        };
    }

    app.controller('errorModalCtrl', ['$uibModalInstance', 'items', modalFunction]);
})(angular);