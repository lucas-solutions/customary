Ext.define('App.ux.AreaForm', function () {

    return {
        extend: 'Ext.form.Panel',

        /**
         * Called by Ext when instantiating
         *
         * @private
         * @param {Object} config Configuration object
         */
        initComponent: function (config) {

            // config
            var o = Ext.apply(this.initialConfig, {
                scope: this,
                items: [
                   {
                       xtype: "textfield",
                       fieldLabel: "Id",
                       name: "Id"
                   },
                   {
                       xtype: "textfield",
                       fieldLabel: "Title",
                       name: "Title"
                   },
                   {
                       xtype: "datefield",
                       fieldLabel: "LastUpdate",
                       name: "LastUpdate",
                       format: "n/j/Y",
                       submitFormat: "n/j/Y"
                   }
                ],
            });

            Ext.Object.merge(o, config);

            // appy the config
            Ext.apply(this, o);

            // Call parent (required)
            App.ux.AreaForm.superclass.initComponent.apply(this, arguments);
        },
    };
});