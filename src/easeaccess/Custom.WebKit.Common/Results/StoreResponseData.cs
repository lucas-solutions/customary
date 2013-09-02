using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Results
{
    using Custom.Extensions;
    using Custom.Utils;

    public class StoreResponseData
    {
        private int count;
        private bool isTree;

        public StoreResponseData()
        {
            Success = true;
            this.count = -1;
        }

        public StoreResponseData(bool isTree)
        {
            Success = true;
            this.count = -1;
            this.isTree = isTree;
        }

        public virtual void Return()
        {
            CompressionUtils.GZipAndSend(this);
        }

        public string Data { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

        public int Total { get; set; }

        public override string ToString()
        {
            if ((this.Data.IsEmpty() && this.Success) && this.Message.IsEmpty())
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            bool flag = false;
            builder.Append("{");
            if (!this.Success)
            {
                builder.Append("success:false");
                flag = true;
            }
            if (!string.IsNullOrEmpty(this.Message))
            {
                if (flag)
                {
                    builder.Append(",");
                }
                builder.AppendFormat("message:{0}", this.Message.ToJson());
                flag = true;
            }
            if (this.Data.IsNotEmpty() && this.Success)
            {
                if (flag)
                {
                    builder.Append(",");
                }
                if (this.Total >= 0)
                {
                    builder.AppendFormat("{2}:{0}, total: {1}", this.Data, (int)this.Total, this.isTree ? "children" : "data");
                }
                else
                {
                    builder.AppendFormat("{1}:{0}", this.Data, this.isTree ? "children" : "data");
                }
            }
            builder.Append("}");
            return builder.ToString();
        }
    }
}
