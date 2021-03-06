﻿// https://github.com/zz9pa/extjsTypescript

var adapter = function (global) {

    // copy properties from source to target using mapping
    function copy (source, target, mapping) {
        for (var name in source) {
            var rename = name;
            var value = source[name];

            if (typeof mapping === 'object') {

                var config = mapping[name];

                switch (typeof config) {
                    case 'boolean':
                        if (config === false) {
                            value = undefined;
                        }
                        break;
                    case 'string':
                        rename = config;
                        break;
                    case 'object':
                        if (typeof config.name === 'string') {
                            rename = config.name;
                        }

                        if (typeof config.convert === 'function') {
                            value = config.convert(value, target);
                        }

                        if (typeof value === 'undefined' && typeof config.default !== 'undefined') {
                            value = config.default;
                        }

                        // type: 'string|object'
                        if (typeof config.type === 'string' && config.type.split('|').indexOf(typeof value) < 0) {
                            value = undefined;
                        }
                        break;

                }
            }
            if (typeof value !== 'undefined') {
                target[rename] = value;
            }
        }
    };

    function getScriptElement() {
        var elements = document.getElementsByTagName('script');
        for (var i = 0; i < elements.length; i++) {
            var element = elements[i];
            var src = element.getAttribute('src');
            if (src && src.indexOf('y7-adapter.js') >= 0) {
                return element;
            }
        }
    };

    function getBaseUrl(url) {
        var path = url.split('/');
        path.pop();
        return path.length ? path.join('/') : '.';
    };

    function getUrlParams(url) {
        var queryIndex = url.lastIndexOf("?");
        if (queryIndex < 0) {
            return {};
        }

        var queryString = url.substring(queryIndex + 1);
        var tokens = queryString.split('&');
        var params = {};
        for (var i = 0; i < tokens.length; i++) {
            var keyValuePair = pair.split('=');
            params[keyValuePair[0]] = keyValuePair.length > 1 ? keyValuePair[1] : keyValuePair[0];
        }

        return params;
    };

    //
    // setup local & global variables

    var scriptEl = getScriptElement();

    window.y7Adapter = (function () {
        var scriptEl = scriptEl;
        var cache = {};
        var merge = function (destination) {
        };

        return {
            copy: copy,

            // adapter script element
            getEl: function () {
                return scriptEl;
            },

            merge: merge,

            // open window
            open: function (url, name, config) {
                config = merge({}, config);
                window.open(url, name);
            },

            // publish an event
            publish: function (event, arg) {
                if (cache.hasOwnProperty(event)) {
                    var arr = cache[event];
                    for (var i = 0; i < arr.length; ++i) {
                        try {
                            var fn = arr[i];
                            if (typeof fn === 'function') {
                                fn.call(null, arg);
                            }
                        } catch (e) {
                            if (console && console.error) {
                                console.error(e);
                            }
                        }
                    }
                }
            },

            // subscribe to event
            subscribe: function (event, callback) {
                if (!cache.hasOwnProperty(event)) {
                    cache[event] = [];
                }
                if (0 > cache[event].indexOf(callback)) {
                    cache[event].push(callback);
                }
            },

            // unsubscribe to event
            unsubscribe: function (event, callback) {
                if (cache.hasOwnProperty(event)) {
                    var arr = cache[event];
                    for (var idx = arr.indexOf(callback) ; idx >= 0; idx = arr.indexOf(callback)) {
                        arr.splice(idx, 1);
                    }
                }
            }
        };
    }());

    for (var key in scriptParams) {
        window.y7Adapter[key] = scriptParams[key];
    }

    for (var i = 0; i < scriptEl.attributes.length; i++) {
        var attr = scriptEl.attributes[i];
        window.y7Adapter[attr.name] = attr.value;
    }

    var scriptUrl = window.y7Adapter['src'];
    var scriptParams = getUrlParams(scriptUrl);
    var baseUrl = window.location.origin; //getBaseUrl(scriptUrl);

    window.y7Adapter['baseUrl'] = baseUrl;
    window.y7Adapter['host'] = window.location.host;
    window.y7Adapter['origin'] = window.location.origin;
    
    var target = "head";
    if (document.getElementsByTagName("body").length > 0) {
        target = "body";
    }

    // load require js
    var loaderScript = document.createElement('script');
    loaderScript.setAttribute('data-main', baseUrl + '/Scripts/main');
    loaderScript.setAttribute('src', baseUrl + '/scripts/require.js?v=1');

    // load html5 shiv js
    var html5ShivScript = document.createElement('script');
    html5ShivScript.setAttribute('src', baseUrl + '/scripts/html5shiv.js');

    document.getElementsByTagName(target)[0].appendChild(loaderScript);
    //document.getElementsByTagName(target)[0].appendChild(html5ShivScript);
}(this);
