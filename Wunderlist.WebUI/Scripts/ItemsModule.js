var itemsModule = angular.module("itemsApp", []);

itemsModule.controller("addController", function ($scope) {

    $scope.tasks = [{ name: 'AAAAAAAAAAAAAAAA', completed : false },
        { name: 'BBBBBBBBBBBBBBBBB', completed : false },
        { name: 'CCCCCCCCCCCCCCc', completed : true }
    ];

    $scope.hideCompleted = true;

    $scope.show = function () {
        $scope.hideCompleted = !$scope.hideCompleted;
        console.dir($scope.hideCompleted);
    };

    $scope.addItem = function () {
        if (this.name) {
            $scope.tasks.push( {name : $scope.name, completed : false});
            $scope.name = "";
            console.log($scope.tasks);
        }
    };
    
    $scope.checkTask = function (task) {
        task.completed = !task.completed;
    };
});