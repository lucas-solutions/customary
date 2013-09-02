
require.config({

    deps: ['main'],

    paths: {
        'ext-js': 'ext-all-debug',
        'en-US': 'resources/en-us'
    },

    shim: {
    }
});

var culture = window.y7Adapter['data-culture'] || window.y7Adapter['culture'] || "en-US";

require(['config', culture, 'ext-js'], function (config, res) {

    Ext.Loader.setPath('Ext', 'Scripts/Ext');
    Ext.Loader.setPath('App', 'Scripts/App');

    Ext.require([
        'Ext.data.*',
        'Ext.tip.QuickTipManager',
        'Ext.window.MessageBox'
    ]);

    if (!config) {
        config = {
            baseUrl: window.y7Adapter['baseUrl']
        };
    }
    else if (!config.baseUrl || !config.baseUrl.length) {
        config.baseUrl = window.y7Adapter['baseUrl'];
    }

    var components = [];
    var hash = {};
    var placeholders = document.getElementsByClassName('y7-widget');

    // load style for widget
    var css = document.createElement('link');
    css.setAttribute('href', config.baseUrl + '/Content/css/ext-all.css');
    css.setAttribute('rel', 'stylesheet');
    css.setAttribute('type', 'text/css');

    (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(css);

    for (var i = 0; i < placeholders.length; i++) {

        var el = placeholders[i];
        var widget = {
            el: el,
            xtype: el.getAttribute('data-widget')
        };

        components.push(widget);
        hash[widget.xtype] = false;
    }

    var names = [], paths = [];
    for (var name in hash) {
        names.push(name);
        paths.push(config.baseUrl + '/Scripts/App/plugins/' + name + '.js');
    }

    require(paths, function () {
        var args = arguments;

        for (var i = 0; i < args.length; i++) {
            hash[names[i]] = args[i];
        }

        for (var i = 0; i < components.length; i++) {
            var component = components[i];
            var pluggin = hash[component.xtype];
            if (!!pluggin) {
                component.pluggin = pluggin.create({}, res, component.el);
            }
        }
    });

    Ext.onReady(function () {
        Ext.tip.QuickTipManager.init();
    });
});