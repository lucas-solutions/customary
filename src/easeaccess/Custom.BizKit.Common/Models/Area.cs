using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class Area
    {
        private List<Text> _title;
        private List<Text> _summary;
        private List<Area> _areas;
        private List<File> _files;
        private List<List> _lists;
        private List<Grid> _grids;
        private List<Note> _notes;
        private DateTime? _createdOn;
        private string _createdBy;

        public string Name
        {
            get;
            set;
        }

        public List<Text> Summary
        {
            get { return _summary ?? (_summary = new List<Text>()); }
            set { _summary = value; }
        }

        public List<Text> Title
        {
            get { return _title ?? (_title = new List<Text>()); }
            set { _title = value; }
        }

        #region - area hierarchy generation -

        // Areas can be generated following a model pattern and stored in a table.
        // There most be an Id field and a Parent field to form the hierarchy.

        public string Model
        {
            get;
            set;
        }

        public string Table
        {
            get;
            set;
        }

        #endregion - area hierarchy generation -
        
        public List<Area> Areas
        {
            get { return _areas ?? (_areas = new List<Area>()); }
            set { _areas = value; }
        }

        public List<File> Files
        {
            get { return _files ?? (_files = new List<File>()); }
            set { _files = value; }
        }

        public List<Grid> Grids
        {
            get { return _grids ?? (_grids = new List<Grid>()); }
            set { _grids = value; }
        }

        public List<List> Lists
        {
            get { return _lists ?? (_lists = new List<List>()); }
            set { _lists = value; }
        }

        public List<Note> Notes
        {
            get { return _notes ?? (_notes = new List<Note>()); }
            set { _notes = value; }
        }

        public DateTime CreatedOn
        {
            get { return (DateTime)(_createdOn ?? (_createdOn = DateTime.UtcNow)); }
            set { _createdOn = value; }
        }

        public string CreatedBy
        {
            get { return _createdBy ?? (_createdBy = "system"); }
            set { _createdBy = value; }
        }

        public DateTime? ModifiedOn
        {
            get;
            set;
        }

        public string ModifiedBy
        {
            get;
            set;
        }
    }
}