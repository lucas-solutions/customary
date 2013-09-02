Ext.define('App.ux.AppTree', function () {

    return {
        extend: 'Ext.tree.Panel',

        tbar: [
            {
                xtype: 'combo',
                width: '100%',
                store: [
                    'localhost',
                    'easeaccess.com',
                    'why7.net'
                ]
            }
        ],

        /**
         * Called by Ext when instantiating
         *
         * @private
         * @param {Object} config Configuration object
         */
        initComponent: function (config) {

            var that = this;
            var scope = this.initialConfig.scope || this;

            // config
            var config = Ext.apply(this.initialConfig, {

                listeners: {

                    afterrender: {
                        fn: function (item) {
                            this.setTitle(this.initialConfig.title);
                        }
                    },

                    beforecollapse: {
                        fn: function (item,
                        direction,
                        animate) {
                            this.setTitle('')
                        }
                    },

                    beforeexpand: {
                        fn: function (item, animate) {
                            this.setTitle(this.initialConfig.title)
                        }
                    },

                    beforeitemdblclick: {
                        fn: function (item, record, node, index, e) {
                            var path = that.getPath(record);
                            that.onItemDblClick.call(this, item, record, node, index, e, path);
                            // stop expanding on db click
                            return false;
                        },
                        scope: scope
                    },

                    itemclick: {
                        fn: function (item, record, node, index, e) {
                            var path = that.getPath(record);
                            that.onItemClick.call(this, item, record, node, index, e, path);
                        },
                        scope: scope
                    },
                },

                root: {
                    allowDrag: false,
                    text: "localhost",
                    name: "localhost",
                    type: "app"
                },

                store: {
                    type: "tree",
                    proxy: {
                        type: "rest",
                        buildUrl: function (request) {
                            var path = that.getPath(request.operation.node);
                            return path + "/Children";
                        },
                        headers: {
                            "Accept": "application/json"
                        }
                    }
                },

                viewConfig: {
                    plugins: [
                       {
                           ptype: "treeviewdragdrop",
                           containerScroll: true
                       }
                    ],
                    xtype: "treeview"
                }
            });

            // appy the config
            Ext.apply(this, config);

            // Call parent (required)
            App.ux.AppTree.superclass.initComponent.apply(this, arguments);
        },

        onItemClick: function (item, record, node, index, e, path) {
        },

        onItemDblClick: function (item, record, node, index, e, path) {
        }
    };
});