﻿Ext.define('App.ux.AreasPanel', function () {

    var publish = window.y7Adapter.publish || Ext.emptyFn;
    var subscribe = window.y7Adapter.subscribe || Ext.emptyFn;

    var model = Ext.define('App.data.Area',
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

    var fields = [
        {
            allowBlank: false,
            fieldLabel: "Name",
            name: "Name",
            xtype: "textfield",
        },
        {
            fieldLabel: "Title",
            name: "Title",
            xtype: "textfield",
        },
        {
            fieldLabel: "Sumary",
            name: "Sumary",
            xtype: "textfield",
        },
        {
            cls: 'x-item-disabled', // simulate disabled; submitted
            fieldLabel: "Modified On",
            format: "n/j/Y",
            name: "ModifiedOn",
            readOnly: true,
            xtype: "datefield",
        },
        {
            cls: 'x-item-disabled', // simulate disabled; submitted
            fieldLabel: "Modified By",
            name: "ModifiedBy",
            readOnly: true,
            xtype: "textfield",
        },
        {
            cls: 'x-item-disabled', // simulate disabled; submitted
            fieldLabel: "Created On",
            format: "n/j/Y",
            name: "CreatedOn",
            readOnly: true,
            xtype: "datefield",
        },
        {
            cls: 'x-item-disabled', // simulate disabled; submitted
            fieldLabel: "Created By",
            name: "CreatedBy",
            readOnly: true,
            xtype: "textfield",
        }
                    /*{
                        fieldLabel: 'Email',
                        name: 'email',
                        allowBlank: false,
                        vtype: 'email'
                    }, {
                        fieldLabel: 'First',
                        name: 'first',
                        allowBlank: false
                    }, {
                        fieldLabel: 'Last',
                        name: 'last',
                        allowBlank: false
                    }*/
    ];

    var columns = [
        {
            /*editor: {
                // defaults to textfield if no xtype is supplied
                allowBlank: true
            },*/
            sortable: false,
            width: 50,
            xtype: "rownumberer",
        },
        {
            editor: {
                allowBlank: true
                //vtype: 'email'
            },
            dataIndex: "Name",
            fixed: false,
            flex: 1,
            text: "Name",
            width: 80
        },
        {
            editor: {
                allowBlank: true
            },
            dataIndex: "Title",
            fixed: false,
            flex: 2,
            text: "Title",
            width: 120
        },
        {
            editor: {
                allowBlank: true
            },
            dataIndex: "Summary",
            fixed: false,
            flex: 5,
            text: "Summary",
            width: 120
        },
        {
            dataIndex: "ModifiedOn",
            fixed: false,
            flex: 1,
            format: "H:i:s",
            text: "Modified On",
            width: 80,
            xtype: "datecolumn"
        },
        {
            dataIndex: "ModifiedBy",
            fixed: false,
            flex: 1,
            text: "Modified By",
            width: 80
        },
        {
            dataIndex: "CreatedOn",
            fixed: false,
            flex: 1,
            format: "H:i:s",
            text: "Created On",
            width: 80,
            xtype: "datecolumn"
        },
        {
            dataIndex: "CreatedBy",
            fixed: false,
            flex: 1,
            format: "H:i:s",
            text: "Create By",
            width: 80
        }
    ];

    var writer = Ext.create('Ext.data.writer.Json', {
        root: 'data',
        allowSingle: false, // force data to be array
        //dateFormat: "",
        writeAllFields: false,
        writeRecordId: true,
        getRecordData: function (record) {
            return {
                'id': record.data.id,
                'Name': record.data.Name,
                'Tittle': record.data.Title,
                'Summary': record.data.Summary
            };
        }
    });

    Ext.define('App.ux.AreasEditForm', {
        extend: 'Ext.form.Panel',
        //alias: 'widget.writerform',

        requires: ['Ext.form.field.Text'],

        initComponent: function () {

            var me = this;
            var scope = this.initialConfig.scope || this;

            this.updateButton = Ext.create('Ext.Button', {
                iconCls: 'icon-save',
                text: 'Update',
                disabled: true,
                scope: scope,
                handler: scope.onUpdate
            });

            this.cancelButton = Ext.create('Ext.Button', {
                iconCls: 'icon-reset',
                text: 'Cancel',
                scope: scope,
                handler: scope.onCancel
            });

            Ext.apply(this,
                {

                    dockedItems: [
                        {
                            xtype: 'toolbar',
                            dock: 'bottom',
                            ui: 'footer',
                            items: ['->', this.updateButton, this.cancelButton]
                        }
                    ]
                });

            this.callParent();
        },

        setStore: function (store) {
        },

        setActiveRecord: function (record) {
            var active = this.activeRecord;

            if (typeof active !== 'undefined' && active !== null) {
            }

            this.activeRecord = record;

            if (record) {
                this.updateButton.enable();
                this.getForm().loadRecord(record);
            } else {
                this.updateButton.disable();
                this.getForm().reset();
            }
        },

        onUpdate: function () {
            var form = this.getForm();

            /*if (form.isValid()) {
                this.fireEvent('create', this, form.getValues());
                form.reset();
            }*/
        },

        onCancel: function () {
            this.getForm().reset();
            this.getForm().loadRecord(this.activeRecord);
        }
    });

    var form = Ext.create('App.ux.AreasEditForm', {
        border: false,
        activeRecord: null,
        //iconCls: 'icon-user',
        frame: false,
        defaultType: 'textfield',
        bodyPadding: 5,

        fieldDefaults: {
            anchor: '100%',
            labelAlign: 'right'
        },

        defaultAnchor: "100%",
        items: fields
    });

    return {
        extend: 'Ext.grid.Panel',
        requires: [
            'Ext.form.field.Text',
            'Ext.toolbar.TextItem'
        ],

        edit: null,
        form: null,

        columns: {
            items: columns
        },

        /**
         * Called by Ext when instantiating
         *
         * @private
         * @param {Object} config Configuration object
         */
        initComponent: function (config) {

            var me = this;
            var scope = this.initialConfig.scope || this;
            var path = this.initialConfig.path;
            var model = this.initialConfig.model;
            var store = this.initialConfig.store(model, path);

            me.form = form;

            me.edit = Ext.create('Ext.window.Window', {
                //xtype: "window",
                hideMode: 'display',
                hidden: false,
                shadow: false,
                layout: "fit",
                closable: true,
                title: "Edit",
                width: 300,
                items: [this.form],
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
                        fn: function (window) {
                            if (!this.form.getForm().isDirty()) {
                                this.onClose(window);
                            }
                            else {
                                Ext.Msg.confirm('Changes', 'Changes are not saved. Continue?', function (answer) {
                                    if (answer == 'yes') {
                                        //window.hide(null); // null to "unset" animation target
                                        //window.destroy();
                                        this.onClose(window);
                                    }
                                });
                                return false; // always stop default close if dirty
                            }
                            return false; // always stop default close if dirty
                        },
                        scope: me
                    },
                    // Fires to indicate that the window is to be closed, usually because the user has clicked the close button.
                    close: {
                        fn: function (window) {
                            return false;
                        },
                        scope: me
                    }
                }
            });

            me.editing = Ext.create('Ext.grid.plugin.RowEditing', {
                clicksToEdit: 2,
                clicksToMoveEditor: 1,
                autoCancel: true
            });

            me.plugins = [me.editing];

            Ext.apply(me,
                {
                    iconCls: 'icon-grid',
                    layout: 'fit',
                    //frame: true,
                    //items: [this.edit],
                    //plugins: [this.editing],
                    dockedItems: [
                        {
                            dock: 'bottom',
                            ui: 'footer',
                            frame: true,
                            xtype: 'toolbar',
                            items: [
                                {
                                    iconCls: 'icon-add',
                                    text: 'Add',
                                    scope: me,
                                    handler: me.onAddClick
                                },
                                {
                                    iconCls: 'icon-delete',
                                    text: 'Delete',
                                    disabled: true,
                                    itemId: 'delete',
                                    scope: me,
                                    handler: me.onDeleteClick,
                                    disabled: true
                                }, '|',
                                {
                                    iconCls: 'icon-sync',
                                    text: 'Commit',
                                    scope: me,
                                    handler: me.onCommitClick
                                },
                                {
                                    iconCls: 'icon-sync',
                                    text: 'Sync',
                                    scope: me,
                                    handler: me.onSyncClick
                                },
                                , '->',
                                {
                                    scope: this,
                                    xtype: 'textfield'
                                },
                                {
                                    iconCls: 'icon-search',
                                    text: 'Search',
                                    scope: me,
                                    handler: this.onSearchClick
                                },
                            ]
                        }
                    ],
                    listeners: {
                        afterrender: {
                            delay: 1,
                            fn: function (item) {
                                this.edit.show();
                                this.edit.el.alignTo(this, 'br-br', [-20, -20]);
                                this.onOpenClick();
                            },
                            scope: this
                        },
                        expand: {
                            fn: function (view, e, eOpts) {
                                this.onFocus();
                            },
                            scope: this
                        },
                        collapse: {
                            fn: function (view, e, eOpts) {
                                this.onBlur();
                            },
                            scope: this
                        },
                        blur: {
                            // this : Ext.Component
                            // e : Ext.EventObject, blur event.
                            // eOpts : Object, The options object passed to Ext.util.Observable.addListener.
                            fn: function (view, e, eOpts) {
                                publish('CanEdit', false);
                                this.onBlur(e, eOpts);
                            },
                            scope: this
                        },
                        focus: {
                            fn: function (view, e, eOpts) {
                                publish('CanEdit', true);
                                this.onFocus(e, eOpts);
                            },
                            scope: this
                        }
                    },
                    store: store,
                    selModel: Ext.create("Ext.selection.RowModel",
                        {
                            selType: "rowmodel",
                            /*listeners: {
                                selectionchange: {
                                    fn: function (selModel, selections) {
                                        this.onSelectionChange(selModel, selections)
                                    },
                                    scope: this
                                }
                            }*/
                        })
                });

            this.callParent();
            this.getSelectionModel().on('selectionchange', this.onSelectionChange, this);

            // appy the config
            //Ext.apply(this, config);

            // Call parent (required)
            //App.ux.AreasPanel.superclass.initComponent.apply(this, arguments);
        },

        // Add button was clicked on the grid toolbar.
        onAddClick: function () {
            this.editing.cancelEdit();

            // Create a model instance
            var r = new this.model/* Ext.create('Employee', {
                name: 'New Guy',
                email: 'new@sencha-test.com',
                start: Ext.Date.clearTime(new Date()),
                salary: 50000,
                active: true
            })*/;

            this.store.insert(0, r);
            this.editing.startEdit(0, 0);
        },

        onBeforeCloseDialog: function () {
            //if (this.form.getForm().isDirty()) {
            publish('CancelCloseDialog');
                Ext.Msg.confirm('Changes', 'Changes are not saved. Continue?', function (answer) {
                    if (answer == 'yes') {
                        publish('CloseDialog');
                    }
                });
            //}
        },

        onBlur: function (e, eOpts) {
            this.title = "Areas (blur)";
            publish('CanEdit', false);
            unsubscribe('BeforeCloseDialog', this.onBeforeCloseDialog);
        },

        // Windows close window was clicked on the edit dialog.
        onCloseClick: function () {
            this.edit.hide(this.edit, function () {
                this.tools[3].enable();
            }, this); // null to "unset" animation target
        },

        onCommitClick: function () {
            this.store.commitChanges();
            if (!this.store.isDirty()) {
                //this.saveButton.disable();
            }
        },

        // Delete button was clicked.
        onDeleteClick: function () {
            this.editing.cancelEdit();

            var view = this.getView();
            var sm = view.getSelectionModel();
            var selection = sm.getSelection();

            var index;
            for (var i = 0; i < selection.length; i++) {
                var record = selection[i];
                index = Math.min(index || record.index, record.index);
                this.store.remove(selection[i]);
            }

            var count = this.store.getCount();
            if (!!index && count > 0) {
                sm.select(Math.min(index, count - 1));
            }
        },

        onFocus: function (e, eOpts) {
            publish('CanEdit', true);
            subscribe('BeforeCloseDialog', this.onBeforeCloseDialog);
        },

        // Open button was clicked on the grid toolbar to open the edit dialog 
        onOpenClick: function () {
            this.edit.show(this.edit, function () {
                this.tools[3].disable();
            }, this);
        },

        // Refresh buton was clicked.
        onRefreshClick: function () {
        },

        // Reset button was clicked.
        onResetClick: function () {
            this.form.loadRecord(this.selected[0]);
        },

        onSaveClick: function () {
        },

        onSyncClick: function () {
            this.store.sync();
        },

        onSearchClick: function () {
        },

        onSelectionChange: function (selModel, selections) {
            this.down('#delete').setDisabled(selections.length === 0);
            var form = this.form.getForm();
            form.reset();
            this.form.setActiveRecord(selections[0]);
        },
    };
});