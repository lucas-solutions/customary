/**********************************************************************************************************************************
**                                                = Tradestation Widget Adapter =                                                **
**                                                                                                                               **
**   After including the adapter script in your HTML, user Require JS to get the adapter instance.                               **
**   The module is defined ad 'ts-adapter'.                                                                                      **
**                                                                                                                               **
**   Example:                                                                                                                    **
**                                                                                                                               **
**     var adapter = require('ts-adapter');                                                                                      **
**                                                                                                                               **
**                 or                                                                                                            **
**                                                                                                                               **
**     define(['ts-adapter'], function (adapter) {                                                                               **
**       // your code using adapter goes here                                                                                    **
**     };                                                                                                                        **
**                                                                                                                               **
**   The adapter exposes the following properties and functions:                                                                 **
**                                                                                                                               **
**     -                                                                                                                         **
**     -                                                                                                                         **
**     -                                                                                                                         **
**     - getDataset(element)                   : Returns an object with the data-* attributes in the element.                    **
**     - loadScript(url|element, callback)     :                                                                                 **
**     - loadStyle(url, callback)              :                                                                                 **
**     - redirect(url)                         :                                                                                 **
**     -                                                                                                                         **
**     -                                                                                                                         **
**                                                                                                                               **
***********************************************************************************************************************************/

// Aliasing window and undefined
(function (window, undefined) {
    
    // *** BEGIN CORS HANDLING **

    function loadIFrame(iframe, content) {
        var doc = iframe.contentWindow.document;
        doc.write(content);
        doc.close();
    };

    function makeCORSRequest(url, method) {
        if (typeof XMLHttpRequest === 'undefined') {
            return null;
        }

        var xhr = new XMLHttpRequest();
        if ("withCredentials" in xhr) {
            // In order to transfer cookies with CORS
            // request should send identifying information.
            // Server should respond with Access-Control-Allow-Credentials
            // in adition to Access-Control-Allow-Origin otherwise
            // the browser will reject the response
            xhr.withCredentials = true;
            // If method is other than GET, POST or HEAD, or if you
            // are sending a custom HTTP header, the browser will make a 
            // preflight request (OPTIONS) for the server to decide whether 
            // the request should be allowed.
            xhr.open(method, url, true);
        } else if (typeof XDomainRequest !== 'undefined') {
            xhr = new XDomainRequest();
            // XDomainRequest doesn't support withCredential property.
            // IE8 and 9 wont support credentiated requests and are
            // incapable to transferring cookies using CORS.
            xhr.open(method, url);
        } else {
            xhr = null;
        }
        return xhr;
    };

    // *** END CORS HANDLING ***
    

    var dom = (function () {

        var document = window.document;
        var dom = {};

        dom.get = function (selector) {
            return selector.charAt(0) === '#' ?
                document.getElementById(selector) :
                document.getElementsByName(selector);
        };

        return dom;

    })();

})(window);


// Aliasing window and undefined
(function (window, undefined) {

    'use strict';

    var Loader = function (baseUrl, framework) {

        function addResource(element, after) {
            if (typeof after === 'string') {
                var entry = document.getElementsByTagName(after);
                if (!!entry & entry.length > 0) {
                    entry[0].parentNode.insertBefore(element, entry[0]);
                    return;
                }
            }
            //  insert either on head or body
            var parentNode = window.document.documentElement.childNodes[0];
            parentNode.appendChild(element);
        };

        var that = this;

        // load script with callback
        this.load = function (target, callback) {
            var url;
            var element;

            if (typeof target === 'string') {
                url = script;
                element = document.createElement('script');
                element.src = url;
            } else {
                url = target.src;
                element = target;
            }

            element.async = true;
            addResource(element, 'script');

            if (typeof callback === 'function') {
                // Use onload event to determine wen the script is loaded. IE 8 and ealier uses onreadystatechange.
                element.onload = element.onreadystatechange = function () {
                    var readyState = element.readyState;
                    // onreadystatechange fires every time the state of the loading script changes.
                    if (typeof readyState === 'undefined' || /complete|loaded/.test(element.readyState)) {
                        // When finished, fire the callback
                        callback();
                        // detach event handler to avoid memory leaks in Internet Exporer
                        element.onload = null;
                        element.onreadystatechange = null;
                    }
                };
            };
        };

        this.main = function (baseUrl, framework, callback) {
            var element = document.createElement('script');
            element.src = baseUrl + '/Scripts/require.js?v=1';
            element.setAttribute('data-main', baseUrl + '/Scripts/' + framework + '/main');
            that.load(element, callback);
        };

        // load script with callback
        this.style = function (url) {
            var element = document.createElement('link');
            element.setAttribute('href', url);
            element.setAttribute('rel', 'Stylesheet');
            element.setAttribute('type', 'text/css');
            addResource(element);
        };
    };

    var Adapter = function (script) {

        // Copy script dataset. do not give direct access. 
        // Plus we are not use we are giving the actual HTML5 Element dataset.
        this.dataset = Adapter.getDataset(script);
        this.framework = this.dataset["framework"] || "Angular";
        this.culture = this.dataset["culture"] || "en";
        this.location = Adapter.parseUrl(script.src);

        if (typeof this.location.host !== 'string') {
            this.location.host = window.location.host;
            this.location.port = window.location.port;
        }

        if (typeof this.location.query === 'string') {
        }

        this.secure = window.location.protocol === 'https:';
        this.baseUrl = (this.secure ? 'https://' : 'http://') + this.location.host;

        if (!!this.location.port) {
            this.baseUrl += ':' + this.location.port;
        }

        this.loader = new Loader(this.baseUrl);

        // load style for widgets
        //this.loader.style(this.baseUrl + '/Content/adapter.css');

        // load html5 shiv js
        //this.loader.load(baseUrl + '/scripts/html5shiv.js');

        var that = this;

        // load require js and main
        this.loader.main(this.baseUrl, this.framework, function () {
            define('Adapter', Adapter);
            // Define the adapter object. Load and include the string resource object in the adapter
            define('adapter', that);
        });
    };

    // expr is a RegEx like /camerastork\.com\/widget\.js/
    Adapter.getScriptElement = function (comparer) {
        // Query DOM for all script elements on the publisher's page
        var scripts = document.getElementsByTagName('script');
        var element;
        var src;

        for (var i = 0; i < scripts.length; i++) {
            element = scripts[i];
            src = element.src;
            // When found, return matching script element's full 
            // src attribute, including query string component.
            var url = Adapter.parseUrl(src);
            if (!comparer || comparer(url)) {
                return element;
            }
        }
        return null;
    };

    Adapter.getDataset = function (el) {

        if (typeof el.dataset === 'object') {
            return el.dataset;
        }
        var dataset = {},
            i,
            attrVal, attrName, propName,
            attribute,
            attributes = el.attributes,
            toUpperCase = function (n0) {
                return n0.charAt(1).toUpperCase();
            };

        if (typeof attributes == 'object') {
            for (i = 0; i < attributes.length; i++) {
                attribute = attributes[i];
                // Fix: This test really should allow any XML Name without 
                //         colons (and non-uppercase for XHTML)
                if (attribute && attribute.name && (/^data-\w[\w\-]*$/).test(attribute.name)) {
                    attrVal = attribute.value;
                    attrName = attribute.name;
                    // Change to CamelCase
                    propName = attrName.substr(5).replace(/-./g, toUpperCase);
                    dataset[propName] = attrVal;
                }
            }
        }
        return dataset;
    };

    // Extract parameters from url query or hash
    Adapter.getParameters = function (fragment) {

        if (typeof fragment !== 'string') {
            return;
        }

        var args = fragment.split('&');
        var params = {};
        var pair;
        var key;
        var value;

        // Helper function for decoding URL-encoded url fragment values
        function decode(string) {
            return decodeURIComponent(string || "").replace('+', ' ');
        };

        // Convert key/value pairs into a JavaScript object (hash)
        for (var i = 0; i < args.length; i++) {

            pair = args[i].split('=');
            key = decode(pair[0]);
            value = decode(pair[1]);
            params[key] = value;
        }

        return params;
    };

    Adapter.parseUrl = function (url) {
        var result = {};
        if (typeof url !== 'string' || url.length === 0) {
            return result;
        }
        var regExpr = /^(?:([A-Za-z]+):)?(\/{0,3})([0-9.\-A-Za-z]+)(?::(\d+))?(?:\/([^?#]*))?(?:\?([^#]*))?(?:#(.*))?$/;
        var names = ['url', 'scheme', 'slash', 'host', 'port', 'path', 'query', 'hash'];
        var values = regExpr.exec(url);

        if (!values) {
            return result;
        }
        for (var i = 0; i < names.length && i < values.length; i++) {
            result[names[i]] = values[i];
            //document.writeln(names[i] + ':' + blanks.substring(names[i].length), result[i]);
        }
        return result;
    };

    Adapter.redirect = function (url) {
        window.document.location = url;
    };

    var scriptElement = Adapter.getScriptElement(function (url) {
        return !!url.path && url.path.toLowerCase() === 'scripts/adapter.js';
    });

    if (!!scriptElement && typeof scriptElement === 'object') {
        new Adapter(scriptElement);
    }

})(window, document);