using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    using Custom.Diagnostics;

    public static class Environment
    {
        private static readonly object _lock = new object();
        private static SimpleInjector.Container _container;
        private static ILogger _logger;

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
    }
}