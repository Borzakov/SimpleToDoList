(function (angular) {
    "use strict";
    angular
        .module("SimpleToDoListClient")
        .controller("listCtrl",
        [
            "$scope", "$uibModal", "$document", "ourApi",
            function ($scope, $uibModal, $document, ourApi
                ) {
                var $ctrl = this;
                $ctrl.taskList = [];
                $ctrl.taskCount = 0;
                $ctrl.newName = undefined;

                ourApi.getTaskList().then(function (response) {
                    if (response.isSuccess) {
                        $ctrl.taskList = response.data;
                        $ctrl.taskCount = $ctrl.taskList.length;
                    } else {
                        //show error
                    }
                });

                $ctrl.openModal = function (size, parentSelector, message) {
                    var parentElem = parentSelector
                        ? angular.element($document[0].querySelector(parentSelector))
                        : undefined;

                    var templateUrl = "";
                    var controller = "";
                    var items = {};
                    templateUrl = "app/templates/ui/errorModal.html";
                    controller = "errorModalCtrl";
                    items = { message: message };
                    
                    var modalInstance = $uibModal.open({
                        animation: true,
                        ariaLabelledBy: "modal-title",
                        ariaDescribedBy: "modal-body",
                        templateUrl: templateUrl,
                        controller: controller,
                        controllerAs: "$ctrl",
                        size: size,
                        appendTo: parentElem,
                        resolve: {
                            items: items
                        }
                    });
                    //After modal closed
                    /*modalInstance.result.then(function (result) {
                        if (result !== null) {
                            $rootScope.isBusy = true;
                        }
                    },
                        function () {

                    });*/
                };

                $ctrl.addTask = function () {
                    if ($ctrl.newName !== undefined) {
                        ourApi.addTask({ text: $ctrl.newName})
                            .then(function (response) {
                                if (response.isSuccess) {
                                    $ctrl.taskList.unshift({ taskId: response.data, text: $ctrl.newName, isDone: false });
                                    $ctrl.taskCount++;
                                    $ctrl.newName = undefined;
                                } else {
                                    //show error
                                    $ctrl.openModal("sm", ".my-container", response.error);
                                }
                            });
                    }
                };
                $ctrl.checkTask = function (taskId) {
                    ourApi.checkTask(taskId)
                        .then(function (response) {
                            if (response.isSuccess) {
                                //all good
                            } else {
                                //show error and (un)check back
                                $ctrl.taskList.forEach(function (element, index, array) {
                                    if (element.taskId === taskId) {
                                        array[index].isDone = !array[index].isDone;
                                    }
                                });
                                $ctrl.openModal("sm", ".my-container", response.error);
                            }
                        });
                };
            }
        ]);
})(angular);