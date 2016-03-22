var itemsModule = angular.module("itemsApp", [])

itemsModule.controller("addController", function ($scope, $http) {

    $scope.tasks = [];

    $scope.lists = [];

    $scope.activeList = "";
    $scope.activeTask = {};

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

    $scope.setStar = function (task) {
        var star = document.getElementById(task.id + 'star');
        star.classList.toggle('hidden');
        var nostar = document.getElementById(task.id + 'nostar');
        nostar.classList.toggle('hidden');
    }
    
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

    $scope.editTask = function (task) {
        console.log(task);
        $scope.activeTask = task;
        $scope.openbox('detail');
    }

    $scope.deleteTask = function () {
        $http.delete('../api/ToDoItems/' + $scope.activeTask.id).success(function () {
            $http.get('../api/ToDoList/' + $scope.activeList).success(function (data) {
                $scope.tasks = data;
                $scope.openbox('detail');
            });
        });
    }

    $scope.editNote = function () {
        console.dir('aaaaaa');
        $http.put('../api/ToDoItems/' + $scope.activeTask.id, $scope.activeTask).success(function () {
            $scope.openbox('detail');
        });
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
                openbox('addList');
            });
        }
    };
    
    //------------------------------------------
    $scope.list;
    $scope.editToDoListShowDialog = function (list) {
        $scope.list = list;
        openbox('editToDoList');
    }

    $scope.editNameToDoList = function () {
        if ($scope.list.name) {
            $http.put('../api/ToDoList', $scope.list).success(function () {
                openbox('editToDoList');
                console.log($scope.list.name)
            });
        }
    }


    $scope.deleteList = function ()
    {
        $http.delete('../api/ToDoList/' + $scope.activeList).success(function () {
            $http.get('../api/ToDoList').success(function (data) {
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
                $scope.openbox('editToDoList');
            });
        });
    }

    $scope.checkTask = function (task) {
        task.completed = !task.completed;
        task.List = $scope.activeList;
        console.log(task);
        $http.put('../api/ToDoItems/' + task.id, task).success(function () {            
            document.getElementById('wl3-complete').play();
        });
        
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

    $scope.openbox = function (id) {
        var display = document.getElementById(id).style.display;
        if (display == 'none') {
            document.getElementById(id).style.display = 'block';
        } else {
            document.getElementById(id).style.display = 'none';
        }
    }
});