var itemsModule = angular.module("itemsApp", [])

itemsModule.controller("addController", function ($scope, $http) {

    $scope.tasks = [];

    $scope.lists = [];

    $scope.activeList = "";

    $scope.profile = [];

    $scope.hideCreateList = false;
    $scope.showCreateList = function () {
        $scope.hideCreateList = !$scope.hideCreateList;
    }

    angular.element(document).ready(function () {
        $http.get('../api/ToDoList').success(function (data) {
            console.log(data);
            $scope.lists = data;
            $scope.activeList = $scope.lists[0].name;
        }).then(function () {
            $http.get('../api/ToDoList/' + $scope.activeList).success(function (data) {
            console.log(data);
            $scope.tasks = data;            
        });
        });

        $http.get('../Profile/GetProfile').success(function (data) {
            if (data) {
                $scope.profile.photo = data.photo;
                $scope.profile.userName = data.userName;
                $scope.profile.email = data.email;
            } else {
                alert('Sorry, there is some error.');
            }
        });
    });

    //--------------------------------------------------------------------------------------------------

    $scope.newTask = {};

    $scope.newList = {};

    $scope.hideCompleted = true;

    $scope.show = function () {
        $scope.hideCompleted = !$scope.hideCompleted;
    };

    $scope.addItem = function () {
        if (this.newTask.name) {
            $scope.newTask.completed = false;
            $scope.newTask.List = $scope.activeList;
            $scope.newTask.Date = null;
            $http.post('../api/ToDoItems', $scope.newTask).success(function () {
                $scope.tasks.push($scope.newTask);
                $scope.newTask = null;
                console.log($scope.tasks);
            });
            
        }
    };

    $scope.addList = function () {
        if (this.newList.name) {
            $http.post('../api/ToDoList', $scope.newList).success(function () {
                $scope.hideCreateList = false;
                $scope.lists.push($scope.newList);
                $scope.newList = null;
            });
        }
    };
    
    $scope.checkTask = function (task) {
        task.completed = !task.completed;
        document.getElementById('wl3-complete').play();
    };

    $scope.newUserName = {};
    $scope.editUserName = function () {
        if (this.newUserName.name) {
            $http.post('../Profile/EditName',
                $scope.newUserName).success(function () {
                $scope.profile.userName = $scope.newUserName.name;
            });
            console.log(typeof (this.newUserName.name));
        }
    };

    $scope.password = {}
    $scope.editPassword = function () {
        if (this.password.confirmPassword == this.password.newPassword) {
            $http.post('../Account/ChangePassword',
                $scope.password).success(function () {
                    document.getElementById('errorPassword').textContent = 'Парорь изменён';
                });
        }
        else document.getElementById('errorPassword').textContent='Пароли должны совпадать';
    };
});