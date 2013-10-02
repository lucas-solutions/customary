/**
 * @fileOverview This "library" contains extended TextArea class which contains a trigger field working similar to TriggerField
 * @name Ext.ux.TriggerTextArea
 * @author Zak Karachiwala
 * @version x
 */
Ext.namespace("Ext.ux");
/**
 * A text area with a trigger
 * @constructor
 * @example
 * Create a text area with a trigger on 'author' field
<pre>
 var newField = new Ext.ux.TriggerTextArea(); 
 newField.applyTo('author');
</pre>
 * @param {Object} config
 */
Ext.ux.form.TriggerTextArea = function (config) {
    this.mimicing = false;
    Ext.ux.form.TriggerTextArea.superclass.constructor.call(this, config);
};

Ext.extend(Ext.ux.form.TriggerTextArea, Ext.form.TextArea, {
    /**
 * @cfg {String} triggerClass A css class to apply to the trigger
 */
    // private
    defaultAutoCreate: { tag: "textarea", style: "width:300px;height:60px;", autocomplete: "off" },

    /**
     * @cfg {Boolean} hideTrigger True to hide the trigger element and display only the base text field (defaults to false)
     */
    hideTrigger: false,

    /** @cfg {Boolean} grow @hide */
    // holder
    /*** @cfg {Number} growMin @hide */
    // holder
    /*** @cfg {Number} growMax @hide */
    // holder
    /***
         * @hide 
         * @method
         */
    //    autoSize: Ext.emptyFn,

    monitorTab: true,

    deferHeight: true,

    // private
    onResize: function (w, h) {
        Ext.ux.TriggerTextArea.superclass.onResize.apply(this, arguments);
        if (typeof w == 'number') {
            this.el.setWidth(this.adjustWidth('input', w - this.trigger.getWidth()));
        }
    },

    onChange: function (field, newValue, oldValue) {
        this.autoSize();
    },

    adjustSize: Ext.BoxComponent.prototype.adjustSize,

    getResizeEl: function () {
        return this.wrap;
    },

    getPositionEl: function () {
        return this.wrap;
    },

    // private
    alignErrorIcon: function () {
        this.errorIcon.alignTo(this.wrap, 'tl-tr', [2, 0]);
    },

    // private
    onRender: function (ct, position) {
        Ext.ux.TriggerTextArea.superclass.onRender.call(this, ct, position);
        this.wrap = this.el.wrap({ cls: "x-form-field-wrap" });
        this.trigger = this.wrap.createChild(this.triggerConfig ||
                { tag: "img", src: Ext.BLANK_IMAGE_URL, cls: "x-form-trigger " + this.triggerClass });
        if (this.hideTrigger) {
            this.trigger.setDisplayed(false);
        }
        this.initTrigger();
        if (!this.width) {
            this.wrap.setWidth(this.el.getWidth() + this.trigger.getWidth());
        }
        this.on("change", this.onChange, this, { preventDefault: true });
    },

    initTrigger: function () {
        this.trigger.on("click", this.onTriggerClick, this, { preventDefault: true });
        this.trigger.addClassOnOver('x-form-trigger-over');
        this.trigger.addClassOnClick('x-form-trigger-click');
    },

    onDestroy: function () {
        if (this.trigger) {
            this.trigger.removeAllListeners();
            this.trigger.remove();
        }
        if (this.wrap) {
            this.wrap.remove();
        }
        Ext.ux.TriggerTextArea.superclass.onDestroy.call(this);
    },

    // private
    onFocus: function () {
        Ext.ux.TriggerTextArea.superclass.onFocus.call(this);
        if (!this.mimicing) {
            this.wrap.addClass('x-trigger-wrap-focus');
            this.mimicing = true;
            Ext.get(Ext.isIE ? document.body : document).on("mousedown", this.mimicBlur, this);
            if (this.monitorTab) {
                this.el.on("keydown", this.checkTab, this);
            }
        }
    },

    // private
    checkTab: function (e) {
        if (e.getKey() == e.TAB) {
            this.triggerBlur();
        }
    },

    // private
    onBlur: function () {
        // do nothing
    },

    // private
    mimicBlur: function (e, t) {
        if (!this.wrap.contains(t) && this.validateBlur()) {
            this.triggerBlur();
        }
    },

    // private
    triggerBlur: function () {
        this.mimicing = false;
        Ext.get(Ext.isIE ? document.body : document).un("mousedown", this.mimicBlur);
        if (this.monitorTab) {
            this.el.un("keydown", this.checkTab, this);
        }
        this.wrap.removeClass('x-trigger-wrap-focus');
        Ext.ux.TriggerTextArea.superclass.onBlur.call(this);
    },

    // private
    // This should be overriden by any subclass that needs to check whether or not the field can be blurred.
    validateBlur: function (e, t) {
        return true;
    },

    // private
    onDisable: function () {
        Ext.ux.TriggerTextArea.onDisable.call(this);
        if (this.wrap) {
            this.wrap.addClass('x-item-disabled');
        }
    },

    // private
    onEnable: function () {
        Ext.ux.TriggerTextArea.onEnable.call(this);
        if (this.wrap) {
            this.wrap.removeClass('x-item-disabled');
        }
    },

    // private
    onShow: function () {
        if (this.wrap) {
            this.wrap.dom.style.display = '';
            this.wrap.dom.style.visibility = 'visible';
        }
    },

    // private
    onHide: function () {
        this.wrap.dom.style.display = 'none';
    },

    /**
     * The function that should handle the trigger's click event.  This method does nothing by default until overridden
     * by a handler implementation.
     * @method
     * @param {EventObject} e
     */
    onTriggerClick: Ext.emptyFn
});