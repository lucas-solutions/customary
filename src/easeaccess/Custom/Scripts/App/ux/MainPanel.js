Ext.define('App.ux.MainPanel', function () {

    var origin = window.y7Adapter.origin || '';
    var publish = window.y7Adapter.publish || Ext.emptyFn;
    var subscribe = window.y7Adapter.subscribe || Ext.emptyFn;

    (function () {

        var dialog = null;

        subscribe('OpenDialog', function (config) {
            dialog = Ext.create('Ext.window.Window', {
                //xtype: "window",
                hideMode: 'display',
                hidden: false,
                shadow: false,
                layout: "fit",
                closable: true,
                title: "Edit",
                width: 300,
                plugins: [
                    Ext.create('Ext.ux.MouseDistanceSensor', {
                        threshold: 25,
                        opacity: true,
                        minOpacity: 0.3,
                        maxOpacity: 1.0/*,
                        getSensorEls: function () {
                            return Ext.get('header');
                        },
                        getConstrainEls: function () {
                            return Ext.get('header');
                        },
                        listeners: {
                            far: {
                                fn: function (item) {
                                    Ext.get('toolbar').hide();
                                }
                            },
                            /*near: {
                                fn: near
                            }
                        }*/
                    })
                ],
                listeners: {
                    // Fires if the user clicks on the windows's close button, but before the close event is fired.
                    beforeclose: {
                        fn: function (wnd) {
                            var dlg = dialog;
                            cancel = false;
                            publish('BeforeCloseDialog');
                            window.setTimeout(function () {
                                if (!cancel) {
                                    //dialog.hide(null); // null to "unset" animation target
                                    dlg.destroy();
                                }
                            }, 10);
                            return false;
                        }
                    },
                    // Fires to indicate that the window is to be closed, usually because the user has clicked the close button.
                    close: {
                        fn: function (wnd) {
                            publish('AfterCloseDialog');
                        },
                    }
                }
            });
            if (!!config) {
                if (!!config.title) {
                    dialog.setTitle(config.title);
                }
                if (!!config.content) {
                    dialog.items.add(config.content);
                }
            }
            dialog.show();
        });

        subscribe('CancelCloseDialog', function () {
            cancel = true;
        });

        subscribe('CloseDialog', function () {
            if (!!dialog) {
                dialog.destroy();
                dialog = null;
            }
        });
    }());

    var getPath = function (node) {
        /// <param name="node" type="Ext.data.NodeInterface">
        /// </param>
        /// <returns type="String"></returns>
        var raw = node.raw;
        var path = [origin];
        if (typeof raw.name === 'string') {
            path.push(raw.name);
        }
        for (node = node.parentNode; node; node = node.parentNode) {
            raw = node.raw;
            if (typeof raw.name === 'string') {
                path.push(raw.name);
            }
        }
        path.reverse();
        return path.join('/');
    };

    var AreaModel = Ext.define('App.data.Area',
        {
            extend: 'Ext.data.Model',
            fields: [
                {
                    name: "Name"
                },
                {
                    name: "Title"
                },
                {
                    name: "Summary"
                },
                {
                    name: 'CreatedBy',
                },
                {
                    name: "CreatedOn",
                    type: "date",
                    dateFormat: "Y-m-d\\TH:i:s"
                },
                {
                    name: "ModifiedOn",
                    type: "date",
                    dateFormat: "Y-m-d\\TH:i:s"
                },
                {
                    name: 'ModifiedBy',
                },
            ]
        });

    var AppModel = Ext.define('App.data.App',
        {
            extend: 'App.data.Area',
            fields: [
                {
                    name: "Id"
                }
            ]
        });

    var store_type = "ajax"; //rest

    var store_config = {
        // destroy the store if the grid is destroyed
        autoDestroy: true,
        autoLoad: true,
        //autoSave: true,
        autoSync: false,
        batchActions: true,
        //buffered: true,
        pageSize: 100,
        proxy: {
            type: store_type, // rest, jsonp or "ajax"
            /*api: { // use for ajax proxy, since all the create, update and detroy requests will be all POST
                read: path + "/Read",
                create: path + "/Create",
                update: path + "/Update",
                destroy: path + "/Destroy"
            },*/
            //url: path,
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
                //dateFormat: "",
                totalProperty: 'total',
                successProperty: 'success',
                messageProperty: 'message'
            },
            writer: {
                type: 'json',
                root: 'data',
                allowSingle: false, // force data to be array
                //dateFormat: "",
                writeAllFields: false,
                writeRecordId: true
            }
        },
        listeners: {
            write: function (proxy, operation) {
                if (operation.action == 'destroy') {
                    //main.child('#form').setActiveRecord(null);
                }
                Ext.example.msg(operation.action, operation.resultSet.message);
            }
        },
        sorters: [{
            property: 'Id',
            direction: 'ASC'
        }]
    };

    var store_constructor = function (model, path, idProperty) {

        var config = Ext.Object.merge({ model: model }, store_config);

        switch (store_type) {
            case "ajax":
                Ext.Object.merge(config, {
                    proxy: {
                        // since create, update and detroy requests will be all POST
                        api: {
                            read: path,
                            create: path + "/Insert",
                            update: path + "/Update",
                            destroy: path + "/Remove"
                        }
                    }
                });
                break;

            case "jsonp":
                Ext.Object.merge(config, {
                    // since all the resquests will be GET
                    proxy: {
                        api: {
                            read: path,
                            create: path + "/Insert",
                            update: path + "/Update",
                            destroy: path + "/Remove"
                        }
                    }
                });
                break;

            case "rest":
                Ext.Object.merge(config, {
                    // read: GET, create: PUT, update: POST, destroy: DELETE
                    proxy: {
                        url: path
                    }
                });
                break;
        }

        Ext.Object.merge(config, {
            proxy: {
                reader: {
                    idProperty: idProperty || "Name",
                },
            }
        });

        return Ext.create('Ext.data.Store', config);
    }

    return {
        extend: 'Ext.container.Viewport',

        dd: {
            app: AppModel,
            area: AreaModel
        },

        tabMap: {},

        /**
        * Called by Ext when instantiating
        *
        * @private
        * @param {Object} config Configuration object
        */
        initComponent: function (config) {

            var me = this;

            this.toolbar = Ext.create('App.ux.MainToolbar', {
                region: "north",
                weight: -2
            });

            this.tabs = Ext.create('Ext.tab.Panel', {
                region: "center",
                items: []
            });

            this.tree = Ext.create('App.ux.AppTree', {
                scope: this,
                region: "west",
                weight: -1,
                getPath: getPath,
                collapsible: true,
                title: "Application:",
                minWidth: 175,
                width: 175,
                split: true,
                bodyPadding: 5,
                tools: [
                    {
                        xtype: 'button',
                    },
                    {
                        xtype: 'button',
                    }
                ],
                onItemClick: this.onTreeItemClick,
                onItemDblClick: this.onTreeItemDblClick
            });

            this.msgs = Ext.create('Ext.tab.Panel', {
                region: "south",
                weight: -2,
                height: 100,
                minHeight: 100,
                split: true,
                collapsed: true,
                collapsible: true,
                tools: [
                    {
                        xtype: 'button',
                    },
                    {
                        xtype: 'button',
                    }
                ],
                listeners: {
                    afterrender: {
                        fn: function (item) {
                            //this.setTitle('');
                        }
                    },
                    beforecollapse: {
                        fn: function (item, direction, animate) {
                            //this.setTitle('')
                        }
                    },
                    beforeexpand: {
                        fn: function (item, animate) {
                            //this.setTitle(this.initialConfig.title)
                        }
                    }
                }
            });

            // install events
            this.addEvents(
                'ReadOnly',
                'RowEdit',
                'FormEdit',
                'Create',
                'Delete',
                'Update',
                'AutoUpdate',
                'Cancel',
                'Search',
                'SyncStore',
                'SyncTree',
                'SyncUrl',
                'SaveChanges',
                'SaveAllChanges',
                'AutoSave',
                'RejectChanges',
                'RejectAllChanges');

            // config
            var config = Ext.apply(this.initialConfig, {
                items: [this.tree, this.tabs, this.toolbar, this.msgs]
            });

            // appy the config
            Ext.apply(this, config);

            // Call parent (required)
            App.ux.MainPanel.superclass.initComponent.apply(this, arguments);
        },

        onTabClose: function (tab, eOpts) {
            delete this.tabMap[tab.path];
        },

        onTreeItemClick: function (item, record, node, index, e, path) {
        },

        onTreeItemDblClick: function (item, record, node, index, e, path) {
            var raw = record.raw;
            var path = getPath(record);

            var tab = this.tabMap[path];

            if (!!tab) {
                this.tabs.setActiveTab(tab);
                //this.tabs.doLayout();
            } else {

                switch (raw.type) {
                    case 'app':
                        /*var config = {
                            dd: this.dd,
                            scope: this,
                            path: path,
                            store: store_constructor,
                            title: raw.text,
                            qtip: raw.type,
                            layout: 'border',
                            closable: true,
                            onBeforeClose: this.onTabBeforeClose,
                            onClose: this.onTabClose
                        };
                        Ext.Object.merge(config, { model: this.dd.app, dd: this.dd });
                        var tab = Ext.create('App.ux.AreaPanel', config);
                        this.tabMap[path] = tab;
                        this.tabs.add(tab);
                        break;*/
                    case 'area':
                    case 'file':
                    case 'files':
                    case 'grid':
                    case 'grids':
                    case 'List':
                    case 'lists':
                    case 'note':
                    case 'notes':
                    case 'Text':
                    case 'texts':
                        Ext.Ajax.request({
                            cors: true,
                            method: 'GET',
                            url: path + '/Metadata',
                            headers: {
                                accept: 'application/json'
                            },
                            /*success: function () {
                            },
                            failure: function () {
                            },*/
                            callback: function (options, success, response) {
                                var metadata = Ext.JSON.decode(response.responseText.trim());
                                //'App.area.area.area.stores.Store'
                                Ext.Object.merge(metadata, { path: path });
                                var tab = Ext.create('Ext.screen.Panel', {
                                    metadata: metadata,
                                    title: metadata.title || raw.text,//record.parentNode.raw.text + " (" + raw.text + ")",
                                    qtip: raw.type,
                                    layout: 'border',
                                    closable: true,
                                    listeners: {
                                        afterClose: function (panel, e) {
                                            this.tabs.remove(tab);
                                            delete this.tabMap[panel.path];
                                        }
                                    }
                                });
                                this.tabMap[path] = tab;
                                this.tabs.add(tab);
                                this.tabs.setActiveTab(tab);
                            },
                            scope: this
                        });
                        break;
                }
            }
        }
    };
});