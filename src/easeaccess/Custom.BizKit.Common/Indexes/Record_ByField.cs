using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Indexes
{
    using Custom.Objects;
    using Raven.Client.Indexes;
    /*
    /// <summary>
    /// Make Records have properties
    /// </summary>
    public class Record_ByField : AbstractIndexCreationTask<AreaObject>
    {
        public Record_ByField()
        {
            Map = records => from r in records
                             select new
                             {
                                 _ = r.Fields.Select(field => CreateField(field.Name, field.Value, false, true))
                             };
        }
    }
     **/
}
