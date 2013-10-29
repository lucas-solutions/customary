
namespace Custom
{
    using Custom.Data.Metadata;
    using Custom.Data.Persistence;
    using Custom.Diagnostics;

    public static class Global
    {
        public const string StoreRouteName = "Store_Default";
        public const string StoreDetailRouteName = "Store_Detail";
        public const string DataGreedyRouteName = "Data_Greedy";
        public const string DataGroupRouteName = "Data_Group";
        public const string DataStoreRouteName = "Data_Repository";
        public const string DataRouteName = "Data_Default";

        private static readonly object _lock = new object();
        private static RavenJObjectCatalogManager _catalogs;
        private static SimpleInjector.Container _container;
        private static Directory _directory;
        private static ILogger _logger;
        private static GlobalizationContext _globalization;
        private static MasterdataContext _masterdata;
        private static MetadataContext _metadata;
        private static NavigationContext _navigation;
        private static RepositoryManager _repositories;

        public static RavenJObjectCatalogManager Catalogs
        {
            get { return _catalogs ?? (_catalogs = new RavenJObjectCatalogManager()); }
        }

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

        public static Directory Directory
        {
            get
            {
                var directory = _directory;

                if (directory == null)
                {
                    lock (_lock)
                    {
                        directory = _directory ?? (_directory = Data.Metadata.Directory.Load(Global.Metadata.Store));
                    }
                }

                return directory;
            }
            set
            {
                _directory = value;
            }
        }

        public static ILogger Logger
        {
            get
            {

                const string LogglyInputDefault = "1205e89a-b51c-467f-a6c4-843f1e2b8827";
                const string inputJSON = "2405d6e9-00c3-4b3f-9202-2f5676501cdb";

                var logger = _logger;

                if (logger == null)
                {
                    lock (_lock)
                    {
                        //logger = _logger ?? (_logger = new LogglyLogger("1205e89a-b51c-467f-a6c4-843f1e2b8827"));

                        logger = _logger;
                        
                        if (logger == null)
                        {
                            var multi = new MultiLogger();

                            var loggly = new LogglyLogger(inputJSON);
                            multi.Add("loggly", loggly);
                            
                            //var log4net = new Log4NetLogger();
                            //multi.Add("log4net", log4net);

                            _logger = logger = multi;
                        }
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

        public static Custom.Data.Persistence.RepositoryManager Repositories
        {
            get
            {
                var repositories = _repositories;

                if (repositories == null)
                {
                    lock (_lock)
                    {
                        repositories = _repositories ?? (_repositories = new RepositoryManager());
                    }
                }

                return repositories;
            }
        }
    }
}