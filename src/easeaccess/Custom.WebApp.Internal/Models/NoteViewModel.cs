using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class NoteViewModel
    {
        public ICollection<Area> Areas { get; set; }

        public Note Note { get; set; }
    }
}