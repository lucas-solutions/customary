(function (window, require, define, undefined) {

    define("App.MessageController", ["angular"], function (angular) {

        var $injector = angular.injector(["App.utils"]);

        var pubsub = $injector.get("pubsub");

        window.MessageController = function ($scope/*, injectables*/) {
        };

        // The 'ng-controller' directive does this behind the scenes
        //injector.instantiate(MyController);

        return MessageController;
    });

})(window, require, define);