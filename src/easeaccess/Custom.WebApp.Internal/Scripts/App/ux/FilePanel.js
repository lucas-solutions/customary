Ext.define('App.ux.FilePanel', function () {

    return {
        extend: 'Ext.panel.Panel',

        /**
         * Called by Ext when instantiating
         *
         * @private
         * @param {Object} config Configuration object
         */
        initComponent: function (config) {

            var that = this;
            var scope = this.initialConfig.scope || this;
            var path = this.initialConfig.path;

            this.form = Ext.create('App.ux.FileForm', {
                title: "Edit",
                path: path,
                collapsible: true,
                region: "north"
            });

            // config
            var o = Ext.apply(this.initialConfig, {
                items: [this.form],

                listeners: {
                    // Fires if the user clicks on the Tab's close button, but before the close event is fired.
                    beforeclose: {
                        fn: function (tab, eOpts) {
                            that.onBeforeClose.call(this, tab, eOpts);
                        },
                        scope: scope
                    },
                    // Fires to indicate that the tab is to be closed, usually because the user has clicked the close button.
                    close: {
                        fn: function (tab, eOpts) {
                            that.onClose.call(this, tab, eOpts);
                        },
                        scope: scope
                    }
                },
            });

            Ext.Object.merge(o, config);

            // appy the config
            Ext.apply(this, o);

            // Call parent (required)
            App.ux.FilePanel.superclass.initComponent.apply(this, arguments);
        },

        onBeforeClose: function (tab, eOpts) {
        },

        onClose: function (tab, eOpts) {
        }
    };
});