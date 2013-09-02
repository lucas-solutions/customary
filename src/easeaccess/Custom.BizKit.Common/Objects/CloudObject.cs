using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Objects
{
    using Models;

    public class CloudObject : ServiceObject
    {
        private List<ApplicationObject> _apps;
        private List<DropboxAccount> _dropboxAccounts;
        private List<DropboxFolder> _dropboxFolders;
        private List<DropboxFile> _dropboxFiles;
        private List<EvernoteAccount> _evernoteAccounts;
        private List<EvernoteNotebook> _evernoteNotebooks;
        private List<EvernoteNote> _evernoteNotes;

        public List<ApplicationObject> Apps
        {
            get { return _apps ?? (_apps = new List<ApplicationObject>()); }
            set { _apps = value; }
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
    }
}
