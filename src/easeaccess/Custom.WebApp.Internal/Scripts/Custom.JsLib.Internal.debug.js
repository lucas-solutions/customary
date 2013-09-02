//! Custom.JsLib.Internal.debug.js
//

(function() {

Type.registerNamespace('Custom.Areas.Reflection.Views');

////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.ApplicationForm

Custom.Areas.Reflection.Views.ApplicationForm = function Custom_Areas_Reflection_Views_ApplicationForm() {
    /// <field name="_form" type="Ext.form.Panel">
    /// </field>
    var config = { '': '' };
    this._form = Ext.create('Ext.form.Panel', config);
}
Custom.Areas.Reflection.Views.ApplicationForm.prototype = {
    _form: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.ApplicationGrid

Custom.Areas.Reflection.Views.ApplicationGrid = function Custom_Areas_Reflection_Views_ApplicationGrid() {
    /// <field name="_grid" type="Ext.grid.Panel">
    /// </field>
    var config = { '': '' };
    this._grid = Ext.create('Ext.grid.Panel', config);
}
Custom.Areas.Reflection.Views.ApplicationGrid.prototype = {
    _grid: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.ApplicationTree

Custom.Areas.Reflection.Views.ApplicationTree = function Custom_Areas_Reflection_Views_ApplicationTree() {
    /// <field name="_tree" type="Ext.tree.Panel">
    /// </field>
    var config = { '': '' };
    this._tree = Ext.create('Ext.tree.Panel', config);
}
Custom.Areas.Reflection.Views.ApplicationTree.prototype = {
    _tree: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.ApplicationViewport

Custom.Areas.Reflection.Views.ApplicationViewport = function Custom_Areas_Reflection_Views_ApplicationViewport() {
    /// <field name="_viewport" type="Ext.container.Viewport">
    /// </field>
    var config = { title: 'Application', icon: 'application', width: 800, height: 600, border: false, x: 100, y: 100, plain: true, layout: 'Border' };
    this._viewport = Ext.create('Ext.container.Viewport', config);
    this._viewport.items.push(null);
}
Custom.Areas.Reflection.Views.ApplicationViewport.prototype = {
    _viewport: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.AreaForm

Custom.Areas.Reflection.Views.AreaForm = function Custom_Areas_Reflection_Views_AreaForm() {
    /// <field name="_form" type="Ext.form.Panel">
    /// </field>
    var config = { '': '' };
    this._form = Ext.create('Ext.form.Panel', config);
}
Custom.Areas.Reflection.Views.AreaForm.prototype = {
    _form: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.AreasGrid

Custom.Areas.Reflection.Views.AreasGrid = function Custom_Areas_Reflection_Views_AreasGrid() {
    /// <field name="_grid" type="Ext.grid.Panel">
    /// </field>
    var config = { '': '' };
    this._grid = Ext.create('Ext.grid.Panel', config);
}
Custom.Areas.Reflection.Views.AreasGrid.prototype = {
    _grid: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.FileForm

Custom.Areas.Reflection.Views.FileForm = function Custom_Areas_Reflection_Views_FileForm() {
    /// <field name="_form" type="Ext.form.Panel">
    /// </field>
    var config = { '': '' };
    this._form = Ext.create('Ext.form.Panel', config);
}
Custom.Areas.Reflection.Views.FileForm.prototype = {
    _form: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.FilesGrid

Custom.Areas.Reflection.Views.FilesGrid = function Custom_Areas_Reflection_Views_FilesGrid() {
    /// <field name="_grid" type="Ext.grid.Panel">
    /// </field>
    var config = { '': '' };
    this._grid = Ext.create('Ext.grid.Panel', config);
}
Custom.Areas.Reflection.Views.FilesGrid.prototype = {
    _grid: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.ListForm

Custom.Areas.Reflection.Views.ListForm = function Custom_Areas_Reflection_Views_ListForm() {
    /// <field name="_form" type="Ext.form.Panel">
    /// </field>
    var config = { '': '' };
    this._form = Ext.create('Ext.form.Panel', config);
}
Custom.Areas.Reflection.Views.ListForm.prototype = {
    _form: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.ListsGrid

Custom.Areas.Reflection.Views.ListsGrid = function Custom_Areas_Reflection_Views_ListsGrid() {
    /// <field name="_grid" type="Ext.grid.Panel">
    /// </field>
    var config = { '': '' };
    this._grid = Ext.create('Ext.grid.Panel', config);
}
Custom.Areas.Reflection.Views.ListsGrid.prototype = {
    _grid: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.ModelForm

Custom.Areas.Reflection.Views.ModelForm = function Custom_Areas_Reflection_Views_ModelForm() {
    /// <field name="_form" type="Ext.form.Panel">
    /// </field>
    var config = { '': '' };
    this._form = Ext.create('Ext.form.Panel', config);
}
Custom.Areas.Reflection.Views.ModelForm.prototype = {
    _form: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.ModelsGrid

Custom.Areas.Reflection.Views.ModelsGrid = function Custom_Areas_Reflection_Views_ModelsGrid() {
    /// <field name="_grid" type="Ext.grid.Panel">
    /// </field>
    var config = { '': '' };
    this._grid = Ext.create('Ext.grid.Panel', config);
}
Custom.Areas.Reflection.Views.ModelsGrid.prototype = {
    _grid: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.NoteForm

Custom.Areas.Reflection.Views.NoteForm = function Custom_Areas_Reflection_Views_NoteForm() {
    /// <field name="_form" type="Ext.form.Panel">
    /// </field>
    var config = { '': '' };
    this._form = Ext.create('Ext.form.Panel', config);
}
Custom.Areas.Reflection.Views.NoteForm.prototype = {
    _form: null
}


////////////////////////////////////////////////////////////////////////////////
// Custom.Areas.Reflection.Views.NotesGrid

Custom.Areas.Reflection.Views.NotesGrid = function Custom_Areas_Reflection_Views_NotesGrid() {
    /// <field name="_grid" type="Ext.grid.Panel">
    /// </field>
    var config = { '': '' };
    this._grid = Ext.create('Ext.grid.Panel', config);
}
Custom.Areas.Reflection.Views.NotesGrid.prototype = {
    _grid: null
}


Custom.Areas.Reflection.Views.ApplicationForm.registerClass('Custom.Areas.Reflection.Views.ApplicationForm');
Custom.Areas.Reflection.Views.ApplicationGrid.registerClass('Custom.Areas.Reflection.Views.ApplicationGrid');
Custom.Areas.Reflection.Views.ApplicationTree.registerClass('Custom.Areas.Reflection.Views.ApplicationTree');
Custom.Areas.Reflection.Views.ApplicationViewport.registerClass('Custom.Areas.Reflection.Views.ApplicationViewport');
Custom.Areas.Reflection.Views.AreaForm.registerClass('Custom.Areas.Reflection.Views.AreaForm');
Custom.Areas.Reflection.Views.AreasGrid.registerClass('Custom.Areas.Reflection.Views.AreasGrid');
Custom.Areas.Reflection.Views.FileForm.registerClass('Custom.Areas.Reflection.Views.FileForm');
Custom.Areas.Reflection.Views.FilesGrid.registerClass('Custom.Areas.Reflection.Views.FilesGrid');
Custom.Areas.Reflection.Views.ListForm.registerClass('Custom.Areas.Reflection.Views.ListForm');
Custom.Areas.Reflection.Views.ListsGrid.registerClass('Custom.Areas.Reflection.Views.ListsGrid');
Custom.Areas.Reflection.Views.ModelForm.registerClass('Custom.Areas.Reflection.Views.ModelForm');
Custom.Areas.Reflection.Views.ModelsGrid.registerClass('Custom.Areas.Reflection.Views.ModelsGrid');
Custom.Areas.Reflection.Views.NoteForm.registerClass('Custom.Areas.Reflection.Views.NoteForm');
Custom.Areas.Reflection.Views.NotesGrid.registerClass('Custom.Areas.Reflection.Views.NotesGrid');
})();

//! This script was generated using Script# v0.7.4.0
