using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Transforms
{
    using Custom.Models;

    public static class AreaTransforms
    {
        public static object ToPlainObject(this Area area)
        {
            return new
            {
                Name = area.Name,
                Title = area.Title,
                Summary = area.Summary,
                CreatedOn = area.CreatedOn,
                CreatedBy = area.CreatedBy,
                ModifiedOn = area.ModifiedOn,
                ModifiedBy = area.ModifiedBy
            };
        }

        public static object ToTreeNode(this Area area)
        {
            return new
            {
            };
        }
    }
}
