using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    using Custom.Diagnostics;
    using Custom.Documents;

    public static class Global
    {
        private static readonly object _lock = new object();
        private static SimpleInjector.Container _container;
        private static ILogger _logger;
        private static Documents.Business _business;
        private static Documents.Globalization _globalization;
        private static Documents.Masterdata _masterdata;
        private static Documents.Metadata _metadata;
        private static Documents.Navigation _navigation;

        public static SimpleInjector.Container Container
        {
            get
            {
                var container = _container;

                if (container == null)
                {
                    lock (_lock)
                    {
                        container = _container ?? (_container = new SimpleInjector.Container());
                    }
                }

                return container;
            }
        }

        public static ILogger Logger
        {
            get
            {
                var logger = _logger;

                if (logger == null)
                {
                    lock (_lock)
                    {
                        logger = _logger ?? (_logger = new LogglyLogger("1205e89a-b51c-467f-a6c4-843f1e2b8827"));
                    }
                }

                return logger;
            }
        }

        public static Business Business
        {
            get
            {
                var business = _business;

                if (business == null)
                {
                    lock (_lock)
                    {
                        business = _business ?? (_business = new Business());
                    }
                }

                return business;
            }
        }

        public static Documents.Globalization Globalization
        {
            get
            {
                var globalization = _globalization;

                if (globalization == null)
                {
                    lock (_lock)
                    {
                        globalization = _globalization ?? (_globalization = new Documents.Globalization());
                    }
                }

                return globalization;
            }
        }

        public static Masterdata Masterdata
        {
            get
            {
                var masterdata = _masterdata;

                if (masterdata == null)
                {
                    lock (_lock)
                    {
                        masterdata = _masterdata ?? (_masterdata = new Masterdata());
                    }
                }

                return masterdata;
            }
        }

        public static Documents.Metadata Metadata
        {
            get
            {
                var metadata = _metadata;

                if (metadata == null)
                {
                    lock (_lock)
                    {
                        metadata = _metadata ?? (_metadata = new Documents.Metadata());
                    }
                }

                return metadata;
            }
        }

        public static Documents.Navigation Navigation
        {
            get
            {
                var navigation = _navigation;

                if (navigation == null)
                {
                    lock (_lock)
                    {
                        navigation = _navigation ?? (_navigation = new Documents.Navigation());
                    }
                }

                return navigation;
            }
        }
    }
}