define(['config'], function (config) {

        return {
            create: function (x, res, el) {
                var o = {
                    applyTo: el,
                    title: "Application",
                    //icon: 'application',
                    width: 800,
                    height: 600,
                    border: false,
                    //closable: false,
                    x: 100,
                    y: 100,
                    //plain: true,
                    layout: 'border',
                };
                Ext.Object.merge(o, x);
                return Ext.create('App.ux.MainPanel', o);
            }
        };
    });