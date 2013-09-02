Ext.define('Ext.custom.Grid', function () {

    var copy = window.y7Adapter.copy || Ext.emptyFn;
    var publish = window.y7Adapter.publish || Ext.emptyFn;
    var subscribe = window.y7Adapter.subscribe || Ext.emptyFn;

    function validation(record, validation) {
        if (typeof record.validations === 'undefined') {
            record.validations = [];
        }
        record.validations.push(validation);
    };

    var ModelFields = {
        // A function which converts the value provided by the Reader into an object that will be stored in the Model.
        convert: true, // function(value, record) { var fullName  = record.get('name'), splits = fullName.split(" "), firstName = splits[0]; return firstName; }

        // Used when converting received data into a Date when the type is specified as "date".
        format: 'dateFormat',

        // The default value used when a Model is being created by a Reader when the item referenced by the mapping does not exist in the data object (i.e. undefined). Defaults to "".
        defaultValue: true,

        // (Optional) A path expression for use by the Ext.data.reader.Reader implementation that is creating the Model to extra.
        mapping: true,

        // The name by which the field is referenced within the Model.
        name: true,

        // False to exclude this field from the Ext.data.Model.modified fields in a model.
        persist: true,

        readOnly: true,

        // Initial direction to sort ("ASC" or "DESC"). Defaults to "ASC".
        sortDir: true,

        // A function which converts a Field's value to a comparable value in order to ensure correct sort ordering.
        sortType: true,

        // The data type for automatic conversion from received data to the stored value if convert has not been specified. This may be specified as a string value.
        // auto (Default, implies no conversion), string, int, float, boolean, date
        type: {
            convert: function (value, record) {
                switch (value) {
                    case 'email':
                        record.vtype = 'email';
                        return 'string';
                    case 'text':
                        return 'string';
                }
                return value;
            }
        },

        // Use when converting received data into a Number type (either int or float). If the value cannot be parsed, null will be used if useNull is true, otherwise the value will be 0. Defaults to false.
        useNull: true,

        //
        // validations
        exclusion: {
            convert: function (value, record) {
                if (value instanceof Array /*typeof value === 'object' && typeof value.length === 'int'*/) {
                    // Validates that the given value is present in the configured list
                    validation({ type: 'exclusion', field: record.name, list: value });
                }
            }
        },

        inclusion: {
            convert: function (value, record) {
                if (typeof record.validations === 'undefined') {
                    record.validations = [];
                }
                if (value instanceof Array /*typeof value === 'object' && typeof value.length === 'int'*/) {
                    // Validates that the given value is present in the configured list
                    validation({ type: 'inclusion', field: record.name, list: value });
                }
            }
        },

        matcher: {
            convert: function (value, record) {
                if (value instanceof Array /*typeof value === 'object' && typeof value.length === 'int'*/) {
                    // Returns true if the given value passes validation against the configured matcher regex
                    validation({ type: 'format', field: record.name, matcher: value });
                }
            }
        },

        max: {
            convert: function (value, record) {
                if (typeof value === 'int') {
                    // Returns true if the given value is between the configured min and max values
                    validation({ type: 'length', field: record.name, max: value });
                }
            }
        },

        min: {
            convert: function (value, record) {
                if (typeof value === 'int') {
                    // Returns true if the given value is between the configured min and max values
                    validation({ type: 'length', field: record.name, mix: value });
                }
            }
        },

        require: {
            convert: function (value, record) {
                if (typeof value === 'boolean' && value === true) {
                    // Validates that the given value is present
                    validation({ type: 'presence', field: record.name });
                }
            }
        },
    };

    var ColumnItems = {

        // Width of the header if no width or flex is specified. Defaults to 100.
        defaultWidth: true,

        // True to disable the component.
        disabled: true,

        // Specifies whether the column header can be reordered by dragging
        draggable: true,

        // An optional xtype or config object for a Field to use for editing. Only applicable if the grid is using an Editing plugin.
        editor: true,

        flex: true,

        format: true,

        // Specifies whether the grid can be grouped by the column dataIndex. See also Ext.grid.feature.Grouping
        groupable: true,

        // True to hide the component.
        hidden: true,

        // Specifies whether the column can be hidden using the column menu
        hideable: true,

        // The maximum value in pixels which this Component will set its width to.
        maxWidth: true,

        // The minimum value in pixels which this Component will set its width to.
        minWidth: true,

        // Disables the column header menu
        menuDisabled: true,

        // The dataIndex is the field in the underlying Ext.data.Store to use as the value for the column.
        name: 'dataIndex',

        // Allows the underlying store value to be transformed before being displayed in the grid
        renderer: true,

        // Set to false to prevent the column from being resizable. Defaults to true
        resizable: true,

        // Specifies whether the column can be sorted by clicking the header or using the column menu
        sortable: true,

        // An Ext.Template, Ext.XTemplate or an array of strings to form an Ext.XTemplate. Used in conjunction with the data and tplWriteMode configurations.
        template: {
            name: 'tpl',
            convert: function (value, record) {
                // The Ext.(X)Template method to use when updating the content area of the Component. See Ext.XTemplate.overwrite for information on default mode.
                // Defaults to: 'overwrite'
                return value;
            },
            type: 'string|object'
        },

        // Sets the header text for the column
        title: 'text',

        // The xtype configuration option can be used to optimize Component creation and rendering. It serves as a shortcut to the full componet name.
        // You can define your own xtype on a custom component by specifying the alias config option with a prefix of widget
        type: {
            name: 'xtype',
            convert: function (value, record) {
                switch (value) {
                    case 'date':
                        return 'datecolumn';
                }
                // return undefined;
            }
        },

        // HeaderContainer overrides the default weight of 0 for all docked items to 100. This is so that it has more priority over things like toolbars.
        width: true
    };

    function init(mt) {

        var that = {
            path: mt.path
        };

        if (typeof mt.members !== 'object') {
            return false;
        }

        var fields = [];
        var items = [
        {
            width: 50,
            xtype: "rownumberer",
            sortable: false
        }];
        
        for (var name in mt.members) {
            var config = mt.members[name];

            var field = { name: name };
            var item = { dataIndex: name };
            

            copy(config, field, ModelFields);
            copy(config, item, ColumnItems);

            switch (field.type) {
                case 'grid':
                    break;
                default:
                    fields.push(field);
                    break;
            }

            switch (item.xtype) {
                case 'grid':
                    break;
                default:
                    items.push(item);
                    break;
            }
        }

        var validations = [];
        for (var field in fields) {
            if (field.validation instanceof Array) {
                validations.concat(field.validation);
                delete field.validation;
            }
        }

        that.model = Ext.define(Ext.id(), {
            extend: 'Ext.data.Model',
            fields: fields,
            validations: validations
        });


        that.columns = {
            items: items
        };

        that.store = Ext.create('Ext.data.Store', {
            // destroy the store if the grid is destroyed
            autoDestroy: true,
            autoLoad: true,
            //autoSave: true,
            autoSync: false,
            batchActions: true,
            //buffered: true,
            pageSize: 100,
            model: that.model,
            proxy: {
                type: 'ajax',
                api: {
                    read: that.path + "/Store",    // GET
                    create: that.path + "/Insert", // POST
                    update: that.path + "/Update", // POST
                    destroy: that.path + "/Remove" // POST
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
                    //dateFormat: "",
                    idProperty: mt.idProperty || "Name",
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
        });

        that.plugins = {
            editing: Ext.create('Ext.grid.plugin.RowEditing', {
                clicksToEdit: 2,
                clicksToMoveEditor: 1,
                autoCancel: true
            })
        };

        that.selModel = Ext.create("Ext.selection.RowModel", {
            selType: "rowmodel",
            /*listeners: {
                selectionchange: {
                    fn: function (selModel, selections) {
                        this.onSelectionChange(selModel, selections)
                    },
                    scope: this
                }
            }*/
        });

        return that;
    };

    return {
        extend: 'Ext.grid.Panel',
        /*requires: [
        ],*/
        initComponent: function (config) {

            var that = init(this.initialConfig.metadata);

            Ext.apply(this,
                {
                    columns: that.columns,
                    iconCls: 'icon-grid',
                    layout: 'fit',
                    listeners: {
                    },
                    plugins: [that.plugins.editing],
                    selModel: that.selModel,
                    store: that.store,
                });

            this.callParent();
        }
    };

    return closure;
});