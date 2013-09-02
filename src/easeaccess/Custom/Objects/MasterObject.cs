using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Web;

namespace Custom.Objects
{
    using Newtonsoft.Json;
    using Raven.Client;
    using Raven.Client.Embedded;

    public class MasterObject : IDisposable
    {
        public static string ConnectionStringName = "RavenDB";
        private static IDocumentStore _store;
        private static readonly object _storeLock = new object();

        public static IDocumentStore Store
        {
            get
            {
                var store = _store;

                // return without locking if already exist
                if (store != null)
                    return store;

                // lock and check again
                lock (_storeLock)
                {
                    if (_store != null)
                        store = _store;
                    else
                    {
                        // create new instance if doesn't exist
                        store = new EmbeddableDocumentStore()
                        {
                            ConnectionStringName = ConnectionStringName
                        };

                        store.Initialize()
                            .RegisterApplicationIdConvention()
                            .RegisterEnumIdConvention()
                            .RegisterFileIdConvention()
                            .RegisterFormIdConvention()
                            .RegisterGridIdConvention()
                            .RegisterJobIdConvention()
                            .RegisterModelIdConvention()
                            .RegisterNoteIdConvention()
                            .RegisterOperationIdConvention()
                            .RegisterPageIdConvention()
                            .RegisterReportIdConvention()
                            .RegisterScreenIdConvention()
                            .RegisterTableIdConvention()
                            .RegisterTaskIdConvention();

                        _store = store;
                    }
                }

                return store;
            }
        }

        private List<ApplicationObject> _applications;
        private List<AssociationObject> _associations;
        private List<DropboxAccount> _dropboxAccounts;
        private List<DropboxFolder> _dropboxFolders;
        private List<DropboxFile> _dropboxFiles;
        private List<EvernoteAccount> _evernoteAccounts;
        private List<EvernoteNotebook> _evernoteNotebooks;
        private List<EvernoteNote> _evernoteNotes;
        private List<JobObject> _jobs;
        private List<ModelObject> _models;
        private List<PageObject> _pages;
        private List<RelationshipObject> _relationships;
        private List<ReportObject> _reports;
        private List<ScreenObject> _screens;
        private List<TableObject> _tables;
        private List<TaskObject> _tasks;
        private IDocumentSession _session;
        private readonly object _sessionLock = new object();

        public List<ApplicationObject> Applications
        {
            get { return _applications ?? (_applications = new List<ApplicationObject>()); }
            set { _applications = value; }
        }

        public List<AssociationObject> Associations
        {
            get { return _associations ?? (_associations = new List<AssociationObject>()); }
            set { _associations = value; }
        }

        public List<JobObject> Jobs
        {
            get { return _jobs ?? (_jobs = new List<JobObject>()); }
            set { _jobs = value; }
        }

        public List<DropboxAccount> DropboxAccounts
        {
            get { return _dropboxAccounts ?? (_dropboxAccounts = new List<DropboxAccount>()); }
            set { _dropboxAccounts = value; }
        }

        public List<DropboxFolder> DropboxFolders
        {
            get { return _dropboxFolders ?? (_dropboxFolders = new List<DropboxFolder>()); }
            set { _dropboxFolders = value; }
        }

        public List<DropboxFile> DropboxFiles
        {
            get { return _dropboxFiles ?? (_dropboxFiles = new List<DropboxFile>()); }
            set { _dropboxFiles = value; }
        }

        public List<EvernoteAccount> EvernoteAccounts
        {
            get { return _evernoteAccounts ?? (_evernoteAccounts = new List<EvernoteAccount>()); }
            set { _evernoteAccounts = value; }
        }

        public List<EvernoteNotebook> EvernoteNotebooks
        {
            get { return _evernoteNotebooks ?? (_evernoteNotebooks = new List<EvernoteNotebook>()); }
            set { _evernoteNotebooks = value; }
        }

        public List<EvernoteNote> EvernoteNotes
        {
            get { return _evernoteNotes ?? (_evernoteNotes = new List<EvernoteNote>()); }
            set { _evernoteNotes = value; }
        }

        public List<ModelObject> Models
        {
            get { return _models ?? (_models = new List<ModelObject>()); }
            set { _models = value; }
        }

        public List<PageObject> Pages
        {
            get { return _pages ?? (_pages = new List<PageObject>()); }
            set { _pages = value; }
        }

        public List<RelationshipObject> Relationships
        {
            get { return _relationships ?? (_relationships = new List<RelationshipObject>()); }
            set { _relationships = value; }
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

        public List<TableObject> Tables
        {
            get { return _tables ?? (_tables = new List<TableObject>()); }
            set { _tables = value; }
        }

        public List<TaskObject> Tasks
        {
            get { return _tasks ?? (_tasks = new List<TaskObject>()); }
            set { _tasks = value; }
        }

        public IDocumentSession Session
        {
            get
            {
                var session = _session;

                if (session == null)
                {
                    lock (_sessionLock)
                    {
                        if (null == (session = _session))
                        {
                            _session = session = Store.OpenSession();
                        }
                    }
                }

                return session;
            }
        }

        public void Dispose()
        {
            var session = _session;
            if (session != null)
            {
                _session = null;
                session.Dispose();
            }
        }
    }
}