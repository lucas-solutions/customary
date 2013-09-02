//! Custom.JsExt.Administration.debug.js
//

(function() {

Type.registerNamespace('Custom.Handlers');

////////////////////////////////////////////////////////////////////////////////
// Custom.Handlers.ReflectionNode

Custom.Handlers.ReflectionNode = function Custom_Handlers_ReflectionNode() {
}
Custom.Handlers.ReflectionNode.path = function Custom_Handlers_ReflectionNode$path(node) {
    /// <param name="node" type="Ext.data.NodeInterface">
    /// </param>
    /// <returns type="String"></returns>
    var raw = node.raw;
    var path = [];
    if (raw.name) {
        path.add(raw.name);
    }
    for (node = node.parentNode; node; node = node.parentNode) {
        raw = node.raw;
        path.add(raw.name);
    }
    path.reverse();
    return path.join('/');
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Handlers.ReflectionTabsObject

Custom.Handlers.ReflectionTabsObject = function Custom_Handlers_ReflectionTabsObject() {
    /// <field name="panel" type="Ext.tab.Panel">
    /// </field>
    /// <field name="application" type="Ext.tab.Tab">
    /// </field>
    /// <field name="area" type="Ext.tab.Tab">
    /// </field>
    /// <field name="files" type="Ext.tab.Tab">
    /// </field>
    /// <field name="file" type="Ext.tab.Tab">
    /// </field>
    /// <field name="lists" type="Ext.tab.Tab">
    /// </field>
    /// <field name="list" type="Ext.tab.Tab">
    /// </field>
    /// <field name="models" type="Ext.tab.Tab">
    /// </field>
    /// <field name="model" type="Ext.tab.Tab">
    /// </field>
    /// <field name="notes" type="Ext.tab.Tab">
    /// </field>
    /// <field name="note" type="Ext.tab.Tab">
    /// </field>
}
Custom.Handlers.ReflectionTabsObject.prototype = {
    panel: null,
    application: null,
    area: null,
    files: null,
    file: null,
    lists: null,
    list: null,
    models: null,
    model: null,
    notes: null,
    note: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Handlers.ReflectionTreePanel

Custom.Handlers.ReflectionTreePanel = function Custom_Handlers_ReflectionTreePanel() {
    Custom.Handlers.ReflectionTreePanel.initializeBase(this);
}
Custom.Handlers.ReflectionTreePanel.prototype = {
    
    itemClick: function Custom_Handlers_ReflectionTreePanel$itemClick(record, item, index, e, tabs) {
        /// <param name="record" type="Ext.data.NodeInterface">
        /// </param>
        /// <param name="item" type="Object" domElement="true">
        /// </param>
        /// <param name="index" type="Number">
        /// </param>
        /// <param name="e" type="Ext.EventObject">
        /// </param>
        /// <param name="tabs" type="Custom.Handlers.ReflectionTabsObject">
        /// </param>
        var tree = this;
        var raw = record.raw;
        switch (raw.type) {
            case 'application':
                tabs.application.show();
                tabs.application.getEl().dom.style.display = '';
                tabs.area.show();
                tabs.files.hide();
                tabs.file.hide();
                tabs.lists.hide();
                tabs.list.hide();
                tabs.models.hide();
                tabs.model.hide();
                tabs.notes.hide();
                tabs.note.hide();
                tabs.application.setActive();
                break;
            case 'area':
                tabs.area.show();
                tabs.area.getEl().dom.style.display = '';
                tabs.files.hide();
                tabs.file.hide();
                tabs.lists.hide();
                tabs.list.hide();
                tabs.models.hide();
                tabs.model.hide();
                tabs.notes.hide();
                tabs.note.hide();
                tabs.area.setActive();
                break;
            case 'files':
                tabs.files.show();
                tabs.files.getEl().dom.style.display = '';
                tabs.files.setVisible(true);
                tabs.file.hide();
                tabs.lists.hide();
                tabs.list.hide();
                tabs.models.hide();
                tabs.model.hide();
                tabs.notes.hide();
                tabs.note.hide();
                tabs.files.setActive();
                break;
            case 'file':
                tabs.file.show();
                tabs.file.getEl().dom.style.display = '';
                tabs.file.setVisible(true);
                tabs.lists.hide();
                tabs.list.hide();
                tabs.models.hide();
                tabs.model.hide();
                tabs.notes.hide();
                tabs.note.hide();
                tabs.file.setActive();
                break;
            case 'lists':
                tabs.files.hide();
                tabs.file.hide();
                tabs.lists.show();
                tabs.lists.getEl().dom.style.display = '';
                tabs.lists.setVisible(true);
                tabs.list.hide();
                tabs.models.hide();
                tabs.model.hide();
                tabs.notes.hide();
                tabs.note.hide();
                tabs.lists.setActive();
                break;
            case 'list':
                tabs.files.hide();
                tabs.file.hide();
                tabs.list.show();
                tabs.list.getEl().dom.style.display = '';
                tabs.list.setVisible(true);
                tabs.models.hide();
                tabs.model.hide();
                tabs.notes.hide();
                tabs.note.hide();
                tabs.list.setActive();
                break;
            case 'models':
                tabs.files.hide();
                tabs.file.hide();
                tabs.lists.hide();
                tabs.list.hide();
                tabs.models.show();
                tabs.models.getEl().dom.style.display = '';
                tabs.models.setVisible(true);
                tabs.model.hide();
                tabs.notes.hide();
                tabs.note.hide();
                tabs.models.setActive();
                break;
            case 'model':
                tabs.files.hide();
                tabs.file.hide();
                tabs.lists.hide();
                tabs.list.hide();
                tabs.model.show();
                tabs.model.getEl().dom.style.display = '';
                tabs.model.setVisible(true);
                tabs.notes.hide();
                tabs.note.hide();
                tabs.model.setActive();
                break;
            case 'notes':
                tabs.files.hide();
                tabs.file.hide();
                tabs.lists.hide();
                tabs.list.hide();
                tabs.models.hide();
                tabs.model.hide();
                tabs.notes.show();
                tabs.notes.getEl().dom.style.display = '';
                tabs.notes.setVisible(true);
                tabs.notes.getEl().show();
                tabs.note.hide();
                tabs.notes.setActive();
                break;
            case 'note':
                tabs.files.hide();
                tabs.file.hide();
                tabs.lists.hide();
                tabs.list.hide();
                tabs.models.hide();
                tabs.model.hide();
                tabs.notes.hide();
                tabs.note.show();
                tabs.note.getEl().dom.style.display = 'block';
                tabs.note.setVisible(true);
                tabs.note.getEl().show();
                tabs.note.setActive();
                break;
        }
        tabs.panel.doLayout();
    },
    
    itemDbClick: function Custom_Handlers_ReflectionTreePanel$itemDbClick(record, item, index, e, tabs) {
        /// <param name="record" type="Ext.data.NodeInterface">
        /// </param>
        /// <param name="item" type="Object" domElement="true">
        /// </param>
        /// <param name="index" type="Number">
        /// </param>
        /// <param name="e" type="Ext.EventObject">
        /// </param>
        /// <param name="tabs" type="Ext.tab.Panel">
        /// </param>
        var tree = this;
        var raw = record.raw;
        var tab = Ext.create('Ext.tab.Tab', { id: Custom.Handlers.ReflectionNode.path(record), title: raw.type });
        tabs.add(tab);
        switch (raw.type) {
            case 'application':
                break;
            case 'area':
                break;
            case 'files':
                break;
            case 'file':
                break;
            case 'lists':
                break;
            case 'list':
                break;
            case 'models':
                break;
            case 'model':
                break;
            case 'notes':
                break;
            case 'note':
                break;
        }
        tabs.doLayout();
    }
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Handlers.ReflectionTreeProxy

Custom.Handlers.ReflectionTreeProxy = function Custom_Handlers_ReflectionTreeProxy() {
}
Custom.Handlers.ReflectionTreeProxy.prototype = {
    
    buildUrl: function Custom_Handlers_ReflectionTreeProxy$buildUrl(request) {
        /// <param name="request" type="Ext.data.Request">
        /// </param>
        /// <returns type="String"></returns>
        var url = Custom.Handlers.ReflectionNode.path(request.operation.node);
        var raw = request.operation.node.raw;
        return (raw.path) ? url + '/' + raw.path : url;
    }
}


Custom.Handlers.ReflectionNode.registerClass('Custom.Handlers.ReflectionNode');
Custom.Handlers.ReflectionTabsObject.registerClass('Custom.Handlers.ReflectionTabsObject');
Custom.Handlers.ReflectionTreePanel.registerClass('Custom.Handlers.ReflectionTreePanel', Ext.tree.Panel);
Custom.Handlers.ReflectionTreeProxy.registerClass('Custom.Handlers.ReflectionTreeProxy');
})();

//! This script was generated using Script# v0.7.4.0
