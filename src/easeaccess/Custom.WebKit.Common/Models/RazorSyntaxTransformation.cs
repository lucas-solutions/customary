using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Presentation
{
    using Dictionary = Dictionary<string, object>;

    public class RazorSyntaxTransformation : TemplateSyntaxTransformation
    {
        public static implicit operator RazorSyntaxTransformation(Dictionary dictionary)
        {
            return new RazorSyntaxTransformation(dictionary);
        }

        public RazorSyntaxTransformation()
        {
        }

        public RazorSyntaxTransformation(Dictionary dictionary)
            : base(dictionary)
        {
        }

        public override object GetDefaultValue(string key)
        {
            return "@Model." + key;
        }
    }
}
