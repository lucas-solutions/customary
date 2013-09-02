Ext.define('App.ux.MainToolbar', function () {

    var publish = window.y7Adapter.publish || Ext.emptyFn;
    var subscribe = window.y7Adapter.subscribe || Ext.emptyFn;

    return {
        extend: 'Ext.toolbar.Toolbar',

        /**
        * Called by Ext when instantiating
        *
        * @private
        * @param {Object} config Configuration object
        */
        initComponent: function (config) {

            var me = this;

            var items = [
                    // edit options
                    (function () {
                        var mode = 'readonly';
                        var items = {};

                        items.readonly = Ext.create('Ext.menu.Item', {
                            text: "Read Only",
                            disabled: true,
                            listeners: {
                                click: {
                                    fn: function () {
                                        mode = 'readonly';
                                        items.readonly.setDisabled(true);
                                        items.form.setDisabled(false);
                                        items.row.setDisabled(false);
                                        this.parentMenu.ownerButton.toggle(true);
                                        this.parentMenu.ownerButton.setText(this.text);
                                        publish('ReadOnly');
                                    }
                                }
                            }
                        });

                        items.form = Ext.create('Ext.menu.Item', {
                            text: "Form Edit",
                            listeners: {
                                click: {
                                    fn: function () {
                                        mode = 'form';
                                        items.readonly.setDisabled(false);
                                        items.form.setDisabled(true);
                                        items.row.setDisabled(false);
                                        this.parentMenu.ownerButton.toggle(false);
                                        this.parentMenu.ownerButton.setText(this.text);
                                        publish('FormEdit');
                                    }
                                }
                            }
                        });

                        items.row = Ext.create('Ext.menu.Item', {
                            text: "Row Edit",
                            listeners: {
                                click: {
                                    fn: function () {
                                        mode = 'row';
                                        items.readonly.setDisabled(false);
                                        items.form.setDisabled(false);
                                        items.row.setDisabled(true);
                                        this.parentMenu.ownerButton.toggle(false);
                                        this.parentMenu.ownerButton.setText(this.text);
                                        publish('RowEdit');
                                    }
                                }
                            }
                        });

                        var canEdit = false;
                        var pressed = false;

                        var menu = new Ext.menu.Menu({
                            items: [items.readonly, items.form, items.row]
                        });

                        var button = Ext.create('Ext.button.Split', {
                            //xtype: 'splitbutton',
                            disabled: !canEdit,
                            text: items.readonly.text,
                            //iconCls: 'icon-cancel',
                            menu: menu,
                            handler: function (e) {
                                switch (mode) {
                                    case 'form':

                                        pressed = !pressed;
                                        if (pressed) {
                                            publish('OpenDialog', { title: 'Edit Dialog', content: Ext.create('Ext.button.Button', { text: "Succeeded" }) });
                                        } else {
                                            publish('CloseDialog');
                                        }
                                        this.toggle(pressed);
                                        break;

                                    case 'row':
                                        pressed = !pressed;
                                        publish('StartRowEdit');
                                        this.toggle(pressed);
                                        break;

                                    default:
                                        // message: drop down and select one of the other options and then click the button 
                                        break;
                                }
                            }
                        });

                        subscribe('CanEdit', function (value) {
                            canEdit = !!value;
                            if (canEdit) {
                                button.setDisabled(false);
                            } else {
                                button.setDisabled(true);
                            }
                        });

                        subscribe('FormEditEnd', function () {
                            switch (mode) {
                                case 'form':
                                    button.toggle(false);
                                    break;
                            }
                        });

                        subscribe('CloseDialog', function () {
                            pressed = false;
                            button.toggle(false);
                        });

                        button.toggle(pressed);

                        return button;
                    }()),
                    // update options
                    (function () {
                        var mode = 'manual';
                        var items = {};

                        items.auto = Ext.create('Ext.menu.Item', {
                            text: "Auto Update",
                            listeners: {
                                click: {
                                    fn: function () {
                                        mode = 'auto';
                                        items.auto.setDisabled(true);
                                        items.manual.setDisabled(false);
                                        this.parentMenu.ownerButton.toggle(true);
                                        this.parentMenu.ownerButton.setText(this.text);
                                    }
                                }
                            }
                        });

                        items.manual = Ext.create('Ext.menu.Item', {
                            text: "Update",
                            disabled: true,
                            listeners: {
                                click: {
                                    fn: function () {
                                        mode = 'manual';
                                        items.auto.setDisabled(false);
                                        items.manual.setDisabled(true);
                                        this.parentMenu.ownerButton.toggle(false);
                                        this.parentMenu.ownerButton.setText(this.text);
                                    }
                                }
                            }
                        });

                        subscribe('CanUpdate', function (value) {
                        });

                        var button = Ext.create('Ext.button.Split', {
                            xtype: 'splitbutton',
                            text: items.manual.text,
                            //iconCls: 'icon-cancel',
                            menu: [items.manual, items.auto],
                            handler: function (e) {
                                switch (mode) {
                                    case 'manual':
                                        alert(mode);
                                        break;

                                    default:
                                        // message: drop down and select one of the other options and then click the button 
                                        break;
                                }
                            }
                        });

                        return button;
                    }()),
                    (function () {

                        subscribe('CanCancel', function (value) {
                        });

                        return {
                            // xtype: 'button', // default for Toolbars
                            text: 'Cancel',
                        }
                    }()),
                    '-', // same as {xtype: 'tbseparator'} to create Ext.toolbar.Separator
                    (function () {

                        subscribe('CanCreate', function (value) {
                        });

                        return {
                            // xtype: 'button', // default for Toolbars
                            text: 'Create',
                        }
                    }()),
                    (function () {

                        subscribe('CanDelete', function (value) {
                        });

                        return {
                            // xtype: 'button', // default for Toolbars
                            text: 'Delete',
                        }
                    }()),
                    // begin using the right-justified button container
                    '->', // same as { xtype: 'tbfill' }
                    // save changes options
                    (function () {
                        var mode = 'manual';
                        var items = {};

                        items.auto = Ext.create('Ext.menu.Item', {
                            text: "Auto Save",
                            listeners: {
                                click: {
                                    fn: function () {
                                        mode = 'auto';
                                        items.auto.setDisabled(true);
                                        items.manual.setDisabled(false);
                                        items.all.setDisabled(false);
                                        this.parentMenu.ownerButton.toggle(true);
                                        this.parentMenu.ownerButton.setText(this.text);
                                    }
                                }
                            }
                        });

                        items.manual = Ext.create('Ext.menu.Item', {
                            text: "Save Changes",
                            disabled: true,
                            listeners: {
                                click: {
                                    fn: function () {
                                        mode = 'manual';
                                        items.auto.setDisabled(false);
                                        items.manual.setDisabled(true);
                                        items.all.setDisabled(false);
                                        this.parentMenu.ownerButton.toggle(false);
                                        this.parentMenu.ownerButton.setText(this.text);
                                    }
                                }
                            }
                        });

                        items.all = Ext.create('Ext.menu.Item', {
                            text: "Save All Changes",
                            disabled: false,
                            listeners: {
                                click: {
                                    fn: function () {
                                        mode = 'all';
                                        items.auto.setDisabled(false);
                                        items.manual.setDisabled(false);
                                        items.all.setDisabled(true);
                                        this.parentMenu.ownerButton.toggle(false);
                                        this.parentMenu.ownerButton.setText(this.text);
                                    }
                                }
                            }
                        });

                        var dirty = 0;

                        subscribe('IsDirty', function (value) {
                            dirty += value;
                        });

                        subscribe('CanSave', function (value) {
                        });

                        var button = Ext.create('Ext.button.Split', {
                            xtype: 'splitbutton',
                            text: items.manual.text,
                            //iconCls: 'icon-cancel',
                            menu: [items.manual, items.all, items.auto],
                            handler: function (e) {
                                switch (mode) {
                                    case 'manual':
                                        publish('SaveChanges');
                                        break;

                                    case 'all':
                                        publish('SaveAllChanges');
                                        break;

                                    default:
                                        // message: drop down and select one of the other options and then click the button 
                                        break;
                                }
                            }
                        });

                        return button;
                    }()),
                    // reject changes options
                    (function () {
                        var mode = 'manual';
                        var items = {};

                        items.manual = Ext.create('Ext.menu.Item', {
                            text: "Reject Changes",
                            disabled: true,
                            listeners: {
                                click: {
                                    fn: function () {
                                        mode = 'manual';
                                        items.manual.setDisabled(true);
                                        items.all.setDisabled(false);
                                        this.parentMenu.ownerButton.setText(this.text);
                                    }
                                }
                            }
                        });

                        items.all = Ext.create('Ext.menu.Item', {
                            text: "Reject All Changes",
                            disabled: false,
                            listeners: {
                                click: {
                                    fn: function () {
                                        mode = 'all';
                                        items.manual.setDisabled(false);
                                        items.all.setDisabled(true);
                                        this.parentMenu.ownerButton.setText(this.text);
                                    }
                                }
                            }
                        });

                        var dirty = 0;

                        subscribe('IsDirty', function (value) {
                            dirty += value;
                        });

                        subscribe('CanSave', function (value) {
                        });

                        var button = Ext.create('Ext.button.Split', {
                            xtype: 'splitbutton',
                            text: items.manual.text,
                            //iconCls: 'icon-cancel',
                            menu: [items.manual, items.all],
                            handler: function (e) {
                                switch (mode) {
                                    case 'manual':
                                        publish('RejectChanges');
                                        break;

                                    case 'all':
                                        publish('RejectAllChanges');
                                        break;
                                }
                            }
                        });

                        return button;
                    }()),
                    /*{
                        xtype: 'splitbutton',
                        iconCls: 'icon-sync',
                        text: 'Sync',
                        handler: function () {
                        },
                        menu: [
                            { text: "Sync Tree", handler: function () { alert("Row Edit clicked"); } },
                            { text: "Sync Url", handler: function () { alert("Form Edit clicked"); } },
                        ]
                    },*/
                    // sync options
                    (function () {
                        var auto = { tree: false, url: false };
                        var items = {};

                        items.tree = Ext.create('Ext.menu.Item', {
                            text: "Auto Sync Tree",
                            checked: auto.tree,
                            listeners: {
                                click: {
                                    fn: function () {
                                        auto.tree = this.checked = !!this.checked;
                                    }
                                }
                            }
                        });

                        items.url = Ext.create('Ext.menu.Item', {
                            text: "Auto Sync Url",
                            checked: auto.url,
                            listeners: {
                                click: {
                                    fn: function () {
                                        auto.url = this.checked = !!this.checked;
                                    }
                                }
                            }
                        });

                        var button = Ext.create('Ext.button.Split', {
                            xtype: 'splitbutton',
                            text: "Sync",
                            //iconCls: 'icon-cancel',
                            menu: [items.tree, items.url],
                            handler: function (e) {
                                alert('sync');
                            }
                        });

                        return button;
                    }()),
                    //'text 1', // same as {xtype: 'tbtext', text: 'text1'} to create Ext.toolbar.TextItem
                    //{ xtype: 'tbspacer' },// same as ' ' to create Ext.toolbar.Spacer
                    //'text 2',
                    //{ xtype: 'tbspacer', width: 50 } // add a 50px space
                    //'text 3',
                    { xtype: 'tbspacer' },// same as ' ' to create Ext.toolbar.Spacer
                    //'-', // same as {xtype: 'tbseparator'} to create Ext.toolbar.Separator
                    {
                        xtype: 'textfield',
                        name: 'field1',
                        emptyText: 'Search...'
                    },
                    {
                        // xtype: 'button', // default for Toolbars
                        //iconCls: 'icon-search',
                        text: 'Go',
                        handler: function () {
                        }
                    },
            ];

            Ext.apply(this,
                {
                    items: items
                });

            // Call parent (required)
            //App.ux.MainToolbar.superclass.initComponent.apply(this, arguments);
            this.callParent();
        }
    };
});