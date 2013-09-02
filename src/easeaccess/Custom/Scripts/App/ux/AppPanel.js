Ext.define('App.ux.AppPanel', function () {

    return {
        extend: 'App.ux.AreaPanel',

        /**
         * Called by Ext when instantiating
         *
         * @private
         * @param {Object} config Configuration object
         */
        initComponent: function (config) {

            var that = this;
            var scope = this.initialConfig.scope || this;

            this.areas = Ext.create('App.ux.AreasPanel', {
            });

            // config
            var config = Ext.apply(this.initialConfig, {
                layout: 'border',
                items: [this.areas]
            });

            // appy the config
            Ext.apply(this, config);

            // Call parent (required)
            App.ux.AppPanel.superclass.initComponent.apply(this, arguments);
        },

        onGridSelectionChange: function (grid, item, selected) {
            this.form.loadRecord(selected[0]);
        },
    };
});