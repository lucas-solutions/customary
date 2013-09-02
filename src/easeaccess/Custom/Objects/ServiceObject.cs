using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class ServiceObject : ComponentObject
    {
        private List<EnumObject> _enums;
        private List<FileObject> _files;
        private List<FormObject> _forms;
        private List<GridObject> _grids;
        private List<LinkObject> _links;
        private List<ModelObject> _models;
        private List<NoteObject> _notes;
        private List<OperationObject> _operations;
        private List<PageObject> _pages;
        private List<ReportObject> _reports;
        private List<ScreenObject> _screens;

        public List<EnumObject> Enums
        {
            get { return _enums ?? (_enums = new List<EnumObject>()); }
            set { _enums = value; }
        }

        public List<FileObject> Files
        {
            get { return _files ?? (_files = new List<FileObject>()); }
            set { _files = value; }
        }

        public List<FormObject> Forms
        {
            get { return _forms ?? (_forms = new List<FormObject>()); }
            set { _forms = value; }
        }

        public List<GridObject> Grids
        {
            get { return _grids ?? (_grids = new List<GridObject>()); }
            set { _grids = value; }
        }

        public List<LinkObject> Links
        {
            get { return _links ?? (_links = new List<LinkObject>()); }
            set { _links = value; }
        }

        public List<ModelObject> Models
        {
            get { return _models ?? (_models = new List<ModelObject>()); }
            set { _models = value; }
        }

        public List<NoteObject> Notes
        {
            get { return _notes ?? (_notes = new List<NoteObject>()); }
            set { _notes = value; }
        }

        public List<OperationObject> Operations
        {
            get { return _operations ?? (_operations = new List<OperationObject>()); }
            set { _operations = value; }
        }

        public List<PageObject> Pages
        {
            get { return _pages ?? (_pages = new List<PageObject>()); }
            set { _pages = value; }
        }

        public List<ReportObject> Reports
        {
            get { return _reports ?? (_reports = new List<ReportObject>()); }
            set { _reports = value; }
        }

        public List<ScreenObject> Screens
        {
            get { return _screens ?? (_screens = new List<ScreenObject>()); }
            set { _screens = value; }
        }
    }
}