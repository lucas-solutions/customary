using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Objects
{
    public class ServiceObject : MasterdataObject
    {
        private List<AssociationObject> _associations;
        private List<FileObject> _files;
        private List<ListObject> _lists;
        private List<ModelObject> _models;
        private List<NoteObject> _notes;
        private List<UnitObject> _units;

        public List<AssociationObject> Associations
        {
            get { return _associations ?? (_associations = new List<AssociationObject>()); }
            set { _associations = value; }
        }

        public List<FileObject> Files
        {
            get { return _files ?? (_files = new List<FileObject>()); }
            set { _files = value; }
        }

        public List<ListObject> Lists
        {
            get { return _lists ?? (_lists = new List<ListObject>()); }
            set { _lists = value; }
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

        public List<UnitObject> Units
        {
            get { return _units ?? (_units = new List<UnitObject>()); }
            set { _units = value; }
        }
    }
}
