using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Custom.Results
{
    using Custom.Extensions;

    public class StoreResult : ActionResult
    {
        private bool success;

        public StoreResult()
        {
            this.success = true;
        }

        public StoreResult(object data)
        {
            this.success = true;
            this.Data = data;
        }

        public StoreResult(object data, int totalCount)
            : this(data)
        {
            this.Total = totalCount;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var data = new StoreResponseData(false);
            data.Data = this.Data.ToJson();
            data.Total = this.Total;
            data.Success = this.Success;
            data.Message = this.Message;
            data.Return();
        }

        public object Data { get; set; }

        public bool IsTree { get; set; }

        public string Message { get; set; }

        public bool Success
        {
            get
            {
                return this.success;
            }
            set
            {
                this.success = value;
            }
        }

        public int Total { get; set; }
    }
}
