using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    [Metadata.Enum("64800dd0-0d1b-4ffb-ae0c-0d66b0a9f3af")]
    public sealed class Culture : Enum<Culture, string>
    {
        static readonly Culture[] _members = GetMembers();

        private Culture(string name)
            : base(name)
        {

        }

        public string Code
        {
            get;
            set;
        }

        public Text Text
        {
            get;
            set;
        }

        protected override Culture[] Members
        {
            get { return _members; }
        }
    }
}