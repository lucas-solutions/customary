Ext.define('Ext.custom.Panel', function () {

    var copy = window.y7Adapter.copy || Ext.emptyFn;
    var publish = window.y7Adapter.publish || Ext.emptyFn;
    var subscribe = window.y7Adapter.subscribe || Ext.emptyFn;

    var FormFields = {
        require: {
            name: 'allowBlank',
            type: 'boolean',
            convert: function (value, record) {
                return !value;
            }
        },
        title: 'fieldLabel',
        type: {
            name: 'xtype',
            convert: function (value, record) {
                switch (value) {
                    case 'date':
                        return 'datefield';
                    case 'text':
                        return 'textfield';
                }
                return value;
            }
        },
    };

    function init(mt) {

        var that = {
            path: mt.path
        };

        if (typeof mt.members !== 'object') {
            return false;
        }

        var fields = [];
        that.grids = [];

        for (var name in mt.members) {
            var config = mt.members[name];

            switch (config.type) {
                case 'grid':
                    var grid = Ext.create('Ext.custom.Grid', {
                        title: name,
                        layout: 'border',
                        metadata: Ext.Object.merge({ path: that.path + '/' + name }, config)
                    });
                    that.grids.push(grid);
                    break;

                default:
                    var field = { name: name };
                    copy(config, field, FormFields);
                    fields.push(field);
                    break;
            }
        };

        alert(Ext.JSON.encode(fields));

        that.form = Ext.create('Ext.form.Panel', {
            region: "north",
            minHeight: 100,
            split: true,
            collapsed: true,
            collapsible: true,
            bodyPadding: 10,
            items: fields
        });

        that.arrange = {
            items: [
                that.form,
                Ext.create('Ext.tab.Panel', {
                    region: "center",
                    items: that.grids
                })
            ]
        };

        return that;
    };

    return {
        extend: 'Ext.panel.Panel',

        initComponent: function (config) {

            var me = this;
            var that = init(this.initialConfig.metadata);
            var parent = this.initialConfig.parent;

            Ext.merge(that.arrange, {
                listeners: {
                    // Fires if the user clicks on the Tab's close button, but before the close event is fired.
                    beforeclose: {
                        fn: function (tab, eOpts) {
                            this.onBeforeClose.call(this, tab, eOpts);
                        },
                        scope: me
                    },
                    // Fires to indicate that the tab is to be closed, usually because the user has clicked the close button.
                    close: {
                        fn: function (tab, eOpts) {
                            this.onClose.call(this, tab, eOpts);
                        },
                        scope: parent
                    }
                },
            });

            Ext.apply(this, that.arrange);

            this.callParent();
        },

        onBeforeClose: function (tab, eOpts) {
            return true;
        },

        onClose: function (tab, eOpts) {
        },
    };
});