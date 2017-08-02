(function (angular) {
    'use strict';
    angular.module('SimpleToDoListClient.Api', []);
    angular
        .module('SimpleToDoListClient', [
            'ui.router',
            'ui.bootstrap',
            'SimpleToDoListClient.Api'
        ])
        .config(['$urlRouterProvider', '$stateProvider', function ($urlRouterProvider, $stateProvider) {
            $urlRouterProvider.otherwise('/');

            $stateProvider
                .state('list', {
                    url: '/',
                    templateUrl: 'app/templates/list.html',
                    controller: 'listCtrl',
                    controllerAs: '$ctrl'
                });
        }]);
})(angular);