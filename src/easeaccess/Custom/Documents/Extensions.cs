using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Documents
{
    using Raven.Json.Linq;

    public static class Extensions
    {
        public static int IndexOf(this RavenJArray array, RavenJToken item, Comparison<RavenJToken> compare)
        {
            var index = 0;
            for (; index < array.Length; index++)
            {
                if (0 == compare(item, array[index]))
                {
                }
            }
            return index < array.Length ? index : -1;
        }

        /*
    /// <summary>
    /// Make Records have properties
    /// </summary>
    public class Record_ByField : AbstractIndexCreationTask<Model>
    {
        public Record_ByField()
        {
            Map = records => from r in records
                             select new
                             {
                                 _ = r.Fields.Select(field => CreateField(field.Name, field.Value, false, true))
                             };
        }
         */
    }
}
