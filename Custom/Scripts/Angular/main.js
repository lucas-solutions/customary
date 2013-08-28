/* AngulasJs Bootstrap */
(function (window, document, require, define, undefined) {

    'use strict';

    require.config({

        deps: ["main"],

        paths: {
            angular: "http://code.angularjs.org/1.1.5/angular.min",
            /*jQuery: "http://code.jquery.com/jquery-1.10.0.min",*/
            jQuery: "http://code.jquery.com/jquery-2.0.0.min",

            "App.utils": "utils",
            "App.account": "account",
            "App.message": "message"
        },

        shim: {
            angular: {
                deps: [/*"jQuery"*/]
            },

            "App.utils": {
                deps: ["angular"]
            }
        }
    });



    require(["adapter", "angular", "App.utils"], function (adapter) {

        var module = angular.module("App.main", ["App.utils"]);

        module.run(function () {
            $(".widget-container").each(function (index, el) {
            });
        });

        angular.element(document).ready(function () {
            angular.bootstrap(document, ["App.main"]);
        });

    });

})(window, document, require, define);