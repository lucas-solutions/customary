﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom
{
    using Custom.Diagnostics;
    using Custom.Repositories;

    public static class Global
    {
        private static readonly object _lock = new object();
        private static SimpleInjector.Container _container;
        private static ILogger _logger;
        private static Repositories.GlobalizationContext _globalization;
        private static Repositories.MasterdataContext _masterdata;
        private static Repositories.MetadataContext _metadata;
        private static Repositories.NavigationContext _navigation;

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

        public static GlobalizationContext Globalization
        {
            get
            {
                var globalization = _globalization;

                if (globalization == null)
                {
                    lock (_lock)
                    {
                        globalization = _globalization ?? (_globalization = new GlobalizationContext());
                    }
                }

                return globalization;
            }
        }

        public static MasterdataContext Masterdata
        {
            get
            {
                var masterdata = _masterdata;

                if (masterdata == null)
                {
                    lock (_lock)
                    {
                        masterdata = _masterdata ?? (_masterdata = new MasterdataContext());
                    }
                }

                return masterdata;
            }
        }

        public static MetadataContext Metadata
        {
            get
            {
                var metadata = _metadata;

                if (metadata == null)
                {
                    lock (_lock)
                    {
                        metadata = _metadata ?? (_metadata = new MetadataContext());
                    }
                }

                return metadata;
            }
        }

        public static NavigationContext Navigation
        {
            get
            {
                var navigation = _navigation;

                if (navigation == null)
                {
                    lock (_lock)
                    {
                        navigation = _navigation ?? (_navigation = new NavigationContext());
                    }
                }

                return navigation;
            }
        }
    }
}