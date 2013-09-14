using System.ComponentModel;

namespace Custom.Diagnostics
{
    [DefaultValue(LogCategories.Info)]
    public enum LogCategories
    {
        Critical,

        Debug,

        Error,

        FailureAudit,

        Fatal,

        Info,

        Resume,

        Start,

        Stop,

        SuccessAudit,

        Suspend,

        Transfer,

        Verbose,

        Warning
    }
}