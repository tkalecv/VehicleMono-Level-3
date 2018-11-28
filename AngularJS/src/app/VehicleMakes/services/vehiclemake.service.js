(function () {
    "use strict";

    angular.module("VehicleMakeModule", []).factory("vMakeService", [$http,
        function ($http) {
            return {
                get: function () {
                    return $http({ method: 'GET', url: 'http://localhost:51134/api/VehicleMake' });
                }
            };
        }]);

});