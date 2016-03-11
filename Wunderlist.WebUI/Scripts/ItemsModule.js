var itemsModule = angular.module("itemsApp", []);

itemsModule.controller("addController", function ($scope, $http) {

    $scope.tasks = [];

    $scope.lists = [];

    $scope.activeList = "Inbox";

    angular.element(document).ready(function () {
        $http.get('../api/ToDoList').success(function (data) {
            console.dir(data);
        });

        $http.get('../api/ToDoList/' + $scope.activeList).success(function (data) {
            console.dir(data);
        });
    });    

    $scope.newTask = {};

    $scope.newList = {};

    $scope.hideCompleted = true;

    $scope.show = function () {
        $scope.hideCompleted = !$scope.hideCompleted;
        console.dir($scope.hideCompleted);
    };

    $scope.addItem = function () {
        if (this.newTask.name) {
            $scope.newTask.completed = false;
            $scope.newTask.List = 'inbox';
            $scope.newTask.Date = null;
            $http.post('../api/ToDoItems', $scope.newTask);
            $scope.tasks.push( $scope.newTask );
            $scope.newTask.name = "";
            console.log($scope.tasks);
        }
    };

    $scope.addList = function () {
        if (this.newList.name) {
            console.log("added");
            $http.post('../api/ToDoList', $scope.newList);
        }
    };
    
    $scope.checkTask = function (task) {
        task.completed = !task.completed;
    };
});