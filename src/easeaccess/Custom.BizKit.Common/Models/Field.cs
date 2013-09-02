using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class Field
    {
        private List<Text> _title;
        private List<Text> _summary;
        private DateTime? _createdOn;
        private string _createdBy;

        public string Name
        {
            get;
            set;
        }

        public List<Text> Title
        {
            get { return _title ?? (_title = new List<Text>()); }
            set { _title = value; }
        }

        public List<Text> Summary
        {
            get { return _summary ?? (_summary = new List<Text>()); }
            set { _summary = value; }
        }

        public string Type
        {
            get;
            set;
        }

        public Boolean Multiple
        {
            get;
            set;
        }

        public Boolean Required
        {
            get;
            set;
        }

        public Boolean Computed
        {
            get;
            set;
        }

        public int? Max
        {
            get;
            set;
        }

        public int? Min
        {
            get;
            set;
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