(function () {
    var controllerId = 'app.views.phonebook.index';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.person',
        function($scope, personService) {
            var vm = this;

            vm.persons = [];

            personService.getPeople({}).then(function (result) {
                vm.persons = result.data.items;
            });


        }
    ]);
})();