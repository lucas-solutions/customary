Ext.define('App.ux.NotesPanel', function () {

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

            this.form = Ext.create('App.ux.FileForm', { path: path });

            this.edit = Ext.create('Ext.window.Window', {
                xtype: "window",
                hidden: false,
                shadow: false,
                layout: "fit",
                closable: false,
                title: "Edit",
                height: 180,
                width: 300,
                items: [this.form],
                plugins: [
                   Ext.create("Ext.ux.MouseDistanceSensor",
                   {
                       minOpacity: 0.3,
                       maxOpacity: 1.0
                   })
                   /*Ext.create('Ext.ux.MouseDistanceSensor', {
                       threshold: 25,
                       opacity: false,
                       minOpacity: 0.0,
                       maxOpacity: 1.0,
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
                           near: {
                               fn: near
                           }
                       }
                   })*/
                ],
                listeners: {
                    afterrender: {
                        delay: 1,
                        fn: function (item) {
                            this.show();
                            this.el.alignTo(document, 'br-br', [-20, -20]);
                        }
                    }
                }/*,
                    initComponent: function () {

                        var config = {
                            items: [this.form],
                        };

                        // appy the config
                        Ext.apply(this, config);

                        // Call parent (required)
                        App.ux.FilesPanel.superclass.initComponent.apply(this, arguments);
                    }*/
            });

            /*this.grid = FilesFile.create({
                scope: this,
                path: path,
                onSelectionChange: this.onFileSelectionChange,
            });*/

            this.grid = Ext.create('Ext.grid.Panel', {
                columns: {
                    items: [
                       {
                           width: 50,
                           xtype: "rownumberer",
                           sortable: false
                       },
                       {
                           flex: 1,
                           dataIndex: "Id",
                           text: "Name"
                       },
                       {
                           width: 70,
                           dataIndex: "Title",
                           text: "Title"
                       },
                       {
                           width: 140,
                           xtype: "datecolumn",
                           dataIndex: "LastUpdate",
                           text: "LastUpdate",
                           format: "H:i:s"
                       }
                    ]
                },

                listeners: {
                    afterrender: {
                        delay: 100,
                        fn: function (item) {
                            this.store.guaranteeRange(0, 99);
                        }
                    },
                    selectionchange: {
                        fn: function (item, selected) {
                            if (selected[0]) {
                                this.onGridSelectionChange(that, item, selected);
                            }
                        },
                        scope: this
                    }
                },

                selModel: Ext.create("Ext.selection.RowModel",
                {
                    selType: "rowmodel",
                    listeners: {
                        selectionchange: {
                            fn: function (item, selected) {
                                if (selected[0]) {
                                    this.onGridSelectionChange(that, item, selected);
                                }
                            },
                            scope: this
                        }
                    }
                }),

                store: {
                    model: Ext.define(Ext.id(),
                    {
                        extend: "Ext.data.Model",
                        fields: [
                           {
                               name: "Id"
                           },
                           {
                               name: "Title"
                           },
                           {
                               name: "LastUpdate",
                               type: "date",
                               dateFormat: "Y-m-d\\TH:i:s"
                           }
                        ]
                    }),
                    proxy: {
                        url: path + '/Store',
                        type: "ajax",
                        reader: {
                            type: "json",
                            root: "data"
                        },
                        headers: {
                            "Accept": "application/json"
                        }
                    },
                    buffered: true,
                    pageSize: 100
                }
            });

            // config
            var o = Ext.apply(this.initialConfig, {
                layout: 'fit',
                items: [this.edit, this.grid],
                listeners: {
                    afterrender: {
                        delay: 1,
                        fn: function (item) {
                            this.edit.show();
                            this.grid.show();
                        }
                    }
                }
            });

            Ext.Object.merge(o, config);

            // appy the config
            Ext.apply(this, o);

            // Call parent (required)
            App.ux.NotesPanel.superclass.initComponent.apply(this, arguments);
        },

        onGridSelectionChange: function (grid, item, selected) {
            this.edit.show();
            this.edit.el.alignTo(document, 'br-br', [-20, -20]);
            this.form.loadRecord(selected[0]);
        }
    };
});