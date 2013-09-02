using System;
using System.Collections.Generic;

namespace Custom.Utils
{
    /// <summary>
    /// ある処理を成功するまで指定した回数だけ繰返し再実行します。
    /// </summary>
    public class Retry
    {
        /// <summary>
        /// 処理が失敗で完了したときに発生するイベントです。
        /// </summary>
        public EventHandler<EventArgs<List<Exception>>> ErrorRaised;

        /// <summary>
        /// 再実行する最大回数を取得または設定します。
        /// </summary>
        public int MaxCount { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Retry()
        {
            MaxCount = 10;
        }

        /// <summary>
        /// 処理を実行します。
        /// </summary>
        /// <param name="action"></param>
        public void Execute(Action action)
        {
            Int32 count = 0;
            List<Exception> l = null;

            while (count < this.MaxCount)
            {
                try
                {
                    action();
                    return;
                }
                catch(Exception ex)
                {
                    if (l == null)
                    {
                        l = new List<Exception>();
                    }
                    l.Add(ex);
                }
                count += 1;
            }
            if (l != null && l.Count > 0)
            {
                this.OnErrorRaised(l);
            }
        }
        /// <summary>
        /// ある処理を成功するまで指定した回数だけ繰返し再実行します。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="inMaxRetryCount"></param>
        /// <param name="inErrorRaisedHandler"></param>
        public static void Execute(Action action, Int32 inMaxRetryCount, EventHandler<EventArgs<List<Exception>>> inErrorRaisedHandler)
        {
            Int32 count = 0;
            List<Exception> l = null;

            while (count < inMaxRetryCount)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception ex)
                {
                    if (l == null)
                    {
                        l = new List<Exception>();
                    }
                    l.Add(ex);
                }
                count += 1;
            }
            if (l != null && l.Count > 0 && inErrorRaisedHandler != null)
            {
                inErrorRaisedHandler(null, new EventArgs<List<Exception>>(l));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inExceptions"></param>
        protected void OnErrorRaised(List<Exception> inExceptions)
        {
            var eh = this.ErrorRaised;
            if (eh != null)
            {
                eh(this, new EventArgs<List<Exception>>(inExceptions));
            }
        }
    }
}
