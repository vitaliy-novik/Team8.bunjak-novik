var itemsModule = angular.module("itemsApp", []);

itemsModule.controller("addController", function ($scope, $http) {

    $scope.tasks = [{ name: 'AAAAAAAAAAAAAAAA', completed: false },
        { name: 'BBBBBBBBBBBBBBBBB', completed: false },
        { name: 'CCCCCCCCCCCCCCc', completed: true }
    ];

    $scope.newTask = {};

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
    
    $scope.checkTask = function (task) {
        task.completed = !task.completed;
    };
});