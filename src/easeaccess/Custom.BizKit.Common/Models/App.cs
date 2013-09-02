using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    using Custom.Areas.Security.Models;

    public class App : Area
    {
        public string Id { get; set; }

        private ICollection<Member> _member;

        public ICollection<Member> Members
        {
            get { return _member ?? (_member = Utils.CollectionHelper.CreateCollection<Member>()); }
            set { _member = value; }
        }
    }
}
