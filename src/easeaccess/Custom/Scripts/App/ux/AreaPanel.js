Ext.define('App.ux.AreaPanel', function () {

    return {
        extend: 'Ext.panel.Panel',

        /*bridgeToolbars : function () {
        },

        initBorderProps: function () {
        },

        getLayout: function () {
            return 'fit';
        },*/

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
            var store = this.initialConfig.store;

            this.form = Ext.create('App.ux.AreaForm', {
                title: "Edit",
                path: path,
                collapsible: true,
                border: false,
                defaultAnchor: "100%",
                bodyPadding: 10,
                region: "north"
            }, {});

            this.areas = Ext.create('App.ux.AreasPanel', {
                dd: this.dd,
                layout: 'fit',
                model: this.dd.area,
                store: store,
                path: path + "/Areas",
                title: "<a href=\"" + path + "/Areas" + "\" target=\"_blank\">" + path + "/<b>Areas<b></a>"
            });

            /*this.areas = Ext.create('Ext.custom.Grid', {
                metadata: {
                    path: path + "/Areas",
                    idProperty: "Name",
                    members: {
                        "Name": {
                            title: "NAme",
                            flex: 1
                        },
                        "Title": {
                            title: "Title",
                            flex: 1
                        },
                        "Summary": {
                            title: "Summary",
                            flex: 1
                        },
                        "CreatedOn": {
                            title: "Created On",
                            type: "date",
                            format: "Y-m-d\\TH:i:s",
                            width: 140
                        },
                        "CreatedBy": {
                            title: "Created By",
                            width: 140
                        },
                        "ModifiedOn": {
                            title: "Modified On",
                            type: "date",
                            format: "H:i:s",
                            width: 140
                        },
                        "ModifiedBy": {
                            title: "Modified By",
                            width: 140
                        }
                    }
                },
                title: "<a href=\"" + path + "/Areas" + "\" target=\"_blank\">" + path + "/<b>Areas<b></a>"
            });*/

            this.grids = Ext.create('Ext.custom.Grid', {
                metadata: {
                    path: path + "/Grids",
                    idProperty: "Name",
                    members: {
                        "Name": {
                            title: "Name",
                            flex: 1
                        },
                        "Title": {
                            title: "Title",
                            flex: 1
                        },
                        "Summary": {
                            title: "Summary",
                            flex: 1
                        },
                        "CreatedOn": {
                            title: "Created On",
                            type: "date",
                            format: "Y-m-d\\TH:i:s",
                            width: 140
                        },
                        "CreatedBy": {
                            title: "Created By",
                            width: 140
                        },
                        "ModifiedOn": {
                            title: "Modified On",
                            type: "date",
                            format: "H:i:s",
                            width: 140
                        },
                        "ModifiedBy": {
                            title: "Modified By",
                            width: 140
                        }
                    }
                },
                title: "<a href=\"" + path + "/Grids" + "\" target=\"_blank\">" + path + "/<b>Grids<b></a>"
            });

            this.files = Ext.create('Ext.custom.Grid', {
                metadata: {
                    path: path + "/Files",
                    idProperty: "Name",
                    members: {
                        "Name": {
                            title: "Name",
                            flex: 1,
                        },
                        "Title": {
                            flex: 1,
                            title: "Title"
                        },
                        "Summary": {
                            title: "Summary",
                            flex: 1
                        },
                        "CreatedOn": {
                            type: "date",
                            format: "Y-m-d\\TH:i:s",
                            title: "Created On",
                            width: 140
                        },
                        "CreatedBy": {
                            title: "Created By",
                            width: 140
                        },
                        "ModifiedOn": {
                            type: "date",
                            format: "H:i:s",
                            title: "Modified On",
                            width: 140
                        },
                        "ModifiedBy": {
                            title: "Modified By",
                            width: 140
                        }
                    }
                },
                title: "<a href=\"" + path + "/Files" + "\" target=\"_blank\">" + path + "/<b>Files<b></a>"
            });

            this.lists = Ext.create('Ext.custom.Grid', {
                metadata: {
                    path: path + "/Lists",
                    idProperty: "Name",
                    members: {
                        "Name": {
                            title: "Name",
                            flex: 1,
                        },
                        "Title": {
                            flex: 1,
                            title: "Title"
                        },
                        "Summary": {
                            title: "Summary",
                            flex: 1
                        },
                        "CreatedOn": {
                            type: "date",
                            format: "Y-m-d\\TH:i:s",
                            title: "Created On",
                            width: 140
                        },
                        "CreatedBy": {
                            title: "Created By",
                            width: 140
                        },
                        "ModifiedOn": {
                            type: "date",
                            format: "H:i:s",
                            title: "Modified On",
                            width: 140
                        },
                        "ModifiedBy": {
                            title: "Modified By",
                            width: 140
                        }
                    }
                },
                title: "<a href=\"" + path + "/Lists" + "\" target=\"_blank\">" + path + "/<b>Lists<b></a>"
            });

            this.notes = Ext.create('Ext.custom.Grid', {
                metadata: {
                    path: path + "/Notes",
                    idProperty: "Name",
                    members: {
                        "Name": {
                            title: "Name",
                            flex: 1,
                        },
                        "Title": {
                            flex: 1,
                            title: "Title"
                        },
                        "Summary": {
                            title: "Summary",
                            flex: 1
                        },
                        "CreatedOn": {
                            type: "date",
                            format: "Y-m-d\\TH:i:s",
                            title: "Created On",
                            width: 140
                        },
                        "CreatedBy": {
                            title: "Created By",
                            width: 140
                        },
                        "ModifiedOn": {
                            type: "date",
                            format: "H:i:s",
                            title: "Modified On",
                            width: 140
                        },
                        "ModifiedBy": {
                            title: "Modified By",
                            width: 140
                        }
                    }
                },
                title: "<a href=\"" + path + "/Notes" + "\" target=\"_blank\">" + path + "/<b>Notes<b></a>"
            });

            // config
            var o = Ext.apply(this.initialConfig, {
                layout: 'border',
                items: [this.form, {
                    xtype: 'panel',
                    region: 'center',
                    layout: {
                        type: 'accordion',
                        fill: true,
                        titleCollapse: true,
                        activeOnTop: true,
                        animate: true,
                        originalHeader: true
                    },
                    items: [this.areas, this.grids, this.files, this.lists, this.notes]
                }],

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
            App.ux.AreaPanel.superclass.initComponent.apply(this, arguments);
        },

        onBeforeClose: function (tab, eOpts) {
        },

        onClose: function (tab, eOpts) {
        },

        onGridSelectionChange: function (grid, item, selected) {
            this.form.loadRecord(selected[0]);
        },
    };
});