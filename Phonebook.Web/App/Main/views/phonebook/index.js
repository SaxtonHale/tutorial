(function () {
    var controllerId = 'app.views.phonebook.index';
    angular.module('app').controller(controllerId, [
        '$scope', 'abp.services.app.person', '$uibModal',
        function ($scope, personService, $uibModal) {
            var vm = this;

            vm.persons = [];


            function getPeople() {
                personService.getPeople({}).then(function (result) {
                    vm.persons = result.data.items;
                });
            }

            vm.createPerson = function() {
                openModal(null);
            }

            vm.editPerson = function(id) {
                openModal(id);
            }

            vm.deletePerson = function(id) {
                abp.message.confirm("Do You Want?",
                    function(confirm) {
                        if (confirm) {
                            personService.deletePerson({
                                id: id
                            }).then(function(result) {
                                getPeople();
                            });
                        }
                    });
            }

            function openModal(id) {
                var modalInstance = $uibModal.open({
                    templateUrl: '/App/Main/views/phonebook/createModal.cshtml',
                    controller: 'app.views.phonebook.createModal as vm',
                    backdrop: 'static',
                    resolve: {
                        personId: function() {
                            return id;
                        }
                    }
                });

                modalInstance.result.then(function () {
                    getPeople();
                });
            }

            getPeople();
        }
    ]);
})();