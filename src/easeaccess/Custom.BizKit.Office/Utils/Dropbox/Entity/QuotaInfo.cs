using System;

namespace Custom.Utils.Dropbox
{
    using Custom.Extensions;
    using Custom.Utils;

    /// <summary>
    /// 
    /// </summary>
    public class QuotaInfo : ResponseObject
    {
        /// <summary>
        /// 
        /// </summary>
        public long Shared { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Quota { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Normal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonText"></param>
        public QuotaInfo(String jsonText)
        {
            this.SetProperty(jsonText);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jsonText"></param>
        public override void SetProperty(String jsonText)
        {
            var d = this.SetData(jsonText);
            this.Shared = d.ToInt64("shared") ?? this.Shared;
            this.Quota = d.ToInt64("quota") ?? this.Quota;
            this.Normal = d.ToInt64("normal") ?? this.Normal;
        }
    }
}
