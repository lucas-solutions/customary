(function (window, define, undefined) {

    'use strict';

    define("App.utils", ["angular"], function () {

        /*** PUBSUB ***/
        var pubsub = function () {
            var cache = {};
            return {
                publish: function (topic, args) {
                    cache[topic] && $.each(cache[topic], function () {
                        this.apply(null, args || []);
                    });
                },

                subscribe: function (topic, callback) {
                    if (!cache[topic]) {
                        cache[topic] = [];
                    }
                    cache[topic].push(callback);
                    return [topic, callback];
                },

                unsubscribe: function (handle) {
                    var t = handle[0];
                    cache[t] && $.each(cache[t], function (idx) {
                        if (this == handle[1]) {
                            cache[t].splice(idx, 1);
                        }
                    });
                }
            }
        };
        /*** PUBSUB ***/

        var module = angular.module('App.utils', []);

        module.config(function ($provide, $compileProvider, $filterProvider) {
            $provide.factory('pubsub', pubsub);
        });

        return module;
    });

})(window, define);