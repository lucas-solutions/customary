using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;

namespace Custom.Utils.Evernote
{   
    using Custom.Utils.Evernote.EDAM.Type;

    public class EvernoteCache
    {
        private static EvernoteCache _theViewModel;
        public static EvernoteCache TheViewModel
        {
            get
            {
                if(_theViewModel == null)
                {
                    _theViewModel = new EvernoteCache();
                }
                return _theViewModel;
            }
        }

        public ObservableCollection<Note> Notes { get; private set; }
        public ObservableCollection<Notebook> Notebooks { get; private set; }

        public EvernoteCache()
        {
            Notes = new ObservableCollection<Note>();
            Notebooks = new ObservableCollection<Notebook>();
        }

        private Notebook _defaultNotebook;
        public Notebook DefaultNotebook
        {
            get { return _defaultNotebook; }
            set
            {
                if (_defaultNotebook == value) return;
                _defaultNotebook = value;
            }
        }

        private bool _versionOK;
        public bool VersionOK
        {
            get { return _versionOK; }
            set
            {
                if (_versionOK == value) return;
                _versionOK = value;
            }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                if (_username == value) return;
                _username = value;
            }
        }

        private string _authToken;
        public string AuthToken
        {
            get { return _authToken; }
            set
            {
                if (_authToken == value) return;
                _authToken = value;
            }
        }
    }
}
