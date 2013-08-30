using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Navigation
{
    public enum AcceptTypes : ulong
    {
        Any = 0,

        Text = 0x01,
        Xml = 0x02,
        Html = 0x04,
        JavaScript = 0x08,
        Json = 0x10,
        Css = 0x20,
        
        Rss = 0x40,
        Pdf = 0x80,

        Gif = 0x0100,
        Jpeg = 0x0200,
        Png = 0x0400,
        Svg = 0x0800,
        Tiff = 0x1000,
        Icon = 0x2000,

        Audio = 0x010000,
        L24 = 0x020000,
        Mp4 = 0x040000,
        Mp3 = 0x080000,
        Ogg = 0x100000,
        Vorbis = 0x200000,
        RealAudio = 0x400000,
        Wav = 0x800000,
        WebM = 0x800000,

        Mpeg = 0x01000000,
        QuickTime = 0x02000000,
        Matroska = 0x04000000,
        Wmv = 0x08000000,
        Flv = 0x10000000,

        Binary = 0x0100000000,

        
        PostScript = 0x0200000000,
        Resource = 0x0400000000,
        Soap = 0x0800000000,
        Font = 0x1000000000,
        Dtd = 0x2000000000,
        Xop = 0x4000000000,
        Zip = 0x8000000000,
        Gzip = 0x010000000000,

        Email = 0x020000000000,
        Webform = 0x040000000000,
        Signed = 0x080000000000,
        Encrypted = 0x100000000000,
        Command = 0x200000000000,
        Csv = 0x400000000000,
        vCard = 0x800000000000
    }
}