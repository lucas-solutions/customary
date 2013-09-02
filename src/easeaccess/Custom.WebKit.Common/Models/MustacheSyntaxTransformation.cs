using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Presentation
{
    using Dictionary = Dictionary<string, object>;

    public class MustacheSyntaxTransformation : TemplateSyntaxTransformation
    {
        public static implicit operator MustacheSyntaxTransformation(Dictionary dictionary)
        {
            return new MustacheSyntaxTransformation(dictionary);
        }

        public MustacheSyntaxTransformation()
        {
        }

        public MustacheSyntaxTransformation(Dictionary dictionary)
            : base(dictionary)
        {
        }

        public override object GetDefaultValue(string key)
        {
            return "{{" + key + "}}";
        }
    }
}
