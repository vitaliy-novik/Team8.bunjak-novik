var profileModule = angular.module('profileApp', []);

profileModule.controller('profileController', function ($scope, $http) {

    $scope.profile;

    angular.element(document).ready(function () {
        $http.get('../Profile/GetProfile').success(function (data) {
            if (data) {
                $scope.profile.imag = "<img "
                           + "src='" + "data.photo:image/jpg;base64,"
                           + data.base64imgage + "'/>";
                //$("#divMyLetterImage").html(imag)
                $scope.profile.userName = data.userName;
                alert('Yea.');
            } else {
                alert('Sorry, there is some error.');
            }
        });
    });
});