var itemsModule = angular.module("itemsApp", [])

itemsModule.controller("addController", function ($scope, $http) {

    $scope.tasks = [];

    $scope.lists = [];

    $scope.activeList = "";

    $scope.profile = [];

    angular.element(document).ready(function () {
        $http.get('../api/ToDoList').success(function (data) {
            console.log(data);
            $scope.lists = data;
            $scope.activeList = $scope.lists[0].id;
            
            
        }).then(function () {
            $http.get('../api/ToDoList/' + $scope.activeList).success(function (data) {
                console.log(data);
                $scope.tasks = data;            
            }).then(function () {
                var e = document.getElementById($scope.activeList).parentElement;
                console.log(e);
                e.classList.add("active");
            });
            
        });

        $http.get('../Profile/GetProfile').success(function (data) {
            if (data) {
                $scope.profile.photo = data.photo;
                $scope.profile.userName = data.userName;
            } else {
                alert('Sorry, there is some error.');
            }
        });
    });

    //--------------------------------------------------------------------------------------------------

    $scope.newTask = {};

    $scope.newList = {};

    $scope.hideCompleted = true;
    
    $scope.selectList = function (param) {
        console.log(param);
        if ($scope.activeList != param.id) {
            var old = document.getElementById($scope.activeList).parentElement;
            console.log(old);
            old.classList.remove("active");
            console.log(old);
            $scope.activeList = param.id;
            document.getElementById(param.id).parentElement.classList.add("active");
            $http.get('../api/ToDoList/' + $scope.activeList).success(function (data) {
                $scope.tasks = data;
            });
        }        
    }

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
                $scope.lists.push($scope.newList);
                $scope.newList = null;
            });
        }
    };
    
    $scope.checkTask = function (task) {
        task.completed = !task.completed;
        task.List = $scope.activeList;
        console.log(task);
        $http.put('../api/ToDoItems/' + task.id, task).success(function () {            
            document.getElementById('wl3-complete').play();
        });
        
    };


});