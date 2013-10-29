using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{
    [Data.Metadata.Value("3aca3d97-de4d-446d-8ad4-e18d7312f658")]
    public sealed class Email : Value<string>
    {
        public static implicit operator string(Email email)
        {
            return string.Empty;
        }
    }
}
