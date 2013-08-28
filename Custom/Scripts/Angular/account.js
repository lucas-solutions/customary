(function (window, define, undefined) {

    'use strict';

    define("App.account", ["angular"], function (angular) {

        var securityQuestion = {
            require: "ngModel",
            link: function (scope, elm, attrs, ctrl) {
                // view -> model
                elm.bind('blur', function () {
                    scope.$apply(function () {
                        ctrl.$setViewValue(elm.html());
                    });
                });

                // model -> view
                ctrl.$render = function (value) {
                    elm.html(value);
                };

                // load init value from DOM
                ctrl.$setViewValue(elm.html());
            }
        };

        var securityAnswer = {
            require: "ngModel",
            link: function (scope, elm, attrs, ctrl) {
                // view -> model
                elm.bind('blur', function () {
                    scope.$apply(function () {
                        ctrl.$setViewValue(elm.html());
                    });
                });

                // model -> view
                ctrl.$render = function (value) {
                    elm.html(value);
                };

                // load init value from DOM
                ctrl.$setViewValue(elm.html());
            }
        };

        var passwordCurrent = {
            require: "ngModel",
            link: function (scope, elm, attrs, ctrl) {
                // view -> model
                elm.bind('blur', function () {
                    scope.$apply(function () {
                        ctrl.$setViewValue(elm.html());
                    });
                });

                // model -> view
                ctrl.$render = function (value) {
                    elm.html(value);
                };

                // load init value from DOM
                ctrl.$setViewValue(elm.html());
            }
        };

        var passwordUpdate = {
            require: "ngModel",
            link: function (scope, elm, attrs, ctrl) {
                // view -> model
                elm.bind('blur', function () {
                    scope.$apply(function () {
                        ctrl.$setViewValue(elm.html());
                    });
                });

                // model -> view
                ctrl.$render = function (value) {
                    elm.html(value);
                };

                // load init value from DOM
                ctrl.$setViewValue(elm.html());
            }
        };

        var passwordConfirm = {
            require: "ngModel",
            link: function (scope, elm, attrs, ctrl) {
                // view -> model
                elm.bind('blur', function () {
                    scope.$apply(function () {
                        ctrl.$setViewValue(elm.html());
                    });
                });

                // model -> view
                ctrl.$render = function (value) {
                    elm.html(value);
                };

                // load init value from DOM
                ctrl.$setViewValue(elm.html());
            }
        };

        var profile = {
            require: "ngModel",
            link: function (scope, elm, attrs, ctrl) {
                // view -> model
                elm.bind('blur', function () {
                    scope.$apply(function () {
                        ctrl.$setViewValue(elm.html());
                    });
                });

                // model -> view
                ctrl.$render = function (value) {
                    elm.html(value);
                };

                // load init value from DOM
                ctrl.$setViewValue(elm.html());
            }
        };

        var forgotUsername = {
            require: "ngModel",
            link: function (scope, elm, attrs, ctrl) {
            }
        };

        var forgotPasssword = {
            require: "ngModel",
            link: function (scope, elm, attrs, ctrl) {
            }
        };

        var passwordReset = {
            require: "ngModel",
            link: function (scope, elm, attrs, ctrl) {
            }
        };

        var ProfileController = function ($scope) {

            $scope.data = {
            };

            $scope.i18n = {
            };

            $scope.view = {
            };

            $scope.save = function () {
            };
        };

        var ForgotUsernameController = function ($scope) {

            $scope.data = {
            };

            $scope.i18n = {
            };

            $scope.view = {
            };

            $scope.save = function () {
            };
        };

        var ForgotPasswordController = function ($scope) {

            $scope.data = {
            };

            $scope.i18n = {
            };

            $scope.view = {
            };

            $scope.save = function () {
            };
        };

        var PasswordResetController = function ($scope) {

            $scope.data = {
            };

            $scope.i18n = {
            };

            $scope.view = {
            };

            $scope.save = function () {
            };
        };

        var module = angular.module('App.account', []);

        module.config(function ($provide, $compileProvider, $filterProvider) {
            $provide.directive('profile', profile);
            $provide.directive('forgotUsername', forgotUsername);
            $provide.directive('forgotPassword', forgotPassword);
            $provide.directive('passwordReset', passwordReset);
            $provide.controller('ProfileController', ProfileController);
            $provide.controller('ForgotUsernameController', ForgotUsernameController);
            $provide.controller('ForgotPasswordController', ForgotPasswordController);
            $provide.controller('PasswordResetController', PasswordResetController);
        });

        return module;

    });

})(window, define);
