(function () {
    angular.module('app').controller('app.views.phonebook.createModal', [
        '$scope', '$uibModalInstance', 'abp.services.app.person', 'personId',
        function ($scope, $uibModalInstance, personAppService, personId) {
            var vm = this;


            vm.personId = personId;
            vm.person = {};

            vm.save = function () {
                if (vm.personId === null) {
                    vm.person.id = null;
                }
                personAppService.createOrUpdatePerson(vm.person).then(function (result) {
                    abp.notify.info(App.localize('SavedSuccessfully'));
                    $uibModalInstance.close();
                });
            };

            vm.cancel = function () {
                $uibModalInstance.dismiss({});
            };

            function init() {
                if (vm.personId !== null) {
                    personAppService.getPersonForEdit({
                        id: vm.personId
                    }).then(function (result) {
                        vm.person = result.data;
                    });
                }
            }

            init();
        }
    ]);
})();