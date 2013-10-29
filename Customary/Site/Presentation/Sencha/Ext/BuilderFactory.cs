using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    public class BuilderFactory
    {
        public ActionColumn.Builder ActionColumn()
        {
            ActionColumn component = new ActionColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ActionColumn(component);
        }

        public ActionColumn.Builder ActionColumn(ActionColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ActionColumn.Builder(component);
        }

        public ActionColumn.Builder ActionColumn(ActionColumn.Config config)
        {
            return new ActionColumn.Builder(new ActionColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ActionItem.Builder ActionItem()
        {
            ActionItem component = new ActionItem
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ActionItem(component);
        }

        public ActionItem.Builder ActionItem(ActionItem component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ActionItem.Builder(component);
        }

        public ActionItem.Builder ActionItem(ActionItem.Config config)
        {
            return new ActionItem.Builder(new ActionItem(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public AjaxOptions.Builder AjaxOptions()
        {
            AjaxOptions component = new AjaxOptions
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.AjaxOptions(component);
        }

        public AjaxOptions.Builder AjaxOptions(AjaxOptions component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new AjaxOptions.Builder(component);
        }

        public AjaxOptions.Builder AjaxOptions(AjaxOptions.Config config)
        {
            return new AjaxOptions.Builder(new AjaxOptions(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public AjaxProxy.Builder AjaxProxy()
        {
            AjaxProxy component = new AjaxProxy
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.AjaxProxy(component);
        }

        public AjaxProxy.Builder AjaxProxy(AjaxProxy component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new AjaxProxy.Builder(component);
        }

        public AjaxProxy.Builder AjaxProxy(AjaxProxy.Config config)
        {
            return new AjaxProxy.Builder(new AjaxProxy(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public App.Builder App()
        {
            App component = new App
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.App(component);
        }

        public App.Builder App(App component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new App.Builder(component);
        }

        public App.Builder App(App.Config config)
        {
            return new App.Builder(new App(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public AppInit.Builder AppInit()
        {
            AppInit component = new AppInit
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.AppInit(component);
        }

        public AppInit.Builder AppInit(AppInit component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new AppInit.Builder(component);
        }

        public AppInit.Builder AppInit(AppInit.Config config)
        {
            return new AppInit.Builder(new AppInit(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public AreaSeries.Builder AreaSeries()
        {
            AreaSeries component = new AreaSeries
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.AreaSeries(component);
        }

        public AreaSeries.Builder AreaSeries(AreaSeries component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new AreaSeries.Builder(component);
        }

        public AreaSeries.Builder AreaSeries(AreaSeries.Config config)
        {
            return new AreaSeries.Builder(new AreaSeries(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ArrayReader.Builder ArrayReader()
        {
            ArrayReader component = new ArrayReader
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ArrayReader(component);
        }

        public ArrayReader.Builder ArrayReader(ArrayReader component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ArrayReader.Builder(component);
        }

        public ArrayReader.Builder ArrayReader(ArrayReader.Config config)
        {
            return new ArrayReader.Builder(new ArrayReader(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public AxisGrid.Builder AxisGrid()
        {
            AxisGrid component = new AxisGrid
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.AxisGrid(component);
        }

        public AxisGrid.Builder AxisGrid(AxisGrid component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new AxisGrid.Builder(component);
        }

        public AxisGrid.Builder AxisGrid(AxisGrid.Config config)
        {
            return new AxisGrid.Builder(new AxisGrid(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public AxisLabel.Builder AxisLabel()
        {
            AxisLabel component = new AxisLabel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.AxisLabel(component);
        }

        public AxisLabel.Builder AxisLabel(AxisLabel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new AxisLabel.Builder(component);
        }

        public AxisLabel.Builder AxisLabel(AxisLabel.Config config)
        {
            return new AxisLabel.Builder(new AxisLabel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public BarSeries.Builder BarSeries()
        {
            BarSeries component = new BarSeries
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.BarSeries(component);
        }

        public BarSeries.Builder BarSeries(BarSeries component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new BarSeries.Builder(component);
        }

        public BarSeries.Builder BarSeries(BarSeries.Config config)
        {
            return new BarSeries.Builder(new BarSeries(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public BelongsToAssociation.Builder BelongsToAssociation()
        {
            BelongsToAssociation component = new BelongsToAssociation
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.BelongsToAssociation(component);
        }

        public BelongsToAssociation.Builder BelongsToAssociation(BelongsToAssociation component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new BelongsToAssociation.Builder(component);
        }

        public BelongsToAssociation.Builder BelongsToAssociation(BelongsToAssociation.Config config)
        {
            return new BelongsToAssociation.Builder(new BelongsToAssociation(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public BooleanColumn.Builder BooleanColumn()
        {
            BooleanColumn component = new BooleanColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.BooleanColumn(component);
        }

        public BooleanColumn.Builder BooleanColumn(BooleanColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new BooleanColumn.Builder(component);
        }

        public BooleanColumn.Builder BooleanColumn(BooleanColumn.Config config)
        {
            return new BooleanColumn.Builder(new BooleanColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public BooleanFilter.Builder BooleanFilter()
        {
            BooleanFilter component = new BooleanFilter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.BooleanFilter(component);
        }

        public BooleanFilter.Builder BooleanFilter(BooleanFilter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new BooleanFilter.Builder(component);
        }

        public BooleanFilter.Builder BooleanFilter(BooleanFilter.Config config)
        {
            return new BooleanFilter.Builder(new BooleanFilter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public BoundList.Builder BoundList()
        {
            BoundList component = new BoundList
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.BoundList(component);
        }

        public BoundList.Builder BoundList(BoundList component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new BoundList.Builder(component);
        }

        public BoundList.Builder BoundList(BoundList.Config config)
        {
            return new BoundList.Builder(new BoundList(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public BoxSplitter.Builder BoxSplitter()
        {
            BoxSplitter component = new BoxSplitter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.BoxSplitter(component);
        }

        public BoxSplitter.Builder BoxSplitter(BoxSplitter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new BoxSplitter.Builder(component);
        }

        public BoxSplitter.Builder BoxSplitter(BoxSplitter.Config config)
        {
            return new BoxSplitter.Builder(new BoxSplitter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public BufferedRenderer.Builder BufferedRenderer()
        {
            BufferedRenderer component = new BufferedRenderer
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.BufferedRenderer(component);
        }

        public BufferedRenderer.Builder BufferedRenderer(BufferedRenderer component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new BufferedRenderer.Builder(component);
        }

        public BufferedRenderer.Builder BufferedRenderer(BufferedRenderer.Config config)
        {
            return new BufferedRenderer.Builder(new BufferedRenderer(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Button.Builder Button()
        {
            Button component = new Button
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Button(component);
        }

        public Button.Builder Button(Button component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Button.Builder(component);
        }

        public Button.Builder Button(Button.Config config)
        {
            return new Button.Builder(new Button(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ButtonGroup.Builder ButtonGroup()
        {
            ButtonGroup component = new ButtonGroup
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ButtonGroup(component);
        }

        public ButtonGroup.Builder ButtonGroup(ButtonGroup component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ButtonGroup.Builder(component);
        }

        public ButtonGroup.Builder ButtonGroup(ButtonGroup.Config config)
        {
            return new ButtonGroup.Builder(new ButtonGroup(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CalendarCombo.Builder CalendarCombo()
        {
            CalendarCombo component = new CalendarCombo
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CalendarCombo(component);
        }

        public CalendarCombo.Builder CalendarCombo(CalendarCombo component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CalendarCombo.Builder(component);
        }

        public CalendarCombo.Builder CalendarCombo(CalendarCombo.Config config)
        {
            return new CalendarCombo.Builder(new CalendarCombo(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CalendarPanel.Builder CalendarPanel()
        {
            CalendarPanel component = new CalendarPanel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CalendarPanel(component);
        }

        public CalendarPanel.Builder CalendarPanel(CalendarPanel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CalendarPanel.Builder(component);
        }

        public CalendarPanel.Builder CalendarPanel(CalendarPanel.Config config)
        {
            return new CalendarPanel.Builder(new CalendarPanel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CalendarStore.Builder CalendarStore()
        {
            CalendarStore component = new CalendarStore
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CalendarStore(component);
        }

        public CalendarStore.Builder CalendarStore(CalendarStore component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CalendarStore.Builder(component);
        }

        public CalendarStore.Builder CalendarStore(CalendarStore.Config config)
        {
            return new CalendarStore.Builder(new CalendarStore(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CapsLockDetector.Builder CapsLockDetector()
        {
            CapsLockDetector component = new CapsLockDetector
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CapsLockDetector(component);
        }

        public CapsLockDetector.Builder CapsLockDetector(CapsLockDetector component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CapsLockDetector.Builder(component);
        }

        public CapsLockDetector.Builder CapsLockDetector(CapsLockDetector.Config config)
        {
            return new CapsLockDetector.Builder(new CapsLockDetector(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CategoryAxis.Builder CategoryAxis()
        {
            CategoryAxis component = new CategoryAxis
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CategoryAxis(component);
        }

        public CategoryAxis.Builder CategoryAxis(CategoryAxis component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CategoryAxis.Builder(component);
        }

        public CategoryAxis.Builder CategoryAxis(CategoryAxis.Config config)
        {
            return new CategoryAxis.Builder(new CategoryAxis(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CellDragDrop.Builder CellDragDrop()
        {
            CellDragDrop component = new CellDragDrop
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CellDragDrop(component);
        }

        public CellDragDrop.Builder CellDragDrop(CellDragDrop component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CellDragDrop.Builder(component);
        }

        public CellDragDrop.Builder CellDragDrop(CellDragDrop.Config config)
        {
            return new CellDragDrop.Builder(new CellDragDrop(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CellEditing.Builder CellEditing()
        {
            CellEditing component = new CellEditing
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CellEditing(component);
        }

        public CellEditing.Builder CellEditing(CellEditing component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CellEditing.Builder(component);
        }

        public CellEditing.Builder CellEditing(CellEditing.Config config)
        {
            return new CellEditing.Builder(new CellEditing(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CellSelectionModel.Builder CellSelectionModel()
        {
            CellSelectionModel component = new CellSelectionModel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CellSelectionModel(component);
        }

        public CellSelectionModel.Builder CellSelectionModel(CellSelectionModel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CellSelectionModel.Builder(component);
        }

        public CellSelectionModel.Builder CellSelectionModel(CellSelectionModel.Config config)
        {
            return new CellSelectionModel.Builder(new CellSelectionModel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Chart.Builder Chart()
        {
            Chart component = new Chart
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Chart(component);
        }

        public Chart.Builder Chart(Chart component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Chart.Builder(component);
        }

        public Chart.Builder Chart(Chart.Config config)
        {
            return new Chart.Builder(new Chart(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ChartLegend.Builder ChartLegend()
        {
            ChartLegend component = new ChartLegend
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ChartLegend(component);
        }

        public ChartLegend.Builder ChartLegend(ChartLegend component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ChartLegend.Builder(component);
        }

        public ChartLegend.Builder ChartLegend(ChartLegend.Config config)
        {
            return new ChartLegend.Builder(new ChartLegend(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ChartTheme.Builder ChartTheme()
        {
            ChartTheme component = new ChartTheme
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ChartTheme(component);
        }

        public ChartTheme.Builder ChartTheme(ChartTheme component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ChartTheme.Builder(component);
        }

        public ChartTheme.Builder ChartTheme(ChartTheme.Config config)
        {
            return new ChartTheme.Builder(new ChartTheme(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ChartTip.Builder ChartTip()
        {
            ChartTip component = new ChartTip
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ChartTip(component);
        }

        public ChartTip.Builder ChartTip(ChartTip component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ChartTip.Builder(component);
        }

        public ChartTip.Builder ChartTip(ChartTip.Config config)
        {
            return new ChartTip.Builder(new ChartTip(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Checkbox.Builder Checkbox()
        {
            Checkbox component = new Checkbox
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Checkbox(component);
        }

        public Checkbox.Builder Checkbox(Checkbox component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Checkbox.Builder(component);
        }

        public Checkbox.Builder Checkbox(Checkbox.Config config)
        {
            return new Checkbox.Builder(new Checkbox(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Checkbox.Builder CheckboxFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<Checkbox, Checkbox.Builder>(expression, setId, convert, format);
        }

        public CheckboxGroup.Builder CheckboxGroup()
        {
            CheckboxGroup component = new CheckboxGroup
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CheckboxGroup(component);
        }

        public CheckboxGroup.Builder CheckboxGroup(CheckboxGroup component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CheckboxGroup.Builder(component);
        }

        public CheckboxGroup.Builder CheckboxGroup(CheckboxGroup.Config config)
        {
            return new CheckboxGroup.Builder(new CheckboxGroup(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CheckboxSelectionModel.Builder CheckboxSelectionModel()
        {
            CheckboxSelectionModel component = new CheckboxSelectionModel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CheckboxSelectionModel(component);
        }

        public CheckboxSelectionModel.Builder CheckboxSelectionModel(CheckboxSelectionModel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CheckboxSelectionModel.Builder(component);
        }

        public CheckboxSelectionModel.Builder CheckboxSelectionModel(CheckboxSelectionModel.Config config)
        {
            return new CheckboxSelectionModel.Builder(new CheckboxSelectionModel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CheckColumn.Builder CheckColumn()
        {
            CheckColumn component = new CheckColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CheckColumn(component);
        }

        public CheckColumn.Builder CheckColumn(CheckColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CheckColumn.Builder(component);
        }

        public CheckColumn.Builder CheckColumn(CheckColumn.Config config)
        {
            return new CheckColumn.Builder(new CheckColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CheckMenuItem.Builder CheckMenuItem()
        {
            CheckMenuItem component = new CheckMenuItem
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CheckMenuItem(component);
        }

        public CheckMenuItem.Builder CheckMenuItem(CheckMenuItem component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CheckMenuItem.Builder(component);
        }

        public CheckMenuItem.Builder CheckMenuItem(CheckMenuItem.Config config)
        {
            return new CheckMenuItem.Builder(new CheckMenuItem(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ChildElement.Builder ChildElement()
        {
            ChildElement component = new ChildElement
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ChildElement(component);
        }

        public ChildElement.Builder ChildElement(ChildElement component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ChildElement.Builder(component);
        }

        public ChildElement.Builder ChildElement(ChildElement.Config config)
        {
            return new ChildElement.Builder(new ChildElement(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Chunking.Builder Chunking()
        {
            Chunking component = new Chunking
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Chunking(component);
        }

        public Chunking.Builder Chunking(Chunking component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Chunking.Builder(component);
        }

        public Chunking.Builder Chunking(Chunking.Config config)
        {
            return new Chunking.Builder(new Chunking(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ClearButton.Builder ClearButton()
        {
            ClearButton component = new ClearButton
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ClearButton(component);
        }

        public ClearButton.Builder ClearButton(ClearButton component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ClearButton.Builder(component);
        }

        public ClearButton.Builder ClearButton(ClearButton.Config config)
        {
            return new ClearButton.Builder(new ClearButton(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ClickRepeater.Builder ClickRepeater()
        {
            ClickRepeater component = new ClickRepeater
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ClickRepeater(component);
        }

        public ClickRepeater.Builder ClickRepeater(ClickRepeater component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ClickRepeater.Builder(component);
        }

        public ClickRepeater.Builder ClickRepeater(ClickRepeater.Config config)
        {
            return new ClickRepeater.Builder(new ClickRepeater(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ColorMenu.Builder ColorMenu()
        {
            ColorMenu component = new ColorMenu
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ColorMenu(component);
        }

        public ColorMenu.Builder ColorMenu(ColorMenu component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ColorMenu.Builder(component);
        }

        public ColorMenu.Builder ColorMenu(ColorMenu.Config config)
        {
            return new ColorMenu.Builder(new ColorMenu(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ColorPicker.Builder ColorPicker()
        {
            ColorPicker component = new ColorPicker
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ColorPicker(component);
        }

        public ColorPicker.Builder ColorPicker(ColorPicker component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ColorPicker.Builder(component);
        }

        public ColorPicker.Builder ColorPicker(ColorPicker.Config config)
        {
            return new ColorPicker.Builder(new ColorPicker(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Column.Builder Column()
        {
            Column component = new Column
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Column(component);
        }

        public Column.Builder Column(Column component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Column.Builder(component);
        }

        public Column.Builder Column(Column.Config config)
        {
            return new Column.Builder(new Column(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ColumnSeries.Builder ColumnSeries()
        {
            ColumnSeries component = new ColumnSeries
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ColumnSeries(component);
        }

        public ColumnSeries.Builder ColumnSeries(ColumnSeries component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ColumnSeries.Builder(component);
        }

        public ColumnSeries.Builder ColumnSeries(ColumnSeries.Config config)
        {
            return new ColumnSeries.Builder(new ColumnSeries(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ComboBox.Builder ComboBox()
        {
            ComboBox component = new ComboBox
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ComboBox(component);
        }

        public ComboBox.Builder ComboBox(ComboBox component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ComboBox.Builder(component);
        }

        public ComboBox.Builder ComboBox(ComboBox.Config config)
        {
            return new ComboBox.Builder(new ComboBox(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ComboBox.Builder ComboBoxFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<ComboBox, ComboBox.Builder>(expression, setId, convert, format);
        }

        public CommandColumn.Builder CommandColumn()
        {
            CommandColumn component = new CommandColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CommandColumn(component);
        }

        public CommandColumn.Builder CommandColumn(CommandColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CommandColumn.Builder(component);
        }

        public CommandColumn.Builder CommandColumn(CommandColumn.Config config)
        {
            return new CommandColumn.Builder(new CommandColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CommandFill.Builder CommandFill()
        {
            CommandFill component = new CommandFill
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CommandFill(component);
        }

        public CommandFill.Builder CommandFill(CommandFill component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CommandFill.Builder(component);
        }

        public CommandFill.Builder CommandFill(CommandFill.Config config)
        {
            return new CommandFill.Builder(new CommandFill(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CommandMenu.Builder CommandMenu()
        {
            CommandMenu component = new CommandMenu
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CommandMenu(component);
        }

        public CommandMenu.Builder CommandMenu(CommandMenu component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CommandMenu.Builder(component);
        }

        public CommandMenu.Builder CommandMenu(CommandMenu.Config config)
        {
            return new CommandMenu.Builder(new CommandMenu(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CommandSeparator.Builder CommandSeparator()
        {
            CommandSeparator component = new CommandSeparator
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CommandSeparator(component);
        }

        public CommandSeparator.Builder CommandSeparator(CommandSeparator component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CommandSeparator.Builder(component);
        }

        public CommandSeparator.Builder CommandSeparator(CommandSeparator.Config config)
        {
            return new CommandSeparator.Builder(new CommandSeparator(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CommandSpacer.Builder CommandSpacer()
        {
            CommandSpacer component = new CommandSpacer
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CommandSpacer(component);
        }

        public CommandSpacer.Builder CommandSpacer(CommandSpacer component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CommandSpacer.Builder(component);
        }

        public CommandSpacer.Builder CommandSpacer(CommandSpacer.Config config)
        {
            return new CommandSpacer.Builder(new CommandSpacer(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CommandText.Builder CommandText()
        {
            CommandText component = new CommandText
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CommandText(component);
        }

        public CommandText.Builder CommandText(CommandText component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CommandText.Builder(component);
        }

        public CommandText.Builder CommandText(CommandText.Config config)
        {
            return new CommandText.Builder(new CommandText(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Component.Builder Component()
        {
            Component component = new Component
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Component(component);
        }

        public Component.Builder Component(Component component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Component.Builder(component);
        }

        public Component.Builder Component(Component.Config config)
        {
            return new Component.Builder(new Component(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ComponentColumn.Builder ComponentColumn()
        {
            ComponentColumn component = new ComponentColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ComponentColumn(component);
        }

        public ComponentColumn.Builder ComponentColumn(ComponentColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ComponentColumn.Builder(component);
        }

        public ComponentColumn.Builder ComponentColumn(ComponentColumn.Config config)
        {
            return new ComponentColumn.Builder(new ComponentColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ComponentDragger.Builder ComponentDragger()
        {
            ComponentDragger component = new ComponentDragger
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ComponentDragger(component);
        }

        public ComponentDragger.Builder ComponentDragger(ComponentDragger component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ComponentDragger.Builder(component);
        }

        public ComponentDragger.Builder ComponentDragger(ComponentDragger.Config config)
        {
            return new ComponentDragger.Builder(new ComponentDragger(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ComponentLoader.Builder ComponentLoader()
        {
            ComponentLoader component = new ComponentLoader
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ComponentLoader(component);
        }

        public ComponentLoader.Builder ComponentLoader(ComponentLoader component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ComponentLoader.Builder(component);
        }

        public ComponentLoader.Builder ComponentLoader(ComponentLoader.Config config)
        {
            return new ComponentLoader.Builder(new ComponentLoader(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ComponentView.Builder ComponentView()
        {
            ComponentView component = new ComponentView
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ComponentView(component);
        }

        public ComponentView.Builder ComponentView(ComponentView component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ComponentView.Builder(component);
        }

        public ComponentView.Builder ComponentView(ComponentView.Config config)
        {
            return new ComponentView.Builder(new ComponentView(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Container.Builder Container()
        {
            Container component = new Container
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Container(component);
        }

        public Container.Builder Container(Container component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Container.Builder(component);
        }

        public Container.Builder Container(Container.Config config)
        {
            return new Container.Builder(new Container(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CRUDMethods.Builder CRUDMethods()
        {
            CRUDMethods component = new CRUDMethods
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CRUDMethods(component);
        }

        public CRUDMethods.Builder CRUDMethods(CRUDMethods component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CRUDMethods.Builder(component);
        }

        public CRUDMethods.Builder CRUDMethods(CRUDMethods.Config config)
        {
            return new CRUDMethods.Builder(new CRUDMethods(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CRUDUrls.Builder CRUDUrls()
        {
            CRUDUrls component = new CRUDUrls
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CRUDUrls(component);
        }

        public CRUDUrls.Builder CRUDUrls(CRUDUrls component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CRUDUrls.Builder(component);
        }

        public CRUDUrls.Builder CRUDUrls(CRUDUrls.Config config)
        {
            return new CRUDUrls.Builder(new CRUDUrls(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CustomIdGenerator.Builder CustomIdGenerator()
        {
            CustomIdGenerator component = new CustomIdGenerator
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CustomIdGenerator(component);
        }

        public CustomIdGenerator.Builder CustomIdGenerator(CustomIdGenerator component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CustomIdGenerator.Builder(component);
        }

        public CustomIdGenerator.Builder CustomIdGenerator(CustomIdGenerator.Config config)
        {
            return new CustomIdGenerator.Builder(new CustomIdGenerator(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public CycleButton.Builder CycleButton()
        {
            CycleButton component = new CycleButton
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.CycleButton(component);
        }

        public CycleButton.Builder CycleButton(CycleButton component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new CycleButton.Builder(component);
        }

        public CycleButton.Builder CycleButton(CycleButton.Config config)
        {
            return new CycleButton.Builder(new CycleButton(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DataFilter.Builder DataFilter()
        {
            DataFilter component = new DataFilter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DataFilter(component);
        }

        public DataFilter.Builder DataFilter(DataFilter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DataFilter.Builder(component);
        }

        public DataFilter.Builder DataFilter(DataFilter.Config config)
        {
            return new DataFilter.Builder(new DataFilter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DataSorter.Builder DataSorter()
        {
            DataSorter component = new DataSorter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DataSorter(component);
        }

        public DataSorter.Builder DataSorter(DataSorter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DataSorter.Builder(component);
        }

        public DataSorter.Builder DataSorter(DataSorter.Config config)
        {
            return new DataSorter.Builder(new DataSorter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DataTip.Builder DataTip()
        {
            DataTip component = new DataTip
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DataTip(component);
        }

        public DataTip.Builder DataTip(DataTip component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DataTip.Builder(component);
        }

        public DataTip.Builder DataTip(DataTip.Config config)
        {
            return new DataTip.Builder(new DataTip(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DataView.Builder DataView()
        {
            DataView component = new DataView
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DataView(component);
        }

        public DataView.Builder DataView(DataView component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DataView.Builder(component);
        }

        public DataView.Builder DataView(DataView.Config config)
        {
            return new DataView.Builder(new DataView(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DataViewAnimated.Builder DataViewAnimated()
        {
            DataViewAnimated component = new DataViewAnimated
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DataViewAnimated(component);
        }

        public DataViewAnimated.Builder DataViewAnimated(DataViewAnimated component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DataViewAnimated.Builder(component);
        }

        public DataViewAnimated.Builder DataViewAnimated(DataViewAnimated.Config config)
        {
            return new DataViewAnimated.Builder(new DataViewAnimated(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DataViewDraggable.Builder DataViewDraggable()
        {
            DataViewDraggable component = new DataViewDraggable
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DataViewDraggable(component);
        }

        public DataViewDraggable.Builder DataViewDraggable(DataViewDraggable component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DataViewDraggable.Builder(component);
        }

        public DataViewDraggable.Builder DataViewDraggable(DataViewDraggable.Config config)
        {
            return new DataViewDraggable.Builder(new DataViewDraggable(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DataViewDragSelector.Builder DataViewDragSelector()
        {
            DataViewDragSelector component = new DataViewDragSelector
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DataViewDragSelector(component);
        }

        public DataViewDragSelector.Builder DataViewDragSelector(DataViewDragSelector component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DataViewDragSelector.Builder(component);
        }

        public DataViewDragSelector.Builder DataViewDragSelector(DataViewDragSelector.Config config)
        {
            return new DataViewDragSelector.Builder(new DataViewDragSelector(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DataViewLabelEditor.Builder DataViewLabelEditor()
        {
            DataViewLabelEditor component = new DataViewLabelEditor
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DataViewLabelEditor(component);
        }

        public DataViewLabelEditor.Builder DataViewLabelEditor(DataViewLabelEditor component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DataViewLabelEditor.Builder(component);
        }

        public DataViewLabelEditor.Builder DataViewLabelEditor(DataViewLabelEditor.Config config)
        {
            return new DataViewLabelEditor.Builder(new DataViewLabelEditor(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DateColumn.Builder DateColumn()
        {
            DateColumn component = new DateColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DateColumn(component);
        }

        public DateColumn.Builder DateColumn(DateColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DateColumn.Builder(component);
        }

        public DateColumn.Builder DateColumn(DateColumn.Config config)
        {
            return new DateColumn.Builder(new DateColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DateField.Builder DateField()
        {
            DateField component = new DateField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DateField(component);
        }

        public DateField.Builder DateField(DateField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DateField.Builder(component);
        }

        public DateField.Builder DateField(DateField.Config config)
        {
            return new DateField.Builder(new DateField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DateField.Builder DateFieldFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<DateField, DateField.Builder>(expression, setId, convert, format);
        }

        public DateFilter.Builder DateFilter()
        {
            DateFilter component = new DateFilter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DateFilter(component);
        }

        public DateFilter.Builder DateFilter(DateFilter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DateFilter.Builder(component);
        }

        public DateFilter.Builder DateFilter(DateFilter.Config config)
        {
            return new DateFilter.Builder(new DateFilter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DateMenu.Builder DateMenu()
        {
            DateMenu component = new DateMenu
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DateMenu(component);
        }

        public DateMenu.Builder DateMenu(DateMenu component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DateMenu.Builder(component);
        }

        public DateMenu.Builder DateMenu(DateMenu.Config config)
        {
            return new DateMenu.Builder(new DateMenu(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DatePicker.Builder DatePicker()
        {
            DatePicker component = new DatePicker
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DatePicker(component);
        }

        public DatePicker.Builder DatePicker(DatePicker component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DatePicker.Builder(component);
        }

        public DatePicker.Builder DatePicker(DatePicker.Config config)
        {
            return new DatePicker.Builder(new DatePicker(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DatePickerOptions.Builder DatePickerOptions()
        {
            DatePickerOptions component = new DatePickerOptions
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DatePickerOptions(component);
        }

        public DatePickerOptions.Builder DatePickerOptions(DatePickerOptions component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DatePickerOptions.Builder(component);
        }

        public DatePickerOptions.Builder DatePickerOptions(DatePickerOptions.Config config)
        {
            return new DatePickerOptions.Builder(new DatePickerOptions(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DayView.Builder DayView()
        {
            DayView component = new DayView
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DayView(component);
        }

        public DayView.Builder DayView(DayView component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DayView.Builder(component);
        }

        public DayView.Builder DayView(DayView.Config config)
        {
            return new DayView.Builder(new DayView(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DD.Builder DD()
        {
            DD component = new DD
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DD(component);
        }

        public DD.Builder DD(DD component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DD.Builder(component);
        }

        public DD.Builder DD(DD.Config config)
        {
            return new DD.Builder(new DD(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DDProxy.Builder DDProxy()
        {
            DDProxy component = new DDProxy
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DDProxy(component);
        }

        public DDProxy.Builder DDProxy(DDProxy component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DDProxy.Builder(component);
        }

        public DDProxy.Builder DDProxy(DDProxy.Config config)
        {
            return new DDProxy.Builder(new DDProxy(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DDTarget.Builder DDTarget()
        {
            DDTarget component = new DDTarget
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DDTarget(component);
        }

        public DDTarget.Builder DDTarget(DDTarget component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DDTarget.Builder(component);
        }

        public DDTarget.Builder DDTarget(DDTarget.Config config)
        {
            return new DDTarget.Builder(new DDTarget(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Desktop.Builder Desktop()
        {
            Desktop component = new Desktop
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Desktop(component);
        }

        public Desktop.Builder Desktop(Desktop component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Desktop.Builder(component);
        }

        public Desktop.Builder Desktop(Desktop.Config config)
        {
            return new Desktop.Builder(new Desktop(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DesktopConfig.Builder DesktopConfig()
        {
            DesktopConfig component = new DesktopConfig
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DesktopConfig(component);
        }

        public DesktopConfig.Builder DesktopConfig(DesktopConfig component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DesktopConfig.Builder(component);
        }

        public DesktopConfig.Builder DesktopConfig(DesktopConfig.Config config)
        {
            return new DesktopConfig.Builder(new DesktopConfig(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DesktopModule.Builder DesktopModule()
        {
            DesktopModule component = new DesktopModule
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DesktopModule(component);
        }

        public DesktopModule.Builder DesktopModule(DesktopModule component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DesktopModule.Builder(component);
        }

        public DesktopModule.Builder DesktopModule(DesktopModule.Config config)
        {
            return new DesktopModule.Builder(new DesktopModule(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DesktopModuleProxy.Builder DesktopModuleProxy()
        {
            DesktopModuleProxy component = new DesktopModuleProxy
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DesktopModuleProxy(component);
        }

        public DesktopModuleProxy.Builder DesktopModuleProxy(DesktopModuleProxy component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DesktopModuleProxy.Builder(component);
        }

        public DesktopModuleProxy.Builder DesktopModuleProxy(DesktopModuleProxy.Config config)
        {
            return new DesktopModuleProxy.Builder(new DesktopModuleProxy(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DesktopShortcut.Builder DesktopShortcut()
        {
            DesktopShortcut component = new DesktopShortcut
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DesktopShortcut(component);
        }

        public DesktopShortcut.Builder DesktopShortcut(DesktopShortcut component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DesktopShortcut.Builder(component);
        }

        public DesktopShortcut.Builder DesktopShortcut(DesktopShortcut.Config config)
        {
            return new DesktopShortcut.Builder(new DesktopShortcut(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DesktopStartMenu.Builder DesktopStartMenu()
        {
            DesktopStartMenu component = new DesktopStartMenu
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DesktopStartMenu(component);
        }

        public DesktopStartMenu.Builder DesktopStartMenu(DesktopStartMenu component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DesktopStartMenu.Builder(component);
        }

        public DesktopStartMenu.Builder DesktopStartMenu(DesktopStartMenu.Config config)
        {
            return new DesktopStartMenu.Builder(new DesktopStartMenu(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DesktopTaskBar.Builder DesktopTaskBar()
        {
            DesktopTaskBar component = new DesktopTaskBar
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DesktopTaskBar(component);
        }

        public DesktopTaskBar.Builder DesktopTaskBar(DesktopTaskBar component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DesktopTaskBar.Builder(component);
        }

        public DesktopTaskBar.Builder DesktopTaskBar(DesktopTaskBar.Config config)
        {
            return new DesktopTaskBar.Builder(new DesktopTaskBar(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DirectProxy.Builder DirectProxy()
        {
            DirectProxy component = new DirectProxy
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DirectProxy(component);
        }

        public DirectProxy.Builder DirectProxy(DirectProxy component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DirectProxy.Builder(component);
        }

        public DirectProxy.Builder DirectProxy(DirectProxy.Config config)
        {
            return new DirectProxy.Builder(new DirectProxy(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DisplayField.Builder DisplayField()
        {
            DisplayField component = new DisplayField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DisplayField(component);
        }

        public DisplayField.Builder DisplayField(DisplayField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DisplayField.Builder(component);
        }

        public DisplayField.Builder DisplayField(DisplayField.Config config)
        {
            return new DisplayField.Builder(new DisplayField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DisplayField.Builder DisplayFieldFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<DisplayField, DisplayField.Builder>(expression, setId, convert, format);
        }

        public DisplayTimeField.Builder DisplayTimeField()
        {
            DisplayTimeField component = new DisplayTimeField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DisplayTimeField(component);
        }

        public DisplayTimeField.Builder DisplayTimeField(DisplayTimeField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DisplayTimeField.Builder(component);
        }

        public DisplayTimeField.Builder DisplayTimeField(DisplayTimeField.Config config)
        {
            return new DisplayTimeField.Builder(new DisplayTimeField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DragSource.Builder DragSource()
        {
            DragSource component = new DragSource
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DragSource(component);
        }

        public DragSource.Builder DragSource(DragSource component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DragSource.Builder(component);
        }

        public DragSource.Builder DragSource(DragSource.Config config)
        {
            return new DragSource.Builder(new DragSource(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DragTracker.Builder DragTracker()
        {
            DragTracker component = new DragTracker
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DragTracker(component);
        }

        public DragTracker.Builder DragTracker(DragTracker component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DragTracker.Builder(component);
        }

        public DragTracker.Builder DragTracker(DragTracker.Config config)
        {
            return new DragTracker.Builder(new DragTracker(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DragZone.Builder DragZone()
        {
            DragZone component = new DragZone
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DragZone(component);
        }

        public DragZone.Builder DragZone(DragZone component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DragZone.Builder(component);
        }

        public DragZone.Builder DragZone(DragZone.Config config)
        {
            return new DragZone.Builder(new DragZone(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DrawBackground.Builder DrawBackground()
        {
            DrawBackground component = new DrawBackground
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DrawBackground(component);
        }

        public DrawBackground.Builder DrawBackground(DrawBackground component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DrawBackground.Builder(component);
        }

        public DrawBackground.Builder DrawBackground(DrawBackground.Config config)
        {
            return new DrawBackground.Builder(new DrawBackground(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DrawComponent.Builder DrawComponent()
        {
            DrawComponent component = new DrawComponent
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DrawComponent(component);
        }

        public DrawComponent.Builder DrawComponent(DrawComponent component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DrawComponent.Builder(component);
        }

        public DrawComponent.Builder DrawComponent(DrawComponent.Config config)
        {
            return new DrawComponent.Builder(new DrawComponent(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DrawText.Builder DrawText()
        {
            DrawText component = new DrawText
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DrawText(component);
        }

        public DrawText.Builder DrawText(DrawText component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DrawText.Builder(component);
        }

        public DrawText.Builder DrawText(DrawText.Config config)
        {
            return new DrawText.Builder(new DrawText(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DropDownField.Builder DropDownField()
        {
            DropDownField component = new DropDownField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DropDownField(component);
        }

        public DropDownField.Builder DropDownField(DropDownField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DropDownField.Builder(component);
        }

        public DropDownField.Builder DropDownField(DropDownField.Config config)
        {
            return new DropDownField.Builder(new DropDownField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public DropDownField.Builder DropDownFieldFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<DropDownField, DropDownField.Builder>(expression, setId, convert, format);
        }

        public DropTarget.Builder DropTarget()
        {
            DropTarget component = new DropTarget
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.DropTarget(component);
        }

        public DropTarget.Builder DropTarget(DropTarget component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new DropTarget.Builder(component);
        }

        public DropTarget.Builder DropTarget(DropTarget.Config config)
        {
            return new DropTarget.Builder(new DropTarget(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Editor.Builder Editor()
        {
            Editor component = new Editor
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Editor(component);
        }

        public Editor.Builder Editor(Editor component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Editor.Builder(component);
        }

        public Editor.Builder Editor(Editor.Config config)
        {
            return new Editor.Builder(new Editor(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public EmailValidation.Builder EmailValidation()
        {
            EmailValidation component = new EmailValidation
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.EmailValidation(component);
        }

        public EmailValidation.Builder EmailValidation(EmailValidation component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new EmailValidation.Builder(component);
        }

        public EmailValidation.Builder EmailValidation(EmailValidation.Config config)
        {
            return new EmailValidation.Builder(new EmailValidation(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public EventDetails.Builder EventDetails()
        {
            EventDetails component = new EventDetails
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.EventDetails(component);
        }

        public EventDetails.Builder EventDetails(EventDetails component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new EventDetails.Builder(component);
        }

        public EventDetails.Builder EventDetails(EventDetails.Config config)
        {
            return new EventDetails.Builder(new EventDetails(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public EventStore.Builder EventStore()
        {
            EventStore component = new EventStore
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.EventStore(component);
        }

        public EventStore.Builder EventStore(EventStore component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new EventStore.Builder(component);
        }

        public EventStore.Builder EventStore(EventStore.Config config)
        {
            return new EventStore.Builder(new EventStore(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public EventWindow.Builder EventWindow()
        {
            EventWindow component = new EventWindow
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.EventWindow(component);
        }

        public EventWindow.Builder EventWindow(EventWindow component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new EventWindow.Builder(component);
        }

        public EventWindow.Builder EventWindow(EventWindow.Config config)
        {
            return new EventWindow.Builder(new EventWindow(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ExclusionValidation.Builder ExclusionValidation()
        {
            ExclusionValidation component = new ExclusionValidation
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ExclusionValidation(component);
        }

        public ExclusionValidation.Builder ExclusionValidation(ExclusionValidation component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ExclusionValidation.Builder(component);
        }

        public ExclusionValidation.Builder ExclusionValidation(ExclusionValidation.Config config)
        {
            return new ExclusionValidation.Builder(new ExclusionValidation(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public FieldContainer.Builder FieldContainer()
        {
            FieldContainer component = new FieldContainer
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.FieldContainer(component);
        }

        public FieldContainer.Builder FieldContainer(FieldContainer component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new FieldContainer.Builder(component);
        }

        public FieldContainer.Builder FieldContainer(FieldContainer.Config config)
        {
            return new FieldContainer.Builder(new FieldContainer(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public FieldReplicator.Builder FieldReplicator()
        {
            FieldReplicator component = new FieldReplicator
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.FieldReplicator(component);
        }

        public FieldReplicator.Builder FieldReplicator(FieldReplicator component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new FieldReplicator.Builder(component);
        }

        public FieldReplicator.Builder FieldReplicator(FieldReplicator.Config config)
        {
            return new FieldReplicator.Builder(new FieldReplicator(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public FieldSet.Builder FieldSet()
        {
            FieldSet component = new FieldSet
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.FieldSet(component);
        }

        public FieldSet.Builder FieldSet(FieldSet component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new FieldSet.Builder(component);
        }

        public FieldSet.Builder FieldSet(FieldSet.Config config)
        {
            return new FieldSet.Builder(new FieldSet(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public FieldTrigger.Builder FieldTrigger()
        {
            FieldTrigger component = new FieldTrigger
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.FieldTrigger(component);
        }

        public FieldTrigger.Builder FieldTrigger(FieldTrigger component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new FieldTrigger.Builder(component);
        }

        public FieldTrigger.Builder FieldTrigger(FieldTrigger.Config config)
        {
            return new FieldTrigger.Builder(new FieldTrigger(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public FileUploadField.Builder FileUploadField()
        {
            FileUploadField component = new FileUploadField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.FileUploadField(component);
        }

        public FileUploadField.Builder FileUploadField(FileUploadField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new FileUploadField.Builder(component);
        }

        public FileUploadField.Builder FileUploadField(FileUploadField.Config config)
        {
            return new FileUploadField.Builder(new FileUploadField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public FlashComponent.Builder FlashComponent()
        {
            FlashComponent component = new FlashComponent
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.FlashComponent(component);
        }

        public FlashComponent.Builder FlashComponent(FlashComponent component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new FlashComponent.Builder(component);
        }

        public FlashComponent.Builder FlashComponent(FlashComponent.Config config)
        {
            return new FlashComponent.Builder(new FlashComponent(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public FormatValidation.Builder FormatValidation()
        {
            FormatValidation component = new FormatValidation
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.FormatValidation(component);
        }

        public FormatValidation.Builder FormatValidation(FormatValidation component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new FormatValidation.Builder(component);
        }

        public FormatValidation.Builder FormatValidation(FormatValidation.Config config)
        {
            return new FormatValidation.Builder(new FormatValidation(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        internal static string FormatValueInternal(object value, string format)
        {
            if (value == null)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(format))
            {
                return System.Convert.ToString(value, System.Globalization.CultureInfo.CurrentCulture);
            }
            return string.Format(System.Globalization.CultureInfo.CurrentCulture, format, new object[] { value });
        }

        public FormPanel.Builder FormPanel()
        {
            FormPanel component = new FormPanel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.FormPanel(component);
        }

        public FormPanel.Builder FormPanel(FormPanel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new FormPanel.Builder(component);
        }

        public FormPanel.Builder FormPanel(FormPanel.Config config)
        {
            return new FormPanel.Builder(new FormPanel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GaugeAxis.Builder GaugeAxis()
        {
            GaugeAxis component = new GaugeAxis
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GaugeAxis(component);
        }

        public GaugeAxis.Builder GaugeAxis(GaugeAxis component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GaugeAxis.Builder(component);
        }

        public GaugeAxis.Builder GaugeAxis(GaugeAxis.Config config)
        {
            return new GaugeAxis.Builder(new GaugeAxis(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GaugeSeries.Builder GaugeSeries()
        {
            GaugeSeries component = new GaugeSeries
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GaugeSeries(component);
        }

        public GaugeSeries.Builder GaugeSeries(GaugeSeries component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GaugeSeries.Builder(component);
        }

        public GaugeSeries.Builder GaugeSeries(GaugeSeries.Config config)
        {
            return new GaugeSeries.Builder(new GaugeSeries(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GenericFeature.Builder GenericFeature()
        {
            GenericFeature component = new GenericFeature
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GenericFeature(component);
        }

        public GenericFeature.Builder GenericFeature(GenericFeature component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GenericFeature.Builder(component);
        }

        public GenericFeature.Builder GenericFeature(GenericFeature.Config config)
        {
            return new GenericFeature.Builder(new GenericFeature(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GenericPlugin.Builder GenericPlugin()
        {
            GenericPlugin component = new GenericPlugin
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GenericPlugin(component);
        }

        public GenericPlugin.Builder GenericPlugin(GenericPlugin component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GenericPlugin.Builder(component);
        }

        public GenericPlugin.Builder GenericPlugin(GenericPlugin.Config config)
        {
            return new GenericPlugin.Builder(new GenericPlugin(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public System.Type GetType()
        {
            return base.GetType();
        }

        public Gradient.Builder Gradient()
        {
            Gradient component = new Gradient
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Gradient(component);
        }

        public Gradient.Builder Gradient(Gradient component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Gradient.Builder(component);
        }

        public Gradient.Builder Gradient(Gradient.Config config)
        {
            return new Gradient.Builder(new Gradient(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GradientStop.Builder GradientStop()
        {
            GradientStop component = new GradientStop
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GradientStop(component);
        }

        public GradientStop.Builder GradientStop(GradientStop component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GradientStop.Builder(component);
        }

        public GradientStop.Builder GradientStop(GradientStop.Config config)
        {
            return new GradientStop.Builder(new GradientStop(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GridCommand.Builder GridCommand()
        {
            GridCommand component = new GridCommand
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GridCommand(component);
        }

        public GridCommand.Builder GridCommand(GridCommand component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GridCommand.Builder(component);
        }

        public GridCommand.Builder GridCommand(GridCommand.Config config)
        {
            return new GridCommand.Builder(new GridCommand(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GridDragDrop.Builder GridDragDrop()
        {
            GridDragDrop component = new GridDragDrop
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GridDragDrop(component);
        }

        public GridDragDrop.Builder GridDragDrop(GridDragDrop component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GridDragDrop.Builder(component);
        }

        public GridDragDrop.Builder GridDragDrop(GridDragDrop.Config config)
        {
            return new GridDragDrop.Builder(new GridDragDrop(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GridFilters.Builder GridFilters()
        {
            GridFilters component = new GridFilters
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GridFilters(component);
        }

        public GridFilters.Builder GridFilters(GridFilters component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GridFilters.Builder(component);
        }

        public GridFilters.Builder GridFilters(GridFilters.Config config)
        {
            return new GridFilters.Builder(new GridFilters(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GridHeaderContainer.Builder GridHeaderContainer()
        {
            GridHeaderContainer component = new GridHeaderContainer
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GridHeaderContainer(component);
        }

        public GridHeaderContainer.Builder GridHeaderContainer(GridHeaderContainer component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GridHeaderContainer.Builder(component);
        }

        public GridHeaderContainer.Builder GridHeaderContainer(GridHeaderContainer.Config config)
        {
            return new GridHeaderContainer.Builder(new GridHeaderContainer(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GridPanel.Builder GridPanel()
        {
            GridPanel component = new GridPanel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GridPanel(component);
        }

        public GridPanel.Builder GridPanel(GridPanel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GridPanel.Builder(component);
        }

        public GridPanel.Builder GridPanel(GridPanel.Config config)
        {
            return new GridPanel.Builder(new GridPanel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GridView.Builder GridView()
        {
            GridView component = new GridView
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GridView(component);
        }

        public GridView.Builder GridView(GridView component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GridView.Builder(component);
        }

        public GridView.Builder GridView(GridView.Config config)
        {
            return new GridView.Builder(new GridView(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GroupImageCommand.Builder GroupImageCommand()
        {
            GroupImageCommand component = new GroupImageCommand
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GroupImageCommand(component);
        }

        public GroupImageCommand.Builder GroupImageCommand(GroupImageCommand component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GroupImageCommand.Builder(component);
        }

        public GroupImageCommand.Builder GroupImageCommand(GroupImageCommand.Config config)
        {
            return new GroupImageCommand.Builder(new GroupImageCommand(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Grouping.Builder Grouping()
        {
            Grouping component = new Grouping
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Grouping(component);
        }

        public Grouping.Builder Grouping(Grouping component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Grouping.Builder(component);
        }

        public Grouping.Builder Grouping(Grouping.Config config)
        {
            return new Grouping.Builder(new Grouping(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GroupingSummary.Builder GroupingSummary()
        {
            GroupingSummary component = new GroupingSummary
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GroupingSummary(component);
        }

        public GroupingSummary.Builder GroupingSummary(GroupingSummary component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GroupingSummary.Builder(component);
        }

        public GroupingSummary.Builder GroupingSummary(GroupingSummary.Config config)
        {
            return new GroupingSummary.Builder(new GroupingSummary(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public GroupTabPanel.Builder GroupTabPanel()
        {
            GroupTabPanel component = new GroupTabPanel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.GroupTabPanel(component);
        }

        public GroupTabPanel.Builder GroupTabPanel(GroupTabPanel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new GroupTabPanel.Builder(component);
        }

        public GroupTabPanel.Builder GroupTabPanel(GroupTabPanel.Config config)
        {
            return new GroupTabPanel.Builder(new GroupTabPanel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public HasManyAssociation.Builder HasManyAssociation()
        {
            HasManyAssociation component = new HasManyAssociation
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.HasManyAssociation(component);
        }

        public HasManyAssociation.Builder HasManyAssociation(HasManyAssociation component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new HasManyAssociation.Builder(component);
        }

        public HasManyAssociation.Builder HasManyAssociation(HasManyAssociation.Config config)
        {
            return new HasManyAssociation.Builder(new HasManyAssociation(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public HasOneAssociation.Builder HasOneAssociation()
        {
            HasOneAssociation component = new HasOneAssociation
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.HasOneAssociation(component);
        }

        public HasOneAssociation.Builder HasOneAssociation(HasOneAssociation component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new HasOneAssociation.Builder(component);
        }

        public HasOneAssociation.Builder HasOneAssociation(HasOneAssociation.Config config)
        {
            return new HasOneAssociation.Builder(new HasOneAssociation(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Hidden.Builder Hidden()
        {
            Hidden component = new Hidden
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Hidden(component);
        }

        public Hidden.Builder Hidden(Hidden component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Hidden.Builder(component);
        }

        public Hidden.Builder Hidden(Hidden.Config config)
        {
            return new Hidden.Builder(new Hidden(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Hidden.Builder HiddenFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<Hidden, Hidden.Builder>(expression, setId, convert, format);
        }

        public History.Builder History()
        {
            History component = new History
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.History(component);
        }

        public History.Builder History(History component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new History.Builder(component);
        }

        public History.Builder History(History.Config config)
        {
            return new History.Builder(new History(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public HtmlEditor.Builder HtmlEditor()
        {
            HtmlEditor component = new HtmlEditor
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.HtmlEditor(component);
        }

        public HtmlEditor.Builder HtmlEditor(HtmlEditor component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new HtmlEditor.Builder(component);
        }

        public HtmlEditor.Builder HtmlEditor(HtmlEditor.Config config)
        {
            return new HtmlEditor.Builder(new HtmlEditor(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public HtmlEditorButtonTip.Builder HtmlEditorButtonTip()
        {
            HtmlEditorButtonTip component = new HtmlEditorButtonTip
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.HtmlEditorButtonTip(component);
        }

        public HtmlEditorButtonTip.Builder HtmlEditorButtonTip(HtmlEditorButtonTip component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new HtmlEditorButtonTip.Builder(component);
        }

        public HtmlEditorButtonTip.Builder HtmlEditorButtonTip(HtmlEditorButtonTip.Config config)
        {
            return new HtmlEditorButtonTip.Builder(new HtmlEditorButtonTip(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public HtmlEditorButtonTips.Builder HtmlEditorButtonTips()
        {
            HtmlEditorButtonTips component = new HtmlEditorButtonTips
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.HtmlEditorButtonTips(component);
        }

        public HtmlEditorButtonTips.Builder HtmlEditorButtonTips(HtmlEditorButtonTips component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new HtmlEditorButtonTips.Builder(component);
        }

        public HtmlEditorButtonTips.Builder HtmlEditorButtonTips(HtmlEditorButtonTips.Config config)
        {
            return new HtmlEditorButtonTips.Builder(new HtmlEditorButtonTips(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public HtmlEditor.Builder HtmlEditorFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<HtmlEditor, HtmlEditor.Builder>(expression, setId, convert, format);
        }

        public HyperLink.Builder HyperLink()
        {
            HyperLink component = new HyperLink
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.HyperLink(component);
        }

        public HyperLink.Builder HyperLink(HyperLink component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new HyperLink.Builder(component);
        }

        public HyperLink.Builder HyperLink(HyperLink.Config config)
        {
            return new HyperLink.Builder(new HyperLink(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Image.Builder Image()
        {
            Image component = new Image
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Image(component);
        }

        public Image.Builder Image(Image component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Image.Builder(component);
        }

        public Image.Builder Image(Image.Config config)
        {
            return new Image.Builder(new Image(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ImageButton.Builder ImageButton()
        {
            ImageButton component = new ImageButton
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ImageButton(component);
        }

        public ImageButton.Builder ImageButton(ImageButton component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ImageButton.Builder(component);
        }

        public ImageButton.Builder ImageButton(ImageButton.Config config)
        {
            return new ImageButton.Builder(new ImageButton(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ImageCommand.Builder ImageCommand()
        {
            ImageCommand component = new ImageCommand
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ImageCommand(component);
        }

        public ImageCommand.Builder ImageCommand(ImageCommand component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ImageCommand.Builder(component);
        }

        public ImageCommand.Builder ImageCommand(ImageCommand.Config config)
        {
            return new ImageCommand.Builder(new ImageCommand(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ImageCommandColumn.Builder ImageCommandColumn()
        {
            ImageCommandColumn component = new ImageCommandColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ImageCommandColumn(component);
        }

        public ImageCommandColumn.Builder ImageCommandColumn(ImageCommandColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ImageCommandColumn.Builder(component);
        }

        public ImageCommandColumn.Builder ImageCommandColumn(ImageCommandColumn.Config config)
        {
            return new ImageCommandColumn.Builder(new ImageCommandColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public InclusionValidation.Builder InclusionValidation()
        {
            InclusionValidation component = new InclusionValidation
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.InclusionValidation(component);
        }

        public InclusionValidation.Builder InclusionValidation(InclusionValidation component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new InclusionValidation.Builder(component);
        }

        public InclusionValidation.Builder InclusionValidation(InclusionValidation.Config config)
        {
            return new InclusionValidation.Builder(new InclusionValidation(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        private TBuilder InitFieldForBuilder<TField, TBuilder>(string expression, bool setId, Func<object, object> convert = null, string format = null)
            where TField : Field
            where TBuilder : Field.Builder<TField, TBuilder>, new()
        {
            TBuilder local = System.Activator.CreateInstance<TBuilder>();
            TField local2 = local.ToComponent();
            local2.ViewContext = this.HtmlHelper.ViewContext;
            local2.IDFromControlFor = setId;
            local2.ConvertControlForValue = convert;
            local2.FormatControlForValue = format;
            local.ControlFor(expression);
            local2.SetControlFor(ModelMetadata.FromStringExpression(expression, this.HtmlHelper.ViewData));
            return local;
        }

        public InputMask.Builder InputMask()
        {
            InputMask component = new InputMask
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.InputMask(component);
        }

        public InputMask.Builder InputMask(InputMask component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new InputMask.Builder(component);
        }

        public InputMask.Builder InputMask(InputMask.Config config)
        {
            return new InputMask.Builder(new InputMask(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public JsonPProxy.Builder JsonPProxy()
        {
            JsonPProxy component = new JsonPProxy
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.JsonPProxy(component);
        }

        public JsonPProxy.Builder JsonPProxy(JsonPProxy component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new JsonPProxy.Builder(component);
        }

        public JsonPProxy.Builder JsonPProxy(JsonPProxy.Config config)
        {
            return new JsonPProxy.Builder(new JsonPProxy(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public JsonReader.Builder JsonReader()
        {
            JsonReader component = new JsonReader
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.JsonReader(component);
        }

        public JsonReader.Builder JsonReader(JsonReader component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new JsonReader.Builder(component);
        }

        public JsonReader.Builder JsonReader(JsonReader.Config config)
        {
            return new JsonReader.Builder(new JsonReader(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public JsonWriter.Builder JsonWriter()
        {
            JsonWriter component = new JsonWriter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.JsonWriter(component);
        }

        public JsonWriter.Builder JsonWriter(JsonWriter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new JsonWriter.Builder(component);
        }

        public JsonWriter.Builder JsonWriter(JsonWriter.Config config)
        {
            return new JsonWriter.Builder(new JsonWriter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public KeyBinding.Builder KeyBinding()
        {
            KeyBinding component = new KeyBinding
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.KeyBinding(component);
        }

        public KeyBinding.Builder KeyBinding(KeyBinding component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new KeyBinding.Builder(component);
        }

        public KeyBinding.Builder KeyBinding(KeyBinding.Config config)
        {
            return new KeyBinding.Builder(new KeyBinding(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public KeyMap.Builder KeyMap()
        {
            KeyMap component = new KeyMap
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.KeyMap(component);
        }

        public KeyMap.Builder KeyMap(KeyMap component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new KeyMap.Builder(component);
        }

        public KeyMap.Builder KeyMap(KeyMap.Config config)
        {
            return new KeyMap.Builder(new KeyMap(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public KeyNav.Builder KeyNav()
        {
            KeyNav component = new KeyNav
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.KeyNav(component);
        }

        public KeyNav.Builder KeyNav(KeyNav component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new KeyNav.Builder(component);
        }

        public KeyNav.Builder KeyNav(KeyNav.Config config)
        {
            return new KeyNav.Builder(new KeyNav(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Label.Builder Label()
        {
            Label component = new Label
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Label(component);
        }

        public Label.Builder Label(Label component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Label.Builder(component);
        }

        public Label.Builder Label(Label.Config config)
        {
            return new Label.Builder(new Label(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Label.Builder Label(string text)
        {
            return this.Label(new Label(text));
        }

        public Labelable.Builder Labelable()
        {
            Labelable component = new Labelable
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Labelable(component);
        }

        public Labelable.Builder Labelable(Labelable component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Labelable.Builder(component);
        }

        public Labelable.Builder Labelable(Labelable.Config config)
        {
            return new Labelable.Builder(new Labelable(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public LengthValidation.Builder LengthValidation()
        {
            LengthValidation component = new LengthValidation
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.LengthValidation(component);
        }

        public LengthValidation.Builder LengthValidation(LengthValidation component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new LengthValidation.Builder(component);
        }

        public LengthValidation.Builder LengthValidation(LengthValidation.Config config)
        {
            return new LengthValidation.Builder(new LengthValidation(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public LineSeries.Builder LineSeries()
        {
            LineSeries component = new LineSeries
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.LineSeries(component);
        }

        public LineSeries.Builder LineSeries(LineSeries component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new LineSeries.Builder(component);
        }

        public LineSeries.Builder LineSeries(LineSeries.Config config)
        {
            return new LineSeries.Builder(new LineSeries(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public LinkButton.Builder LinkButton()
        {
            LinkButton component = new LinkButton
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.LinkButton(component);
        }

        public LinkButton.Builder LinkButton(LinkButton component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new LinkButton.Builder(component);
        }

        public LinkButton.Builder LinkButton(LinkButton.Config config)
        {
            return new LinkButton.Builder(new LinkButton(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ListFilter.Builder ListFilter()
        {
            ListFilter component = new ListFilter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ListFilter(component);
        }

        public ListFilter.Builder ListFilter(ListFilter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ListFilter.Builder(component);
        }

        public ListFilter.Builder ListFilter(ListFilter.Config config)
        {
            return new ListFilter.Builder(new ListFilter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ListItem.Builder ListItem()
        {
            ListItem component = new ListItem
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ListItem(component);
        }

        public ListItem.Builder ListItem(ListItem component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ListItem.Builder(component);
        }

        public ListItem.Builder ListItem(ListItem.Config config)
        {
            return new ListItem.Builder(new ListItem(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public LiveSearchGridPanel.Builder LiveSearchGridPanel()
        {
            LiveSearchGridPanel component = new LiveSearchGridPanel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.LiveSearchGridPanel(component);
        }

        public LiveSearchGridPanel.Builder LiveSearchGridPanel(LiveSearchGridPanel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new LiveSearchGridPanel.Builder(component);
        }

        public LiveSearchGridPanel.Builder LiveSearchGridPanel(LiveSearchGridPanel.Config config)
        {
            return new LiveSearchGridPanel.Builder(new LiveSearchGridPanel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public LiveSearchToolbar.Builder LiveSearchToolbar()
        {
            LiveSearchToolbar component = new LiveSearchToolbar
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.LiveSearchToolbar(component);
        }

        public LiveSearchToolbar.Builder LiveSearchToolbar(LiveSearchToolbar component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new LiveSearchToolbar.Builder(component);
        }

        public LiveSearchToolbar.Builder LiveSearchToolbar(LiveSearchToolbar.Config config)
        {
            return new LiveSearchToolbar.Builder(new LiveSearchToolbar(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public LoadMask.Builder LoadMask()
        {
            LoadMask component = new LoadMask
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.LoadMask(component);
        }

        public LoadMask.Builder LoadMask(LoadMask component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new LoadMask.Builder(component);
        }

        public LoadMask.Builder LoadMask(LoadMask.Config config)
        {
            return new LoadMask.Builder(new LoadMask(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public LocalStorageProxy.Builder LocalStorageProxy()
        {
            LocalStorageProxy component = new LocalStorageProxy
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.LocalStorageProxy(component);
        }

        public LocalStorageProxy.Builder LocalStorageProxy(LocalStorageProxy component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new LocalStorageProxy.Builder(component);
        }

        public LocalStorageProxy.Builder LocalStorageProxy(LocalStorageProxy.Config config)
        {
            return new LocalStorageProxy.Builder(new LocalStorageProxy(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Menu.Builder Menu()
        {
            Menu component = new Menu
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Menu(component);
        }

        public Menu.Builder Menu(Menu component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Menu.Builder(component);
        }

        public Menu.Builder Menu(Menu.Config config)
        {
            return new Menu.Builder(new Menu(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MenuCommand.Builder MenuCommand()
        {
            MenuCommand component = new MenuCommand
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MenuCommand(component);
        }

        public MenuCommand.Builder MenuCommand(MenuCommand component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MenuCommand.Builder(component);
        }

        public MenuCommand.Builder MenuCommand(MenuCommand.Config config)
        {
            return new MenuCommand.Builder(new MenuCommand(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MenuItem.Builder MenuItem()
        {
            MenuItem component = new MenuItem
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MenuItem(component);
        }

        public MenuItem.Builder MenuItem(MenuItem component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MenuItem.Builder(component);
        }

        public MenuItem.Builder MenuItem(MenuItem.Config config)
        {
            return new MenuItem.Builder(new MenuItem(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MenuPanel.Builder MenuPanel()
        {
            MenuPanel component = new MenuPanel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MenuPanel(component);
        }

        public MenuPanel.Builder MenuPanel(MenuPanel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MenuPanel.Builder(component);
        }

        public MenuPanel.Builder MenuPanel(MenuPanel.Config config)
        {
            return new MenuPanel.Builder(new MenuPanel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MenuSeparator.Builder MenuSeparator()
        {
            MenuSeparator component = new MenuSeparator
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MenuSeparator(component);
        }

        public MenuSeparator.Builder MenuSeparator(MenuSeparator component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MenuSeparator.Builder(component);
        }

        public MenuSeparator.Builder MenuSeparator(MenuSeparator.Config config)
        {
            return new MenuSeparator.Builder(new MenuSeparator(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MessageBus.Builder MessageBus()
        {
            MessageBus component = new MessageBus
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MessageBus(component);
        }

        public MessageBus.Builder MessageBus(MessageBus component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MessageBus.Builder(component);
        }

        public MessageBus.Builder MessageBus(MessageBus.Config config)
        {
            return new MessageBus.Builder(new MessageBus(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Model.Builder Model()
        {
            Model component = new Model
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Model(component);
        }

        public Model.Builder Model(Model component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Model.Builder(component);
        }

        public Model.Builder Model(Model.Config config)
        {
            return new Model.Builder(new Model(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ModelField.Builder ModelField()
        {
            ModelField component = new ModelField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ModelField(component);
        }

        public ModelField.Builder ModelField(ModelField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ModelField.Builder(component);
        }

        public ModelField.Builder ModelField(ModelField.Config config)
        {
            return new ModelField.Builder(new ModelField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ModelStateStore.Builder ModelStateStore()
        {
            ModelStateStore component = new ModelStateStore
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ModelStateStore(component);
        }

        public ModelStateStore.Builder ModelStateStore(ModelStateStore component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ModelStateStore.Builder(component);
        }

        public ModelStateStore.Builder ModelStateStore(ModelStateStore.Config config)
        {
            return new ModelStateStore.Builder(new ModelStateStore(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MonthPicker.Builder MonthPicker()
        {
            MonthPicker component = new MonthPicker
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MonthPicker(component);
        }

        public MonthPicker.Builder MonthPicker(MonthPicker component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MonthPicker.Builder(component);
        }

        public MonthPicker.Builder MonthPicker(MonthPicker.Config config)
        {
            return new MonthPicker.Builder(new MonthPicker(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MonthView.Builder MonthView()
        {
            MonthView component = new MonthView
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MonthView(component);
        }

        public MonthView.Builder MonthView(MonthView component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MonthView.Builder(component);
        }

        public MonthView.Builder MonthView(MonthView.Config config)
        {
            return new MonthView.Builder(new MonthView(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MouseDistanceSensor.Builder MouseDistanceSensor()
        {
            MouseDistanceSensor component = new MouseDistanceSensor
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MouseDistanceSensor(component);
        }

        public MouseDistanceSensor.Builder MouseDistanceSensor(MouseDistanceSensor component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MouseDistanceSensor.Builder(component);
        }

        public MouseDistanceSensor.Builder MouseDistanceSensor(MouseDistanceSensor.Config config)
        {
            return new MouseDistanceSensor.Builder(new MouseDistanceSensor(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MultiCombo.Builder MultiCombo()
        {
            MultiCombo component = new MultiCombo
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MultiCombo(component);
        }

        public MultiCombo.Builder MultiCombo(MultiCombo component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MultiCombo.Builder(component);
        }

        public MultiCombo.Builder MultiCombo(MultiCombo.Config config)
        {
            return new MultiCombo.Builder(new MultiCombo(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MultiCombo.Builder MultiComboFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<MultiCombo, MultiCombo.Builder>(expression, setId, convert, format);
        }

        public MultiSelect.Builder MultiSelect()
        {
            MultiSelect component = new MultiSelect
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MultiSelect(component);
        }

        public MultiSelect.Builder MultiSelect(MultiSelect component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MultiSelect.Builder(component);
        }

        public MultiSelect.Builder MultiSelect(MultiSelect.Config config)
        {
            return new MultiSelect.Builder(new MultiSelect(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MultiSelect.Builder MultiSelectFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<MultiSelect, MultiSelect.Builder>(expression, setId, convert, format);
        }

        public MvcItem.Builder MvcItem()
        {
            MvcItem component = new MvcItem
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.MvcItem(component);
        }

        public MvcItem.Builder MvcItem(MvcItem component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new MvcItem.Builder(component);
        }

        public MvcItem.Builder MvcItem(MvcItem.Config config)
        {
            return new MvcItem.Builder(new MvcItem(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public MvcItem.Builder MvcItem(Func<IHtmlString> expression)
        {
            return new MvcItem.Builder(expression);
        }

        public Node.Builder Node()
        {
            Node component = new Node
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Node(component);
        }

        public Node.Builder Node(Node component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Node.Builder(component);
        }

        public Node.Builder Node(Node.Config config)
        {
            return new Node.Builder(new Node(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public NumberColumn.Builder NumberColumn()
        {
            NumberColumn component = new NumberColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.NumberColumn(component);
        }

        public NumberColumn.Builder NumberColumn(NumberColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new NumberColumn.Builder(component);
        }

        public NumberColumn.Builder NumberColumn(NumberColumn.Config config)
        {
            return new NumberColumn.Builder(new NumberColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public NumberField.Builder NumberField()
        {
            NumberField component = new NumberField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.NumberField(component);
        }

        public NumberField.Builder NumberField(NumberField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new NumberField.Builder(component);
        }

        public NumberField.Builder NumberField(NumberField.Config config)
        {
            return new NumberField.Builder(new NumberField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public NumberField.Builder NumberFieldFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<NumberField, NumberField.Builder>(expression, setId, convert, format);
        }

        public NumericAxis.Builder NumericAxis()
        {
            NumericAxis component = new NumericAxis
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.NumericAxis(component);
        }

        public NumericAxis.Builder NumericAxis(NumericAxis component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new NumericAxis.Builder(component);
        }

        public NumericAxis.Builder NumericAxis(NumericAxis.Config config)
        {
            return new NumericAxis.Builder(new NumericAxis(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public NumericFilter.Builder NumericFilter()
        {
            NumericFilter component = new NumericFilter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.NumericFilter(component);
        }

        public NumericFilter.Builder NumericFilter(NumericFilter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new NumericFilter.Builder(component);
        }

        public NumericFilter.Builder NumericFilter(NumericFilter.Config config)
        {
            return new NumericFilter.Builder(new NumericFilter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ObjectHolder.Builder ObjectHolder()
        {
            ObjectHolder component = new ObjectHolder
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ObjectHolder(component);
        }

        public ObjectHolder.Builder ObjectHolder(ObjectHolder component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ObjectHolder.Builder(component);
        }

        public ObjectHolder.Builder ObjectHolder(ObjectHolder.Config config)
        {
            return new ObjectHolder.Builder(new ObjectHolder(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ODataProxy.Builder ODataProxy()
        {
            ODataProxy component = new ODataProxy
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ODataProxy(component);
        }

        public ODataProxy.Builder ODataProxy(ODataProxy component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ODataProxy.Builder(component);
        }

        public ODataProxy.Builder ODataProxy(ODataProxy.Config config)
        {
            return new ODataProxy.Builder(new ODataProxy(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ODataReader.Builder ODataReader()
        {
            ODataReader component = new ODataReader
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ODataReader(component);
        }

        public ODataReader.Builder ODataReader(ODataReader component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ODataReader.Builder(component);
        }

        public ODataReader.Builder ODataReader(ODataReader.Config config)
        {
            return new ODataReader.Builder(new ODataReader(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public PageProxy.Builder PageProxy()
        {
            PageProxy component = new PageProxy
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.PageProxy(component);
        }

        public PageProxy.Builder PageProxy(PageProxy component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new PageProxy.Builder(component);
        }

        public PageProxy.Builder PageProxy(PageProxy.Config config)
        {
            return new PageProxy.Builder(new PageProxy(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public PagingToolbar.Builder PagingToolbar()
        {
            PagingToolbar component = new PagingToolbar
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.PagingToolbar(component);
        }

        public PagingToolbar.Builder PagingToolbar(PagingToolbar component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new PagingToolbar.Builder(component);
        }

        public PagingToolbar.Builder PagingToolbar(PagingToolbar.Config config)
        {
            return new PagingToolbar.Builder(new PagingToolbar(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Panel.Builder Panel()
        {
            Panel component = new Panel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Panel(component);
        }

        public Panel.Builder Panel(Panel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Panel.Builder(component);
        }

        public Panel.Builder Panel(Panel.Config config)
        {
            return new Panel.Builder(new Panel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public PanelHeader.Builder PanelHeader()
        {
            PanelHeader component = new PanelHeader
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.PanelHeader(component);
        }

        public PanelHeader.Builder PanelHeader(PanelHeader component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new PanelHeader.Builder(component);
        }

        public PanelHeader.Builder PanelHeader(PanelHeader.Config config)
        {
            return new PanelHeader.Builder(new PanelHeader(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Parameter.Builder Parameter()
        {
            Parameter component = new Parameter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Parameter(component);
        }

        public Parameter.Builder Parameter(Parameter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Parameter.Builder(component);
        }

        public Parameter.Builder Parameter(Parameter.Config config)
        {
            return new Parameter.Builder(new Parameter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public PasswordMask.Builder PasswordMask()
        {
            PasswordMask component = new PasswordMask
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.PasswordMask(component);
        }

        public PasswordMask.Builder PasswordMask(PasswordMask component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new PasswordMask.Builder(component);
        }

        public PasswordMask.Builder PasswordMask(PasswordMask.Config config)
        {
            return new PasswordMask.Builder(new PasswordMask(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public PieSeries.Builder PieSeries()
        {
            PieSeries component = new PieSeries
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.PieSeries(component);
        }

        public PieSeries.Builder PieSeries(PieSeries component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new PieSeries.Builder(component);
        }

        public PieSeries.Builder PieSeries(PieSeries.Config config)
        {
            return new PieSeries.Builder(new PieSeries(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Portal.Builder Portal()
        {
            Portal component = new Portal
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Portal(component);
        }

        public Portal.Builder Portal(Portal component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Portal.Builder(component);
        }

        public Portal.Builder Portal(Portal.Config config)
        {
            return new Portal.Builder(new Portal(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public PortalColumn.Builder PortalColumn()
        {
            PortalColumn component = new PortalColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.PortalColumn(component);
        }

        public PortalColumn.Builder PortalColumn(PortalColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new PortalColumn.Builder(component);
        }

        public PortalColumn.Builder PortalColumn(PortalColumn.Config config)
        {
            return new PortalColumn.Builder(new PortalColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Portlet.Builder Portlet()
        {
            Portlet component = new Portlet
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Portlet(component);
        }

        public Portlet.Builder Portlet(Portlet component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Portlet.Builder(component);
        }

        public Portlet.Builder Portlet(Portlet.Config config)
        {
            return new Portlet.Builder(new Portlet(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public PresenceValidation.Builder PresenceValidation()
        {
            PresenceValidation component = new PresenceValidation
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.PresenceValidation(component);
        }

        public PresenceValidation.Builder PresenceValidation(PresenceValidation component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new PresenceValidation.Builder(component);
        }

        public PresenceValidation.Builder PresenceValidation(PresenceValidation.Config config)
        {
            return new PresenceValidation.Builder(new PresenceValidation(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Preview.Builder Preview()
        {
            Preview component = new Preview
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Preview(component);
        }

        public Preview.Builder Preview(Preview component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Preview.Builder(component);
        }

        public Preview.Builder Preview(Preview.Config config)
        {
            return new Preview.Builder(new Preview(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ProgressBar.Builder ProgressBar()
        {
            ProgressBar component = new ProgressBar
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ProgressBar(component);
        }

        public ProgressBar.Builder ProgressBar(ProgressBar component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ProgressBar.Builder(component);
        }

        public ProgressBar.Builder ProgressBar(ProgressBar.Config config)
        {
            return new ProgressBar.Builder(new ProgressBar(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ProgressBarPager.Builder ProgressBarPager()
        {
            ProgressBarPager component = new ProgressBarPager
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ProgressBarPager(component);
        }

        public ProgressBarPager.Builder ProgressBarPager(ProgressBarPager component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ProgressBarPager.Builder(component);
        }

        public ProgressBarPager.Builder ProgressBarPager(ProgressBarPager.Config config)
        {
            return new ProgressBarPager.Builder(new ProgressBarPager(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public PropertyGrid.Builder PropertyGrid()
        {
            PropertyGrid component = new PropertyGrid
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.PropertyGrid(component);
        }

        public PropertyGrid.Builder PropertyGrid(PropertyGrid component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new PropertyGrid.Builder(component);
        }

        public PropertyGrid.Builder PropertyGrid(PropertyGrid.Config config)
        {
            return new PropertyGrid.Builder(new PropertyGrid(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public PropertyGridParameter.Builder PropertyGridParameter()
        {
            PropertyGridParameter component = new PropertyGridParameter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.PropertyGridParameter(component);
        }

        public PropertyGridParameter.Builder PropertyGridParameter(PropertyGridParameter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new PropertyGridParameter.Builder(component);
        }

        public PropertyGridParameter.Builder PropertyGridParameter(PropertyGridParameter.Config config)
        {
            return new PropertyGridParameter.Builder(new PropertyGridParameter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RadarSeries.Builder RadarSeries()
        {
            RadarSeries component = new RadarSeries
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RadarSeries(component);
        }

        public RadarSeries.Builder RadarSeries(RadarSeries component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RadarSeries.Builder(component);
        }

        public RadarSeries.Builder RadarSeries(RadarSeries.Config config)
        {
            return new RadarSeries.Builder(new RadarSeries(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RadialAxis.Builder RadialAxis()
        {
            RadialAxis component = new RadialAxis
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RadialAxis(component);
        }

        public RadialAxis.Builder RadialAxis(RadialAxis component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RadialAxis.Builder(component);
        }

        public RadialAxis.Builder RadialAxis(RadialAxis.Config config)
        {
            return new RadialAxis.Builder(new RadialAxis(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Radio.Builder Radio()
        {
            Radio component = new Radio
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Radio(component);
        }

        public Radio.Builder Radio(Radio component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Radio.Builder(component);
        }

        public Radio.Builder Radio(Radio.Config config)
        {
            return new Radio.Builder(new Radio(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Radio.Builder RadioFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<Radio, Radio.Builder>(expression, setId, convert, format);
        }

        public RadioGroup.Builder RadioGroup()
        {
            RadioGroup component = new RadioGroup
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RadioGroup(component);
        }

        public RadioGroup.Builder RadioGroup(RadioGroup component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RadioGroup.Builder(component);
        }

        public RadioGroup.Builder RadioGroup(RadioGroup.Config config)
        {
            return new RadioGroup.Builder(new RadioGroup(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RatingColumn.Builder RatingColumn()
        {
            RatingColumn component = new RatingColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RatingColumn(component);
        }

        public RatingColumn.Builder RatingColumn(RatingColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RatingColumn.Builder(component);
        }

        public RatingColumn.Builder RatingColumn(RatingColumn.Config config)
        {
            return new RatingColumn.Builder(new RatingColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ReminderCombo.Builder ReminderCombo()
        {
            ReminderCombo component = new ReminderCombo
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ReminderCombo(component);
        }

        public ReminderCombo.Builder ReminderCombo(ReminderCombo component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ReminderCombo.Builder(component);
        }

        public ReminderCombo.Builder ReminderCombo(ReminderCombo.Config config)
        {
            return new ReminderCombo.Builder(new ReminderCombo(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Resizer.Builder Resizer()
        {
            Resizer component = new Resizer
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Resizer(component);
        }

        public Resizer.Builder Resizer(Resizer component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Resizer.Builder(component);
        }

        public Resizer.Builder Resizer(Resizer.Config config)
        {
            return new Resizer.Builder(new Resizer(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ResourcesRegistrator.Builder ResourcesRegistrator()
        {
            ResourcesRegistrator component = new ResourcesRegistrator
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ResourcesRegistrator(component);
        }

        public ResourcesRegistrator.Builder ResourcesRegistrator(ResourcesRegistrator component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ResourcesRegistrator.Builder(component);
        }

        public ResourcesRegistrator.Builder ResourcesRegistrator(ResourcesRegistrator.Config config)
        {
            return new ResourcesRegistrator.Builder(new ResourcesRegistrator(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RestProxy.Builder RestProxy()
        {
            RestProxy component = new RestProxy
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RestProxy(component);
        }

        public RestProxy.Builder RestProxy(RestProxy component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RestProxy.Builder(component);
        }

        public RestProxy.Builder RestProxy(RestProxy.Config config)
        {
            return new RestProxy.Builder(new RestProxy(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RotateAttribute.Builder RotateAttribute()
        {
            RotateAttribute component = new RotateAttribute
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RotateAttribute(component);
        }

        public RotateAttribute.Builder RotateAttribute(RotateAttribute component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RotateAttribute.Builder(component);
        }

        public RotateAttribute.Builder RotateAttribute(RotateAttribute.Config config)
        {
            return new RotateAttribute.Builder(new RotateAttribute(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RowBody.Builder RowBody()
        {
            RowBody component = new RowBody
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RowBody(component);
        }

        public RowBody.Builder RowBody(RowBody component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RowBody.Builder(component);
        }

        public RowBody.Builder RowBody(RowBody.Config config)
        {
            return new RowBody.Builder(new RowBody(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RowEditing.Builder RowEditing()
        {
            RowEditing component = new RowEditing
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RowEditing(component);
        }

        public RowEditing.Builder RowEditing(RowEditing component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RowEditing.Builder(component);
        }

        public RowEditing.Builder RowEditing(RowEditing.Config config)
        {
            return new RowEditing.Builder(new RowEditing(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RowExpander.Builder RowExpander()
        {
            RowExpander component = new RowExpander
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RowExpander(component);
        }

        public RowExpander.Builder RowExpander(RowExpander component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RowExpander.Builder(component);
        }

        public RowExpander.Builder RowExpander(RowExpander.Config config)
        {
            return new RowExpander.Builder(new RowExpander(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RowNumbererColumn.Builder RowNumbererColumn()
        {
            RowNumbererColumn component = new RowNumbererColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RowNumbererColumn(component);
        }

        public RowNumbererColumn.Builder RowNumbererColumn(RowNumbererColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RowNumbererColumn.Builder(component);
        }

        public RowNumbererColumn.Builder RowNumbererColumn(RowNumbererColumn.Config config)
        {
            return new RowNumbererColumn.Builder(new RowNumbererColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RowSelectionModel.Builder RowSelectionModel()
        {
            RowSelectionModel component = new RowSelectionModel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RowSelectionModel(component);
        }

        public RowSelectionModel.Builder RowSelectionModel(RowSelectionModel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RowSelectionModel.Builder(component);
        }

        public RowSelectionModel.Builder RowSelectionModel(RowSelectionModel.Config config)
        {
            return new RowSelectionModel.Builder(new RowSelectionModel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public RowWrap.Builder RowWrap()
        {
            RowWrap component = new RowWrap
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.RowWrap(component);
        }

        public RowWrap.Builder RowWrap(RowWrap component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new RowWrap.Builder(component);
        }

        public RowWrap.Builder RowWrap(RowWrap.Config config)
        {
            return new RowWrap.Builder(new RowWrap(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ScaleAttribute.Builder ScaleAttribute()
        {
            ScaleAttribute component = new ScaleAttribute
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ScaleAttribute(component);
        }

        public ScaleAttribute.Builder ScaleAttribute(ScaleAttribute component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ScaleAttribute.Builder(component);
        }

        public ScaleAttribute.Builder ScaleAttribute(ScaleAttribute.Config config)
        {
            return new ScaleAttribute.Builder(new ScaleAttribute(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ScatterSeries.Builder ScatterSeries()
        {
            ScatterSeries component = new ScatterSeries
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ScatterSeries(component);
        }

        public ScatterSeries.Builder ScatterSeries(ScatterSeries component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ScatterSeries.Builder(component);
        }

        public ScatterSeries.Builder ScatterSeries(ScatterSeries.Config config)
        {
            return new ScatterSeries.Builder(new ScatterSeries(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SelectBox.Builder SelectBox()
        {
            SelectBox component = new SelectBox
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SelectBox(component);
        }

        public SelectBox.Builder SelectBox(SelectBox component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SelectBox.Builder(component);
        }

        public SelectBox.Builder SelectBox(SelectBox.Config config)
        {
            return new SelectBox.Builder(new SelectBox(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SelectBox.Builder SelectBoxFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<SelectBox, SelectBox.Builder>(expression, setId, convert, format);
        }

        public SelectedCell.Builder SelectedCell()
        {
            SelectedCell component = new SelectedCell
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SelectedCell(component);
        }

        public SelectedCell.Builder SelectedCell(SelectedCell component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SelectedCell.Builder(component);
        }

        public SelectedCell.Builder SelectedCell(SelectedCell.Config config)
        {
            return new SelectedCell.Builder(new SelectedCell(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SelectedListItem.Builder SelectedListItem()
        {
            SelectedListItem component = new SelectedListItem
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SelectedListItem(component);
        }

        public SelectedListItem.Builder SelectedListItem(SelectedListItem component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SelectedListItem.Builder(component);
        }

        public SelectedListItem.Builder SelectedListItem(SelectedListItem.Config config)
        {
            return new SelectedListItem.Builder(new SelectedListItem(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SelectedRow.Builder SelectedRow()
        {
            SelectedRow component = new SelectedRow
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SelectedRow(component);
        }

        public SelectedRow.Builder SelectedRow(SelectedRow component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SelectedRow.Builder(component);
        }

        public SelectedRow.Builder SelectedRow(SelectedRow.Config config)
        {
            return new SelectedRow.Builder(new SelectedRow(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SequentialIdGenerator.Builder SequentialIdGenerator()
        {
            SequentialIdGenerator component = new SequentialIdGenerator
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SequentialIdGenerator(component);
        }

        public SequentialIdGenerator.Builder SequentialIdGenerator(SequentialIdGenerator component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SequentialIdGenerator.Builder(component);
        }

        public SequentialIdGenerator.Builder SequentialIdGenerator(SequentialIdGenerator.Config config)
        {
            return new SequentialIdGenerator.Builder(new SequentialIdGenerator(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SeriesLabel.Builder SeriesLabel()
        {
            SeriesLabel component = new SeriesLabel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SeriesLabel(component);
        }

        public SeriesLabel.Builder SeriesLabel(SeriesLabel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SeriesLabel.Builder(component);
        }

        public SeriesLabel.Builder SeriesLabel(SeriesLabel.Config config)
        {
            return new SeriesLabel.Builder(new SeriesLabel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SessionStorageProxy.Builder SessionStorageProxy()
        {
            SessionStorageProxy component = new SessionStorageProxy
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SessionStorageProxy(component);
        }

        public SessionStorageProxy.Builder SessionStorageProxy(SessionStorageProxy component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SessionStorageProxy.Builder(component);
        }

        public SessionStorageProxy.Builder SessionStorageProxy(SessionStorageProxy.Config config)
        {
            return new SessionStorageProxy.Builder(new SessionStorageProxy(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ShortcutDefaults.Builder ShortcutDefaults()
        {
            ShortcutDefaults component = new ShortcutDefaults
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ShortcutDefaults(component);
        }

        public ShortcutDefaults.Builder ShortcutDefaults(ShortcutDefaults component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ShortcutDefaults.Builder(component);
        }

        public ShortcutDefaults.Builder ShortcutDefaults(ShortcutDefaults.Config config)
        {
            return new ShortcutDefaults.Builder(new ShortcutDefaults(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Slider.Builder Slider()
        {
            Slider component = new Slider
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Slider(component);
        }

        public Slider.Builder Slider(Slider component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Slider.Builder(component);
        }

        public Slider.Builder Slider(Slider.Config config)
        {
            return new Slider.Builder(new Slider(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Slider.Builder SliderFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<Slider, Slider.Builder>(expression, setId, convert, format);
        }

        public SliderTip.Builder SliderTip()
        {
            SliderTip component = new SliderTip
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SliderTip(component);
        }

        public SliderTip.Builder SliderTip(SliderTip component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SliderTip.Builder(component);
        }

        public SliderTip.Builder SliderTip(SliderTip.Config config)
        {
            return new SliderTip.Builder(new SliderTip(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SortInfo.Builder SortInfo()
        {
            SortInfo component = new SortInfo
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SortInfo(component);
        }

        public SortInfo.Builder SortInfo(SortInfo component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SortInfo.Builder(component);
        }

        public SortInfo.Builder SortInfo(SortInfo.Config config)
        {
            return new SortInfo.Builder(new SortInfo(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SpinnerField.Builder SpinnerField()
        {
            SpinnerField component = new SpinnerField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SpinnerField(component);
        }

        public SpinnerField.Builder SpinnerField(SpinnerField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SpinnerField.Builder(component);
        }

        public SpinnerField.Builder SpinnerField(SpinnerField.Config config)
        {
            return new SpinnerField.Builder(new SpinnerField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SpinnerField.Builder SpinnerFieldFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<SpinnerField, SpinnerField.Builder>(expression, setId, convert, format);
        }

        public SplitButton.Builder SplitButton()
        {
            SplitButton component = new SplitButton
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SplitButton(component);
        }

        public SplitButton.Builder SplitButton(SplitButton component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SplitButton.Builder(component);
        }

        public SplitButton.Builder SplitButton(SplitButton.Config config)
        {
            return new SplitButton.Builder(new SplitButton(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SplitCommand.Builder SplitCommand()
        {
            SplitCommand component = new SplitCommand
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SplitCommand(component);
        }

        public SplitCommand.Builder SplitCommand(SplitCommand component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SplitCommand.Builder(component);
        }

        public SplitCommand.Builder SplitCommand(SplitCommand.Config config)
        {
            return new SplitCommand.Builder(new SplitCommand(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Spotlight.Builder Spotlight()
        {
            Spotlight component = new Spotlight
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Spotlight(component);
        }

        public Spotlight.Builder Spotlight(Spotlight component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Spotlight.Builder(component);
        }

        public Spotlight.Builder Spotlight(Spotlight.Config config)
        {
            return new Spotlight.Builder(new Spotlight(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Sprite.Builder Sprite()
        {
            Sprite component = new Sprite
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Sprite(component);
        }

        public Sprite.Builder Sprite(Sprite component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Sprite.Builder(component);
        }

        public Sprite.Builder Sprite(Sprite.Config config)
        {
            return new Sprite.Builder(new Sprite(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SpriteAttributes.Builder SpriteAttributes()
        {
            SpriteAttributes component = new SpriteAttributes
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SpriteAttributes(component);
        }

        public SpriteAttributes.Builder SpriteAttributes(SpriteAttributes component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SpriteAttributes.Builder(component);
        }

        public SpriteAttributes.Builder SpriteAttributes(SpriteAttributes.Config config)
        {
            return new SpriteAttributes.Builder(new SpriteAttributes(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public StatusBar.Builder StatusBar()
        {
            StatusBar component = new StatusBar
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.StatusBar(component);
        }

        public StatusBar.Builder StatusBar(StatusBar component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new StatusBar.Builder(component);
        }

        public StatusBar.Builder StatusBar(StatusBar.Config config)
        {
            return new StatusBar.Builder(new StatusBar(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Store.Builder Store()
        {
            Store component = new Store
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Store(component);
        }

        public Store.Builder Store(Store component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Store.Builder(component);
        }

        public Store.Builder Store(Store.Config config)
        {
            return new Store.Builder(new Store(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public StoreParameter.Builder StoreParameter()
        {
            StoreParameter component = new StoreParameter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.StoreParameter(component);
        }

        public StoreParameter.Builder StoreParameter(StoreParameter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new StoreParameter.Builder(component);
        }

        public StoreParameter.Builder StoreParameter(StoreParameter.Config config)
        {
            return new StoreParameter.Builder(new StoreParameter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public StringFilter.Builder StringFilter()
        {
            StringFilter component = new StringFilter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.StringFilter(component);
        }

        public StringFilter.Builder StringFilter(StringFilter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new StringFilter.Builder(component);
        }

        public StringFilter.Builder StringFilter(StringFilter.Config config)
        {
            return new StringFilter.Builder(new StringFilter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Summary.Builder Summary()
        {
            Summary component = new Summary
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Summary(component);
        }

        public Summary.Builder Summary(Summary component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Summary.Builder(component);
        }

        public Summary.Builder Summary(Summary.Config config)
        {
            return new Summary.Builder(new Summary(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public SummaryColumn.Builder SummaryColumn()
        {
            SummaryColumn component = new SummaryColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.SummaryColumn(component);
        }

        public SummaryColumn.Builder SummaryColumn(SummaryColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new SummaryColumn.Builder(component);
        }

        public SummaryColumn.Builder SummaryColumn(SummaryColumn.Config config)
        {
            return new SummaryColumn.Builder(new SummaryColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Tab.Builder Tab()
        {
            Tab component = new Tab
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Tab(component);
        }

        public Tab.Builder Tab(Tab component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Tab.Builder(component);
        }

        public Tab.Builder Tab(Tab.Config config)
        {
            return new Tab.Builder(new Tab(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TabMenu.Builder TabMenu()
        {
            TabMenu component = new TabMenu
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TabMenu(component);
        }

        public TabMenu.Builder TabMenu(TabMenu component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TabMenu.Builder(component);
        }

        public TabMenu.Builder TabMenu(TabMenu.Config config)
        {
            return new TabMenu.Builder(new TabMenu(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TabPanel.Builder TabPanel()
        {
            TabPanel component = new TabPanel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TabPanel(component);
        }

        public TabPanel.Builder TabPanel(TabPanel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TabPanel.Builder(component);
        }

        public TabPanel.Builder TabPanel(TabPanel.Config config)
        {
            return new TabPanel.Builder(new TabPanel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TabScrollerMenu.Builder TabScrollerMenu()
        {
            TabScrollerMenu component = new TabScrollerMenu
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TabScrollerMenu(component);
        }

        public TabScrollerMenu.Builder TabScrollerMenu(TabScrollerMenu component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TabScrollerMenu.Builder(component);
        }

        public TabScrollerMenu.Builder TabScrollerMenu(TabScrollerMenu.Config config)
        {
            return new TabScrollerMenu.Builder(new TabScrollerMenu(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TabStrip.Builder TabStrip()
        {
            TabStrip component = new TabStrip
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TabStrip(component);
        }

        public TabStrip.Builder TabStrip(TabStrip component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TabStrip.Builder(component);
        }

        public TabStrip.Builder TabStrip(TabStrip.Config config)
        {
            return new TabStrip.Builder(new TabStrip(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Task.Builder Task()
        {
            Task component = new Task
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Task(component);
        }

        public Task.Builder Task(Task component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Task.Builder(component);
        }

        public Task.Builder Task(Task.Config config)
        {
            return new Task.Builder(new Task(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TaskManager.Builder TaskManager()
        {
            TaskManager component = new TaskManager
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TaskManager(component);
        }

        public TaskManager.Builder TaskManager(TaskManager component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TaskManager.Builder(component);
        }

        public TaskManager.Builder TaskManager(TaskManager.Config config)
        {
            return new TaskManager.Builder(new TaskManager(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TemplateColumn.Builder TemplateColumn()
        {
            TemplateColumn component = new TemplateColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TemplateColumn(component);
        }

        public TemplateColumn.Builder TemplateColumn(TemplateColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TemplateColumn.Builder(component);
        }

        public TemplateColumn.Builder TemplateColumn(TemplateColumn.Config config)
        {
            return new TemplateColumn.Builder(new TemplateColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TextArea.Builder TextArea()
        {
            TextArea component = new TextArea
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TextArea(component);
        }

        public TextArea.Builder TextArea(TextArea component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TextArea.Builder(component);
        }

        public TextArea.Builder TextArea(TextArea.Config config)
        {
            return new TextArea.Builder(new TextArea(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TextArea.Builder TextAreaFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<TextArea, TextArea.Builder>(expression, setId, convert, format);
        }

        public TextField.Builder TextField()
        {
            TextField component = new TextField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TextField(component);
        }

        public TextField.Builder TextField(TextField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TextField.Builder(component);
        }

        public TextField.Builder TextField(TextField.Config config)
        {
            return new TextField.Builder(new TextField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TextField.Builder TextFieldFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<TextField, TextField.Builder>(expression, setId, convert, format);
        }

        public TimeAxis.Builder TimeAxis()
        {
            TimeAxis component = new TimeAxis
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TimeAxis(component);
        }

        public TimeAxis.Builder TimeAxis(TimeAxis component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TimeAxis.Builder(component);
        }

        public TimeAxis.Builder TimeAxis(TimeAxis.Config config)
        {
            return new TimeAxis.Builder(new TimeAxis(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TimeField.Builder TimeField()
        {
            TimeField component = new TimeField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TimeField(component);
        }

        public TimeField.Builder TimeField(TimeField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TimeField.Builder(component);
        }

        public TimeField.Builder TimeField(TimeField.Config config)
        {
            return new TimeField.Builder(new TimeField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TimeField.Builder TimeFieldFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<TimeField, TimeField.Builder>(expression, setId, convert, format);
        }

        public TimePicker.Builder TimePicker()
        {
            TimePicker component = new TimePicker
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TimePicker(component);
        }

        public TimePicker.Builder TimePicker(TimePicker component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TimePicker.Builder(component);
        }

        public TimePicker.Builder TimePicker(TimePicker.Config config)
        {
            return new TimePicker.Builder(new TimePicker(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Tool.Builder Tool()
        {
            Tool component = new Tool
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Tool(component);
        }

        public Tool.Builder Tool(Tool component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Tool.Builder(component);
        }

        public Tool.Builder Tool(Tool.Config config)
        {
            return new Tool.Builder(new Tool(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Toolbar.Builder Toolbar()
        {
            Toolbar component = new Toolbar
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Toolbar(component);
        }

        public Toolbar.Builder Toolbar(Toolbar component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Toolbar.Builder(component);
        }

        public Toolbar.Builder Toolbar(Toolbar.Config config)
        {
            return new Toolbar.Builder(new Toolbar(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ToolbarFill.Builder ToolbarFill()
        {
            ToolbarFill component = new ToolbarFill
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ToolbarFill(component);
        }

        public ToolbarFill.Builder ToolbarFill(ToolbarFill component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ToolbarFill.Builder(component);
        }

        public ToolbarFill.Builder ToolbarFill(ToolbarFill.Config config)
        {
            return new ToolbarFill.Builder(new ToolbarFill(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ToolbarSeparator.Builder ToolbarSeparator()
        {
            ToolbarSeparator component = new ToolbarSeparator
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ToolbarSeparator(component);
        }

        public ToolbarSeparator.Builder ToolbarSeparator(ToolbarSeparator component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ToolbarSeparator.Builder(component);
        }

        public ToolbarSeparator.Builder ToolbarSeparator(ToolbarSeparator.Config config)
        {
            return new ToolbarSeparator.Builder(new ToolbarSeparator(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ToolbarSpacer.Builder ToolbarSpacer()
        {
            ToolbarSpacer component = new ToolbarSpacer
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ToolbarSpacer(component);
        }

        public ToolbarSpacer.Builder ToolbarSpacer(ToolbarSpacer component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ToolbarSpacer.Builder(component);
        }

        public ToolbarSpacer.Builder ToolbarSpacer(ToolbarSpacer.Config config)
        {
            return new ToolbarSpacer.Builder(new ToolbarSpacer(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ToolbarSpacer.Builder ToolbarSpacer(int width)
        {
            return this.ToolbarSpacer(new ToolbarSpacer(width));
        }

        public ToolbarTextItem.Builder ToolbarTextItem()
        {
            ToolbarTextItem component = new ToolbarTextItem
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ToolbarTextItem(component);
        }

        public ToolbarTextItem.Builder ToolbarTextItem(ToolbarTextItem component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ToolbarTextItem.Builder(component);
        }

        public ToolbarTextItem.Builder ToolbarTextItem(ToolbarTextItem.Config config)
        {
            return new ToolbarTextItem.Builder(new ToolbarTextItem(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ToolTip.Builder ToolTip()
        {
            ToolTip component = new ToolTip
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ToolTip(component);
        }

        public ToolTip.Builder ToolTip(ToolTip component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ToolTip.Builder(component);
        }

        public ToolTip.Builder ToolTip(ToolTip.Config config)
        {
            return new ToolTip.Builder(new ToolTip(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string ToString()
        {
            return base.ToString();
        }

        public TransformGrid.Builder TransformGrid()
        {
            TransformGrid component = new TransformGrid
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TransformGrid(component);
        }

        public TransformGrid.Builder TransformGrid(TransformGrid component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TransformGrid.Builder(component);
        }

        public TransformGrid.Builder TransformGrid(TransformGrid.Config config)
        {
            return new TransformGrid.Builder(new TransformGrid(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TranslateAttribute.Builder TranslateAttribute()
        {
            TranslateAttribute component = new TranslateAttribute
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TranslateAttribute(component);
        }

        public TranslateAttribute.Builder TranslateAttribute(TranslateAttribute component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TranslateAttribute.Builder(component);
        }

        public TranslateAttribute.Builder TranslateAttribute(TranslateAttribute.Config config)
        {
            return new TranslateAttribute.Builder(new TranslateAttribute(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TrayClock.Builder TrayClock()
        {
            TrayClock component = new TrayClock
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TrayClock(component);
        }

        public TrayClock.Builder TrayClock(TrayClock component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TrayClock.Builder(component);
        }

        public TrayClock.Builder TrayClock(TrayClock.Config config)
        {
            return new TrayClock.Builder(new TrayClock(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TreeColumn.Builder TreeColumn()
        {
            TreeColumn component = new TreeColumn
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TreeColumn(component);
        }

        public TreeColumn.Builder TreeColumn(TreeColumn component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TreeColumn.Builder(component);
        }

        public TreeColumn.Builder TreeColumn(TreeColumn.Config config)
        {
            return new TreeColumn.Builder(new TreeColumn(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TreeDragZone.Builder TreeDragZone()
        {
            TreeDragZone component = new TreeDragZone
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TreeDragZone(component);
        }

        public TreeDragZone.Builder TreeDragZone(TreeDragZone component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TreeDragZone.Builder(component);
        }

        public TreeDragZone.Builder TreeDragZone(TreeDragZone.Config config)
        {
            return new TreeDragZone.Builder(new TreeDragZone(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TreePanel.Builder TreePanel()
        {
            TreePanel component = new TreePanel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TreePanel(component);
        }

        public TreePanel.Builder TreePanel(TreePanel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TreePanel.Builder(component);
        }

        public TreePanel.Builder TreePanel(TreePanel.Config config)
        {
            return new TreePanel.Builder(new TreePanel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TreeSelectionModel.Builder TreeSelectionModel()
        {
            TreeSelectionModel component = new TreeSelectionModel
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TreeSelectionModel(component);
        }

        public TreeSelectionModel.Builder TreeSelectionModel(TreeSelectionModel component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TreeSelectionModel.Builder(component);
        }

        public TreeSelectionModel.Builder TreeSelectionModel(TreeSelectionModel.Config config)
        {
            return new TreeSelectionModel.Builder(new TreeSelectionModel(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TreeStore.Builder TreeStore()
        {
            TreeStore component = new TreeStore
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TreeStore(component);
        }

        public TreeStore.Builder TreeStore(TreeStore component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TreeStore.Builder(component);
        }

        public TreeStore.Builder TreeStore(TreeStore.Config config)
        {
            return new TreeStore.Builder(new TreeStore(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TreeView.Builder TreeView()
        {
            TreeView component = new TreeView
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TreeView(component);
        }

        public TreeView.Builder TreeView(TreeView component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TreeView.Builder(component);
        }

        public TreeView.Builder TreeView(TreeView.Config config)
        {
            return new TreeView.Builder(new TreeView(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TreeViewDragDrop.Builder TreeViewDragDrop()
        {
            TreeViewDragDrop component = new TreeViewDragDrop
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TreeViewDragDrop(component);
        }

        public TreeViewDragDrop.Builder TreeViewDragDrop(TreeViewDragDrop component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TreeViewDragDrop.Builder(component);
        }

        public TreeViewDragDrop.Builder TreeViewDragDrop(TreeViewDragDrop.Config config)
        {
            return new TreeViewDragDrop.Builder(new TreeViewDragDrop(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TriggerField.Builder TriggerField()
        {
            TriggerField component = new TriggerField
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.TriggerField(component);
        }

        public TriggerField.Builder TriggerField(TriggerField component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new TriggerField.Builder(component);
        }

        public TriggerField.Builder TriggerField(TriggerField.Config config)
        {
            return new TriggerField.Builder(new TriggerField(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public TriggerField.Builder TriggerFieldFor(string expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<TriggerField, TriggerField.Builder>(expression, setId, convert, format);
        }

        public UserControlLoader.Builder UserControlLoader()
        {
            UserControlLoader component = new UserControlLoader
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.UserControlLoader(component);
        }

        public UserControlLoader.Builder UserControlLoader(UserControlLoader component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new UserControlLoader.Builder(component);
        }

        public UserControlLoader.Builder UserControlLoader(UserControlLoader.Config config)
        {
            return new UserControlLoader.Builder(new UserControlLoader(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public UuidIdGenerator.Builder UuidIdGenerator()
        {
            UuidIdGenerator component = new UuidIdGenerator
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.UuidIdGenerator(component);
        }

        public UuidIdGenerator.Builder UuidIdGenerator(UuidIdGenerator component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new UuidIdGenerator.Builder(component);
        }

        public UuidIdGenerator.Builder UuidIdGenerator(UuidIdGenerator.Config config)
        {
            return new UuidIdGenerator.Builder(new UuidIdGenerator(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ValidationStatus.Builder ValidationStatus()
        {
            ValidationStatus component = new ValidationStatus
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ValidationStatus(component);
        }

        public ValidationStatus.Builder ValidationStatus(ValidationStatus component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ValidationStatus.Builder(component);
        }

        public ValidationStatus.Builder ValidationStatus(ValidationStatus.Config config)
        {
            return new ValidationStatus.Builder(new ValidationStatus(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public VerticalMarker.Builder VerticalMarker()
        {
            VerticalMarker component = new VerticalMarker
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.VerticalMarker(component);
        }

        public VerticalMarker.Builder VerticalMarker(VerticalMarker component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new VerticalMarker.Builder(component);
        }

        public VerticalMarker.Builder VerticalMarker(VerticalMarker.Config config)
        {
            return new VerticalMarker.Builder(new VerticalMarker(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public ViewItem.Builder ViewItem()
        {
            ViewItem component = new ViewItem
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.ViewItem(component);
        }

        public ViewItem.Builder ViewItem(ViewItem component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new ViewItem.Builder(component);
        }

        public ViewItem.Builder ViewItem(ViewItem.Config config)
        {
            return new ViewItem.Builder(new ViewItem(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Viewport.Builder Viewport()
        {
            Viewport component = new Viewport
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Viewport(component);
        }

        public Viewport.Builder Viewport(Viewport component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Viewport.Builder(component);
        }

        public Viewport.Builder Viewport(Viewport.Config config)
        {
            return new Viewport.Builder(new Viewport(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public WeekView.Builder WeekView()
        {
            WeekView component = new WeekView
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.WeekView(component);
        }

        public WeekView.Builder WeekView(WeekView component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new WeekView.Builder(component);
        }

        public WeekView.Builder WeekView(WeekView.Config config)
        {
            return new WeekView.Builder(new WeekView(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public Window.Builder Window()
        {
            Window component = new Window
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.Window(component);
        }

        public Window.Builder Window(Window component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new Window.Builder(component);
        }

        public Window.Builder Window(Window.Config config)
        {
            return new Window.Builder(new Window(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public XController.Builder XController()
        {
            XController component = new XController
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.XController(component);
        }

        public XController.Builder XController(XController component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new XController.Builder(component);
        }

        public XController.Builder XController(XController.Config config)
        {
            return new XController.Builder(new XController(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public XmlReader.Builder XmlReader()
        {
            XmlReader component = new XmlReader
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.XmlReader(component);
        }

        public XmlReader.Builder XmlReader(XmlReader component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new XmlReader.Builder(component);
        }

        public XmlReader.Builder XmlReader(XmlReader.Config config)
        {
            return new XmlReader.Builder(new XmlReader(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public XmlWriter.Builder XmlWriter()
        {
            XmlWriter component = new XmlWriter
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.XmlWriter(component);
        }

        public XmlWriter.Builder XmlWriter(XmlWriter component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new XmlWriter.Builder(component);
        }

        public XmlWriter.Builder XmlWriter(XmlWriter.Config config)
        {
            return new XmlWriter.Builder(new XmlWriter(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public XScript.Builder XScript()
        {
            XScript component = new XScript
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.XScript(component);
        }

        public XScript.Builder XScript(XScript component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new XScript.Builder(component);
        }

        public XScript.Builder XScript(XScript.Config config)
        {
            return new XScript.Builder(new XScript(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public XTemplate.Builder XTemplate()
        {
            XTemplate component = new XTemplate
            {
                ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null
            };
            return this.XTemplate(component);
        }

        public XTemplate.Builder XTemplate(XTemplate component)
        {
            component.ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null;
            return new XTemplate.Builder(component);
        }

        public XTemplate.Builder XTemplate(XTemplate.Config config)
        {
            return new XTemplate.Builder(new XTemplate(config) { ViewContext = (this.HtmlHelper != null) ? this.HtmlHelper.ViewContext : null });
        }

        public System.Web.Mvc.HtmlHelper HtmlHelper { get; set; }
    }

    public class BuilderFactory<TModel> : BuilderFactory
    {
        private HtmlHelper<TModel> htmlHelper;

        public Hidden.Builder AntiForgeryField()
        {
            string str = AntiForgery.GetHtml().ToString();
            Hidden hidden = new Hidden();
            System.Text.RegularExpressions.Match match = System.Text.RegularExpressions.Regex.Match(str, "name=\"(.+?)\"");
            if (match.get_Success())
            {
                hidden.Name = match.Groups.get_Item(1).get_Value();
            }
            match = System.Text.RegularExpressions.Regex.Match(str, "value=\"(.+?)\"");
            if (match.get_Success())
            {
                hidden.Text = match.Groups.get_Item(1).get_Value();
            }
            return hidden.ToBuilder();
        }

        public Checkbox.Builder CheckboxFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<Checkbox, Checkbox.Builder, TProperty>(expression, setId, convert, format);
        }

        public CheckboxGroup.Builder CheckboxGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, System.Collections.Generic.IEnumerable<Checkbox.Config> items, string htmlFieldName = null)
        {
            if (htmlFieldName == null)
            {
                htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            }
            object obj2 = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, this.HtmlHelper.ViewData).get_Model();
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>((obj2 != null) ? ((System.Collections.Generic.IEnumerable<string>)obj2.ToString().Split((char[])new char[] { ',' })) : ((System.Collections.Generic.IEnumerable<string>)new string[0]));
            string fullHtmlFieldName = this.htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            CheckboxGroup component = new CheckboxGroup();
            foreach (Checkbox.Config config in items)
            {
                Checkbox item = new Checkbox(config)
                {
                    Name = fullHtmlFieldName
                };
                if (list.get_Count() > 0)
                {
                    item.Checked = (bool)((list.Contains(item.InputValue) || list.Contains(item.TagString)) || list.Contains(item.get_ID()));
                }
                component.Items.Add(item);
            }
            return new CheckboxGroup.Builder(component);
        }

        public CheckboxGroup.Builder CheckboxGroupForEnum<T>(string htmlFieldName = "")
        {
            System.Action<AbstractComponent> action = null;
            string fullName = this.htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            if (!TypeUtils.GetTypeWithoutNullability(typeof(T)).get_IsEnum())
            {
                throw new System.Exception("CheckboxGroupForEnum helper should be used for enums only");
            }
            CheckboxGroup.Builder builder = new CheckboxGroup.Builder(CheckboxGroup.FromEnum(typeof(T), null, htmlFieldName));
            if (!TypeUtils.IsNullable(typeof(T)))
            {
                builder.ToComponent().AllowBlank = false;
            }
            if (action == null)
            {
                action = delegate(AbstractComponent cb)
                {
                    ((Checkbox)cb).Name = this.fullName;
                };
            }
            ((System.Collections.Generic.IEnumerable<AbstractComponent>)builder.ToComponent().Items).Each<AbstractComponent>((System.Action<AbstractComponent>)action);
            return builder;
        }

        public CheckboxGroup.Builder CheckboxGroupForEnum<TProperty>(Expression<Func<TModel, TProperty>> expression, string htmlFieldName = null)
        {
            System.Action<AbstractComponent> action = null;
            if (htmlFieldName == null)
            {
                htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            }
            object obj2 = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, this.HtmlHelper.ViewData).get_Model();
            string fullName = this.htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            if ((obj2 == null) || !TypeUtils.GetTypeWithoutNullability(obj2.GetType()).get_IsEnum())
            {
                throw new System.Exception("CheckboxGroupForEnum helper should be used for enums only");
            }
            CheckboxGroup.Builder builder = new CheckboxGroup.Builder(CheckboxGroup.FromEnum(obj2.GetType(), (System.Enum)obj2, htmlFieldName));
            if (!TypeUtils.IsNullable(obj2.GetType()))
            {
                builder.ToComponent().AllowBlank = false;
            }
            if (action == null)
            {
                action = delegate(AbstractComponent cb)
                {
                    ((Checkbox)cb).Name = this.fullName;
                };
            }
            ((System.Collections.Generic.IEnumerable<AbstractComponent>)builder.ToComponent().Items).Each<AbstractComponent>((System.Action<AbstractComponent>)action);
            return builder;
        }

        public ColumnBase ColumnFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return TablePanel.CreateColumn(ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, this.HtmlHelper.ViewData), this.HtmlHelper.ViewContext);
        }

        public ColumnBase ColumnFor<T, TProperty>(System.Collections.Generic.IEnumerable<T> model, Expression<Func<T, TProperty>> expression) where T : class
        {
            return TablePanel.CreateColumn(ModelMetadata.FromLambdaExpression<T, TProperty>(expression, new ViewDataDictionary<T>()), this.HtmlHelper.ViewContext);
        }

        public ColumnBase ColumnFor<T, TProperty>(T model, Expression<Func<T, TProperty>> expression) where T : class
        {
            return TablePanel.CreateColumn(ModelMetadata.FromLambdaExpression<T, TProperty>(expression, new ViewDataDictionary<T>()), this.HtmlHelper.ViewContext);
        }

        public ComboBox.Builder ComboBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<ComboBox, ComboBox.Builder, TProperty>(expression, setId, convert, format);
        }

        private TBuilder CreateWidtgetForBuilder<TControl, TBuilder, TProperty>(Expression<Func<TModel, TProperty>> expression, System.Action<TBuilder> beforeSet = null)
            where TControl : BaseControl
            where TBuilder : BaseControl.Builder<TControl, TBuilder>, new()
        {
            TBuilder local = System.Activator.CreateInstance<TBuilder>();
            TControl local2 = local.ToComponent();
            local2.ViewContext = this.HtmlHelper.ViewContext;
            local.ControlFor(ExpressionHelper.GetExpressionText(expression));
            if (beforeSet != null)
            {
                beforeSet(local);
            }
            local2.SetControlFor(ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, this.HtmlHelper.ViewData));
            return local;
        }

        public DateField.Builder DateFieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<DateField, DateField.Builder, TProperty>(expression, setId, convert, format);
        }

        public DisplayField.Builder DisplayFieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<DisplayField, DisplayField.Builder, TProperty>(expression, setId, convert, format);
        }

        public DropDownField.Builder DropDownFieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<DropDownField, DropDownField.Builder, TProperty>(expression, setId, convert, format);
        }

        public FormPanel.Builder FormPanelFor<T>(bool modelOnly = false, string htmlFieldName = "", object additionalViewData = null)
        {
            FormPanel.Builder builder = new FormPanel.Builder();
            FormPanel panel = builder.ToComponent();
            panel.ViewContext = this.HtmlHelper.ViewContext;
            panel.InitForModelOnly = modelOnly;
            panel.HtmlFieldName = htmlFieldName;
            panel.AdditionalViewData = additionalViewData;
            panel.InitByType(typeof(T), null, modelOnly, htmlFieldName, additionalViewData);
            return builder;
        }

        public FormPanel.Builder FormPanelFor(object data, bool modelOnly = false, string htmlFieldName = "", object additionalViewData = null)
        {
            FormPanel.Builder builder = new FormPanel.Builder();
            FormPanel panel = builder.ToComponent();
            panel.ViewContext = this.HtmlHelper.ViewContext;
            panel.InitForModelOnly = modelOnly;
            panel.HtmlFieldName = htmlFieldName;
            panel.AdditionalViewData = additionalViewData;
            panel.InitByObject(data, modelOnly, htmlFieldName, additionalViewData);
            return builder;
        }

        public FormPanel.Builder FormPanelFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool modelOnly = false, string htmlFieldName = null, object additionalViewData = null)
        {
            if (htmlFieldName == null)
            {
                htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            }
            return this.CreateWidtgetForBuilder<FormPanel, FormPanel.Builder, TProperty>(expression, delegate(FormPanel.Builder b)
            {
                FormPanel panel = b.ToComponent();
                panel.InitForModelOnly = this.modelOnly;
                panel.HtmlFieldName = this.htmlFieldName;
                panel.AdditionalViewData = this.additionalViewData;
            });
        }

        public FormPanel.Builder FormPanelForModel(bool modelOnly = false, string htmlFieldName = "", object additionalViewData = null)
        {
            FormPanel.Builder builder = new FormPanel.Builder();
            FormPanel panel = builder.ToComponent();
            panel.ViewContext = this.HtmlHelper.ViewContext;
            panel.InitForModelOnly = modelOnly;
            panel.HtmlFieldName = htmlFieldName;
            panel.AdditionalViewData = additionalViewData;
            ModelMetadata modelMetadata = this.HtmlHelper.ViewData.ModelMetadata;
            if (modelMetadata.get_Model() != null)
            {
                panel.InitByObject(modelMetadata.get_Model(), modelOnly, htmlFieldName, additionalViewData);
                return builder;
            }
            panel.InitByType(modelMetadata.ModelType, null, modelOnly, htmlFieldName, additionalViewData);
            return builder;
        }

        private GridPanel.Builder GridPanelFor(DataTable data, bool buildStore = true)
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            GridPanel panel = builder.ToComponent();
            if (buildStore)
            {
                panel.Store.Add((Store)this.StoreFor(data));
            }
            panel.ViewContext = this.HtmlHelper.ViewContext;
            panel.InitFromDataTable(data);
            return builder;
        }

        public GridPanel.Builder GridPanelFor<T>(bool modelOnly = false, bool buildStore = true, bool createColumns = true) where T : class
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            GridPanel panel = builder.ToComponent();
            if (buildStore)
            {
                panel.Store.Add((Store)this.StoreFor<T>(modelOnly));
            }
            panel.ViewContext = this.HtmlHelper.ViewContext;
            panel.InitForModelOnly = modelOnly;
            panel.CreateModelColumns = createColumns;
            panel.InitByType(typeof(T), modelOnly, true);
            return builder;
        }

        private GridPanel.Builder GridPanelFor(System.Collections.IEnumerable data, bool modelOnly = false, bool buildStore = true, bool createColumns = true)
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            GridPanel panel = builder.ToComponent();
            if (buildStore)
            {
                panel.Store.Add((Store)this.StoreFor(data, modelOnly));
            }
            panel.ViewContext = this.HtmlHelper.ViewContext;
            panel.InitForModelOnly = modelOnly;
            panel.CreateModelColumns = createColumns;
            panel.InitByObject(data, modelOnly);
            return builder;
        }

        public GridPanel.Builder GridPanelFor<T>(T model, bool modelOnly = false, bool buildStore = true, bool createColumns = true) where T : class
        {
            if (model is System.Collections.IEnumerable)
            {
                return this.GridPanelFor(model as System.Collections.IEnumerable, modelOnly, buildStore, createColumns);
            }
            if (model is DataTable)
            {
                return this.GridPanelFor(model as DataTable, buildStore);
            }
            return this.GridPanelFor<T>(modelOnly, buildStore, createColumns);
        }

        public GridPanel.Builder GridPanelFor<T>(string viewDataKey, bool modelOnly = false, bool buildStore = true, bool createColumns = true) where T : class
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            GridPanel panel = builder.ToComponent();
            if (buildStore)
            {
                panel.Store.Add((Store)this.StoreFor<T>(viewDataKey, modelOnly));
            }
            panel.ViewContext = this.HtmlHelper.ViewContext;
            panel.InitForModelOnly = modelOnly;
            panel.CreateModelColumns = createColumns;
            panel.InitByObject(this.HtmlHelper.ViewContext.ViewData.Eval(viewDataKey) as System.Collections.Generic.IEnumerable<T>, modelOnly);
            return builder;
        }

        public GridPanel.Builder GridPanelFor(System.Type type, bool modelOnly = false, bool buildStore = true, bool createColumns = true)
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            GridPanel panel = builder.ToComponent();
            if (buildStore)
            {
                panel.Store.Add((Store)this.StoreFor(type, modelOnly));
            }
            panel.ViewContext = this.HtmlHelper.ViewContext;
            panel.InitForModelOnly = modelOnly;
            panel.CreateModelColumns = createColumns;
            panel.InitByType(type, modelOnly, true);
            return builder;
        }

        public GridPanel.Builder GridPanelFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool modelOnly = false, bool buildStore = true, bool createColumns = true)
        {
            return this.CreateWidtgetForBuilder<GridPanel, GridPanel.Builder, TProperty>(expression, delegate (GridPanel.Builder b) {
                if (this.buildStore)
                {
                    b.ToComponent().Store.Add((Store) this.<>4__this.StoreFor<TProperty>(this.expression, this.modelOnly));
                }
                b.ToComponent().InitForModelOnly = this.modelOnly;
                b.ToComponent().CreateModelColumns = this.createColumns;
            });
        }

        public GridPanel.Builder GridPanelForModel(bool modelOnly = false, bool buildStore = true, bool createColumns = true)
        {
            GridPanel.Builder builder = new GridPanel.Builder();
            GridPanel panel = builder.ToComponent();
            if (buildStore)
            {
                panel.Store.Add((Store)this.StoreForModel(modelOnly));
            }
            panel.ViewContext = this.HtmlHelper.ViewContext;
            panel.InitForModelOnly = modelOnly;
            panel.CreateModelColumns = createColumns;
            ModelMetadata modelMetadata = this.HtmlHelper.ViewData.ModelMetadata;
            if (modelMetadata.get_Model() != null)
            {
                panel.InitByObject(modelMetadata.get_Model(), modelOnly);
                return builder;
            }
            panel.InitByType(modelMetadata.ModelType, modelOnly, true);
            return builder;
        }

        public Hidden.Builder HiddenFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<Hidden, Hidden.Builder, TProperty>(expression, setId, convert, format);
        }

        public HtmlEditor.Builder HtmlEditorFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<HtmlEditor, HtmlEditor.Builder, TProperty>(expression, setId, convert, format);
        }

        private TBuilder InitFieldForBuilder<TField, TBuilder, TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId, Func<object, object> convert = null, string format = null)
            where TField : Field
            where TBuilder : Field.Builder<TField, TBuilder>, new()
        {
            TBuilder local = System.Activator.CreateInstance<TBuilder>();
            TField local2 = local.ToComponent();
            local2.ViewContext = this.HtmlHelper.ViewContext;
            local2.IDFromControlFor = setId;
            local2.ConvertControlForValue = convert;
            local2.FormatControlForValue = format;
            local.ControlFor(ExpressionHelper.GetExpressionText(expression));
            local2.SetControlFor(ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, this.HtmlHelper.ViewData));
            return local;
        }

        public ModelField.Builder ModelField<T, TProperty>(System.Collections.Generic.IEnumerable<T> model, Expression<Func<T, TProperty>> expression) where T : class
        {
            return new ModelField.Builder(Store.CreateModelFieldFromMeta(ModelMetadata.FromLambdaExpression<T, TProperty>(expression, new ViewDataDictionary<T>()), null, null, (this.HtmlHelper.ViewContext.Controller != null) ? this.HtmlHelper.ViewContext.Controller.ControllerContext : null));
        }

        public ModelField.Builder ModelField<T, TProperty>(T model, Expression<Func<T, TProperty>> expression) where T : class
        {
            return new ModelField.Builder(Store.CreateModelFieldFromMeta(ModelMetadata.FromLambdaExpression<T, TProperty>(expression, new ViewDataDictionary<T>()), null, null, (this.HtmlHelper.ViewContext.Controller != null) ? this.HtmlHelper.ViewContext.Controller.ControllerContext : null));
        }

        public ModelField.Builder ModelFieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            return new ModelField.Builder(Store.CreateModelFieldFromMeta(ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, this.HtmlHelper.ViewData), null, null, (this.HtmlHelper.ViewContext.Controller != null) ? this.HtmlHelper.ViewContext.Controller.ControllerContext : null));
        }

        public MultiCombo.Builder MultiComboFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<MultiCombo, MultiCombo.Builder, TProperty>(expression, setId, convert, format);
        }

        public MultiSelect.Builder MultiSelectFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<MultiSelect, MultiSelect.Builder, TProperty>(expression, setId, convert, format);
        }

        public NumberField.Builder NumberFieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<NumberField, NumberField.Builder, TProperty>(expression, setId, convert, format);
        }

        public Radio.Builder RadioFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<Radio, Radio.Builder, TProperty>(expression, setId, convert, format);
        }

        public RadioGroup.Builder RadioGroupFor<TProperty>(Expression<Func<TModel, TProperty>> expression, System.Collections.Generic.IEnumerable<Radio.Config> items, string htmlFieldName = null)
        {
            if (htmlFieldName == null)
            {
                htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            }
            object obj2 = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, this.HtmlHelper.ViewData).get_Model();
            string text = (obj2 != null) ? obj2.ToString() : ((string)"");
            string fullHtmlFieldName = this.htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            RadioGroup component = new RadioGroup
            {
                GroupName = fullHtmlFieldName
            };
            foreach (Radio.Config config in items)
            {
                Radio item = new Radio(config);
                if (text.IsNotEmpty())
                {
                    item.Checked = ((text == item.InputValue) || (text == item.TagString)) ? ((bool)true) : ((bool)(text == item.get_ID()));
                }
                component.Items.Add(item);
            }
            return new RadioGroup.Builder(component);
        }

        public RadioGroup.Builder RadioGroupForEnum<T>(string htmlFieldName = "")
        {
            string fullHtmlFieldName = this.htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            if (!TypeUtils.GetTypeWithoutNullability(typeof(T)).get_IsEnum())
            {
                throw new System.Exception("RadioGroupForEnum helper should be used for enums only");
            }
            RadioGroup.Builder builder = new RadioGroup.Builder(RadioGroup.FromEnum(typeof(T), 0, fullHtmlFieldName));
            if (!TypeUtils.IsNullable(typeof(T)))
            {
                builder.ToComponent().AllowBlank = false;
            }
            return builder;
        }

        public RadioGroup.Builder RadioGroupForEnum<TProperty>(Expression<Func<TModel, TProperty>> expression, string htmlFieldName = null)
        {
            if (htmlFieldName == null)
            {
                htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            }
            object obj2 = ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, this.HtmlHelper.ViewData).get_Model();
            string fullHtmlFieldName = this.htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(htmlFieldName);
            if ((obj2 == null) || !TypeUtils.GetTypeWithoutNullability(obj2.GetType()).get_IsEnum())
            {
                throw new System.Exception("RadioGroupForEnum helper should be used for enums only");
            }
            RadioGroup.Builder builder = new RadioGroup.Builder(RadioGroup.FromEnum(obj2.GetType(), (System.Enum)obj2, fullHtmlFieldName));
            if (!TypeUtils.IsNullable(obj2.GetType()))
            {
                builder.ToComponent().AllowBlank = false;
            }
            return builder;
        }

        public SelectBox.Builder SelectBoxFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<SelectBox, SelectBox.Builder, TProperty>(expression, setId, convert, format);
        }

        public Slider.Builder SliderFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<Slider, Slider.Builder, TProperty>(expression, setId, convert, format);
        }

        public SpinnerField.Builder SpinnerFieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<SpinnerField, SpinnerField.Builder, TProperty>(expression, setId, convert, format);
        }

        public Store.Builder StoreFor<T>(bool modelOnly = false) where T : class
        {
            Store.Builder builder = new Store.Builder();
            builder.ToComponent().ViewContext = this.HtmlHelper.ViewContext;
            builder.ToComponent().InitForModelOnly = modelOnly;
            builder.ToComponent().InitByType(typeof(T), true);
            return builder;
        }

        private Store.Builder StoreFor(DataTable data)
        {
            Store.Builder builder = new Store.Builder();
            builder.ToComponent().ViewContext = this.HtmlHelper.ViewContext;
            builder.ToComponent().InitByObject(data);
            return builder;
        }

        private Store.Builder StoreFor(System.Collections.IEnumerable data, bool modelOnly = false)
        {
            Store.Builder builder = new Store.Builder();
            builder.ToComponent().ViewContext = this.HtmlHelper.ViewContext;
            builder.ToComponent().InitForModelOnly = modelOnly;
            builder.ToComponent().InitByObject(data);
            return builder;
        }

        public Store.Builder StoreFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool modelOnly = false)
        {
            return this.CreateWidtgetForBuilder<Store, Store.Builder, TProperty>(expression, delegate(Store.Builder b)
            {
                b.ToComponent().InitForModelOnly = this.modelOnly;
            });
        }

        public Store.Builder StoreFor(System.Type type, bool modelOnly = false)
        {
            Store.Builder builder = new Store.Builder();
            builder.ToComponent().ViewContext = this.HtmlHelper.ViewContext;
            builder.ToComponent().InitForModelOnly = modelOnly;
            builder.ToComponent().InitByType(type, true);
            return builder;
        }

        public Store.Builder StoreFor<T>(T model, bool modelOnly = false) where T : class
        {
            if (model is System.Collections.IEnumerable)
            {
                return this.StoreFor(model as System.Collections.IEnumerable, modelOnly);
            }
            if (model is DataTable)
            {
                return this.StoreFor(model as DataTable);
            }
            return this.StoreFor<T>(modelOnly);
        }

        public Store.Builder StoreFor<T>(string viewDataKey, bool modelOnly = false) where T : class
        {
            Store.Builder builder = new Store.Builder();
            builder.ToComponent().ViewContext = this.HtmlHelper.ViewContext;
            builder.ToComponent().InitForModelOnly = modelOnly;
            builder.ToComponent().InitByObject(this.HtmlHelper.ViewContext.ViewData.Eval(viewDataKey) as System.Collections.Generic.IEnumerable<T>);
            return builder;
        }

        public Store.Builder StoreForModel(bool modelOnly = false)
        {
            Store.Builder builder = new Store.Builder();
            Store store = builder.ToComponent();
            store.ViewContext = this.HtmlHelper.ViewContext;
            store.InitForModelOnly = modelOnly;
            ModelMetadata modelMetadata = this.HtmlHelper.ViewData.ModelMetadata;
            if (modelMetadata.get_Model() != null)
            {
                store.InitByObject(modelMetadata.get_Model());
                return builder;
            }
            store.InitByType(modelMetadata.ModelType, true);
            return builder;
        }

        public TextArea.Builder TextAreaFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<TextArea, TextArea.Builder, TProperty>(expression, setId, convert, format);
        }

        public TextField.Builder TextFieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<TextField, TextField.Builder, TProperty>(expression, setId, convert, format);
        }

        public TimeField.Builder TimeFieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<TimeField, TimeField.Builder, TProperty>(expression, setId, convert, format);
        }

        public TriggerField.Builder TriggerFieldFor<TProperty>(Expression<Func<TModel, TProperty>> expression, bool setId = true, Func<object, object> convert = null, string format = null)
        {
            return this.InitFieldForBuilder<TriggerField, TriggerField.Builder, TProperty>(expression, setId, convert, format);
        }

        public HtmlHelper<TModel> HtmlHelper
        {
            get
            {
                return this.htmlHelper;
            }
            set
            {
                this.htmlHelper = value;
                base.HtmlHelper = value;
            }
        }
    }
}