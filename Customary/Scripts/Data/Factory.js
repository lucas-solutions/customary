// Create model, grid and forms for data definitions

Ext.define('Custom.data.Factory', function () {

    function fullName(node) {
        /// <param name="node" type="Ext.data.NodeInterface">
        /// </param>
        /// <returns type="String"></returns>
        var name = [];
        name.push(node.raw.text);
        for (node = node.parentNode; node; node = node.parentNode) {
            name.push(node.raw.text);
        }
        name.reverse();
        return name.slice(1).join('-');
    };

    function onRefreshClick() {
        this.store.load();
        App.core.Adapter.publish('Custom.data.Directory.selectionchange', this.selModel);
    };

    function onDirectorySelectionChange(selModel, selections, opts) {
        if (typeof selections == 'object' && selections.length > 0 && typeof selections[0].raw == 'object') {
            App.core.Adapter.publish('Custom.data.Directory.selectionchange', selModel, selections, selections[0].raw.type, selections[0].raw.id);
        } else {
            App.core.Adapter.publish('Custom.data.Directory.selectionchange', selModel, selections);
        }
    };

    return {

        static: {

            createDirectoryPanel: function (context, config) {

                var buttons = {
                    refresh: Ext.create('Ext.Button', {
                        iconCls: 'icon-refresh',
                        text: 'Refresh',
                        scope: this,
                        handler: onDirectoryRefreshClick
                    })
                };

                if (context !== null && typeof context === 'object') {
                    Ext.Object.merge(contex, {
                        buttons: buttons
                    });
                }

                //Ext.Object.merge(config, 

                return Ext.create('Ext.tree.Panel', {
                    header: false,
                    store: context.store,
                    rootVisible: false,
                    useArrows: true,
                    listeners: {
                        selectionchange: {
                            fn: onDirectorySelectionChange,
                            scope: this
                        }
                    },
                    dockedItems: [
                        {
                            xtype: 'toolbar',
                            dock: 'bottom',
                            ui: 'footer',
                            margin: '6 0 3 0',
                            items: ['->', button.refresh]
                        }
                    ]
                });
            },

            createDirectoryStore: function (url) {

                return Ext.create('Ext.data.TreeStore', {
                    id: 'Custom.data.Directory.Store',
                    autoLoad: true,
                    //defaultRootId: '0',
                    //defaultRootText: "text",
                    //defaultRootProperty: 'children',
                    folderSort: true,
                    // not using model. direct proxy
                    proxy: {
                        // Use for ajax proxy, since all the create, update and detroy requests will be all POST
                        // and for jsonp the api is the same, but the method is GET
                        type: 'ajax', // rest, jsonp or ajax. 
                        api: {
                            read: url + '/Read/'
                        },
                        buildUrl: function (request) {
                            switch (request.action) {
                                case 'read':
                                    return url + '/Read/' + fullName(request.operation.node);
                                default:
                                    return url;
                            }
                        },
                        headers: {
                            "Accept": "application/json"
                        },
                        listeners: {
                            exception: function (proxy, response, operation) {
                                Ext.MessageBox.show({
                                    title: 'REMOTE EXCEPTION',
                                    msg: operation.getError(),
                                    icon: Ext.MessageBox.ERROR,
                                    buttons: Ext.Msg.OK
                                });
                            }
                        },
                        reader: {
                            type: "json",
                            root: "data",
                            totalProperty: 'total',
                            successProperty: 'success',
                            messageProperty: 'message'
                        }
                    },
                    root: {
                        text: "Root",
                        expanded: true,
                        loaded: false,
                    }
                });
            }
        }
    };

});