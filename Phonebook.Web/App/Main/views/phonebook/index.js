(function () {
    var controllerId = 'app.views.phonebook.index';
    angular.module('app').controller(controllerId, [
        '$scope',
        function ($scope) {
            var vm = this;

            $scope.$on('$viewContentLoaded', function () {
                Metronic.initAjax();
            });

        }
    ]);
})();