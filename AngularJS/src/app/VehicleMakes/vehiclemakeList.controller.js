(function (angular) {
    "use strict";

    angular.module("VehicleMakeModule", []).controller("VMakeListController", ["$scope", "vMakeService",
        function ($scope, vMakeService) {

            var vm = this;
            $scope.vm = vm;

            vm.vehiclemakes = [];

            vMakeService.get().then(function (response) {
                var vehiclemakes = response.data;
                vm.vehiclemakes = vehiclemakes;
            });
        }]);

})(angular);
