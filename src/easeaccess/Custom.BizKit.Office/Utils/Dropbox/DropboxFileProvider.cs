using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Utils.Dropbox
{
    public class DropboxFileProvider
    {
        public DropboxFileProvider()
        {
            var cl = new DropboxClient("consumerKey", "consumerSecret", "accessToken", "accessTokenSecret");
            //Get your account info 
            var ai = cl.GetAccountInfo();
            //You can get meta data of file     
            var cm1 = new GetMetadataCommand();
            cm1.Path = "/MyFile.txt";
            var rr = cl.GetMetadata(cm1);
            //Upload new file to dropbox 
            var cm2 = new UploadFileCommand();
            //cm2.FilePath = "C:\\YourFile.txt";
            cm2.FileName = "FileNameOnDropbox.txt";
            cm2.FolderPath = "/";
            cl.UploadFile(cm2); 
        }
    }
}
