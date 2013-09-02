using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Networking.Connectivity;
using Windows.Security.Cryptography.Certificates;
using Windows.Security.Cryptography.Core;
using Windows.Storage.Streams;
using System.Runtime.InteropServices.WindowsRuntime;
using HigLabo.Net.Internal;

namespace HigLabo.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SocketClient
    {
        private StreamSocket _Socket = null;
        /// <summary>
        /// 
        /// </summary>
        protected StreamSocket Socket
        {
            get { return _Socket; }
            set { _Socket = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected DataReader DataReader { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        protected DataWriter DataWriter { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket"></param>
        public SocketClient(StreamSocket socket)
        {
            this.Socket = socket;
        }
        /// 接続先のサーバーと通信を行うためのSocketオブジェクトを取得します。
        /// <summary>
        /// Get Socket object to communicate to server.
        /// 接続先のサーバーと通信を行うためのSocketオブジェクトを取得します。
        /// </summary>
        /// <returns></returns>
        protected void SetSocket()
        {
            StreamSocket tc = null;
            Task t = null;

            try
            {
                tc = new StreamSocket();
                if (this.Ssl == true)
                {
                    t = tc.ConnectAsync(new HostName(this.ServerName), this.Port.ToString(), SocketProtectionLevel.Ssl).AsTask();
                }
                else
                {
                    t = tc.ConnectAsync(new HostName(this.ServerName), this.Port.ToString(), SocketProtectionLevel.PlainSocket).AsTask();
                }
                this.ExecuteAsyncTask(t);
                this.Socket = tc;
            }
            finally
            {
                if (this.Socket == null &&
                    tc != null)
                {
                    tc.Dispose();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public void SetProperty(SocketClient client)
        {
            var cl = client;
            this.ServerName = cl.ServerName;
            this.Port = cl.Port;
            this.UserName = cl.UserName;
            this.Password = cl.Password;
            this.ResponseEncoding = cl.ResponseEncoding;
            this.Ssl = cl.Ssl;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public Boolean Connect(StreamSocket socket)
        {
            this.Socket = socket;
            return this.Connect();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean Connect()
        {
            if (this.Socket == null)
            {
                this.SetSocket();
            }
            if (this.Socket == null)
            {
                this.DataReader = null;
                this.DataWriter = null;
                return false;
            }
            else
            {
                this.DataReader = new DataReader(this.Socket.InputStream);
                this.DataWriter = new DataWriter(this.Socket.OutputStream);
                return true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        public void Send(String command)
        {
            this.Send(Encoding.UTF8.GetBytes(command + SocketClient.NewLine));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        public void Send(Byte[] bytes)
        {
            this.Send(new MemoryStream(bytes));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        public void Send(Stream stream)
        {
            DataSendContext cx = null;
            Byte[] bb = null;

            if (this.Socket == null)
            {
                throw new SocketClientException("Connection is closed");
            }
            try
            {
                cx = new DataSendContext(stream, this.RequestEncoding);
                while (true)
                {
                    cx.FillBuffer();
                    bb = cx.GetByteArray();

                    var w = this.DataWriter;
                    for (int i = 0; i < cx.SendBufferSize; i++)
                    {
                        w.WriteByte(bb[i]);
                    }
                    this.ExecuteAsyncTask(w.StoreAsync().AsTask());

                    if (cx.DataRemained == false) { break; }
                }
            }
            catch (Exception ex)
            {
                throw new SocketClientException(ex);
            }
            finally
            {
                if (cx != null)
                {
                    cx.Dispose();
                }
            }
            //Throw exception that occor other thread.
            if (cx.Exception != null)
            {
                throw cx.Exception;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String GetResponseText()
        {
            var bb = this.GetResponseBytes();
            return this.ResponseEncoding.GetString(bb, 0, bb.Length);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual Byte[] GetResponseBytes()
        {
            MemoryStream ms = new MemoryStream();
            this.GetResponseStream(ms);
            return ms.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        public void GetResponseStream(Stream stream)
        {
            this.GetResponseStream(new DataReceiveContext(stream, this.ResponseEncoding));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected void GetResponseStream(DataReceiveContext context)
        {
            Byte[] bb = null;
            Int32 index = 0;

            if (this.Socket == null)
            {
                throw new SocketClientException("Connection is closed");
            }
            using (var cx = context)
            {
                var r = this.DataReader;
                r.InputStreamOptions = InputStreamOptions.Partial;
                while (true)
                {
                    this.ExecuteAsyncTask(r.LoadAsync(1024).AsTask());

                    if (r.UnconsumedBufferLength == 0) { break; }

                    bb = cx.GetByteArray();
                    index = 0;
                    while (r.UnconsumedBufferLength > 0)
                    {
                        bb[index] = r.ReadByte();
                        index = index + 1;
                    }
                    if (cx.ReadBuffer(index) == false) { break; }
                }
                if (cx.Exception != null)
                {
                    throw cx.Exception;
                }
                if (cx.Timeout == true)
                {
                    throw new SocketClientException("Response timeout");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected Byte[] GetResponseBytes(DataReceiveContext context)
        {
            this.GetResponseStream(context);
            return context.GetData();
        }
        private void ExecuteAsyncTask(Task task)
        {
            var t = task;
            t.ConfigureAwait(false);
            t.Wait();
        }
        /// 非同期でPOP3メールサーバーへコマンドを送信します。受信したレスポンスの文字列はcallbackFunctionの引数として取得できます。
        /// <summary>
        /// Send a command with asynchronous and get response text by first parameter of callbackFunction.
        /// 非同期でPOP3メールサーバーへコマンドを送信します。受信したレスポンスの文字列はcallbackFunctionの引数として取得できます。
        /// </summary>
        /// <param name="command"></param>
        /// <param name="context"></param>
        /// <param name="callbackFunction"></param>
        public void BeginSend(String command, DataReceiveContext context, Action<String> callbackFunction)
        {
            Task task = Task.Factory.StartNew(() =>
            {
                this.Send(command);
                var bb = this.GetResponseBytes(context);
                String text = this.ResponseEncoding.GetString(bb);
                callbackFunction(text);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        protected void DisposeSocket()
        {
            if (this.Socket != null)
            {
                ((IDisposable)this.Socket).Dispose();
                this.Socket = null;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual void Close()
        {
            if (this.Socket != null)
            {
                this.Socket.Dispose();
            }
            if (this.DataReader != null)
            {
                this.DataReader.Dispose();
            }
            if (this.DataWriter != null)
            {
                this.DataWriter.Dispose();
            }
            this.Socket = null;
            this.DataReader = null;
            this.DataWriter = null;
        }

    }
}
